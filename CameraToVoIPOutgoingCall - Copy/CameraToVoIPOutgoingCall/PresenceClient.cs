using Matrix;
using Matrix.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VC
{

    public class PresenceClient
    {
        XmppClient xmppClient;
        MucManager mucManager;

        private BackgroundWorker _sendPresenceAsyncBgWorker;
        private const int TEN_SECONDS = 10000;

        public ObservableCollection<PresenceContact> GroupMembers { get; }

        public PresenceClient()
        {
            xmppClient = new XmppClient();

            GroupMembers = new ObservableCollection<PresenceContact>();
        }

        public void Connect(string username, string password, string ipAddress)
        {
            xmppClient.SetUsername(username);
            xmppClient.Password = password;
            xmppClient.SetXmppDomain(ipAddress);
            xmppClient.SetResource("BEL_VOT");
            xmppClient.Port = 5222;
            xmppClient.Status = "Online";

            string lic = @"eJxkkNtS20AMhl+F4bbTru0EAh2x04nt2jnUTQiBkDthb+Ml3kP24IQ8fUMJ
0NIbjaRPv/SPYMxLJi072YlG2qtTXH226pfbomFfmxd0SmFiVOVLN6jozPmK
KyDvHZh6lI67JxoCecsh9tYpwQyFAgWjaYuNR6cMkD81xEpolE+vgCt5crQC
5JVBKpA31GLD7Le/nH2pDkMv7DD8dmiuK3Qs3WluWHLIaBREYdCNLoH8h2Bg
EyYUdcYfdh0LeI7/6oPg7Fn/AcCMryQ6bxg16Z7YBea6Gj0gbh6zIWn3bK9T
vBXZZvjQt2HONB8t75o8mWXFJll0bx4nVaeOx1nne7cKO0Haa80iK/t2Ud9F
UZm2u6IeBr0inI+QTZNtXEixJsmP69aul341a4est2ykyVRfnf+c3Df1tv00
uJZ5eb8azMfzgGOq22VeR/2duLy40eNp7PX6Csi7byDHd9PfAg==";

            Matrix.License.LicenseManager.SetLicense(lic);

            xmppClient.Open();

            xmppClient.OnSendXml += XmppClient_OnSendXml;
            xmppClient.OnReceiveXml += XmppClient_OnReceiveXml;
            xmppClient.OnRegister += XmppClient_OnRegister;
            xmppClient.OnRegisterInformation += XmppClient_OnRegisterInformation;
            xmppClient.OnRegisterError += XmppClient_OnRegisterError;

            mucManager = new MucManager(xmppClient);

            // Setup new Presence Callback using the PresenceFilter
            Jid roomJid = new Jid("35655@conference.10.10.206.10");
            xmppClient.PresenceFilter.Add(roomJid, new BareJidComparer(), PresenceCallback);

            _sendPresenceAsyncBgWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            _sendPresenceAsyncBgWorker.DoWork += SendPresenceAsyncBgWorker_DoWork;

            _sendPresenceAsyncBgWorker.RunWorkerAsync();
        }

        private void XmppClient_OnRegisterError(object sender, IqEventArgs e)
        {
            Debug.WriteLine("XmppClient_OnRegisterError: " + e);
        }

        private void XmppClient_OnRegister(object sender, Matrix.EventArgs e)
        {
            Debug.WriteLine("XmppClient_OnRegister: " + e);
        }

        private void XmppClient_OnRegisterInformation(object sender, Matrix.Xmpp.Register.RegisterEventArgs e)
        {
            Debug.WriteLine("XmppClient_OnRegisterInformation: " + e);
        }

        private void SendPresenceAsyncBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_sendPresenceAsyncBgWorker.CancellationPending)
            {
                xmppClient.SendPresence();
                //Debug.WriteLine("presence sent to openfire server...");
                Thread.Sleep(TEN_SECONDS);
            }
        }

        public void ConnectToConferenceRoom(string roomJid, string roomPassword, string nickname)
        {
            roomJid = "35655";
            roomPassword = "1234";
            nickname = "221";
            Jid jid = new Jid(roomJid + "@conference.10.10.206.10");
            mucManager.EnterRoom(room: jid, nickname: nickname, password: roomPassword);
            mucManager.OnInvite += MucManager_OnInvite;
            mucManager.OnDeclineInvite += MucManager_OnDeclineInvite;
        }

        public void DisconnectFromConferenceRoom(string roomJid, string nickname)
        {
            roomJid = "35655";
            Jid jid = new Jid(roomJid + "@conference.10.10.206.10");
            mucManager.ExitRoom(room: jid, nickname: nickname);
        }

        private void PresenceCallback(object sender, PresenceEventArgs e)
        {
            //var mucX = e.Presence.MucUser;

            var nickName = e.Presence.From.Resource.ToString();
            var presenceStatus = e.Presence.Type.ToString();

            Debug.WriteLine("PresenceCallback: " + e.Presence.From + " ; " + e.Presence.Type);

            bool found = false;
            foreach (var member in GroupMembers)
            {
                if(member.ContactNickName == nickName)
                {
                    member.PresenceStatus = presenceStatus;
                    found = true;
                    break;
                }
            }

            if (!found)
                GroupMembers.Add(new PresenceContact(nickName, presenceStatus));
        }

        private void MucManager_OnDeclineInvite(object sender, MessageEventArgs e)
        {
            Debug.WriteLine("MucManager_OnInvite: " + e.Message.Body + " , " + e.Message.Error);
        }

        private void MucManager_OnInvite(object sender, MessageEventArgs e)
        {
            Debug.WriteLine("MucManager_OnInvite: " + e.Message.Body + " , " + e.Message.Error);
        }

        private void XmppClient_OnReceiveXml(object sender, Matrix.TextEventArgs e)
        {
            //Debug.WriteLine("Recieve: " + e.Text);
        }

        private void XmppClient_OnSendXml(object sender, Matrix.TextEventArgs e)
        {
            //Debug.WriteLine("Send: " + e.Text);
        }

        private void CloseSession()
        {
            xmppClient.SendUnavailablePresence("Disconnecting."); 
            xmppClient.Close();
        }
    }
}

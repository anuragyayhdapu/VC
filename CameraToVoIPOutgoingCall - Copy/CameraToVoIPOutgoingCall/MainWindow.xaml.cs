using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Ozeki.Camera;
using Ozeki.Media;
using Ozeki.VoIP;

namespace VC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DrawingImageProvider _provider, _providerRecv;

        private MediaConnector _connector;

        private SoftPhone _softPhone;

        private PresenceClient _presenceClient;

        public MainWindow()
        {
            InitializeComponent();

            _connector = new MediaConnector();

            _provider = new DrawingImageProvider();
            _providerRecv = new DrawingImageProvider();

            _softPhone = new SoftPhone();
            _softPhone.OnRegistrationStateChanged += softPhone_OnRegistrationStateChanged;
            _softPhone.OnCallStateChanged += softPhone_OnCallStateChanged;

            _presenceClient = new PresenceClient();

            videoViewer.SetImageProvider(_provider);
            videoViewerReciever.SetImageProvider(_providerRecv);

            _webcam = WebCameraFactory.GetDefaultDevice();
            _connector.Connect(_webcam?.VideoChannel, _provider);
            _webcam?.Start();
            videoViewer?.Start();

            MembersListView.ItemsSource = _presenceClient.GroupMembers;

        }

        void InvokeThread(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        void softPhone_OnCallStateChanged(object sender, Ozeki.VoIP.CallStateChangedArgs e)
        {


            InvokeThread(() =>
            {
                var call = sender as ICall;

                if (e.State == CallState.InCall)
                {
                    _connector.Connect(_softPhone._videoReciever, _providerRecv);
                    videoViewerReciever.Start();
                }
                if (call.CallState.IsCallEnded())
                {
                    _connector.Disconnect(_softPhone._videoReciever, _providerRecv);
                    videoViewerReciever.Stop();
                }

                CallStateText.Text = e.State.ToString();
            });
        }

        private string softPhoneLineState;
        public string SoftPhoneLineState
        {
            get => softPhoneLineState;
            set
            {
                softPhoneLineState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SoftPhoneLineState"));
            }
        }

        void softPhone_OnRegistrationStateChanged(object sender, Ozeki.VoIP.RegistrationStateChangedArgs e)
        {
            InvokeThread(() =>
            {
                //SoftPhoneLineState = e.State.ToString();

                PhoneLineStateText.Text = e.State.ToString();
            });
        }

        private void SipRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var registration = true;
            var displayname = DisplayNameText.Text;
            var username = UserNameText.Text;
            var authname = UserNameText.Text;
            var password = PasswordText.Password;
            var domain = "10.10.206.10:5060";

            _softPhone.RegisterSipAccount(registration, displayname, username, authname, password, domain);

            _presenceClient.Connect(displayname, password, "10.10.206.10");
        }

        private void SipUnregistrationButton_Click(object sender, RoutedEventArgs e)
        {
            _softPhone.UnregisterPhoneLine();
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            _softPhone.CameraVideo = _webcam.VideoChannel;

            var dial = DialToCallText.Text;
            _softPhone.RoomPassword = RoomPassword.Password;
            _softPhone.StartCall(dial);

            _presenceClient.ConnectToConferenceRoom(DialToCallText.Text, RoomPassword.Password, DisplayNameText.Text);
        }

        private void CallHangUpButton_Click(object sender, RoutedEventArgs e)
        {
            _softPhone.CloseCall();
            _presenceClient.DisconnectFromConferenceRoom(DialToCallText.Text, DisplayNameText.Text);
        }

        static IWebCamera _webcam;

        private void VideoFeedToggle_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is CheckBox checkbox)
            {
                if (checkbox?.IsChecked == true)
                {
                    _softPhone?.ConnectVideoToCall();
                    _webcam?.Start();
                }
                else /*if (checkbox?.IsChecked == false)*/
                {
                    _softPhone?.DisconnectVideoFromCall();
                    _webcam?.Stop();
                }
            }
        }

        private void MicToggle_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is CheckBox checkBox)
            {
                if (checkBox?.IsChecked == true)
                    _softPhone?.ConnectMicToCall();
                else if (checkBox?.IsChecked == false)
                    _softPhone?.DisconnectMicFromCall();
            }
        }

        private void SpeakerToggle_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is CheckBox checkBox)
            {
                if (checkBox?.IsChecked == true)
                    _softPhone?.ConnectSpeakerToCall();
                else if (checkBox?.IsChecked == false)
                    _softPhone?.DisconnectSpeakerFromCall();
            }
        }

        private void InvokeGuiThread(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }
    }
}
using System;
using System.Diagnostics;
using Ozeki.Media;
using Ozeki.VoIP;

namespace VC
{
    class SoftPhone
    {
        private ISoftPhone _softphone;
        private IPhoneLine _phoneLine;
        private IPhoneCall _call;

        public IVideoSender CameraVideo { get; set; }
        public string RoomPassword { get; set; }

        private MediaConnector _connector;
        private PhoneCallVideoSender _videoSender;
        public PhoneCallVideoReceiver _videoReciever { get; set; }

        static Microphone microphone;
        static Speaker speaker;
        private PhoneCallAudioSender _audioSender;
        private PhoneCallAudioReceiver _audioReciever;

        public event EventHandler<RegistrationStateChangedArgs> OnRegistrationStateChanged;
        public event EventHandler<CallStateChangedArgs> OnCallStateChanged;
        //public event EventHandler<IncomingCallEventArgs>

        public SoftPhone()
        {
            _softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000);

            _connector = new MediaConnector();
            _videoSender = new PhoneCallVideoSender();
            _videoReciever = new PhoneCallVideoReceiver();

            microphone = Microphone.GetDefaultDevice();
            speaker = Speaker.GetDefaultDevice();
            _audioSender = new PhoneCallAudioSender();
            _audioReciever = new PhoneCallAudioReceiver();
        }

        public void RegisterSipAccount(bool registrationRequired, string displayname, string name, string registername, string password, string domain)
        {
            if (_phoneLine != null)
                _phoneLine.RegistrationStateChanged -= phoneLine_RegistrationStateChanged;

            var account = new SIPAccount(registrationRequired, displayname, name, registername, password, domain);
            _phoneLine = _softphone.CreatePhoneLine(account);
            _phoneLine.RegistrationStateChanged += phoneLine_RegistrationStateChanged;
            _softphone.RegisterPhoneLine(_phoneLine);
            _softphone.IncomingCall += softphone_IncomingCall;
        }

        private void softphone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            var call = e.Item;
            call.CallStateChanged += SingleCall_CallStateChanged;
            call.Answer();

            _call = call;
        }

        public void UnregisterPhoneLine()
        {
            _softphone.UnregisterPhoneLine(_phoneLine);
        }

        private void phoneLine_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            var handler = OnRegistrationStateChanged;
            if (handler != null)
                handler(this, e);
        }

        public void StartCall(string dial)
        {
            if (_call != null)
                return;

            if (_phoneLine == null) return;
            var dialParams = new DialParameters(dial) { CallType = CallType.AudioVideo };
            var call = _softphone.CreateCallObject(_phoneLine, dialParams);
            call.CallStateChanged += SingleCall_CallStateChanged;
            
            
            call.Start();

            _call = call;
        }

        

        private void SingleCall_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            var call = sender as ICall;
            if (call == null)
                return;

            Debug.WriteLine("Call Status: " + e.State);

            if(e.State == CallState.InCall)
            {
                ConnectToCall(call);

                // send password 
                foreach (var item in RoomPassword)
                {
                    DtmfNamedEvents dtmfEvent = DtmfNamedEventConverter.FromString(item.ToString());
                    call.StartDTMFSignal(dtmfEvent);
                    call.StopDTMFSignal(dtmfEvent);
                }
            }

            OnCallStateChanged?.Invoke(sender, e);

            if (call.CallState.IsCallEnded())
            {
                DisconnectFromCall();
                call.CallStateChanged -= SingleCall_CallStateChanged;
                _call = null;
            }
        }

        private void ConnectToCall(ICall call)
        {
            if (call == null)
                return;

            _videoSender.AttachToCall(call);
            _videoReciever.AttachToCall(call);

            microphone = Microphone.GetDefaultDevice();
            speaker = Speaker.GetDefaultDevice();
            microphone?.Start();
            speaker?.Start();
            _audioSender.AttachToCall(call);
            _audioReciever.AttachToCall(call);

            _connector.Connect(CameraVideo, _videoSender);
            _connector.Connect(microphone, _audioSender);
            _connector.Connect(_audioReciever, speaker);
        }

        private void DisconnectFromCall()
        {
            _videoSender.Detach();
            _videoReciever.Detach();

            microphone?.Stop();
            speaker?.Stop();
            _audioSender.Detach();
            _audioReciever.Detach();

            _connector.Disconnect(CameraVideo, _videoSender);
            _connector.Disconnect(microphone, _audioSender);
            _connector.Disconnect(_audioReciever, speaker);
        }

        public void ConnectMicToCall()
        {
            if (_call == null)
                return;

            microphone = Microphone.GetDefaultDevice();
            microphone?.Start();
            _audioSender.AttachToCall(_call);
            _connector.Connect(microphone, _audioSender);
        }

        public void DisconnectMicFromCall()
        {
            if (_call == null)
                return;

            microphone?.Stop();
            _audioSender.Detach();
            _connector.Disconnect(microphone, _audioSender);
        }

        public void ConnectSpeakerToCall()
        {
            if (_call == null)
                return;

            speaker = Speaker.GetDefaultDevice();
            speaker?.Start();
            _audioReciever.AttachToCall(_call);
            _connector.Connect(_audioReciever, speaker);
        }

        public void DisconnectSpeakerFromCall()
        {
            if (_call == null)
                return;

            speaker?.Stop();
            _audioReciever.Detach();
            _connector.Disconnect(_audioReciever, speaker);
        }

        public void ConnectVideoToCall()
        {
            if (_call == null)
                return;

            _videoSender.AttachToCall(_call);
            _connector.Connect(CameraVideo, _videoSender);
        }

        public void DisconnectVideoFromCall()
        {
            if (_call == null)
                return;

            _videoSender.Detach();
            _connector.Disconnect(CameraVideo, _videoSender);
        }

        public void CloseCall()
        {
            _call?.HangUp();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC
{
    public class PresenceContact : BindableBase
    {
        private string contactName;
        public string ContactNickName
        {
            get => contactName;
            set => SetProperty(ref contactName, value);
        }

        private string presenceStatus;
        public string PresenceStatus
        {
            get => presenceStatus;
            set => SetProperty(ref presenceStatus, value);
        }

        public PresenceContact(string contactNickName, string presenceStatus)
        {
            ContactNickName = contactNickName;
            PresenceStatus = presenceStatus;
        }
    }
}

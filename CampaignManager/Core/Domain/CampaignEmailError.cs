using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;
using Iesi.Collections.Generic;

namespace CampaignManager.Core.Domain
{
    public class CampaignEmailError : ICampaignEmailError
    {
        public virtual int ID { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual string Email { get; set; }
        public virtual string Message { get; set; }
        public virtual bool Removed { get; set; }
    }
}

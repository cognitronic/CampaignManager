using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignOptedOut : ICampaignOptedOut
    {
        public virtual int ID { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual int SubscriberID { get; set; }
        public virtual string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOptedOut { get; set; }
    }
}

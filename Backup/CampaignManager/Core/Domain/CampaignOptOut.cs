using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignOptOut : ICampaignOptOut
    {
        public virtual int ID { get; set; }
        public virtual int SubscriberID { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual DateTime DateUnsubscribed { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}

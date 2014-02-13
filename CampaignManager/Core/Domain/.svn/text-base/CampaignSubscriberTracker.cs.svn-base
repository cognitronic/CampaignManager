using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignSubscriberTracker : ICampaignClientTracker
    {
        public virtual int ID { get; set; }
        public virtual string IpAddress { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string UriStem { get; set; }
        public virtual string QueryString { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual DateTime DateRead { get; set; }
        public virtual Guid CampaignClientID { get; set; }
        public virtual CampaignSubscriber CampaignClient { get; set; }
    }
}

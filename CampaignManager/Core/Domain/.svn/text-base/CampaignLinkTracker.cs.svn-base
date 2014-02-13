using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignLinkTracker : ICampaignLinkTracker
    {
        public virtual int ID { get; set; }
        public virtual Guid CampaignLinkID { get; set; }
        public virtual Guid CampaignClientID { get; set; }
        public virtual string IpAddress { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual string Browser { get; set; }
        public virtual string Referer { get; set; }
        public virtual CampaignSubscriber CampaignClient { get; set; }
        public virtual CampaignLink CampaignLink { get; set; }
    }
}

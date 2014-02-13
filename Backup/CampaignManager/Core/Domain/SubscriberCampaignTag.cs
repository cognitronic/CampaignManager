using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class SubscriberCampaignTag : ISubscriberCampaignTag<int>
    {
        public virtual int ID { get; set; }
        public virtual int SubscriberID { get; set; }
        public virtual int CampaignTagID { get; set; }
        private IList<CampaignTag> _campaignTags = new List<CampaignTag>();
        public virtual IList<CampaignTag> CampaignTags { get { return _campaignTags; } set { _campaignTags = value; } }
        private IList<Subscriber> _subscribers = new List<Subscriber>();
        public virtual IList<Subscriber> Subscribers { get { return _subscribers; } set { _subscribers = value; } }
    }
}

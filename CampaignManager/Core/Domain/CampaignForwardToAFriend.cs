using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignForwardToAFriend : ICampaignForwardToAFriend
    {
        public virtual int ID { get; set; }
        public virtual int SubscriberID { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual DateTime DateForwarded { get; set; }
        public virtual string Emails { get; set; }
        public virtual Subscriber SubscriberRef { get; set; }
    }
}

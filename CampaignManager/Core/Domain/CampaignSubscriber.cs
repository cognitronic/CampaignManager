using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;
namespace CampaignManager.Core.Domain
{
    /// <summary>
    /// CampaignClient maps a client uniquely to a campaign.  There will be one CampaignClient for every client that is sent an email, for every campaign.
    /// </summary>
    public class CampaignSubscriber : ICampaignSubscriber
    {
        public virtual Guid ID { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual int SubscriberID { get; set; }
    }
}

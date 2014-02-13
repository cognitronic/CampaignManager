using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignSubscriberLinkRequest : ICampaignSubscriberLinkRequest
    {
        public virtual int ID { get; set; }
        public virtual Guid CampaignSubscriberID { get; set; }
        public virtual int CampaignLinkID { get; set; }
        public virtual string IP { get; set; }
        public virtual string Browser { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual DateTime DateClicked { get; set; }
        public virtual string Referrer { get; set; }
        public virtual string OperatingSystem { get; set; }
        public virtual string HostName { get; set; }
    }
}

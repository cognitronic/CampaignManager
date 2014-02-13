using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Domain
{
    public class CampaignTotals
    {
        public virtual int ID { get; set; }
        public virtual int TotalMessagesSent { get; set; }
        public virtual int TotalErrors { get; set; }
        public virtual int TotalRecipients { get; set; }
        public virtual int UniqueEmailReads { get; set; }
        public virtual int TotalEmailReads { get; set; }
        public virtual int UniqueLinkClicks { get; set; }
        public virtual int TotalLinkClicks { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual Campaign CampaignRef { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignLink : ICampaignLink
    {
        public virtual int ID { get; set; }
        public virtual string Text { get; set; }
        public virtual string NavigateURL { get; set; }
        public virtual int CampaignID { get; set; }
        public virtual bool IsImage { get; set; }
        public virtual string ImageURL { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual int TotalLinkClicks { get; set; }
    }
}

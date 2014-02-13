using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignTemplateLink : ICampaignTemplateLink
    {
        public virtual string Text { get; set; }
        public virtual string NavigateUrl { get; set; }
        public virtual int CampaignTemplateID { get; set; }
        public virtual CampaignTemplate CampaignTemplate { get; set; }
    }
}

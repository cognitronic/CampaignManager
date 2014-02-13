using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces.Presentation;

namespace CampaignManager.Presentation
{
    public class CampaignLinksReportHelper : ICampaignLinksReportHelper
    {
        public string LinkText { get; set; }
        public int TotalLinkClicks { get; set; }
    }
}

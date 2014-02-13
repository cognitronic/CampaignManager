using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces.Presentation
{
    public interface ICampaignLinksReportHelper
    {
        string LinkText { get; set; }
        int TotalLinkClicks { get; set; }
    }
}

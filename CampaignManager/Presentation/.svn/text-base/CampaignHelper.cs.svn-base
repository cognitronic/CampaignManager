using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IdeaSeed.Core.Mail;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using CampaignManager.Core.Interfaces;
using System.Configuration;
using IdeaSeed.Web;
using System.Web.UI.HtmlControls;
using IdeaSeed.Core;
using System.Web.UI.WebControls;

namespace CampaignManager.Presentation
{
    public class CampaignHelper
    {
        #region Properties
        public static int SelectedTemplateID
        {
            get { return (int)SessionManager.Current["CURRENT_TEMPLATE_ID"]; }
            set { SessionManager.Current["CURRENT_TEMPLATE_ID"] = value; }
        }

        public static int SelectedCampaignID
        {
            get { return (int)SessionManager.Current["CURRENT_CAMPAIGN_ID"]; }
            set { SessionManager.Current["CURRENT_CAMPAIGN_ID"] = value; }
        }

        public static int? SelectedCouponID
        {
            get 
            {
                if (SessionManager.Current["CURRENT_COUPON_ID"] != null)
                    return (int)SessionManager.Current["CURRENT_COUPON_ID"];
                else
                    return null;
            }
            set { SessionManager.Current["CURRENT_COUPON_ID"] = value; }
        }

        #endregion

        #region Methods

        public static void BuildTagControlsForNewCampaign(HtmlGenericControl div)
        {
            var tags = new CampaignTagRepository().GetAll();
            int count = 0;
            var list = new DataList();
            foreach (var tag in tags)
            { 
               
            }
        }
        #endregion
    }
}

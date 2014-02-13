using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace CampaignManager.Web.Controls
{
    public class CouponsDDL : DropDownList
    {
        public CouponsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            foreach (var s in new CouponRepository().GetAll())
            {
                this.Items.Add(new RadComboBoxItem(s.Name, s.ID.ToString()));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICouponCode
    {
        int ID { get; set; }
        string Code { get; set; }
        string CodeText { get; set; }
        int CouponID { get; set; }
        bool IsRedeemed { get; set; }
        bool IsAssigned { get; set; }
        Coupon Coupon { get; set; }
        DateTime? RedeemedDate { get; set; }
        DateTime? AssignedDate { get; set; }
    }
}

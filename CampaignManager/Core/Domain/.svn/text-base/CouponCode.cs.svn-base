using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CouponCode : ICouponCode
    {
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string CodeText { get; set; }
        public virtual int CouponID { get; set; }
        public virtual bool IsRedeemed { get; set; }
        public virtual bool IsAssigned { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual DateTime? RedeemedDate { get; set; }
        public virtual DateTime? AssignedDate { get; set; }
    }
}

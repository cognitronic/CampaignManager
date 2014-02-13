using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces
{
    public interface ICoupon
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool IsActive { get; set; }
    }
}

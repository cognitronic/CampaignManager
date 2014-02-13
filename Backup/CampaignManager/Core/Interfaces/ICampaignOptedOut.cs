using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignOptedOut
    {
        int ID { get; set; }
        int CampaignID { get; set; }
        int SubscriberID { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOptedOut { get; set; }
    }
}

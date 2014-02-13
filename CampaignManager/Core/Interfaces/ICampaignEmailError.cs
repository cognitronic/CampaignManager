using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignEmailError
    {
        int ID { get; set; }
        int CampaignID { get; set; }
        string Email { get; set; }
        string Message { get; set; }
        bool Removed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;  

namespace CampaignManager.Core.Domain
{
    public class CampaignManagerSetting : ICampaignManagerSetting
    {
        public virtual int ID { get; set; }
        public virtual string Setting { get; set; }
        public virtual string Description { get; set; }
        public virtual string Value { get; set; }
    }
}

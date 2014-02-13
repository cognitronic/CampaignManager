using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;
using Iesi.Collections.Generic;

namespace CampaignManager.Core.Domain
{
    public class Subscriber : ISubscriber<int>
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime DateCreated { get; set; }
        private IList<CampaignTag> _campaignTags = new List<CampaignTag>();
        public virtual IList<CampaignTag> CampaignTags { get { return _campaignTags; } set { _campaignTags = value; } }
    }
}

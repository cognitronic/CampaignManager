using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;
using Iesi.Collections.Generic;

namespace CampaignManager.Core.Domain
{
    public class CampaignTag : ICampaignTag
    {
        public virtual int ID { get; set; }
        public virtual string Tag { get; set; }
        public virtual bool IsPublic { get; set; }
        private IList<Subscriber> _subscribers = new List<Subscriber>();
        public virtual IList<Subscriber> Subscribers { get { return _subscribers; } set { _subscribers = value; } }
    }
}

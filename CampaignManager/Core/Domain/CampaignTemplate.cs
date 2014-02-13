using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignTemplate : ICampaignTemplate
    {
        public virtual int ID { get; set; }
        public virtual string TemplateName { get; set; }
        public virtual string Description { get; set; }
        public virtual string EmailSubject { get; set; }
        public virtual string EmailBody { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
    }
}

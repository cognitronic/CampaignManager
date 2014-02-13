using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class Campaign : ICampaign
    {
        public virtual int ID { get; set; }
        public virtual int CampaignTemplateID { get; set; }
        public virtual int SentBy { get; set; }
        public virtual string CampaignName { get; set; }
        public virtual string Description { get; set; }
        public virtual string EmailSubject { get; set; }
        public virtual string EmailBody { get; set; }
        public virtual DateTime DateTimeSent { get; set; }
        public virtual string EmailFrom { get; set; }
        public virtual int TotalRecipients { get; set; }
    }
}

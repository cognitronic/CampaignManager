using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Presentation;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;

namespace CampaignManager.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var template = new CampaignTemplateRepository().GetByID(1, false);
            var campaign = new Campaign();
            campaign.CampaignName = "April 20 Test - 2:07";
            campaign.CampaignTemplateID = template.ID;
            campaign.DateTimeSent = DateTime.Now;
            campaign.Description = "This is the description";
            campaign.EmailBody = template.EmailBody;
            campaign.EmailFrom = "newsletter@mydatapath.com";
            campaign.EmailSubject = template.EmailSubject;
            campaign.SentBy = 1;
            campaign.TotalRecipients = 0;

            var manager = new CampaignManager.Presentation.CampaignManager(campaign);
            campaign = manager.SaveCampaign(campaign);
            manager.BuildLinks(campaign);
            System.Console.WriteLine(manager.CurrentBody);

            var subscribers = new SubscriberRepository().GetAll();
            manager.SendCampaign(campaign, (List<Subscriber>)subscribers, 1, true);

            System.Console.WriteLine("-----------------------------------------------------------");

            System.Console.Read();
        }
    }
}

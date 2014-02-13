using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using MbUnit;
using CampaignManager.Data;
using CampaignManager.Data.Repositories;
using CampaignManager.Core.Domain;
using IdeaSeed.Core.Utils;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Criterion;
using CampaignManager.Presentation;

namespace CampaignManager.Test
{
    [TestFixture]
    public class CampaignTemplateTest
    {
        private CampaignTemplateRepository _templateRepository;
        private CampaignRepository _campaignRepository;
        private CampaignTagRepository _campaignTagRepository;
        private SubscriberRepository _subscriberRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _templateRepository = new CampaignTemplateRepository();
            _campaignRepository = new CampaignRepository();
            _campaignTagRepository = new CampaignTagRepository();
            _subscriberRepository = new SubscriberRepository();
        }

        #region CampaignTemplate Tests
        [Test]
        public void CanSaveCampaignTemplate()
        {
            var ct = new CampaignTemplate()
            {
                EmailBody = "<html><body><div>What up yo?</div></body></html>",
                EnteredBy = 1,
                EmailSubject = "Test Campaign Entry",
                TemplateName = "Test Entry",
                ChangedBy = 1,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now
            };
            var newCT = _templateRepository.Save(ct);

            Assert.IsInstanceOfType(typeof(CampaignTemplate), newCT);

            var newerCT = _templateRepository.GetByID(newCT.ID, false);
            Assert.AreSame(newCT, newerCT);

            _templateRepository.Delete(newCT);
        }

        #endregion

        #region Campaign Tests

        [Test]
        public void CanSaveCampaign()
        {
            var ct = new CampaignTemplate()
            {
                EmailBody = "<html><body><div>What up yo?</div></body></html>",
                EnteredBy = 1,
                EmailSubject = "Test Campaign Entry",
                TemplateName = "Test Entry",
                ChangedBy = 1,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now
            };
            var newCT = _templateRepository.Save(ct);
            
            var c = new Campaign()
            {
                EmailBody = "<html><body><div>What up yo?</div></body></html>",
                SentBy = 1,
                EmailSubject = "Test Campaign Entry",
                CampaignName = "Test Campaign",
                EmailFrom = "test@mydatapath.com",
                CampaignTemplateID = newCT.ID,
                DateTimeSent = DateTime.Now,
                Description = "This is a test campaign",
                TotalRecipients = 1
            };

            var newC = _campaignRepository.Save(c);

            Assert.IsInstanceOfType(typeof(Campaign), newC);

            var newerC = _campaignRepository.GetByID(newC.ID, false);
            Assert.AreSame(newC, newerC);

            _campaignRepository.Delete(newC);
            _templateRepository.Delete(newCT);
        }

        [Test]
        public void CanGetAllCampaignTags()
        {
            IList<CampaignTag> tags = _campaignTagRepository.GetAll();

            Assert.AreEqual(4, tags.Count);

            foreach (var t in tags)
            {
                Assert.IsInstanceOfType(typeof(CampaignTag), t);
            }
        }

        [Test]
        public void CanGetSubscribersNotInCampaignTagGroup()
        {
            int campaignTagID = 2;
            IList<Subscriber> subscribers = _subscriberRepository.GetSubscribersNotInCampaignTagGroup(campaignTagID);

            Assert.AreEqual(2, subscribers.Count);
        }

        [Test]
        public void CanGetSubscribersInCampaignTagGroup()
        {
            int campaignTagID = 2;
            IList<Subscriber> subscribers = _subscriberRepository.GetSubscribersInCampaignTagGroup(campaignTagID);

            Assert.AreEqual(1, subscribers.Count);
        }

        #endregion
    }
}

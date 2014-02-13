using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Transform;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;
using CampaignManager.Core.Domain;
using CampaignManager.Core.Interfaces.Data;

namespace CampaignManager.Data.Repositories
{
    public class SubscriberRepository : BaseRepository<Subscriber, int>, ISubscriberRepository
    {
        /// <summary>
        /// Returns a list of SubscriberCampaignTags, deeploading the Subscriber object associated with the passed in campaignTagID.  Use this method to get a list of Subscribers by campaignTagID.
        /// </summary>
        /// <param name="campaignTagID"></param>
        /// <returns></returns>
        public IList<SubscriberCampaignTag> GetSubscriberCampaignTagsByCampaignTagID(int campaignTagID)
        {
            return Session.CreateCriteria<SubscriberCampaignTag>()
                    .Add(Expression.Eq("CampaignTagID", campaignTagID))
                    .List<SubscriberCampaignTag>();

        }

        public IList<Subscriber> GetSubscribersNotInCampaignTagGroup(int campaignTagID)
        {
            DetachedCriteria c = DetachedCriteria.For<SubscriberCampaignTag>()
            .SetProjection(Projections.Property("SubscriberID"))
            .Add(Restrictions.Eq("CampaignTagID", campaignTagID));

            return Session.CreateCriteria<Subscriber>()
                .Add(Subqueries.PropertyNotIn("ID", c))
                .List<Subscriber>();
        }

        public IList<Subscriber> GetSubscribersInCampaignTagGroup(int campaignTagID)
        {
            DetachedCriteria c = DetachedCriteria.For<SubscriberCampaignTag>()
            .SetProjection(Projections.Property("SubscriberID"))
            .Add(Restrictions.Eq("CampaignTagID", campaignTagID));

            return Session.CreateCriteria<Subscriber>()
                .Add(Expression.Eq("IsActive", true))
                .Add(Subqueries.PropertyIn("ID", c))
                .List<Subscriber>();
        }

        public Subscriber GetByEmail(string email)
        {
            var subscriber = Session.CreateCriteria<Subscriber>()
                .Add(Expression.Eq("Email", email))
                .List<Subscriber>();
            if (subscriber != null && subscriber.Count > 0)
            {
                return subscriber[0];
            }
            return null;
        }

        public IList<Subscriber> GetByLikeEmail(string email)
        {
            return Session.CreateCriteria<Subscriber>()
                .Add(Expression.Like("Email", "%" + email + "%"))
                .List<Subscriber>();
        }

        public IList<Subscriber> GetByLikeFirstName(string firstName)
        {
            return Session.CreateCriteria<Subscriber>()
                .Add(Expression.Like("FirstName", "%" + firstName + "%"))
                .List<Subscriber>();
        }

        public IList<Subscriber> GetByLikeLastName(string lastName)
        {
            return Session.CreateCriteria<Subscriber>()
                .Add(Expression.Like("LastName", "%" + lastName + "%"))
                .List<Subscriber>();
        }
    }
}

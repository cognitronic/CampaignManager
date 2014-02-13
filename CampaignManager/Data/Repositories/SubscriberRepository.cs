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
            return Session.CreateCriteria<Subscriber>()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<Subscriber>();
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

        public IList<Subscriber> GetByFilters(DateTime? startdate, DateTime? enddate, string firstname, string lastname, string email)
        {
            var list = new List<SearchCriterion>();
            if (!string.IsNullOrEmpty(firstname))
                list.Add(new SearchCriterion("FirstName", Operators.LIKE, firstname));
            if (!string.IsNullOrEmpty(lastname))
                list.Add(new SearchCriterion("LastName", Operators.LIKE, lastname));
            if (!string.IsNullOrEmpty(email))
                list.Add(new SearchCriterion("Email", Operators.LIKE, email));
            if (startdate != null)
                list.Add(new SearchCriterion("DateCreated", Operators.GREATER_THAN, startdate));
            if (enddate != null)
                list.Add(new SearchCriterion("DateCreated", Operators.LESS_THAN, enddate));
            ICriteria query = Session.CreateCriteria<Subscriber>();
            foreach (var l in list)
            {
                switch (l.Operator)
                {
                    case Operators.EQUALS:
                        query.Add(Restrictions.Eq(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.GREATER_THAN:
                        query.Add(Restrictions.Ge(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.LESS_THAN:
                        query.Add(Restrictions.Le(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.LIKE:
                        query.Add(Restrictions.Like(l.SearchColumn, "%" + l.SearchCriteria + "%"));
                        break;
                }
            }
            return query.List<Subscriber>();
        }
    }
}

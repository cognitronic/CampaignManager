using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;
using CampaignManager.Core.Domain;
using CampaignManager.Core.Interfaces.Data;

namespace CampaignManager.Data.Repositories
{
    public class CouponCodeRepository : BaseRepository<CouponCode, int>, ICouponCodeRepository
    {
        public CouponCode GetCouponCodeByCouponID(string couponid)
        {
            return Session.CreateCriteria<CouponCode>()
                    .Add(Expression.Eq("CouponID", Convert.ToInt32(couponid)))
                    .Add(Expression.Eq("IsAssigned", false))
                    .SetMaxResults(1)
                    .UniqueResult<CouponCode>();
        }

        public CouponCode GetCouponCodeByCodeText(string code)
        {
            return Session.CreateCriteria<CouponCode>()
                    .Add(Expression.Eq("CodeText", code))
                    .SetMaxResults(1)
                    .UniqueResult<CouponCode>();
        }

        public IList<CouponCode> GetByFilters(string codetext, int? couponid, bool? isRedeemed, bool? isAssigned)
        {
            var list = new List<SearchCriterion>();
            if (!string.IsNullOrEmpty(codetext))
                list.Add(new SearchCriterion("CodeText", Operators.EQUALS, codetext));
            if (couponid != null)
                list.Add(new SearchCriterion("CouponID", Operators.EQUALS, couponid));
            if(isRedeemed != null)
                list.Add(new SearchCriterion("IsRedeemed", Operators.EQUALS, isRedeemed));
            if (isAssigned != null)
                list.Add(new SearchCriterion("IsAssigned", Operators.EQUALS, isAssigned));
            ICriteria query = Session.CreateCriteria<CouponCode>();
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
                }
            }
            return query.List<CouponCode>();
        }
    }
}

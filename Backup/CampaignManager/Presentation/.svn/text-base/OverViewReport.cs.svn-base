using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IdeaSeed.Core.Mail;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using CampaignManager.Core.Interfaces;
using System.Configuration;

namespace CampaignManager.Presentation
{
    public class OverViewReport
    {
        private int _campaignId;

        public OverViewReport(int campaignID)
        {
            this._campaignId = campaignID;
        }

        public int TotalRecipients
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetTotalRecipients(_campaignId);
                }
                return 0;
            }
        }

        public int UniqueEmailReads
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetEmailReads(_campaignId, true);
                }
                return 0;
            }
        }

        public int TotalEmailReads
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetEmailReads(_campaignId, false);
                }
                return 0;
            }
        }

        public int UniqueLinkClicks
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetLinkClicks(_campaignId, true);
                }
                return 0;
            }
        }

        public int TotalLinkClicks
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetLinkClicks(_campaignId, false);
                }
                return 0;
            }
        }

        public IList<CampaignLinksReportHelper> CampaignLinksResult
        {
            get
            {
                if (_campaignId > 0)
                {
                    return GetCampaignLinksResult(_campaignId);
                }
                return null;
            }
        }

        private int GetTotalRecipients(int campaignID)
        {
            return new CampaignRepository().GetByID(campaignID, false).TotalRecipients;
        }

        private int GetEmailReads(int campaignID, bool unique)
        {
            var cclist = new CampaignSubscriberRepository().GetByCampaignID(campaignID);
            int totalReads = 0;
            foreach (var cc in cclist)
            {
                if (cc != null)
                {
                    if (unique)
                    {
                        //A work around for distinct.  Using linq to groupby campaignclientid and select the first entry in the group
                        var ccr = new CampaignSubscriberRequestRepository().GetByCampaignSubscriberID(cc.ID)
                            .GroupBy(c => c.CampaignSubscriberID)
                            .Select(f => f.First())
                            .ToList();
                        if (ccr != null && ccr.Count() > 0)
                        {
                            totalReads += ccr.Count();
                        }
                    }
                    else
                    {
                        var ccr = new CampaignSubscriberRequestRepository().GetByCampaignSubscriberID(cc.ID);
                        if (ccr != null && ccr.Count > 0)
                        {
                            totalReads += ccr.Count;
                        }
                    }
                }
            }
            return totalReads;
        }

        private int GetLinkClicks(int campaignID, bool unique)
        {
            var cclist = new CampaignSubscriberRepository().GetByCampaignID(campaignID);
            int totalReads = 0;
            foreach (var cc in cclist)
            {
                if (cc != null)
                {
                    if (unique)
                    {
                        //A work around for distinct.  Using linq to groupby campaignclientid and select the first entry in the group
                        var ccr = new CampaignSubscriberLinkRequestRepository().GetByCampaignSubscriberID(cc.ID)
                            .GroupBy(c => c.CampaignLinkID)
                            .Select(f => f.First())
                            .ToList();
                        if (ccr != null && ccr.Count() > 0)
                        {
                            totalReads += ccr.Count();
                        }
                    }
                    else
                    {
                        var ccr = new CampaignSubscriberLinkRequestRepository().GetByCampaignSubscriberID(cc.ID);
                        if (ccr != null && ccr.Count > 0)
                        {
                            totalReads += ccr.Count;
                        }
                    }
                }
            }
            return totalReads;
        }

        private IList<CampaignLinksReportHelper> GetCampaignLinksResult(int campaignID)
        {
            IList<CampaignLinksReportHelper> linkResults = new List<CampaignLinksReportHelper>();
            var cclist = new CampaignSubscriberRepository().GetByCampaignID(campaignID);
            foreach (var cc in cclist)
            {
                if (cc != null)
                {
                    //A work around for distinct.  Using linq to groupby campaignclientid and select the first entry in the group
                    var ccr = new CampaignSubscriberLinkRequestRepository().GetByCampaignSubscriberID(cc.ID)
                        .GroupBy(c => c.CampaignLinkID)
                        .Select(f => f.First())
                        .ToList();
                    if (ccr != null && ccr.Count() > 0)
                    {
                        foreach (var hlink in ccr)
                        {
                            var clink = new CampaignLinksReportHelper();
                            var campaignLink = new CampaignLinkRepository().GetByID(hlink.CampaignLinkID, false);
                            clink.LinkText = campaignLink.Text;
                            clink.TotalLinkClicks = new CampaignSubscriberLinkRequestRepository().GetByCampaignLinkID(hlink.CampaignLinkID).Count;
                            linkResults.Add(clink);
                        }
                    }
                }
            }
            return linkResults;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using CampaignManager.Presentation;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using IdeaSeed.Core.Mail;
using System.Configuration;

namespace CampaignManager.Web
{
    public class LinkTrackerHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public LinkTrackerHandler()
        {
        }

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            string userID = requestContext.RouteData.Values["USER_GUID"].ToString();
            int campaignID = int.Parse(requestContext.RouteData.Values["CAMPAIGN_ID"].ToString());
            var request = new CampaignSubscriberLinkRequest();
            var savedRequest = new CampaignSubscriberLinkRequest();
            //request.Browser = requestContext.HttpContext.Request.Browser.Type;
            request.CampaignSubscriberID = new Guid(userID);
            request.CampaignLinkID = campaignID;
            request.DateClicked = DateTime.Now;
            //request.HostName = requestContext.HttpContext.Request.UserHostName;
            request.OperatingSystem = "";
            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request.UserHostName))
            {
                request.IP = requestContext.HttpContext.Request.UserHostAddress;
            }
            else
            {
                request.IP = "Not Found";
            }
            if (requestContext.HttpContext.Request.UrlReferrer != null)
            {
                request.Referrer = requestContext.HttpContext.Request.UrlReferrer.PathAndQuery;
            }
            //request.UserAgent = requestContext.HttpContext.Request.UserAgent;
            try
            {
                var csr = new CampaignSubscriberLinkRequestRepository().GetByCampaignLinkID(request.CampaignLinkID);
                var totals = new CampaignTotalsRepository().GetByCampaignID(new CampaignLinkRepository().GetByID(request.CampaignLinkID, false).CampaignID);
                if (csr == null || csr.Count < 1)
                {
                    totals.UniqueLinkClicks = totals.UniqueLinkClicks + 1;
                    try
                    {
                        savedRequest = new CampaignSubscriberLinkRequestRepository().Save(request);
                    }
                    catch (Exception excc)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Message: <br />");
                        sb.Append(excc.Message);
                        sb.Append("<br /><br />");
                        sb.Append("Stack: <br />");
                        sb.Append(excc.StackTrace);
                        sb.Append("<br /><br />");
                        sb.Append("Inner Exception: <br />");
                        sb.Append(excc.InnerException);
                        sb.Append("<br /><br />");
                        sb.Append("Base Exception: <br />");
                        sb.Append(excc.GetBaseException().Message);
                        sb.Append("<br /><br />");
                        sb.Append("CampignID: <br />");
                        sb.Append(campaignID.ToString());
                        sb.Append("<br /><br />");
                        sb.Append("UserID: <br />");
                        sb.Append(userID.ToString());
                        sb.Append("<br /><br />");
                        sb.Append("URL: <br />");
                        sb.Append(requestContext.HttpContext.Request.Url.ToString());
                        EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", ConfigurationManager.AppSettings["COMPANYNAME"] + " Link Saver Saving Request", sb.ToString());
                    }
                }

                var clink = new CampaignLinkRepository().GetByID(campaignID, false);
                clink.TotalLinkClicks = clink.TotalLinkClicks + 1;
                new CampaignLinkRepository().SaveOrUpdate(clink);
                totals.TotalLinkClicks = totals.TotalLinkClicks + 1;
                new CampaignTotalsRepository().Save(totals);

                
            }
            catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Message: ");
                sb.Append(ex.Message);
                sb.Append("<br /><br />");
                sb.Append("Stack: ");
                sb.Append(ex.StackTrace);
                sb.Append("<br /><br />");
                sb.Append("CampignID: <br />");
                sb.Append(campaignID.ToString());
                sb.Append("<br /><br />");
                sb.Append("UserID: <br />");
                sb.Append(userID.ToString());
                sb.Append("<br /><br />");
                sb.Append("URL: <br />");
                sb.Append(requestContext.HttpContext.Request.Url.ToString());
                EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", ConfigurationManager.AppSettings["COMPANYNAME"] + " Saving Link", sb.ToString());
            }
            if(savedRequest != null)
            {
                var url = new CampaignLinkRepository().GetByID(campaignID, false).NavigateURL;
                url = url.Replace("[USERID]", userID).Replace("[CAMPAIGNID]", campaignID.ToString());
                HttpContext.Current.Response.Redirect(url);
            }

            return new LinkTrackerPage();
        }

        #endregion
    }
}

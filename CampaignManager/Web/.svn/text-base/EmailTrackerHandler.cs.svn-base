using System;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using CampaignManager.Presentation;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using IdeaSeed.Core.Mail;

namespace CampaignManager.Web
{
    public class EmailTrackerHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public EmailTrackerHandler()
        {
           
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            

            string userID = requestContext.RouteData.Values["USER_GUID"].ToString();
            int campaignID = int.Parse(requestContext.RouteData.Values["CAMPAIGN_ID"].ToString());
            var request = new CampaignSubscriberRequest();
            var savedRequest = new CampaignSubscriberRequest();
            bool IsUnique = false;
            //request.Browser = requestContext.HttpContext.Request.Browser.Type;
            request.CampaignSubscriberID = new Guid(userID);
            request.DateRequested = DateTime.Now;
            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request.UserHostName))
            {
                request.HostName = requestContext.HttpContext.Request.UserHostName;
            }
            else
            {
                request.HostName = "Not Found";
            }
            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request.UserHostName))
            {
                request.IP = requestContext.HttpContext.Request.UserHostAddress;
            }
            else
            {
                request.IP = "Not Found";
            }
            //request.UserAgent = requestContext.HttpContext.Request.UserAgent;
            try
            {
                var csr = new CampaignSubscriberRequestRepository().GetByCampaignSubscriberID(request.CampaignSubscriberID);
                var totals = new CampaignTotalsRepository().GetByCampaignID(campaignID);
                if (csr == null || csr.Count < 1)
                {
                    totals.UniqueEmailReads = totals.UniqueEmailReads + 1;
                    try
                    {
                        savedRequest = new CampaignSubscriberRequestRepository().Save(request);
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
                        EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", ConfigurationManager.AppSettings["COMPANYNAME"] + " Email Reader Saving Request", sb.ToString());
                    }
                }
                totals.TotalEmailReads = totals.TotalEmailReads + 1;
                new CampaignTotalsRepository().Save(totals);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Message: <br />");
                sb.Append(ex.Message);
                sb.Append("<br /><br />");
                sb.Append("Stack: <br />");
                sb.Append(ex.StackTrace);
                sb.Append("<br /><br />");
                sb.Append("Inner Exception: <br />");
                sb.Append(ex.InnerException);
                sb.Append("<br /><br />");
                sb.Append("Base Exception: <br />");
                sb.Append(ex.GetBaseException().Message);
                sb.Append("<br /><br />");
                sb.Append("CampignID: <br />");
                sb.Append(campaignID.ToString());
                sb.Append("<br /><br />");
                sb.Append("UserID: <br />");
                sb.Append(userID.ToString());
                sb.Append("<br /><br />");
                sb.Append("URL: <br />");
                sb.Append(requestContext.HttpContext.Request.Url.ToString());
                EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", ConfigurationManager.AppSettings["COMPANYNAME"] + " Email Readerzz", sb.ToString());
            }

            return new EmailTrackerPage();
        }

        #endregion
    }
}

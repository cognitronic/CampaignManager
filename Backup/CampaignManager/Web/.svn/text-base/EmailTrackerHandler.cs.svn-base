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
            request.Browser = requestContext.HttpContext.Request.Browser.Type;
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
            request.UserAgent = requestContext.HttpContext.Request.UserAgent;
            try
            {
                savedRequest = new CampaignSubscriberRequestRepository().Save(request);
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
                sb.Append("Request Object: <br />");
                sb.Append(request);
                EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", "Email Reader", sb.ToString());
            }

            return new EmailTrackerPage();
        }

        #endregion
    }
}

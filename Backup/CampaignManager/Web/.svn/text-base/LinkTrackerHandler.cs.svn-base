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
            request.Browser = requestContext.HttpContext.Request.Browser.Type;
            request.CampaignSubscriberID = new Guid(userID);
            request.CampaignLinkID = campaignID;
            request.DateClicked = DateTime.Now;
            request.HostName = requestContext.HttpContext.Request.UserHostName;
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
            request.UserAgent = requestContext.HttpContext.Request.UserAgent;
            try
            {
                savedRequest = new CampaignSubscriberLinkRequestRepository().Save(request);
            }
            catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Message: ");
                sb.Append(ex.Message);
                sb.Append("<br /><br />");
                sb.Append("Stack: ");
                sb.Append(ex.StackTrace);
                EmailUtils.SendEmail("dschreiber@mydatapath.com", "campaignerror@mydatapath.com", "Saving Link", sb.ToString());
            }
            if(savedRequest != null)
            {
                HttpContext.Current.Response.Redirect(new CampaignLinkRepository().GetByID(campaignID, false).NavigateURL);
            }

            return new LinkTrackerPage();
        }

        #endregion
    }
}

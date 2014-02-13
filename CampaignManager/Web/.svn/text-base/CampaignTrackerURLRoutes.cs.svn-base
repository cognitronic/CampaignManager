using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace CampaignManager.Web
{
    public class CampaignTrackerURLRoutes
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            Route imageTrackRoute = new Route("MDL/CT/IT/{CAMPAIGN_ID}/{USER_GUID}/TImage.gif", new EmailTrackerHandler());
            imageTrackRoute.Constraints = new RouteValueDictionary { 
                  { "CAMPAIGN_ID", @"^[0-9]*$" }, 
                  { "USER_GUID", @"^[a-zA-Z0-9-]*$" } };
            routes.Add("ImageTrackRoute", imageTrackRoute);

            Route LinkTrackRoute = new Route("MDL/CT/LT/{CAMPAIGN_ID}/{USER_GUID}", new LinkTrackerHandler());
            LinkTrackRoute.Constraints = new RouteValueDictionary { 
                  { "CAMPAIGN_ID", @"^[0-9]*$" }, 
                  { "USER_GUID", @"^[a-zA-Z0-9-]*$" } };
            routes.Add("LinkTrackRoute", LinkTrackRoute);
        }
    }
}

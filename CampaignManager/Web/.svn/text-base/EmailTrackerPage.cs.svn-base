using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Reflection;
using System.Web;
using System.Drawing;
using System.Configuration;

namespace CampaignManager.Web
{
    public class EmailTrackerPage : Page
    {
        public string BaseUrl
        {
            get { return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/"); }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //System.Reflection.Assembly asm = Assembly.GetExecutingAssembly();
            //System.IO.Stream imageStream = asm.GetManifestResourceStream("PrimeShine.CampaignTracker.Web.Images.TImage.gif");
            //Image image = Image.FromStream(imageStream);

            //Write file to response
            Response.ContentType = "image/gif";
            Response.WriteFile(HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings["HIDDENCAMPAIGNIMAGE"]));
            Response.End();
        }
    }
}

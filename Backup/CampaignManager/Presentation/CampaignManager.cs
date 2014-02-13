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
    public class CampaignManager
    {
        #region Constructors
        public CampaignManager(Campaign campaign)
        {
            _campaign = campaign;
            _template = new CampaignTemplateRepository().GetByID(_campaign.CampaignTemplateID, false);
        }
        #endregion

        #region Declarations


        #endregion

        #region Properties

        public string OptOutURL { get; set; }
        public StringBuilder CurrentBody { get; set; }
        private CampaignTemplate _template;
        private Campaign _campaign;
        public CampaignTemplate CurrentTemplate { get { return _template; } }
        public List<Subscriber> CampaignSubscribers { get; set; }
        #endregion

        #region Methods

        public CampaignTemplate SaveCampaignTemplate(string body, string description, string subject, string title, int currentUserID)
        {
            var template = new CampaignTemplate();
            template.EmailBody = body;
            template.EnteredBy = currentUserID;
            template.Description = description;
            template.EmailSubject = subject;
            template.TemplateName = title;
            template.ChangedBy = currentUserID;

            return SaveCampaignTemplate(template);
        }

        public CampaignTemplate SaveCampaignTemplate(CampaignTemplate template)
        {
            return new CampaignTemplateRepository().SaveOrUpdate(template);
        }

        public Campaign SaveCampaign(string campaignName, string description, int campaignTemplateID, int SentBy, int totalRecipients, string subject, string body, DateTime timeSent)
        {
            var campaign = new Campaign();
            campaign.CampaignName = campaignName;
            campaign.CampaignTemplateID = campaignTemplateID;
            campaign.DateTimeSent = timeSent;
            campaign.Description = description;
            campaign.EmailBody = body;
            campaign.EmailSubject = subject;
            campaign.SentBy = SentBy;
            campaign.TotalRecipients = totalRecipients;
            return SaveCampaign(campaign);
        }

        public Campaign SaveCampaign(Campaign campaign)
        {
            return new CampaignRepository().SaveOrUpdate(campaign);
        }

        public string SendCampaign(Campaign campaign, List<Subscriber> subscribers, int userID)
        {
            int totalRecipients = 0;
            if (campaign == null || campaign.ID == 0)
                throw new Exception("Campaign parameter cannot be null or 0.");

            //REMOVE DUPLICATES
            subscribers = subscribers.Distinct().ToList();

            string userBody = string.Empty;

            foreach (var s in subscribers)
            {
                var campaignSubscriber = new CampaignSubscriber();
                //campaignSubscriber.ID = Guid.NewGuid();
                campaignSubscriber.CampaignID = campaign.ID;
                campaignSubscriber.SubscriberID = s.ID;
                campaignSubscriber = new CampaignSubscriberRepository().SaveOrUpdate(campaignSubscriber);

                string body = CurrentBody.Replace("[USERID]", campaignSubscriber.ID.ToString()).ToString();

                StringBuilder sb = new StringBuilder();
                string optOutString = "<p style='color: #222222; font-size: 10px; text-align: center; font-family: Geneva,Arial,Helvetica,sans-serif; font-weight: bold;'>If you do not wish to receive emails from us any longer, please click here: <a style='text-decoration: none; color: #aaaaaa;' href='" + 
                    CampaignManagerURLs.OptOut + "?sid=" + s.ID.ToString() + "&cid=" + campaign.ID.ToString() + "'>Unsubscribe</a></p><br /><br />";
                string trackingImage = optOutString + string.Format("<img src='http://" + ConfigurationManager.AppSettings["BASEURL"] + "/MDL/CT/IT/{0}/{1}/TImage.gif' />", campaign.ID, campaignSubscriber.ID) + "</body></html>";

                if (body.Contains(@"</body>"))
                {
                    Regex _bodyRegex = new Regex("</body>", RegexOptions.Compiled);

                    body = _bodyRegex.Replace(body, string.Empty);

                    //body.Replace(@"</body>","<br />");
                }
                if (body.Contains(@"</html>"))
                {
                    Regex _htmlRegex = new Regex("</html>", RegexOptions.Compiled);

                    body = _htmlRegex.Replace(body, string.Empty);
                }
                //else
                //{
                //    //ADD TRACKING IMAGE
                //    body += trackingImage;
                //}
                sb.Append(body);
                sb.Append(trackingImage);
                try
                {
                    EmailUtils.SendEmail(s.Email.Trim(), campaign.EmailFrom, "", "dschreiber@mydatapath.com", campaign.EmailSubject, sb.ToString(), false, "");
                    totalRecipients++;
                }
                catch (Exception ex)
                {
                    StringBuilder error = new StringBuilder();
                    error.Append("Message: <br />");
                    error.Append(ex.Message);
                    error.Append("<br /><br />");
                    error.Append("Stack: <br />");
                    error.Append(ex.StackTrace);
                    error.Append("<br /><br />");
                    error.Append("Subscriber: <br />");
                    error.Append(s);
                    error.Append("<br /><br />");
                    error.Append("Campaign Subscriber: <br />");
                    error.Append(campaignSubscriber);

                    EmailUtils.SendEmail("dschreiber@mydatapath.com", "error@swooncms.com", "", "dschreiber@mydatapath.com", "Sending Email From Campaign Failed", error.ToString(), false, "");
                }
            }
            campaign.TotalRecipients = totalRecipients;
            new CampaignRepository().SaveOrUpdate(campaign);
            return userBody;
        }


        public void BuildLinks(Campaign campaign)
        {
            if (campaign.ID == 0)
                throw new Exception("Template must be saved before you can send a campaign.");

            List<CampaignLink> linklist = new List<CampaignLink>();

            //Find all HyperLink tags
            MatchCollection m1 = Regex.Matches(campaign.EmailBody, @"(<a.*?>.*?</a>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // Loop over each A HREF match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;

                //DOUBLE CHECK HYPERLINK HAS HREF
                Match m2 = Regex.Match(value, @"href=[\""|'](.*?)[\""|']", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                if (m2.Success)
                {
                    CampaignLink link = new CampaignLink();
                    link.NavigateURL = m2.Groups[1].Value.Trim();

                    // Remove inner tags from text.
                    string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    link.Text = t;

                    //CHECK IF IMAGE
                    Match imgMatch = Regex.Match(value, @"src=[\""|'](.*?)[\""|']", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    if (imgMatch.Success)
                    {
                        //GRAB THE ALT TEXT 
                        Match altMatch = Regex.Match(value, @"alt=[\""|'](.*?)[\""|']");
                        if (altMatch.Success)
                        {
                            link.Text = altMatch.Groups[1].Value;
                        }
                        else
                        {
                            link.Text = null;
                        }
                        link.ImageURL = imgMatch.Groups[1].Value;
                        link.IsImage = true;
                    }

                    linklist.Add(link);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(campaign.EmailBody);

            foreach (CampaignLink link in linklist)
            {
                var campaignLink = new CampaignLink();
                campaignLink.CampaignID = campaign.ID;
                campaignLink.NavigateURL = link.NavigateURL;
                campaignLink.IsImage = link.IsImage;

                campaignLink.ImageURL = link.ImageURL;
                campaignLink.Text = link.Text;

                campaignLink = new CampaignLinkRepository().Save(campaignLink);
                //BUILD NEW LINK USING HISTORY LINK ID AND [USERID] PLACE HOLDER FOR BULK EMAILING

                sb.Replace(link.NavigateURL + "\"", string.Format("http://{0}/{1}/[USERID]", ConfigurationManager.AppSettings["BASEURL"] + "/MDL/CT/LT/", campaignLink.ID) + "\"");
            }

            CurrentBody = sb;    
        }
        #endregion
    }
}

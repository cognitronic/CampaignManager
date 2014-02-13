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
    public class CampaignManagerUtils
    {
        public static bool SubscriberHasTag(int subscriberID, int campaignTagID)
        {
            if (new SubscriberCampaignTagRepository().GetByCampaignTagIDSubscriberID(campaignTagID, subscriberID).Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDuplicateSubscriber(string email)
        {
            if (new SubscriberRepository().GetByEmail(email) != null)
            {
                return true;
            }
            return false;
        }
    }
}

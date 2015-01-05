using Badge.Plugin.Abstractions;
using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;


namespace Badge.Plugin
{
  /// <summary>
  /// Implementation for Badge
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      public void ClearBadge()
      {
          BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
      }

      public void SetBadge(int badgeNumber, string title = null)
      {
          var badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
          var badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
          badgeElement.SetAttribute("value", badgeNumber.ToString());

          var badge = new BadgeNotification(badgeXml);
          BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
      }
  }
}
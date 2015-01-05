using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Badge.Plugin.Abstractions;

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation of Badge for Windows Phone 8.1 and Windows 8
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      /// <summary>
      /// Clears the badge.
      /// </summary>
      public void ClearBadge()
      {
          BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
      }

      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      /// <param name="title">The title. Used only by Android</param>
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
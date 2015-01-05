using Android;
using Android.App;
using Android.Content;
using Badge.Plugin.Abstractions;

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation of Badge for Android
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      private const int BadgeNotificationId = int.MinValue;

      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      /// <param name="title">The title. Used only by Android</param>
      public void SetBadge(int badgeNumber, string title = null)
      {
          var notificationManager = getNotificationManager();
          var notification = createNativeNotification(badgeNumber, title ?? string.Format("{0} new messages", badgeNumber));

          notificationManager.Notify(BadgeNotificationId, notification);
      }

      /// <summary>
      /// Clears the badge.
      /// </summary>
      public void ClearBadge()
      {
          var notificationManager = getNotificationManager();
          notificationManager.Cancel(BadgeNotificationId);
      }

      private NotificationManager getNotificationManager()
      {
          var notificationManager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;
          return notificationManager;
      }

      private Notification createNativeNotification(int badgeNumber, string title)
      {
          var builder = new Notification.Builder(Application.Context)
              .SetContentTitle(title)
              .SetTicker(title)
              .SetNumber(badgeNumber)
              .SetSmallIcon(Resource.Drawable.IcDialogEmail);

          var nativeNotification = builder.Build();
          return nativeNotification;
      }
  }
}
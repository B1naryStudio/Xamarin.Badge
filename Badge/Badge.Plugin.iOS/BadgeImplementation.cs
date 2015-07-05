using Badge.Plugin.Abstractions;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation of Badge for iOS
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      /// <summary>
      /// Clears the badge.
      /// </summary>
      public void ClearBadge()
      {
          UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
      }

      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      public void SetBadge(int badgeNumber)
      {
          UIApplication.SharedApplication.ApplicationIconBadgeNumber = badgeNumber;
      }
  }
}
using Badge.Plugin.Abstractions;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation for Badge
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      public void ClearBadge()
      {
          UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
      }

      public void SetBadge(int badgeNumber)
      {
          UIApplication.SharedApplication.ApplicationIconBadgeNumber = badgeNumber;
      }
  }
}
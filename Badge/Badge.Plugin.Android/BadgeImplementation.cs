
using System;
using Android.App;
using Badge.Plugin.Abstractions;

/*

<!-- for android -->
<uses-permission android:name="com.android.launcher.permission.READ_SETTINGS"/>
<uses-permission android:name="com.android.launcher.permission.WRITE_SETTINGS"/>
<uses-permission android:name="com.android.launcher.permission.INSTALL_SHORTCUT" />
<uses-permission android:name="com.android.launcher.permission.UNINSTALL_SHORTCUT" />

<!-- Samsung -->
<uses-permission android:name="com.sec.android.provider.badge.permission.READ" />
<uses-permission android:name="com.sec.android.provider.badge.permission.WRITE" />

<!-- HTC -->
<uses-permission android:name="com.htc.launcher.permission.READ_SETTINGS" />
<uses-permission android:name="com.htc.launcher.permission.UPDATE_SHORTCUT" />

<!-- Sony -->
<uses-permission android:name="com.sonyericsson.home.permission.BROADCAST_BADGE" />

<!--for apex-->
<uses-permission android:name="com.anddoes.launcher.permission.UPDATE_COUNT"/>

<!--for solid-->
<uses-permission android:name="com.majeur.launcher.permission.UPDATE_BADGE"/>

*/

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation of Badge for Android
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      public void SetBadge(int badgeNumber)
      {
	      Badges.SetBadge(Application.Context, badgeNumber);
      }

      /// <summary>
      /// Clears the badge.
      /// </summary>
      public void ClearBadge()
      {
	      Badges.RemoveBadge(Application.Context);
      }
  }
}
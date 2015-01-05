using System.Linq;
using Badge.Plugin.Abstractions;
using Microsoft.Phone.Shell;

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation of Badge for Windows Phone 8.0
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      /// <summary>
      /// Clears the badge.
      /// </summary>
      public void ClearBadge()
      {
          SetBadge(0);
      }

      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      /// <param name="title">The title. Used only by Android</param>
      public void SetBadge(int badgeNumber, string title = null)
      {
          var shellTile = ShellTile.ActiveTiles.First();

          if (shellTile == null) return;
          
          var tileData = new StandardTileData
          {
              Count = badgeNumber
          };

          shellTile.Update(tileData);
      }
  }
}
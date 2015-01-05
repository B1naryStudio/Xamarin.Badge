using System.Linq;
using Badge.Plugin.Abstractions;
using Microsoft.Phone.Shell;

namespace Badge.Plugin
{
  /// <summary>
  /// Implementation for Badge
  /// </summary>
  public class BadgeImplementation : IBadge
  {
      public void ClearBadge()
      {
          SetBadge(0);
      }

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
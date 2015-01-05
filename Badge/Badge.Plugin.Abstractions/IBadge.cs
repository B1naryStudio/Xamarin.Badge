namespace Badge.Plugin.Abstractions
{
  /// <summary>
  /// Interface for Badge
  /// </summary>
  public interface IBadge
  {
      void ClearBadge();

      void SetBadge(int badgeNumber);
  }
}

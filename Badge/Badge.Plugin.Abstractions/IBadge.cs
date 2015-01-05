namespace Badge.Plugin.Abstractions
{
  /// <summary>
  /// Interface for changing Badge value
  /// </summary>
  public interface IBadge
  {
      /// <summary>
      /// Clears the badge.
      /// </summary>
      void ClearBadge();

      /// <summary>
      /// Sets the badge.
      /// </summary>
      /// <param name="badgeNumber">The badge number.</param>
      /// <param name="title">The title. Used only by Android</param>
      void SetBadge(int badgeNumber, string title = null);
  }
}

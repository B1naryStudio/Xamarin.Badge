using Badge.Plugin.Abstractions;
using System;

namespace Badge.Plugin
{
  /// <summary>
  /// Cross platform Badge implemenations
  /// </summary>
  public class CrossBadge
  {
    static Lazy<IBadge> Implementation = new Lazy<IBadge>(() => CreateBadge(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IBadge Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IBadge CreateBadge()
    {
#if PORTABLE
        return null;
#else
        return new BadgeImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}

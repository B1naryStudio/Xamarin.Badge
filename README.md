Badge Plugin for Xamarin and Windows

Simple cross platform plugin to work with application badge

### Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugin.Badge/
* Install into your PCL project and Client projects.

**Supports**
* Xamarin.iOS
* Xamarin.iOS (x64 Unified)
* Xamarin.Android
* Windows Phone 8.0
* Windows Phone 8.1 RT
* Windows Store 8.0+

### API Usage

Call **CrossBadge.Current** from any project or PCL to gain access to APIs.

**Setting application badge value**
```
CrossBadge.Current.SetBadge(10);
```

**Clearing application badge value**
```
CrossBadge.Current.ClearBadge();
```

#### Contributors
* [sbondini](https://github.com/sbondini)

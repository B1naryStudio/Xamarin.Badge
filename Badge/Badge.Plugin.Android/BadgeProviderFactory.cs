/*
 * Copyright (C) 2014 Arturo Gutiérrez Díaz-Guerra.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Android.Content;
using System.Collections.Generic;
using System;

namespace Badge.Plugin
{
	/**
	 * Factory created to provide BadgeProvider implementations depending what launcher is being executed
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Alex Rainman
	 */
	public class BadgeProviderFactory {

	    readonly Context context;
		Dictionary<string, BadgeProvider> providers;

		/// <summary>
		/// Badge provider factory constructor
		/// </summary>
	    public BadgeProviderFactory(Context context) {
	        this.context = context;
			providers = new Dictionary<string, BadgeProvider>();

			/* from https://github.com/arturogutierrez/Badges */
			providers.Add("com.sec.android.app.launcher", new SamsungBadgeProvider(context));
			providers.Add("com.sec.android.app.twlauncher", new SamsungBadgeProvider(context));
			providers.Add("com.lge.launcher", new LGBadgeProvider(context));
			providers.Add("com.lge.launcher2", new LGBadgeProvider(context));
			providers.Add("com.sonyericsson.home", new SonyBadgeProvider(context));
			providers.Add("com.htc.launcher", new HtcBadgeProvider(context));

			/* from https://github.com/leolin310148/ShortcutBadger */
			providers.Add("org.adw.launcher", new AdwBadgeProvider(context));
			providers.Add("org.adwfreak.launcher", new AdwBadgeProvider(context));
			providers.Add("com.anddoes.launcher", new ApexBadgeProvider(context));
			providers.Add("com.asus.launcher", new AsusBadgeProvider(context));
			providers.Add("com.teslacoilsw.launcher", new NovaBadgeProvider(context));
			providers.Add("com.majeur.launcher", new SolidBadgeProvider(context));
			providers.Add("com.miui.home", new XiaomiBadgeProvider(context));
			providers.Add("com.miui.miuilite", new XiaomiBadgeProvider(context));
			providers.Add("com.miui.miuihome", new XiaomiBadgeProvider(context));
			providers.Add("com.miui.miuihome2", new XiaomiBadgeProvider(context));
			providers.Add("com.miui.mihome", new XiaomiBadgeProvider(context));
			providers.Add("com.miui.mihome2", new XiaomiBadgeProvider(context));
	    }

		/// <summary>
		/// Get badge provider
		/// </summary>
	    public BadgeProvider GetBadgeProvider() {
	        string currentPackage = GetHomePackage();

			return providers.ContainsKey (currentPackage) ? providers [currentPackage] : new DefaultBadgeProvider (context); //new NullBadgeProvider ();
	    }

	    private string GetHomePackage() {
	        var identify = new HomePackageIdentify();
	        return identify.GetHomePackage(context);
	    }
	}
}
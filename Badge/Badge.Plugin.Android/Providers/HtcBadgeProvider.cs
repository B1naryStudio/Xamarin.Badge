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

//import android.content.ComponentName;
//import android.content.Context;
//import android.content.Intent;
using Android.Content;

namespace Badge.Plugin
{
	/**
	 * BadgeProvider implementation to support badges on HTC devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Alex Rainman
	 */
	class HtcBadgeProvider : BadgeProvider {

	    public HtcBadgeProvider(Context context)
			: base(context)
		{
	    }
			
	    public override void SetBadge(int count) {
	        var intent = new Intent("com.htc.launcher.action.UPDATE_SHORTCUT");
	        intent.PutExtra("packagename", GetPackageName());
	        intent.PutExtra("count", count);
			mContext.SendBroadcast (intent);

	        var setNotificationIntent = new Intent("com.htc.launcher.action.SET_NOTIFICATION");
	        var componentName = new ComponentName(GetPackageName(), GetMainActivityClassName());
	        setNotificationIntent.PutExtra("com.htc.launcher.extra.COMPONENT", componentName.FlattenToShortString());
	        setNotificationIntent.PutExtra("com.htc.launcher.extra.COUNT", count);
	        mContext.SendBroadcast(setNotificationIntent);
	    }
			
	    public override void RemoveBadge() {
	        SetBadge(0);
	    }
	}
}
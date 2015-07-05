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

namespace Badge.Plugin
{
	/**
	 * BadgeProvider implementation to support badges on Sony devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Alex Rainman
	 */
	class SonyBadgeProvider : BadgeProvider {

	    public SonyBadgeProvider(Context context)
	        : base(context)
		{
	    }
			
	    public override void SetBadge(int count) {
	        var intent = new Intent();

	        intent.SetAction("com.sonyericsson.home.action.UPDATE_BADGE");
	        intent.PutExtra("com.sonyericsson.home.intent.extra.badge.PACKAGE_NAME", GetPackageName());
	        intent.PutExtra("com.sonyericsson.home.intent.extra.badge.ACTIVITY_NAME", GetMainActivityClassName());
	        intent.PutExtra("com.sonyericsson.home.intent.extra.badge.SHOW_MESSAGE", count > 0);
			intent.PutExtra("com.sonyericsson.home.intent.extra.badge.MESSAGE", count.ToString());

	        mContext.SendBroadcast(intent);
	    }
			
	    public override void RemoveBadge() {
	        SetBadge(0);
	    }
	}
}
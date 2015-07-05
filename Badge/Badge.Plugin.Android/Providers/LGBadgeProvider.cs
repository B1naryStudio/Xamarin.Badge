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
	 * BadgeProvider implementation to support badges on LG devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 */
	class LGBadgeProvider : BadgeProvider {

	    public LGBadgeProvider(Context context)
			: base(context)
		{
	    }
			
	    public override void SetBadge(int count) {
	        var intent = new Intent("android.intent.action.BADGE_COUNT_UPDATE");
	        intent.PutExtra("badge_count_package_name", GetPackageName());
	        intent.PutExtra("badge_count_class_name", GetMainActivityClassName());
	        intent.PutExtra("badge_count", count);

	        mContext.SendBroadcast(intent);
	    }
			
	    public override void RemoveBadge() {
	        SetBadge(0);
	    }
	}
}

using System;
using Android.Content;

namespace Badge.Plugin
{
	/**
     * @author leolin
     * 
     * ported to C# by Alex Rainman
     */
	class DefaultBadgeProvider : BadgeProvider {

		public DefaultBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			var intent = new Intent("android.intent.action.BADGE_COUNT_UPDATE");
			intent.PutExtra("badge_count", count);
			intent.PutExtra("badge_count_package_name", GetPackageName());
			intent.PutExtra("badge_count_class_name", GetMainActivityClassName());
			mContext.SendBroadcast(intent);
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}


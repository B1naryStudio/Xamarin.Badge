using Android.Content;

namespace Badge.Plugin
{
	/**
     * @author leolin
     * 
     * ported to C# by Alex Rainman
     */
	class AsusBadgeProvider : BadgeProvider {
		
		public AsusBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			var intent = new Intent("android.intent.action.BADGE_COUNT_UPDATE");
			intent.PutExtra("badge_count", count);
			intent.PutExtra("badge_count_package_name", GetPackageName());
			intent.PutExtra("badge_count_class_name", GetMainActivityClassName());
			intent.PutExtra("badge_vip_count", 0);
			mContext.SendBroadcast(intent);
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}


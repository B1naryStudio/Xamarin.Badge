
using Android.Content;

namespace Badge.Plugin
{
	/**
     * @author Gernot Pansy
     * 
     * ported to C# by Alex Rainman
     */
	class ApexBadgeProvider : BadgeProvider {

		public ApexBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			var intent = new Intent("com.anddoes.launcher.COUNTER_CHANGED");
			intent.PutExtra("package", GetPackageName());
			intent.PutExtra("count", count);
			intent.PutExtra("class", GetMainActivityClassName());
			mContext.SendBroadcast(intent);
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}


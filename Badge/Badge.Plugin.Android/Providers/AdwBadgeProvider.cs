
using Android.Content;

namespace Badge.Plugin
{
	/**
     * @author Gernot Pansy
     */
	class AdwBadgeProvider : BadgeProvider {

		public AdwBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			var intent = new Intent("org.adw.launcher.counter.SEND");
			intent.PutExtra("PNAME", GetPackageName());
			intent.PutExtra("COUNT", count);
			mContext.SendBroadcast(intent);
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}

using Android.Content;

namespace Badge.Plugin
{
	/**
	 * @author MajeurAndroid
	 * 
	 * ported to C# by Alex Rainman
	 */
	class SolidBadgeProvider : BadgeProvider {

		public SolidBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			var intent = new Intent("com.majeur.launcher.intent.action.UPDATE_BADGE");
			intent.PutExtra("com.majeur.launcher.intent.extra.BADGE_PACKAGE", GetPackageName());
			intent.PutExtra("com.majeur.launcher.intent.extra.BADGE_COUNT", count);
			intent.PutExtra("com.majeur.launcher.intent.extra.BADGE_CLASS", GetMainActivityClassName());
			mContext.SendBroadcast(intent);
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}


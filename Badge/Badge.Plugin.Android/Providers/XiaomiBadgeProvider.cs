
using Android.Content;
using Java.Lang;
using Java.Lang.Reflect;

namespace Badge.Plugin
{
	/**
	 * @author leolin
	 * 
	 * ported to C# by Alex Rainman
	 */
	class XiaomiBadgeProvider : BadgeProvider {

		public XiaomiBadgeProvider(Context context)
			: base(context)
		{
		}

		public override void SetBadge(int count) {
			try {
				Class miuiNotificationClass = Class.ForName("android.app.MiuiNotification");
				Object miuiNotification = miuiNotificationClass.NewInstance();
				Field field = miuiNotification.Class.GetDeclaredField("messageCount");
				field.Accessible = true;
				field.Set(miuiNotification, count == 0 ? "" : count.ToString());
			} catch (System.Exception e) {
				var localIntent = new Intent("android.intent.action.APPLICATION_MESSAGE_UPDATE");
				localIntent.PutExtra("android.intent.extra.update_application_component_name", GetPackageName() + "/" + GetMainActivityClassName());
				localIntent.PutExtra("android.intent.extra.update_application_message_text", count == 0 ? "" : count.ToString());
				mContext.SendBroadcast(localIntent);
			}
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}
	}
}


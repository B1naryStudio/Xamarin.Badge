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
using Java.Lang;

namespace Badge.Plugin
{

	/**
	 * Helper to set badge count on current application icon on any supported launchers.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 */
	public static class Badges {

	    /**
	     * Set badge count on app icon
	     *
	     * @param context context activity
	     * @param count   should be &gt;= 0, passing count as 0 the badge will be removed.
	     * @throws BadgesNotSupportedException when the current launcher is not supported by Badges
	     */
		public static void SetBadge(Context context, int count) {
			
	        if (context == null) {
	            throw new BadgesNotSupportedException();
	        }

	        var badgeFactory = new BadgeProviderFactory(context);
			var badgeProvider = badgeFactory.GetBadgeProvider();

	        try {
	            badgeProvider.SetBadge(count);
	        } catch (UnsupportedOperationException e) {
	            throw new BadgesNotSupportedException();
	        }
	    }

	    /**
	     * Remove current badge count
	     *
	     * @param context context activity
	     * @throws BadgesNotSupportedException when the current launcher is not supported by Badges
	     */

		public static void RemoveBadge(Context context) {
	        Badges.SetBadge(context, 0);
	    }
	}
}

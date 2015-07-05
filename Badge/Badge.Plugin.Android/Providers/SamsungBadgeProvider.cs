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
using System;

namespace Badge.Plugin
{
	/**
	 * BadgeProvider implementation to support badges on Samsung devices (WITH FIXES).
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# and fixed by Alex Rainman
	 */
	class SamsungBadgeProvider : BadgeProvider {

		static Android.Net.Uri CONTENT_URI = Android.Net.Uri.Parse("content://com.sec.badge/apps");
	    //const string COLUMN_ID = "_id";
	    //const string COLUMN_PACKAGE = "package";
	    //const string COLUMN_CLASS = "class";
	    //const string COLUMN_BADGE_COUNT = "badgecount";

		public SamsungBadgeProvider(Context context) : base(context){
	    }
			
	    public override void SetBadge(int count) {
	        try {
				
				/*ContentResolver contentResolver = mContext.ContentResolver;
				var cursor = contentResolver.Query(CONTENT_URI, new string[]{ COLUMN_ID }, COLUMN_PACKAGE + "=?", new string[]{ GetPackageName() }, null);

				if (cursor == null || !cursor.MoveToFirst()) {
	                var contentValues = new ContentValues();
	                contentValues.Put(COLUMN_PACKAGE, GetPackageName());
	                contentValues.Put(COLUMN_CLASS, GetMainActivityClassName());
	                contentValues.Put(COLUMN_BADGE_COUNT, count);
	                contentResolver.Insert(CONTENT_URI, contentValues);
	            } else {
	                int idColumnIndex = cursor.GetColumnIndex(COLUMN_ID);

	                var contentValues = new ContentValues();
	                contentValues.Put(COLUMN_BADGE_COUNT, count);
					contentResolver.Update(CONTENT_URI, contentValues, COLUMN_ID + "=?", new string[]{ cursor.GetInt(idColumnIndex).ToString() });
	            }*/
				
				var cv = new ContentValues();
				cv.Put("package", GetPackageName());
				cv.Put("class", GetMainActivityClassName());
				cv.Put("badgecount", count); // integer count you want to display

				ContentResolver contentResolver = mContext.ContentResolver;

				int updated = contentResolver.Update(CONTENT_URI, cv, "package=?", new string[] { GetPackageName() });

				if (updated == 0)
				    contentResolver.Insert(CONTENT_URI, cv);

	        } catch (Exception e) {
	            // Some Samsung devices are throwing SecurityException or RuntimeException when
	            // trying to set the badge saying the app needs permission which are already added,
	            // this try/catch protect us from these "crappy phones" :)
	            throw new Java.Lang.UnsupportedOperationException();
	        }
	    }
			
	    public override void RemoveBadge() {
	        SetBadge(0);
	    }

		/*const string CONTENT_URI = "content://com.sec.badge/apps?notify=true";
		static string[] CONTENT_PROJECTION = new string[]{ "_id","class" };

		public SamsungBadgeProvider(Context context) : base(context){
		}

		public override void SetBadge(int count) {
			Android.Net.Uri mUri = Android.Net.Uri.Parse(CONTENT_URI);
			ContentResolver contentResolver = mContext.ContentResolver;
			try {
				var cursor = contentResolver.Query(mUri, CONTENT_PROJECTION, "package=?", new string[]{ GetPackageName() }, null);
				if (cursor != null) {
					string entryActivityName = GetMainActivityClassName();
					bool entryActivityExist = false;
					while (cursor.MoveToNext()) {
						int id = cursor.GetInt(0);
						ContentValues contentValues = GetContentValues(count, false);
						contentResolver.Update(mUri, contentValues, "_id=?", new String[]{ id.ToString() });
						entryActivityExist |= entryActivityName.Equals (cursor.GetString (cursor.GetColumnIndex ("class")));
					}

					if (!entryActivityExist) {
						ContentValues contentValues = GetContentValues(count, true);
						contentResolver.Insert(mUri, contentValues);
					}
				}
			} catch (Exception e) {
				// Some Samsung devices are throwing SecurityException or RuntimeException when
				// trying to set the badge saying the app needs permission which are already added,
				// this try/catch protect us from these "crappy phones" :)
				throw new Java.Lang.UnsupportedOperationException();
			}
		}

		public override void RemoveBadge() {
			SetBadge(0);
		}

		ContentValues GetContentValues(int count, bool isInsert) {
			var contentValues = new ContentValues();
			if (isInsert) {
				contentValues.Put("package", GetPackageName());
				contentValues.Put("class", GetMainActivityClassName());
			}

			contentValues.Put("badgecount", count);

			return contentValues;
		}*/
	}
}
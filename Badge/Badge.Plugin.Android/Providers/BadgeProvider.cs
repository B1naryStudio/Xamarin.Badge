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
	 * Abstract class created to be implemented by different classes to provide badge change support on
	 * different launchers.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Alex Rainman
	 */

	public class BadgeProvider {

		/// <summary>
		/// Badge provider context
		/// </summary>
	    protected Context mContext;

		/// <summary>
		/// Badge provider constructor
		/// </summary>
	    public BadgeProvider(Context context) {
	        mContext = context;
	    }

		/// <summary>
		/// Virtual set badge
		/// </summary>
		public virtual void SetBadge(int count){
		}

		/// <summary>
		/// Virtual remove badge
		/// </summary>
		public virtual void RemoveBadge(){
		}

		/// <summary>
		/// Get package name
		/// </summary>
	    protected string GetPackageName() {
			return mContext.PackageName;
	    }

		/// <summary>
		/// Get main activity class name
		/// </summary>
	    protected string GetMainActivityClassName() {
			return mContext.PackageManager.GetLaunchIntentForPackage(GetPackageName()).Component.ClassName;
	    }
	}
}
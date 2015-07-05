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
using System;

namespace Badge.Plugin
{

	/**
	 * Exception to tell the current launcher is not supported by Badges library.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 */
	public class BadgesNotSupportedException : Exception {

		/// <summary>
		/// Current home launcher is not supported by Badges library
		/// </summary>
	    public BadgesNotSupportedException()
			: base("Current home launcher is not supported by Badges library")
		{
	    }

		/// <summary>
		/// The home launcher package is not supported by Badges library
		/// </summary>
	    public BadgesNotSupportedException(String homePackage)
			: base(string.Format("The home launcher with package {0} is not supported by Badges library", homePackage))
		{
	    }
	}

}
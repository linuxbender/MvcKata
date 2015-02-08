// MvcKata DiResolver
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 daniel glenn
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies 
// or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
// LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Web.Mvc;

namespace DiResolver.Feature
{
    public class FeatureViewEngine : RazorViewEngine
    {
        private readonly string[] _newAreaViewLocations = {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Views/{2}/Views/{1}/{0}.cshtml",
            "~/Views/{2}/Views/Shared/{0}.cshtml"
        };

        private readonly string[] _newAreaMasterLocations = {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Views/{2}/Views/{1}/{0}.cshtml",
            "~/Views/{2}/Views/Shared/{0}.cshtml"
        };

        private readonly string[] _newAreaPartialViewLocations = {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Views/{2}/Views/{1}/{0}.cshtml",
            "~/Views/{2}/Views/Shared/{0}.cshtml"
        };

        private readonly string[] _newViewLocations = {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
            "~/bin/Views/{1}/{0}.cshtml",
            "~/binViews/Shared/{0}.cshtml"
        };

        private readonly string[] _newMasterLocations = {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
            "~/bin/Views/{1}/{0}.cshtml",
            "~/binViews/Shared/{0}.cshtml"
        };

        private readonly string[] _newPartialViewLocations = {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
            "~/bin/Views/{1}/{0}.cshtml",
            "~/binViews/Shared/{0}.cshtml"
        };

        public FeatureViewEngine()
        {
            AreaViewLocationFormats = _newAreaViewLocations;
            AreaMasterLocationFormats = _newAreaMasterLocations;
            AreaPartialViewLocationFormats = _newAreaPartialViewLocations;
            ViewLocationFormats = _newViewLocations;
            MasterLocationFormats = _newMasterLocations;
            PartialViewLocationFormats = _newPartialViewLocations;
        }
    }
}
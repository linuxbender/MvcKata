// MvcKata DiResolver.Tests
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

using System.Linq;
using System.Web.Mvc;
using DiResolver.Bootstrapper;
using DiResolver.Filter;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace DiResolver.Tests.Bootstrapper
{
    [TestFixture]
    public class ContainerConfigFilterTests : BaseConfig
    {
        [Test]
        public void Given_Unity_Register_FilterProvider_With_ActionFilter_Exceptet_To_Resolve_DebugFilter()
        {
            Container.RegisterType<IActionFilter, DebugFilter>("DebugFilter", new InjectionConstructor(Container.Resolve<IDebugMessageService>()));
            Container.RegisterType<IFilterProvider, FilterProvider>("FilterProvider", new InjectionConstructor(Container));

            var filterProvider = Container.Resolve<FilterProvider>();
            var filterResult = Container.ResolveAll<IActionFilter>();
            var providerResult = filterProvider.GetFilters(null, null);

            Assert.AreEqual(filterResult.Count(), 1);
            Assert.AreEqual(providerResult.Count(), 1);
        }
         
    }
}
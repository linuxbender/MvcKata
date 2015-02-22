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
using DiResolver.Bootstrapper;
using DiResolver.Pages;
using DiResolver.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace DiResolver.Tests.Bootstrapper
{
    [TestFixture]
    public class ContainerConfigViewTests : BaseConfig
    {
        [Test]
        public void Given_UnityViewActivator_Register_IMessageService_Exceptet_To_Resolve_Message()
        {
            Container.RegisterType<IMessageService, MessageService>(new InjectionConstructor("1,2,3"));
            var viewActivator = Container.Resolve<UnityViewActivator>();

            var result = viewActivator.Create(null, typeof(MainNavigation)) as INavigationProvider;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MessageService.Message, "1,2,3");
        }

        [Test]
        public void Given_UnityViewActivator_Register_NoService_Exceptet_To_Resolve_Null()
        {
            var viewActivator = Container.Resolve<UnityViewActivator>();
            var result = viewActivator.Create(null, typeof(MainNavigation)) as INavigationProvider;
            Assert.IsNull(result);
        }

        [Test]
        public void Given_UnityViewActivator_Register_INavigationProvider_Exceptet_To_Resolve_NavigationList()
        {
            Container.RegisterType<INavigationItem, MockNaviItemA>("NaviItemA");
            Container.RegisterType<INavigationItem, MockNaviItemB>("NaviItemB");
            Container.RegisterType<IMessageService, MessageService>(new InjectionConstructor("1,2,3"));

            var viewActivator = Container.Resolve<UnityViewActivator>();
            var result = viewActivator.Create(null, typeof(MainNavigation)) as INavigationProvider;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.NavigationList.Count(), 2);
        }
    }
}
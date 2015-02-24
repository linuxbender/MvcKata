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

using DiResolver.Business.Calculation;
using DiResolver.Provider;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using NUnit.Framework;

namespace DiResolver.Tests.Bootstrapper
{
    public class ContainerConfigInterceptorTests : BaseConfig
    {
        [Test]
        public void Given_Unity_Register_AuditProvider_Exceptet_To_Intercept_Method_Call()
        {
            Container.RegisterType<IStorePrice, StorePrice>("Demo12", new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<AuditProvider>());

            var storePriceService = Container.Resolve<IStorePrice>("Demo12");
            var result = storePriceService.GetPrice(20);
            Assert.AreEqual(result, 21.6);
        }
    }
}
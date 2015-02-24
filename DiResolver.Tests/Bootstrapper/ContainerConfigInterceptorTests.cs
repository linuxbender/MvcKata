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

using System;
using DiResolver.Business.Calculation;
using DiResolver.Provider;
using DiResolver.Tests.Mocks;
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

        [Test]
        public void Given_Unity_Register_AuditProvider_Exceptet_To_Intercept_3_Diff_Services()
        {
            var businessProductA = new MockBusinessParam {Id = 1, Mwt = 0.1, Price = 50, ProductName = "iMusic Store"};
            var businessProductB = new MockBusinessParam { Id = 2, Mwt = 0.1, Price = 100, ProductName = "iBoxOffice Store" };

            Func<MockBusinessParam, MockBusinessResult> funA = p => new MockBusinessResult { Result = p.Price * p.Mwt };
            Func<MockBusinessParam, MockBusinessResult> funB = p => new MockBusinessResult { Result = p.Price * p.Mwt + 10 };

            Container.RegisterType<IMockBusinessCase<MockBusinessParam, MockBusinessResult>, MockBusiness>("BusinessCalculate", new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<AuditProvider>());
            var myBusiness = Container.Resolve<IMockBusinessCase<MockBusinessParam, MockBusinessResult>>("BusinessCalculate");

            var resultA = myBusiness.Execute(funA, businessProductA);
            var resultB = myBusiness.Execute(funB, businessProductB);
            var resultNullable = myBusiness.Execute(funB, null);

            Assert.IsNotNull(resultA.Result);
            Assert.IsNotNull(resultB.Result);
            Assert.AreEqual(resultNullable.Result, 0);
            Assert.AreNotEqual(resultA.Result, resultB.Result);
        }
    }
}
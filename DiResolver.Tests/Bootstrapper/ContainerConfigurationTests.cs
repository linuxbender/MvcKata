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

using System.Configuration;
using System.Web.Mvc;
using DiResolver.Controllers;
using DiResolver.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace DiResolver.Tests.Bootstrapper
{
    [TestFixture]
    public class ContainerConfigurationTests : BaseConfig
    {

        [Test]
        public void Given_Unity_Config_From_Convention_TypeOf_HelloController_Exceptet_Resolve_New_Instance()
        {
            var controller = Container.Resolve<HomeController>();

            Assert.IsNotNull(controller);
        }

        [Test]
        public void Given_Unity_Config_From_Convention_TypeOf_HelloController_Exceptet_Resolve_New_Instance_Per_Call()
        {
            var controllerA = Container.Resolve<HomeController>();
            var controllerB = Container.Resolve<HomeController>();

            Assert.AreNotEqual(controllerA.GetHashCode(), controllerB.GetHashCode());
        }

        [Test]
        public void Given_Unity_Config_From_Xml_TypeOf_PersonService_ExceptetTo_Resolve_Service_As_Singelton_Per_Call()
        {
            IPersonService personServiceA = Container.Resolve<PersonService>();
            IPersonService personServiceB = Container.Resolve<PersonService>();

            Assert.AreEqual(personServiceA.GetHashCode(), personServiceB.GetHashCode());
        }

        [Test]
        public void Given_Unity_Config_From_Xml_With_Initial_Data_TypeOf_PersonService_ExceptetTo_Resolve_Service_Initial_Data()
        {
            IPersonService personServiceA = Container.Resolve<PersonService>();

            Assert.AreEqual(personServiceA.Name,"Alex");
            Assert.AreEqual(personServiceA.Vorname, "Muster");
        }

        [Test]
        public void Given_Unity_Register_From_Xml_With_Config_Data_TypeOf_PersonService_Exceptet_Overwrite_Data_In_Second_Call()
        {
            IPersonService personServiceA = Container.Resolve<PersonService>();
            personServiceA.Name = "Hans";
            personServiceA.Vorname = "Tester";
            IPersonService personServiceB = Container.Resolve<PersonService>();

            Assert.AreEqual(personServiceB.Name, "Hans");
            Assert.AreEqual(personServiceB.Vorname, "Tester");
        }

        [Test]
        public void Given_Unity_Register_Type_As_Singelton_Exceptet_to_return_PersonService()
        {
            Container.RegisterInstance(typeof(IPersonService),new PersonService());
            var resultA = Container.Resolve<PersonService>();
            var resultB = Container.Resolve<PersonService>();
            Assert.AreEqual(resultA.GetHashCode(), resultB.GetHashCode());
        }

        [Test]
        public void Given_Unity_Register_Type_Exceptet_to_Resolve_DebugService_From_The_AppSettings_ServiceType_Name()
        {
            Container.RegisterType<IHelloService, HelloService>("StandardService");
            Container.RegisterType<IHelloService, HelloDebugService>("DebugService");

            var serviceType = ConfigurationManager.AppSettings["ServiceType"];
            Container.RegisterType<Controller, HomeController>(new InjectionConstructor(Container.Resolve<IHelloService>(serviceType)));

            var controller = Container.Resolve<HomeController>();
            var response = (ViewResult) controller.Index();

            Assert.AreEqual(response.ViewBag.Message, "Debug, Nicole Tester!");
        }
    }
}
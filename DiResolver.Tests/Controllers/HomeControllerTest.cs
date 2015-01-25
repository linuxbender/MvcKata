using System.Web.Mvc;
using DiResolver.Bootstrapper;
using DiResolver.Controllers;
using DiResolver.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace DiResolver.Tests.Controllers
{    
    [TestFixture]
    public class HomeControllerTest
    {
        private IUnityContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new UnityContainer();
        }

        [TearDown]
        public void Cleanup()
        {
            _container.Dispose();
        }

        [Test]
        public void Index()
        {
            // Arrange            
            ContainerConfiguration.RegisterTypes(_container);

            var controller = _container.Resolve<HomeController>();        

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(new HelloService());

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(new HelloService());

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
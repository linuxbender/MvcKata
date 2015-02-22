using System;
using System.Web.Mvc;
using DiResolver.Services;
using Microsoft.Practices.Unity;

namespace DiResolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloService _helloService;

        [Dependency]
        protected IPersonService PersonService { get; set; }

        public HomeController(IHelloService helloService)
        {
            if (helloService == null)
            {
                throw new ArgumentNullException("helloService");
            }

            _helloService = helloService;
        }

        public ActionResult Index()
        {            
            PersonService.Name = "Nicole";
            PersonService.Vorname = "Tester";

            ViewBag.Message = _helloService.SayHello(PersonService.FullName);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}
using System.Web.Mvc;
using DiResolver.Services;

namespace DiResolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloService _helloService;

        public HomeController(IHelloService helloService)
        {            
            _helloService = helloService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _helloService.SayHello("Alex");
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
    }
}
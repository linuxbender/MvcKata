using System.Web.Mvc;
using DiResolver.Business.Calculation;

namespace DiResolver.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStorePrice _storePrice;

        public StoreController(IStorePrice storePrice)
        {
            _storePrice = storePrice;
        }

        // GET: Store
        public ActionResult Index()
        {
            var price  = _storePrice.GetPrice(20);
            ViewBag.Price = price;
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace AmazonSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}

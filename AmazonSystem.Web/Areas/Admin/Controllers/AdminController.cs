using Microsoft.AspNetCore.Mvc;

namespace AmazonSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

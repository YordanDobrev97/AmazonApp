using Microsoft.AspNetCore.Mvc;

namespace AmazonSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}

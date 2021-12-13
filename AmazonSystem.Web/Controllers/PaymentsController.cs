using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AmazonSystem.Web.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pay(PaymentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                // TODO ...
            }



            return new JsonResult("It works");
        }
    }
}

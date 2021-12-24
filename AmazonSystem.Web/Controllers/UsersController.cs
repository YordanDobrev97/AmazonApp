using AmazonSystem.Common.Services.Users;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userData = await this.usersService.GetProfileData(userId);
            return View(userData);
        }

        [HttpPost]
        [Route("api/[controller]/UserSettings")]
        public async Task<IActionResult> UserSettings([FromBody] UserSettingsViewModel inputModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var setSuccessfully = await this.usersService.SetUserSettings(userId, inputModel?.FirstName, inputModel?.LastName, inputModel?.City,
                inputModel?.Street, inputModel?.Postcode, inputModel?.Country, inputModel?.PhoneNumber);

            if (setSuccessfully)
            {
                return new JsonResult("Everything was successful!");
            }

            return new JsonResult("Something wrong please try again!");
        }
    }
}

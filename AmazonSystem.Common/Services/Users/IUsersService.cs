using AmazonSystem.Common.ViewModels;
using System.Threading.Tasks;

namespace AmazonSystem.Common.Services.Users
{
    public interface IUsersService
    {
        Task<bool> SetUserSettings(string userId, string firstName, string lastName, string city, string street, string postcode, string country, string phoneNumber);

        Task<int> GetAddress(string userId);

        Task<ProfileDataViewModel> GetProfileData(string userId);
    }
}

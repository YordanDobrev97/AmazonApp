using AmazonSystem.Common.ViewModels;
using AmazonSystem.Data;
using AmazonSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Common.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GetAddress(string userId)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user.AddressId == null)
            {
                return GlobalConstants.InvalidAddressStatusCode;
            }

            return (int)user.AddressId;
        }

        public async Task<bool> SetUserSettings(string userId, string firstName, string lastName, string city, string street, string postcode, string country, string phoneNumber)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            var address = await this.dbContext.Addresses.FirstOrDefaultAsync(
                x => x.City.ToLower() == city.ToLower() && 
                x.Street.ToLower() == street.ToLower() &&
                x.Country.ToLower() == country.ToLower());

            if (address == null)
            {
                address = new Address()
                {
                    Street = street,
                    City = city,
                    Country = country,
                    ZipCode = postcode,
                };

                await this.dbContext.Addresses.AddAsync(address);
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Address = address;
            user.PhoneNumber = phoneNumber;

            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProfileDataViewModel> GetProfileData(string userId)
        {
            var user = await this.dbContext.Users
                .Where(x => x.Id == userId)
                .Select(x => new ProfileDataViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.PhoneNumber,
                    City = x.Address.City,
                    ZipCode = x.Address.ZipCode,
                    Street = x.Address.Street,
                    Country = x.Address.Country,
                }).FirstOrDefaultAsync();

            return user;
        }
    }
}

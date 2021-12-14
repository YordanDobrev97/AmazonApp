using AmazonSystem.Data;
using AmazonSystem.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Common.Services.Addresses
{
    public class AddressesService : IAddressesService
    {
        private readonly ApplicationDbContext dbContext;

        public AddressesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(string street, string city, string country, string zipCode)
        {
            if (this.IsExist(street, city, country) == GlobalConstants.InvalidAddressStatusCode)
            {
                return GlobalConstants.InvalidAddressStatusCode;
            }

            var newAddress = new Address
            {
                Street = street,
                City = city,
                Country = country,
                ZipCode = zipCode,
            };

            await this.dbContext.Addresses.AddAsync(newAddress);
            await this.dbContext.SaveChangesAsync();
            return newAddress.Id;
        }

        public int IsExist(string street, string city, string country)
        {
            if (street == null || city == null || country == null)
            {
                return GlobalConstants.InvalidAddressStatusCode;
            }

            var address = this.dbContext.Addresses.FirstOrDefault(
                x => x.Street.ToLower() == street.ToLower() &&
                x.City.ToLower() == city.ToLower() &&
                x.Country.ToLower() == country.ToLower());

            if (address == null)
            {
                return GlobalConstants.InvalidAddressStatusCode;
            }

            return address.Id;
        }
    }
}

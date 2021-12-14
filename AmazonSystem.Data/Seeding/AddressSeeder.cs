using AmazonSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Data.Seeding
{
    public class AddressSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Addresses.Count() > 0)
            {
                return;
            }

            var listAddress = new List<Address>()
            {
                new Address()
                {
                    Street = "street LOM",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ZipCode = "1000"
                },
                new Address()
                {
                    Street = "street K.V",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ZipCode = "1000"
                },
            };

            foreach (var address in listAddress)
            {
                await dbContext.Addresses.AddAsync(address);
            }
        }
    }
}

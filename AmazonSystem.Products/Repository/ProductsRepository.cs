using AmazonSystem.Data.Models;
using AmazonSystem.Products.ViewModels;
using AmazonSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category)
        {
            var productCategory = await this.dbContext.Categories.FirstOrDefaultAsync(x => x.Name == category);

            if (productCategory == null)
            {
                productCategory = new Category()
                {
                    Name = category
                };

                await this.dbContext.Categories.AddAsync(productCategory);
            }

            var product = new Product()
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                Price = price,
                Category = productCategory
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<ListProductViewModel>> All()
        {
            var products = this.dbContext.Products.Select(p => new ListProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price
            }).ToListAsync();
            
            return await products;
        }
    }
}

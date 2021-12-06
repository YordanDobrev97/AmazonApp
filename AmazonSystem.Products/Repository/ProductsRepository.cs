using AmazonSystem.Data.Models;
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

        public async Task Add(Product product)
        {
            await this.dbContext.Products.AddAsync(product);
        }

        public async Task<List<Product>> All()
        {
            var products = this.dbContext.Products.ToListAsync();
            return await products;
        }
    }
}

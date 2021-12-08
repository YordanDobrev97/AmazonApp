using AmazonSystem.Common;
using AmazonSystem.Data.Models;
using AmazonSystem.Products.ViewModels;
using AmazonSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ProductViewModel> All(int id)
        {
            var max = GlobalConstants.ProductPerPage;
            var skip = (id - 1) * max;

            var products = await this.dbContext.Products
                .Skip(skip)
                .Take(max)
                .Select(p => new ListProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price
            }).ToListAsync();

            var categories = await this.dbContext.Categories.Select(x => new CategoryViewModel()
            {
                Name = x.Name,
            }).ToListAsync();

            var viewModel = new ProductViewModel()
            {
                CurrentPage = id,
                PagesCount = (int)Math.Ceiling(this.dbContext.Products.Count() / (decimal)max),
                Products = products,
                Categories = categories
            };

            return viewModel;
        }

        public async Task<ProductDetailsViewModel> Details(int id)
        {
            var product = await this.dbContext.Products.Where(x => x.Id == id).Select(x => new ProductDetailsViewModel()
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return product;
        }
    }
}

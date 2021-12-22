using AmazonSystem.Common;
using AmazonSystem.Data.Models;
using AmazonSystem.Products.ViewModels;
using AmazonSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext dbContext;
        private const int Max = GlobalConstants.ProductPerPage;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductViewModel> All(int id)
        {
            var skip = (id - 1) * Max;

            var products = await this.dbContext.Products
                .Skip(skip)
                .Take(Max)
                .Select(p => new ProductByCategoryViewModel
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
                PagesCount = (int)Math.Ceiling(this.dbContext.Products.Count() / (decimal)Max),
                Products = products,
                Categories = categories
            };

            return viewModel;
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

        public async Task<ProductDetailsViewModel> Details(int id)
        {
            var product = await this.dbContext.Products.Where(x => x.Id == id).Select(x => new ProductDetailsViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return product;
        }

        public async Task Delete(int id)
        {
            var product = await this.dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            this.dbContext.Products.Remove(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProductEditViewModel> Edit(int id)
        {
            var categories = await this.dbContext.Categories.Select(x => x.Name).ToListAsync();

            var product = await this.dbContext.Products.Where(x => x.Id == id)
                .Select(x => new ProductEditViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price.ToString(),
                    Description = x.Description,
                    Category = x.Category.Name,
                    Categories = categories,
                })
                .FirstOrDefaultAsync();

            return product;

        }

        public async Task Update(ProductEditViewModel productInput)
        {
            var parsed = decimal.Parse(productInput.Price, CultureInfo.InvariantCulture);

            var product = await this.dbContext.Products.Where(x => x.Id == productInput.Id).FirstOrDefaultAsync();
            var category = await this.dbContext.Categories.FirstOrDefaultAsync(x => x.Name == productInput.Category);

            category.Name = productInput.Category;
            product.Name = productInput.Name;
            product.ImageUrl = productInput.ImageUrl;
            product.Description = productInput.Description;
            product.Price = parsed;
            product.Category = category;

            this.dbContext.Products.Update(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ListProductViewModel> SearchByCategory(int id, string category)
        {
            var skip = (id - 1) * Max;
            var allCategoryProducts = this.dbContext.Products.Where(x => x.Category.Name == category);

            var products = await allCategoryProducts
                .Skip(skip)
                .Take(Max)
                .Select(x => new ProductByCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                }).ToListAsync();

            var viewModel = new ListProductViewModel()
            {
                Category = category,
                Products = products,
                CurrentPage = id,
                PagesCount = (int)Math.Ceiling(allCategoryProducts.Count() / (decimal)Max),
            };

            return viewModel;
        }
    }
}

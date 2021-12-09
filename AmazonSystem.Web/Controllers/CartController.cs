using AmazonSystem.Common;
using AmazonSystem.Products.ViewModels;
using AmazonSystem.Web.Services.Products;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISession session;

        public CartController(IProductsService productsService, IHttpContextAccessor httpContextAccessor)
        {
            this.productsService = productsService;
            this.httpContextAccessor = httpContextAccessor;
            this.session = this.httpContextAccessor.HttpContext.Session;
        }

        [Route("api/[controller]/AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemModel inputModel)
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            var productItem = await this.productsService.Details(inputModel.ProductId);

            if (session.GetString(GlobalConstants.SessionKey) != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItemModel>>(session.GetString(GlobalConstants.SessionKey));

                if (cartItems.Exists(x => x.ProductId == inputModel.ProductId))
                {
                    cartItems.Find(x => x.ProductId == inputModel.ProductId).Quantity++;
                }
                else
                {
                    AddToCartItems(inputModel, cartItems, productItem);
                }
            }
            else
            {
                AddToCartItems(inputModel, cartItems, productItem);
            }

            session.SetString(GlobalConstants.SessionKey, JsonConvert.SerializeObject(cartItems));

            return new JsonResult("Succesfully added!");
        }

        public IActionResult Basket()
        {
            var productItems = session.GetString(GlobalConstants.SessionKey);
            var cartItems = JsonConvert.DeserializeObject<List<CartItemModel>>(productItems);
            return this.View(cartItems);
        }

        private static void AddToCartItems(CartItemModel inputModel, List<CartItemModel> cartItems, ProductDetailsViewModel productItem)
        {
            var newCartItem = new CartItemModel()
            {
                ProductName = productItem.Name,
                ProductPrice = productItem.Price,
                ProductId = inputModel.ProductId,
                ImageUrl = productItem.ImageUrl,
                Quantity = 1
            };
            cartItems.Add(newCartItem);
        }
    }
}

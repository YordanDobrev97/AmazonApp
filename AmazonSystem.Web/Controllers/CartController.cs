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

        [Route("api/[controller]/RemoveFromCart")]
        public IActionResult RemoveFromCart([FromBody] ItemCartModel cartModel)
        {
            List<CartItemModel> cartItems = GetCartItems();
            var item = cartItems.Find(x => x.ProductId == cartModel.Id);
            cartItems.Remove(item);

            session.SetString(GlobalConstants.SessionKey, JsonConvert.SerializeObject(cartItems));
            return new JsonResult(cartModel.Id);
        }

        [Route("api/[controller]/IncreaseProductQuantity")]
        public IActionResult IncreaseProductQuantity([FromBody] ItemCartModel cartModel)
        {
            List<CartItemModel> cartItems = GetCartItems();
            var item = cartItems.Find(x => x.ProductId == cartModel.Id);
            cartItems.Remove(item);
            item.Quantity++;
            cartItems.Add(item);
            session.SetString(GlobalConstants.SessionKey, JsonConvert.SerializeObject(cartItems));

            var response = new
            {
                Id = item.ProductId,
                TotalPrice = item.ProductPrice * item.Quantity,
                DoublePrice = item.ProductPrice * 2,
                UpdateQuantity = item.Quantity
            };

            return new JsonResult(response);
        }

        public IActionResult Basket()
        {
            List<CartItemModel> cartItems = GetCartItems();
            return this.View(cartItems);
        }

        public IActionResult Checkout()
        {
            List<CartItemModel> cartItems = GetCartItems();
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

        private List<CartItemModel> GetCartItems()
        {
            var productItems = session.GetString(GlobalConstants.SessionKey);
            if (productItems == null)
            {
                productItems = "[]";
            }

            var cartItems = JsonConvert.DeserializeObject<List<CartItemModel>>(productItems);
            return cartItems;
        }
    }
}

namespace AmazonSystem.Web.ViewModels
{
    public class CartItemModel
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductId { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}

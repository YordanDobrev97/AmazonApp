namespace AmazonSystem.Web.ViewModels
{
    public class ProductsCategoryByPriceInputModel
    {
        public int Id { get; set; } // page number

        public string Category { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models
{
    public class ProductItem
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice {  get; set; }
        public string Thumbnail { get; set; }


    }
}

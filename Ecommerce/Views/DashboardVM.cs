using Ecommerce.Models;

namespace Ecommerce.Views
{
    public class DashboardVM
    {
        public List<Category> categoryinfo {  get; set; }

        public List <ProductItem> productitem { get; set; }
    }
}

using Ecommerce.DAO;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductItemController : Controller
    {
        ApplicationDbContext _context;
        public ProductItemController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var datas = _context.ProductItem.ToList();
            return View(datas);
           
        }
        public JsonResult Save(string productName, string productCode, string productcId ,string productdescription, decimal productprice,string productthumb , int hiddenid)
        {
            if (hiddenid==0)
            {
                ProductItem p = new ProductItem()
                {
                    ProductName= productName,
                    ProductCode= productCode,
                    CategoryId= productcId,
                    Description= productdescription,
                    UnitPrice= productprice,
                    Thumbnail= productthumb,


                };
                _context.ProductItem.Add(p);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data successfully saved"
                });

            }
            else
            {

                var olddata = _context.ProductItem.Where(x => x.ProductId==hiddenid).FirstOrDefault();
                if(olddata==null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Data not found"
                    });
                }
                else
                {
                    olddata.ProductName= productName;
                    olddata.ProductCode= productCode;
                    olddata.CategoryId= productcId;
                    olddata.Description= productdescription;
                    olddata.UnitPrice= productprice;
                    olddata.Thumbnail= productthumb;
                    _context.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        message="Data updated successfully"
                    });
                }
            }

        }
        public JsonResult Delete(int productId)
        {
            var data = _context.ProductItem.Where(x => x.ProductId == productId).FirstOrDefault();


            if (data == null)
            {

                return Json(new
                {
                    success = false,
                    message = "Data not found"

                });
            }

            else
            {
                _context.ProductItem.Remove(data);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data deleted successfully"

                });
            }
        }
        public JsonResult GetById(int productId)
        {
            var datas = _context.ProductItem.Where(x => x.ProductId == productId).FirstOrDefault();


            if (datas == null)
            {

                return Json(new
                {
                    success = false,
                    message = "Data not found"

                });
            }

            else
            {

                return Json(new
                {
                    success = true,
                    data = datas

                });
            }
        }
    }
}

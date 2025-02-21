using Ecommerce.DAO;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller

    {
        ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            /* Category c;
             c = new Category();

             c.CategoryName="Electronics";
             c.CategoryCode="all items";
             _context.Add(c);
             _context.SaveChanges(); */
            var datas = _context.Category.ToList();
            return View(datas);
        }
        public JsonResult Save(string categoryName, string categoryCode , int hiddenid)
        {
            if (hiddenid == 0)
            {
                Category c = new Category()
                {
                    CategoryName= categoryName,
                    CategoryCodee= categoryCode,

                };
                _context.Category.Add(c);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data successfully saved"
                });

            }
            else
            {
                var olddata=_context.Category.Where(x => x.CategoryId==hiddenid).FirstOrDefault();
                if(olddata==null)
                {
                    return Json(new
                    {
                        success = false,
                        message="data not found"
                    });
                    
                }
                else
                {
                   olddata.CategoryName= categoryName;
                   olddata.CategoryCodee=categoryCode;
                    _context.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        message = "Data updated successfully!"
                    });

                }
            }

        }
        public JsonResult Delete(int categoryId)
        {
            var data = _context.Category.Where(x => x.CategoryId == categoryId).FirstOrDefault();
           
           
            if (data == null)
            {

                return Json(new
                {
                    success = false,
                    message = "Data not found"

                });
            }
        
            else
            {_context.Category.Remove(data);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data deleted successfully"

                });
            }
        }
        public JsonResult GetById(int categoryId)
        {
            var datas = _context.Category.Where(x => x.CategoryId == categoryId).FirstOrDefault();


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
                    data= datas

                });
            }
        }

        public JsonResult GetCategory()
        {

            var data = _context.Category.ToList();

            // Return the data as JSON
            return Json(data);

        }
        public IActionResult List( int Id)
        {
            var data=_context.Category.Where(x => x.CategoryId==Id).FirstOrDefault();
            var datas = data.CategoryName;
            var pdata=_context.ProductItem.Where(x=>x.CategoryId==datas).ToList();
            return View(pdata);

        }
        
    
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
namespace Coffee_Hello.Controllers
{
    public class HomeController : Controller
    {
        CoffeeDbContext db = new CoffeeDbContext();
        
        // GET: /Home/



        public ActionResult Index()
        {
            var model = db.PRODUCT.Where(x => x.ProductName != null).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Timkiem(string search)
        {
            var model = db.PRODUCT.Where(x => x.ProductName.Contains(search)).ToList();
            return View("Index", model);
        }


        public ActionResult DanhMuc(int id)
        {
            var model = db.PRODUCT.Where(x => x.CategoryID == id).ToList();
            return View("Index", model);
        }

        public ActionResult Preview(int id)
        {
            var model = db.PRODUCT.Where(x => x.ProductID == id).FirstOrDefault();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = db.CATEGORY.ToList();
            return PartialView(model);
        }


        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(CUSTOMER cUSTOMER)
        {
            //string name=Request.Form["NameCus"];
            //string mail = Request.Form["MailCus"];

            return RedirectToAction("Index");
        }

    }
}
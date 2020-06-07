using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.EF;

namespace Coffee_Hello.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        public ActionResult Coffee()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListCoffee();
            return View(model);
        }

        public ActionResult Drink()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListDrink();
            return View(model);
        }

        public ActionResult Dessert()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListDessert();
            return View(model);
        }

        public ActionResult MainDish()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListMainDish();
            return View(model);
        }
        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCT collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ProductModel();
                    int res = model.Create(collection.ProductName, collection.ProductDescription,  collection.ShowImage, collection.CategoryID,collection.ProductPrice, collection.CreatedDate, collection.Size );
                    if (res > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Them moi err");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PRODUCT collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ProductModel();
                    int res1 = model.Edit(id,collection.ProductName, collection.ProductDescription, collection.ShowImage, collection.CategoryID, collection.ProductPrice,collection.Size,collection.CreatedDate);
                    if (res1 > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Edit err");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ProductModel();
                    int res = model.Delete(id);
                    if (res > 0)
                        return RedirectToAction("Coffee");
                    else
                    {
                        ModelState.AddModelError("", "Delete err");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }
    }
}

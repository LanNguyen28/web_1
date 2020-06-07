using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coffee_Hello.Common;
using Models.Dao;
using Models.EF;
namespace Coffee_Hello.Controllers
{
    public class CartController : Controller
    {
       
       CoffeeDbContext db = new CoffeeDbContext();       //
        // GET: /Cart/

        public ActionResult Index()
        {
            var cart = (CartModel)Session["CartSession"];
            if (cart == null)
            {
                cart = new CartModel();
            }

            return View(cart);
        }



        public ActionResult AddItem(string id, string returnURL)
        {
            var product = db.PRODUCT.Find(id);
            var cart = (CartModel)Session["CartSession"];
            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new CartModel();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }
            return Redirect(returnURL);
        }

        //

        // GET: /Cart/Details/5
        public ActionResult RemoveLine(string id)
        {

            var product = db.PRODUCT.Find(id);

            var cart = (CartModel)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(string[] masp, int[] qty)
        {
            var cart = (CartModel)Session["CartSession"];

            if (cart != null)
            {
                for (int i = 0; i < masp.Count(); i++)
                {
                    var product = db.PRODUCT.Find(masp[i]);
                    cart.UpdateItem(product, qty[i]);
                }

                Session["CartSession"] = cart;
            }

            return RedirectToAction("Index");

        }


        public ActionResult HeaderCart()
        {
            //var list = 
            return PartialView("HeaderCart");
        }

        //
        // GET: /Cart/Details/5
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = (CartModel)Session["CartSession"];
            if (cart == null)
            {
                cart = new CartModel();
            }
            return View(cart);
        }

        [HttpPost]
        public JsonResult HoanThanh(ORDER model)
        {
            try
            {
                var db = new CoffeeDbContext();
                var cart = (CartModel)Session["CartSession"];
                var id = AddHoaDon(model);
                foreach (var item in cart.Lines)
                {
                    var cthd = new ORDERDETAIL
                    {
                        OrderID = id,
                         ProductID = item.product.ProductID,
                        Quantity = item.Quantity,
                       
                    };
                    db.ORDERDETAIL.Add(cthd);
                    db.SaveChanges();
                }
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }

        public int AddHoaDon(ORDER model)
        { //check sesion user
            var db = new CoffeeDbContext();
            var hoadon = new ORDER();
            var session = (UserLogin)Session[Coffee_Hello.Common.Constant.USER_SESSION];
            if (session == null)
            {
                hoadon.CustomerName = model.CustomerName;
                hoadon.CustomerAdress = model.CustomerAdress;
                hoadon.CustomerEmail = model.CustomerEmail;
                hoadon.CustomerPhone = model.CustomerPhone;
                hoadon.OrderDate = DateTime.Now;
            }
            else
            {
                var kh = db.CUSTOMER.Find(session.Customerid);
                hoadon.CustomerID = kh.CustomerID;
                hoadon.CustomerName = kh.CustomerName;
                hoadon.CustomerAdress = kh.CustomerAdress;
                hoadon.CustomerEmail = kh.CustomerEmail;
                hoadon.CustomerPhone = kh.CustomerPhone;
                hoadon.OrderDate = DateTime.Now;
            }
            db.ORDER.Add(hoadon);
            db.SaveChanges();
            return hoadon.OrderID;
        }


        [HttpPost]
        public ActionResult Payment(ORDER oRDER)
        {
            oRDER.OrderDate = DateTime.Now;
            //try
            //{
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                var cart = (CartModel)Session["CartSession"];
                foreach (var item in cart.Lines)
                {
                    ORDERDETAIL obj = new ORDERDETAIL();
                   
                    obj.OrderID = oRDER.OrderID;
                    obj.ProductID = item.product.ProductID;
                    obj.Quantity = item.Quantity;
                    db.ORDERDETAIL.Add(obj);
                    db.SaveChanges();
                }
                cart.Clear();
                Session["CartSession"] = cart;
            //}
            //catch (Exception ex)
            //{
            //    //ghi log
            //    return RedirectToAction("/Loi");
            //}
            return View("Complete");
        }

        //
        // GET: /Cart/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cart/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cart/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cart/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopInventoryApp.Models;

namespace BookShopInventoryApp.Controllers
{
    public class OrdersController : Controller
    {
        private BookShopInventoryAppContext db = new BookShopInventoryAppContext();

        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View(db.OrderModels.ToList());
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderModel ordermodel = db.OrderModels.Find(id);
            if (ordermodel == null)
            {
                return HttpNotFound();
            }
            return View(ordermodel);
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderModel ordermodel)
        {
            if (ModelState.IsValid)
            {
                db.OrderModels.Add(ordermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordermodel);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderModel ordermodel = db.OrderModels.Find(id);
            if (ordermodel == null)
            {
                return HttpNotFound();
            }
            return View(ordermodel);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderModel ordermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordermodel);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderModel ordermodel = db.OrderModels.Find(id);
            if (ordermodel == null)
            {
                return HttpNotFound();
            }
            return View(ordermodel);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel ordermodel = db.OrderModels.Find(id);
            db.OrderModels.Remove(ordermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using Asp_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_ADO.Controllers
{
    public class ProductController : Controller
    {
        private Asp_ADOEntities db;
        public ProductController()
        {
            db = new Asp_ADOEntities();
        }
        // GET: Category
        public ActionResult Index()
        {
            var pro = db.Product.AsEnumerable();
            return View(pro);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product p)
        {

            db.Product.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var pro = db.Product.SingleOrDefault(x => x.ProId == id);
            return View(pro);
        }
        public ActionResult Edit(string id)
        {
            var pro = db.Product.SingleOrDefault(x => x.ProId == id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var pro = db.Product.Find(id);
            db.Product.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
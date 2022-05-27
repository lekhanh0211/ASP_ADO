using Asp_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_ADO.Controllers
{
    public class CategoryController : Controller
    {
        private Asp_ADOEntities db;
        public CategoryController()
        {
            db = new Asp_ADOEntities();
        }
        // GET: Category
        public ActionResult Index()
        {
            var cat = db.Category.ToList();
            return View(cat);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            db.Category.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(db.Category.Find(id));
        }
        public ActionResult Edit(int id)
        {
            var cat = db.Category.Find(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var cat = db.Category.Find(id);
            db.Category.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
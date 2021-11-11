using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProducts.Data;
using WebProducts.Models;
using WebProducts.Repository;

namespace WebProducts.Controllers
{
   

    public class ProductController : Controller
    {
        ProductDbContext context = new ProductDbContext();

        // GET: Product
        public ActionResult Index(string category, string name)
        {
            int cat = String.IsNullOrEmpty(category) ? 0 : 2;
            int nam = String.IsNullOrEmpty(name) ? 0 : 1;
            int val = cat | nam;
            switch (val)
            {
               
                case 0:
                    //Product/Index
                    return View(context.Products.ToList());
                case 2:
                    //Product/categoria
                    return View((from p in context.Products
                                 where p.Category == category
                                 select p).ToList());
                case 1:
                    //Product/nombre
                    return View((from p in context.Products
                                where p.ProductName == name
                                select p).ToList());
                case 3:
                    //Product/Categoria/Nombre
                    return View((from p in context.Products
                                 where p.Category == category && p.ProductName == name
                                 select p).ToList());
                default:
                    return View();
            }

        }

        public ActionResult Detail(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Detail", product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }

        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", product);
        }

        public ActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Edit", product);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", product);
        }

        public ActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Delete", product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
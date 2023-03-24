using Antlr.Runtime.Tree;
using MVCAuthCrud_0.AuthenticationClasses;
using MVCAuthCrud_0.DesignPatterns.SingletonPattern;
using MVCAuthCrud_0.Models.Context;
using MVCAuthCrud_0.Models.Entities;
using MVCAuthCrud_0.Models.PageVms;
using MVCAuthCrud_0.Models.PureVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthCrud_0.Controllers
{
    [AdminAuthentication]
    public class ProductController : Controller
    {
        MyContext _db;

        public ProductController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult ListProducts()
        {
            List<ProductVM> products = _db.Products.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category.CategoryName
            }).ToList();

            ListProductPageVM lpvm = new ListProductPageVM
            {
                Products = products
            };
            return View(lpvm);
        }

        public ActionResult AddProduct()
        {
            List<CategoryVM> categories = GetCategories();
            AddUpdateProductPageVM auPvm = new AddUpdateProductPageVM
            {
                Categories = categories
            };
            return View(auPvm);
        }

        private List<CategoryVM> GetCategories()
        {
            return _db.Categories.Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductVM product)
        {
            Product p = new Product()
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryID = product.CategoryID
            };
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }


        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = _db.Products.Select(x=> new ProductVM
            {
                ID = x.ID,
                CategoryID = x.CategoryID,
                ProductName = x.ProductName,
                UnitPrice  = x.UnitPrice
            }).FirstOrDefault(x=>x.ID == id);

            List<CategoryVM> categories = GetCategories();  
            AddUpdateProductPageVM aupvm = new AddUpdateProductPageVM
            {
                Product = pvm,
                Categories = categories
            };

            return View(aupvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductVM product)
        {
            Product pro = _db.Products.Find(product.ID);
            pro.CategoryID = product.CategoryID;
            pro.ProductName = product.ProductName;
            pro.UnitPrice = product.UnitPrice;
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }
    }
}
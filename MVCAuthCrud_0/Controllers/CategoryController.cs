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
    public class CategoryController : Controller
    {
        //ProductRepository _pRep;
        MyContext _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult ListCategories()
        {
            List<CategoryVM> categories = _db.Categories.Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();

            ListCategoryPageVM lcvm = new ListCategoryPageVM
            {
                Categories = categories
            };
            return View(lcvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM category)
        {
            Category c = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            _db.Categories.Add(c);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM category = _db.Categories.Select(x => new CategoryVM
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                ID = id

            }).FirstOrDefault(x => x.ID == id);


            AddUpdateCategoryPageVM aupvm = new AddUpdateCategoryPageVM
            {
                Category = category
            };

            return View(aupvm);

        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM category)
        {
            Category toBeUpdated = _db.Categories.Find(category.ID);

            toBeUpdated.CategoryName = category.CategoryName;
            toBeUpdated.Description = category.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
    }
}
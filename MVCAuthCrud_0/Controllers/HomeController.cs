using MVCAuthCrud_0.DesignPatterns.SingletonPattern;
using MVCAuthCrud_0.Models.Context;
using MVCAuthCrud_0.Models.Entities;
using MVCAuthCrud_0.Models.PureVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthCrud_0.Controllers
{
    public class HomeController : Controller
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUserVM appUser)
        {
            if (_db.AppUsers.Any(x => x.UserName == appUser.UserName && x.Password == appUser.Password && x.Role == Models.Enums.UserRole.Admin ))
            {
                Session["admin"] = _db.AppUsers.FirstOrDefault(x => x.UserName == appUser.UserName && x.Password == appUser.Password);

                return RedirectToAction("ListCategories", "Category");
            }
            ViewBag.Message = "Kullanıcının ya yetkisi yok ya da böyle bir kullanıcı yok";
            return View();
        }
    }
}
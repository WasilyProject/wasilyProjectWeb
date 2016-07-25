using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private wasilyEntities1 db = new wasilyEntities1();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(loginModel model)
        {
            if (ModelState.IsValid)
            {
                if (valid(model.Username, model.Password))
                {
                    
                    return RedirectToAction("index", "users");
                }
                ModelState.AddModelError("informationwrong", "اسم المستخدم او كلمة المرور غير صحيحة");
            }
            return View(model);

        }

        public Boolean valid(string username,string password)
        {
            bool isvalid = false;
            var usernow = db.user.FirstOrDefault(u => u.Username == username);
            if (usernow !=null)
            {
                if (usernow.Password == password)
                {
                    isvalid = true;
                    Session["username"] = usernow.Username;
                    Session["userid"] = usernow.UserID;
                    Session["userid"] = "user";

                }
            }

            return isvalid; 
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register(RegisterModel registermodel, HttpPostedFileBase file)
        {
            file.SaveAs(HttpContext.Server.MapPath("~/picture/")
                                      + file.FileName);

            user newuser = new user()
            {
                City = registermodel.City,
                Country = registermodel.Country,
                Mobile = registermodel.Mobile,
                Rating = 0,
                Picture = file.FileName,
                Email = registermodel.Email,
                Password= registermodel.Password,
                Username= registermodel.Username,

            };
            db.user.Add(newuser);
            int x = db.SaveChanges();
            if (x > 0)
            {
                TempData["Success"] = "تم إنشاء العضوية بنجاح";
                return RedirectToAction("index");

            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(loginModel model)
        {
            if (ModelState.IsValid)
            {
                if (validadmin(model.Username, model.Password))
                {

                    return RedirectToAction("index", "Admins");
                }
                ModelState.AddModelError("informationwrong", "اسم المستخدم او كلمة المرور غير صحيحة");
            }
            return View(model);
        }
        public Boolean validadmin(string username, string password)
        {
            bool isvalid = false;
            Admin usernow = db.Admin.FirstOrDefault(u => u.username == username);
            if (usernow != null)
            {
                if (usernow.Password == password)
                {
                    isvalid = true;
                    Session["username"] = usernow.username;
                    Session["userid"] = usernow.AdminID;
                    Session["type"] = "admin";
                }
            }

            return isvalid;
        }

    }
}
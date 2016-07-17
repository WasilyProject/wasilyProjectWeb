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
                }
            }

            return isvalid; 
        }


    }
}
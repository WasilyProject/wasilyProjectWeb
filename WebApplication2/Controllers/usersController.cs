using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    
    public class usersController : Controller
    {
        private wasilyEntities1 db = new wasilyEntities1();

        // GET: users
        public ActionResult Index()
        {
            user user = db.user.Find(Session["userid"]);
            return View(user);

        }


        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
                TempData["result"] = "false";
            int useridmofdel1 = Int32.Parse(id.ToString());
            int useridmodadel1 = Int32.Parse(Session["userid"].ToString());
            var x = db.Favorite.Where(u => u.useridmofadel == useridmodadel1 && u.useridmofdel == useridmofdel1);
            if (x.Count() >0)
            {
                TempData["result"] = "true";
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password,Email,Picture,City,Country,Mobile")] user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password,Email,Picture,City,Country,Mobile")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.user.Find(id);
            db.user.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            return null;

        }
        [HttpGet]
        public ActionResult Myfavroite()
        {
            int userid = Int32.Parse(Session["userid"].ToString());
            var favorite = db.Favorite.Where(u => u.useridmofadel == userid);
            return View(favorite.ToList());
        }
        public ActionResult ShowUserFavorite(int? userid)
        {


            var favorite = db.Favorite.Where(u => u.useridmofadel == userid);
            return View(favorite.ToList());
        }

        public ActionResult FavoriteSomeOne(int? userid)
        {
            Favorite newfavorite = new Favorite()
            {
                useridmofadel = Int32.Parse(Session["userid"].ToString()),
                useridmofdel = Int32.Parse(userid.ToString())
            };
           db.Favorite.Add(newfavorite);
           var result1= db.SaveChanges();
            if (result1 == 1)
            {
                TempData["Success"] = "تم إضافة اليوزر إلى قائمة مفضلتك";
                return RedirectToAction("Details", new { id = newfavorite.useridmofdel });

            }
            else
            {
                TempData["fail"] = "حدثت مشكلةٌ ما! لم يتم الإضافة إلى مفضلتك";
                return RedirectToAction("Details", new { id = newfavorite.useridmofdel });
            }
        }
        public ActionResult RemoveFavorite(int? userid)
        {
            Favorite removedone = new Favorite()
            {
                useridmofadel = Int32.Parse(Session["userid"].ToString()),
                useridmofdel = Int32.Parse(userid.ToString())
            };
            var favoirte1 = db.Favorite.FirstOrDefault(u => u.useridmofadel == removedone.useridmofadel && u.useridmofdel == removedone.useridmofdel);
            var favorite2 = db.Favorite.Find(favoirte1.Favoriteid);


            var x = db.Favorite.Remove(favorite2);
            var result1 = db.SaveChanges();
            if (result1 == 1)
            { 
                    TempData["Success"] = "تم إزالة العضو من مفضلتك";
                    return RedirectToAction("Details", new { id = userid });
            }else
            {
                TempData["fail"] = "حدث خطاء ما , لم تتم إزالته";
                return RedirectToAction("Details", new { id = userid });
            }

            }




        }
    }

    
          


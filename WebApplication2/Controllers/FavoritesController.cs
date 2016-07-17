using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FavoritesController : Controller
    {
        private wasilyEntities1 db = new wasilyEntities1();

        // GET: Favorites
        public ActionResult Index()
        {
            var favorite = db.Favorite.Include(f => f.user).Include(f => f.user1);
            return View(favorite.ToList());
            // helloootest
        }

        // GET: Favorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = db.Favorite.Find(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            return View(favorite);
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            ViewBag.useridmofdel = new SelectList(db.user, "UserID", "Username");
            ViewBag.useridmofadel = new SelectList(db.user, "UserID", "Username");
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Favoriteid,useridmofdel,useridmofadel")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                db.Favorite.Add(favorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.useridmofdel = new SelectList(db.user, "UserID", "Username", favorite.useridmofdel);
            ViewBag.useridmofadel = new SelectList(db.user, "UserID", "Username", favorite.useridmofadel);
            return View(favorite);
        }

        // GET: Favorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = db.Favorite.Find(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            ViewBag.useridmofdel = new SelectList(db.user, "UserID", "Username", favorite.useridmofdel);
            ViewBag.useridmofadel = new SelectList(db.user, "UserID", "Username", favorite.useridmofadel);
            return View(favorite);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Favoriteid,useridmofdel,useridmofadel")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.useridmofdel = new SelectList(db.user, "UserID", "Username", favorite.useridmofdel);
            ViewBag.useridmofadel = new SelectList(db.user, "UserID", "Username", favorite.useridmofadel);
            return View(favorite);
        }

        // GET: Favorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = db.Favorite.Find(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favorite favorite = db.Favorite.Find(id);
            db.Favorite.Remove(favorite);
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
    }
}

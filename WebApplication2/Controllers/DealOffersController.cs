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
    public class DealOffersController : Controller
    {
        private wasilyEntities1 db = new wasilyEntities1();

        // GET: DealOffers
        public ActionResult Index()
        {
            var dealOffer = db.DealOffer.Include(d => d.user);
            return View(dealOffer.ToList());
        }

        // GET: DealOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealOffer dealOffer = db.DealOffer.Find(id);
            if (dealOffer == null)
            {
                return HttpNotFound();
            }
            return View(dealOffer);
        }

        // GET: DealOffers/Create
        public ActionResult Create()
        {
            TempData["userid"] = Session["userid"];
            return View();
        }

        // POST: DealOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(CreateDealOffers model)
        {
            var dealofferOBJ = new DealOffer() { 
            
                ArrivalCity = model.ArrivalCity1,
                ArrivalDate = model.ArrivalDate1,
                ArrivalTime = model.ArrivalTime1,
                Currency = model.Currency1,
                DeliveryMethod = model.DeliveryMethod1,
                ReceiveMethod = model.ReceiveMethod1,
                DepartureCity = model.DepartureCity1,
                DepartureDate = model.DepartureDate1,
                DepartureTime = model.DepartureTime1,
                Flexibility = model.Flexibility1,
                Price = model.Price1,
                Weight = model.Weight1,
                UserID = Int16.Parse(Session["userid"].ToString()),

        };
                db.DealOffer.Add(dealofferOBJ);
                db.SaveChanges();
            TempData["arrivaldate"] = model.ArrivalDate1;
                return RedirectToAction("Index","users");


        }

        // GET: DealOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealOffer dealOffer = db.DealOffer.Find(id);
            if (dealOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.user, "UserID", "Username", dealOffer.UserID);
            return View(dealOffer);
        }

        // POST: DealOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealOfferID,Currency,Price,Weight,ArrivalCity,DepartureCity,ArrivalTime,DepartureTime,ArrivalDate,DepartureDate,ReceiveMethod,DeliveryMethod,Flexibility,UserID")] DealOffer dealOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.user, "UserID", "Username", dealOffer.UserID);
            return View(dealOffer);
        }

        // GET: DealOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealOffer dealOffer = db.DealOffer.Find(id);
            if (dealOffer == null)
            {
                return HttpNotFound();
            }
            return View(dealOffer);
        }

        // POST: DealOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DealOffer dealOffer = db.DealOffer.Find(id);
            db.DealOffer.Remove(dealOffer);
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

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
    public class DealsController : Controller
    {
        private wasilyEntities1 db = new wasilyEntities1();

        // GET: Deals
        public ActionResult Index()
        {
            var deal = db.Deal.Include(d => d.DealOffer).Include(d => d.DealOffer1).Include(d => d.user);
            return View(deal.ToList());
        }

        // GET: Deals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = db.Deal.Find(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // GET: Deals/Create
        public ActionResult Create()
        {
            ViewBag.DealOfferID = new SelectList(db.DealOffer, "DealOfferID", "Currency");
            ViewBag.UserDealOfferIDMoasel = new SelectList(db.DealOffer, "DealOfferID", "Currency");
            ViewBag.UserIDMorsel = new SelectList(db.user, "UserID", "Username");
            return View();
        }

        // POST: Deals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DealID,Date,RecipientNumber,RecipientName,Dimension,Weight,Contentt,UserDealOfferIDMoasel,DealOfferID,FirstPassword,SecoundPssword,UserIDMorsel,TypeOfDeal")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Deal.Add(deal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DealOfferID = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.DealOfferID);
            ViewBag.UserDealOfferIDMoasel = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.UserDealOfferIDMoasel);
            ViewBag.UserIDMorsel = new SelectList(db.user, "UserID", "Username", deal.UserIDMorsel);
            return View(deal);
        }

        // GET: Deals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = db.Deal.Find(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            ViewBag.DealOfferID = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.DealOfferID);
            ViewBag.UserDealOfferIDMoasel = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.UserDealOfferIDMoasel);
            ViewBag.UserIDMorsel = new SelectList(db.user, "UserID", "Username", deal.UserIDMorsel);
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealID,Date,RecipientNumber,RecipientName,Dimension,Weight,Contentt,UserDealOfferIDMoasel,DealOfferID,FirstPassword,SecoundPssword,UserIDMorsel,TypeOfDeal")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DealOfferID = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.DealOfferID);
            ViewBag.UserDealOfferIDMoasel = new SelectList(db.DealOffer, "DealOfferID", "Currency", deal.UserDealOfferIDMoasel);
            ViewBag.UserIDMorsel = new SelectList(db.user, "UserID", "Username", deal.UserIDMorsel);
            return View(deal);
        }

        // GET: Deals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = db.Deal.Find(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deal deal = db.Deal.Find(id);
            db.Deal.Remove(deal);
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

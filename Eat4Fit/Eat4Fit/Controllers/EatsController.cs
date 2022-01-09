using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Eat4Fit
{
    public class EatsController : Controller
    {
        private Entities db = new Entities();

        // GET: Eats
        public ActionResult Index()
        {
            var eats = db.Eats.Include(e => e.Food);
            return View(eats.ToList());
        }

        // GET: Eats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eats eats = db.Eats.Find(id);
            if (eats == null)
            {
                return HttpNotFound();
            }
            return View(eats);
        }

        // GET: Eats/Create
        public ActionResult Create()
        {
            ViewBag.FoodId = new SelectList(db.Food, "Id", "Name");
            return View();
        }

        // POST: Eats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,FoodId,DateTime")] Eats eats)
        {
            if (ModelState.IsValid)
            {
                db.Eats.Add(eats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodId = new SelectList(db.Food, "Id", "Name", eats.FoodId);
            return View(eats);
        }

        // GET: Eats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eats eats = db.Eats.Find(id);
            if (eats == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodId = new SelectList(db.Food, "Id", "Name", eats.FoodId);
            return View(eats);
        }

        // POST: Eats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,FoodId,DateTime")] Eats eats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodId = new SelectList(db.Food, "Id", "Name", eats.FoodId);
            return View(eats);
        }

        // GET: Eats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eats eats = db.Eats.Find(id);
            if (eats == null)
            {
                return HttpNotFound();
            }
            return View(eats);
        }

        // POST: Eats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eats eats = db.Eats.Find(id);
            db.Eats.Remove(eats);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class SPECS_DETAILSController : Controller
    {
        private OnlineSpecsDetailsEntities db = new OnlineSpecsDetailsEntities();

        // GET: SPECS_DETAILS
        public ActionResult Index()
        {
            
            return View(db.SPECS_DETAILS.ToList());
        }

        // GET: SPECS_DETAILS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECS_DETAILS sPECS_DETAILS = db.SPECS_DETAILS.Find(id);
            if (sPECS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sPECS_DETAILS);
        }

        // GET: SPECS_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.SPECS_ID = new SelectList(db.ADD_TO_CART, "SPECS_ID", "SPECS_NAME");
            return View();
        }

        // POST: SPECS_DETAILS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPECS_ID,SPECS_NAME,SPECS_IMAGE,FRAME_TYPE,FRAME_WIDTH,FRAME_SIZE,SPECS_PRICE")] SPECS_DETAILS sPECS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.SPECS_DETAILS.Add(sPECS_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SPECS_ID = new SelectList(db.ADD_TO_CART, "SPECS_ID", "SPECS_NAME", sPECS_DETAILS.SPECS_ID);
            return View(sPECS_DETAILS);
        }

        // GET: SPECS_DETAILS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECS_DETAILS sPECS_DETAILS = db.SPECS_DETAILS.Find(id);
            if (sPECS_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.SPECS_ID = new SelectList(db.ADD_TO_CART, "SPECS_ID", "SPECS_NAME", sPECS_DETAILS.SPECS_ID);
            return View(sPECS_DETAILS);
        }

        // POST: SPECS_DETAILS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPECS_ID,SPECS_NAME,SPECS_IMAGE,FRAME_TYPE,FRAME_WIDTH,FRAME_SIZE,SPECS_PRICE")] SPECS_DETAILS sPECS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPECS_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SPECS_ID = new SelectList(db.ADD_TO_CART, "SPECS_ID", "SPECS_NAME", sPECS_DETAILS.SPECS_ID);
            return View(sPECS_DETAILS);
        }

        // GET: SPECS_DETAILS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECS_DETAILS sPECS_DETAILS = db.SPECS_DETAILS.Find(id);
            if (sPECS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sPECS_DETAILS);
        }

        // POST: SPECS_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPECS_DETAILS sPECS_DETAILS = db.SPECS_DETAILS.Find(id);
            db.SPECS_DETAILS.Remove(sPECS_DETAILS);
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

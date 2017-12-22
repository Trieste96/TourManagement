using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourCommon.Model;

namespace TourMVC.Controllers
{
    public class NhiemVusController : Controller
    {
        private TourDBEntities db = new TourDBEntities();

        // GET: NhiemVus
        public ActionResult Index()
        {
            return View(db.NhiemVus.ToList());
        }

        // GET: NhiemVus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhiemVu nhiemVu = db.NhiemVus.Find(id);
            if (nhiemVu == null)
            {
                return HttpNotFound();
            }
            return View(nhiemVu);
        }

        // GET: NhiemVus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhiemVus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenNhiemVu")] NhiemVu nhiemVu)
        {
            if (ModelState.IsValid)
            {
                db.NhiemVus.Add(nhiemVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhiemVu);
        }

        // GET: NhiemVus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhiemVu nhiemVu = db.NhiemVus.Find(id);
            if (nhiemVu == null)
            {
                return HttpNotFound();
            }
            return View(nhiemVu);
        }

        // POST: NhiemVus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenNhiemVu")] NhiemVu nhiemVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhiemVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhiemVu);
        }

        // GET: NhiemVus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhiemVu nhiemVu = db.NhiemVus.Find(id);
            if (nhiemVu == null)
            {
                return HttpNotFound();
            }
            return View(nhiemVu);
        }

        // POST: NhiemVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhiemVu nhiemVu = db.NhiemVus.Find(id);
            db.NhiemVus.Remove(nhiemVu);
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

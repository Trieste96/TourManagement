using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourMVC.Models;

namespace TourMVC.Controllers
{
    public class KhachDuLichesController : Controller
    {
        private TourDBEntities1 db = new TourDBEntities1();

        // GET: KhachDuLiches
        public ActionResult Index()
        {
            return View(db.KhachDuLiches.ToList());
        }

        // GET: KhachDuLiches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachDuLich khachDuLich = db.KhachDuLiches.Find(id);
            if (khachDuLich == null)
            {
                return HttpNotFound();
            }
            return View(khachDuLich);
        }

        // GET: KhachDuLiches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachDuLiches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaKhach,HoTen,CMND,DiaChi,GioiTinh,SDT")] KhachDuLich khachDuLich)
        {
            if (ModelState.IsValid)
            {
                db.KhachDuLiches.Add(khachDuLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachDuLich);
        }

        // GET: KhachDuLiches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachDuLich khachDuLich = db.KhachDuLiches.Find(id);
            if (khachDuLich == null)
            {
                return HttpNotFound();
            }
            return View(khachDuLich);
        }

        // POST: KhachDuLiches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaKhach,HoTen,CMND,DiaChi,GioiTinh,SDT")] KhachDuLich khachDuLich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachDuLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachDuLich);
        }

        // GET: KhachDuLiches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachDuLich khachDuLich = db.KhachDuLiches.Find(id);
            if (khachDuLich == null)
            {
                return HttpNotFound();
            }
            return View(khachDuLich);
        }

        // POST: KhachDuLiches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachDuLich khachDuLich = db.KhachDuLiches.Find(id);
            db.KhachDuLiches.Remove(khachDuLich);
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

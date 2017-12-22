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
    public class NhanVienDoansController : Controller
    {
        private TourDBEntities db = new TourDBEntities();

        // GET: NhanVienDoans
        public ActionResult Index()
        {
            var nhanVienDoans = db.NhanVienDoans.Include(n => n.DoanDuLich).Include(n => n.NhanVien).Include(n => n.NhiemVu);
            return View(nhanVienDoans.ToList());
        }

        // GET: NhanVienDoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienDoan nhanVienDoan = db.NhanVienDoans.Find(id);
            if (nhanVienDoan == null)
            {
                return HttpNotFound();
            }
            return View(nhanVienDoan);
        }

        // GET: NhanVienDoans/Create
        public ActionResult Create()
        {
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan");
            ViewBag.NhanVienID = new SelectList(db.NhanViens, "ID", "MaNhanVien");
            ViewBag.NhiemVuID = new SelectList(db.NhiemVus, "ID", "TenNhiemVu");
            return View();
        }

        // POST: NhanVienDoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DoanID,NhanVienID,NhiemVuID")] NhanVienDoan nhanVienDoan)
        {
            if (ModelState.IsValid)
            {
                db.NhanVienDoans.Add(nhanVienDoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", nhanVienDoan.DoanID);
            ViewBag.NhanVienID = new SelectList(db.NhanViens, "ID", "MaNhanVien", nhanVienDoan.NhanVienID);
            ViewBag.NhiemVuID = new SelectList(db.NhiemVus, "ID", "TenNhiemVu", nhanVienDoan.NhiemVuID);
            return View(nhanVienDoan);
        }

        // GET: NhanVienDoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienDoan nhanVienDoan = db.NhanVienDoans.Find(id);
            if (nhanVienDoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", nhanVienDoan.DoanID);
            ViewBag.NhanVienID = new SelectList(db.NhanViens, "ID", "MaNhanVien", nhanVienDoan.NhanVienID);
            ViewBag.NhiemVuID = new SelectList(db.NhiemVus, "ID", "TenNhiemVu", nhanVienDoan.NhiemVuID);
            return View(nhanVienDoan);
        }

        // POST: NhanVienDoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DoanID,NhanVienID,NhiemVuID")] NhanVienDoan nhanVienDoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVienDoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", nhanVienDoan.DoanID);
            ViewBag.NhanVienID = new SelectList(db.NhanViens, "ID", "MaNhanVien", nhanVienDoan.NhanVienID);
            ViewBag.NhiemVuID = new SelectList(db.NhiemVus, "ID", "TenNhiemVu", nhanVienDoan.NhiemVuID);
            return View(nhanVienDoan);
        }

        // GET: NhanVienDoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienDoan nhanVienDoan = db.NhanVienDoans.Find(id);
            if (nhanVienDoan == null)
            {
                return HttpNotFound();
            }
            return View(nhanVienDoan);
        }

        // POST: NhanVienDoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVienDoan nhanVienDoan = db.NhanVienDoans.Find(id);
            db.NhanVienDoans.Remove(nhanVienDoan);
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

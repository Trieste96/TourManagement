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
    public class ThanhVienDoansController : Controller
    {
        private TourDBEntities db = new TourDBEntities();

        // GET: ThanhVienDoans
        public ActionResult Index()
        {
            var thanhVienDoans = db.ThanhVienDoans.Include(t => t.DoanDuLich).Include(t => t.KhachDuLich);
            return View(thanhVienDoans.ToList());
        }

        // GET: ThanhVienDoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVienDoan thanhVienDoan = db.ThanhVienDoans.Find(id);
            if (thanhVienDoan == null)
            {
                return HttpNotFound();
            }
            return View(thanhVienDoan);
        }

        // GET: ThanhVienDoans/Create
        public ActionResult Create()
        {
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan");
            ViewBag.KhachID = new SelectList(db.KhachDuLiches, "ID", "MaKhach");
            return View();
        }

        // POST: ThanhVienDoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TyLeTraLai,DoanID,KhachID")] ThanhVienDoan thanhVienDoan)
        {
            if (ModelState.IsValid)
            {
                db.ThanhVienDoans.Add(thanhVienDoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", thanhVienDoan.DoanID);
            ViewBag.KhachID = new SelectList(db.KhachDuLiches, "ID", "MaKhach", thanhVienDoan.KhachID);
            return View(thanhVienDoan);
        }

        // GET: ThanhVienDoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVienDoan thanhVienDoan = db.ThanhVienDoans.Find(id);
            if (thanhVienDoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", thanhVienDoan.DoanID);
            ViewBag.KhachID = new SelectList(db.KhachDuLiches, "ID", "MaKhach", thanhVienDoan.KhachID);
            return View(thanhVienDoan);
        }

        // POST: ThanhVienDoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TyLeTraLai,DoanID,KhachID")] ThanhVienDoan thanhVienDoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVienDoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", thanhVienDoan.DoanID);
            ViewBag.KhachID = new SelectList(db.KhachDuLiches, "ID", "MaKhach", thanhVienDoan.KhachID);
            return View(thanhVienDoan);
        }

        // GET: ThanhVienDoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVienDoan thanhVienDoan = db.ThanhVienDoans.Find(id);
            if (thanhVienDoan == null)
            {
                return HttpNotFound();
            }
            return View(thanhVienDoan);
        }

        // POST: ThanhVienDoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhVienDoan thanhVienDoan = db.ThanhVienDoans.Find(id);
            db.ThanhVienDoans.Remove(thanhVienDoan);
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

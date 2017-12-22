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
    public class ChiPhiDoansController : Controller
    {
        private TourDBEntities db = new TourDBEntities();

        // GET: ChiPhiDoans
        public ActionResult Index()
        {
            var chiPhiDoans = db.ChiPhiDoans.Include(c => c.DoanDuLich).Include(c => c.LoaiChiPhi);
            return View(chiPhiDoans.ToList());
        }

        // GET: ChiPhiDoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiDoan chiPhiDoan = db.ChiPhiDoans.Find(id);
            if (chiPhiDoan == null)
            {
                return HttpNotFound();
            }
            return View(chiPhiDoan);
        }

        // GET: ChiPhiDoans/Create
        public ActionResult Create()
        {
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan");
            ViewBag.LoaiCP = new SelectList(db.LoaiChiPhis, "ID", "TenLoaiCP");
            return View();
        }

        // POST: ChiPhiDoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenChiPhi,ChiPhiThucTe,SoLuong,Tong,GhiChu,DoanID,LoaiCP")] ChiPhiDoan chiPhiDoan)
        {
            if (ModelState.IsValid)
            {
                chiPhiDoan.Tong = chiPhiDoan.ChiPhiThucTe * chiPhiDoan.SoLuong;
                db.ChiPhiDoans.Add(chiPhiDoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", chiPhiDoan.DoanID);
            ViewBag.LoaiCP = new SelectList(db.LoaiChiPhis, "ID", "TenLoaiCP", chiPhiDoan.LoaiCP);
            return View(chiPhiDoan);
        }

        // GET: ChiPhiDoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiDoan chiPhiDoan = db.ChiPhiDoans.Find(id);
            if (chiPhiDoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", chiPhiDoan.DoanID);
            ViewBag.LoaiCP = new SelectList(db.LoaiChiPhis, "ID", "TenLoaiCP", chiPhiDoan.LoaiCP);
            return View(chiPhiDoan);
        }

        // POST: ChiPhiDoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenChiPhi,ChiPhiThucTe,SoLuong,Tong,GhiChu,DoanID,LoaiCP")] ChiPhiDoan chiPhiDoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiPhiDoan).State = EntityState.Modified;
                chiPhiDoan.Tong = chiPhiDoan.ChiPhiThucTe * chiPhiDoan.SoLuong;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoanID = new SelectList(db.DoanDuLiches, "ID", "TenDoan", chiPhiDoan.DoanID);
            ViewBag.LoaiCP = new SelectList(db.LoaiChiPhis, "ID", "TenLoaiCP", chiPhiDoan.LoaiCP);
            return View(chiPhiDoan);
        }

        // GET: ChiPhiDoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiDoan chiPhiDoan = db.ChiPhiDoans.Find(id);
            if (chiPhiDoan == null)
            {
                return HttpNotFound();
            }
            return View(chiPhiDoan);
        }

        // POST: ChiPhiDoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiPhiDoan chiPhiDoan = db.ChiPhiDoans.Find(id);
            db.ChiPhiDoans.Remove(chiPhiDoan);
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

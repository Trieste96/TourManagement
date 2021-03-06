﻿using System;
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
    public class DoanDuLichesController : Controller
    {
        private TourDBEntities db = new TourDBEntities();

        // GET: DoanDuLiches
        public ActionResult Index()
        {
            var doanDuLich = db.DoanDuLich.Include(d => d.TinhTrangDoan).Include(d => d.Tour);
            return View(doanDuLich.ToList());
        }

        // GET: DoanDuLiches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanDuLich doanDuLich = db.DoanDuLich.Find(id);
            if (doanDuLich == null)
            {
                return HttpNotFound();
            }
            return View(doanDuLich);
        }

        // GET: DoanDuLiches/Create
        public ActionResult Create()
        {
            ViewBag.TinhTrangID = new SelectList(db.TinhTrangDoan, "ID", "TenTinhTrang");
            ViewBag.TourID = new SelectList(db.Tour, "ID", "MaTour");
            return View();
        }

        // POST: DoanDuLiches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDoan,NgayKhoiHanh,NgayKetThuc,ChiTietND,GiaTour,MaDoan,TinhTrangID,TourID")] DoanDuLich doanDuLich)
        {
            if (ModelState.IsValid)
            {
                db.DoanDuLich.Add(doanDuLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TinhTrangID = new SelectList(db.TinhTrangDoan, "ID", "TenTinhTrang", doanDuLich.TinhTrangID);
            ViewBag.TourID = new SelectList(db.Tour, "ID", "MaTour", doanDuLich.TourID);
            return View(doanDuLich);
        }

        // GET: DoanDuLiches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanDuLich doanDuLich = db.DoanDuLich.Find(id);
            if (doanDuLich == null)
            {
                return HttpNotFound();
            }
            ViewBag.TinhTrangID = new SelectList(db.TinhTrangDoan, "ID", "TenTinhTrang", doanDuLich.TinhTrangID);
            ViewBag.TourID = new SelectList(db.Tour, "ID", "MaTour", doanDuLich.TourID);
            return View(doanDuLich);
        }

        // POST: DoanDuLiches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDoan,NgayKhoiHanh,NgayKetThuc,ChiTietND,GiaTour,MaDoan,TinhTrangID,TourID")] DoanDuLich doanDuLich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanDuLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TinhTrangID = new SelectList(db.TinhTrangDoan, "ID", "TenTinhTrang", doanDuLich.TinhTrangID);
            ViewBag.TourID = new SelectList(db.Tour, "ID", "MaTour", doanDuLich.TourID);
            return View(doanDuLich);
        }

        // GET: DoanDuLiches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanDuLich doanDuLich = db.DoanDuLich.Find(id);
            if (doanDuLich == null)
            {
                return HttpNotFound();
            }
            return View(doanDuLich);
        }

        // POST: DoanDuLiches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoanDuLich doanDuLich = db.DoanDuLich.Find(id);
            db.DoanDuLich.Remove(doanDuLich);
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

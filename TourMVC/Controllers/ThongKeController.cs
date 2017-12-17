using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourModel;
using System.Data.Entity;

namespace TourMVC.Controllers
{
    public class ThongKeController : Controller
    {
        TourDBEntities db = new TourDBEntities();
        // GET: ThongKe
        public ActionResult Index()
        {

            return View();
        }

        // GET: ThongKe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThongKe/Create
        public ActionResult SoDoan()
        {
            ViewBag.Title = "Thống kê số đoàn";
            return View();
        }

        // POST: ThongKe/Create
        [HttpPost]
        public ActionResult SoDoan(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            // TODO: Add insert logic here
            ViewBag.TuNgay = TuNgayGio.ToString("dd-MM-yyyy");
            ViewBag.DenNgay = DenNgayGio.ToString("dd-MM-yyyy");
            ViewBag.LoaiCP = db.LoaiChiPhis.ToList();
            return View();
        }

        // GET: ThongKe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThongKe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThongKe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThongKe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

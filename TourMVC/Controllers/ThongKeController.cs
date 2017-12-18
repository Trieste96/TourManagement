using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourCommon.Model;
using TourCommon.DAL;

namespace TourMVC.Controllers
{
    public class ThongKeController : Controller
    {
        TourDBEntities db = new TourDBEntities();
        TourCommon.BUS.ThongKe bus = new TourCommon.BUS.ThongKe();
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
            List<SoDoanTour> list = bus.xemSoDoan(TuNgayGio, DenNgayGio);
            return View(list);
        }
    }
}

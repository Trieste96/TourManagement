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
        public ActionResult DoanhThu()
        {
            return View();
        }

        // POST: ThongKe/Create
        [HttpPost]
        public ActionResult DoanhThu(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            // TODO: Add insert logic here
            ViewBag.TuNgay = TuNgayGio.ToString("dd-MM-yyyy");
            ViewBag.DenNgay = DenNgayGio.ToString("dd-MM-yyyy");
            List<DoanhThuTour> list = bus.xemDoanhThu(TuNgayGio, DenNgayGio);
            return View(list);
        }

        public ActionResult ChiPhiTheoTour()
        {
            return View();
        }

        // POST: ThongKe/Create
        [HttpPost]
        public ActionResult ChiPhiTheoTour(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            // TODO: Add insert logic here
            ViewBag.TuNgay = TuNgayGio.ToString("MM/dd/yyyy");
            ViewBag.DenNgay = DenNgayGio.ToString("MM/dd/yyyy");
            List<ChiPhiTour> list = bus.xemChiPhiTheoTour(TuNgayGio, DenNgayGio);
            return View(list);
        }
        public ActionResult ChiPhiTheoDoan()
        {
            return View();
        }

        // POST: ThongKe/Create
        [HttpGet]
        public ActionResult ChiPhiTheoDoan(string MaTour, DateTime tuNgay, DateTime denNgay)
        {
            // TODO: Add insert logic here
            ViewBag.MaTour = MaTour;
            ViewBag.TuNgay = tuNgay.ToString("MM/dd/yyyy");
            ViewBag.DenNgay = denNgay.ToString("MM/dd/yyyy");
            List<TongChiPhiDoan> list = bus.xemChiPhiTheoDoan(MaTour, tuNgay, denNgay);
            return View(list);
        }
    }
}

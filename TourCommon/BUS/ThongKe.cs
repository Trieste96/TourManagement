using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;
using TourCommon.DAL;

namespace TourCommon.BUS
{
    public class ThongKe
    {
        TourDBEntities db = new TourDBEntities();
        public List<SoDoanTour> xemSoDoan(DateTime tuNgay, DateTime denNgay)
        {
            List<SoDoanTour> list = new List<SoDoanTour>();
            foreach (Tour tour in db.Tours)
            {
                SoDoanTour row = new SoDoanTour();
                row.tour = tour;
                row.SoDoan = tour.DoanDuLiches.Where(d => d.NgayKhoiHanh >= tuNgay && d.NgayKhoiHanh <= denNgay).Count();
                list.Add(row);
            }
            return list;
        }
        public List<DoanhThuTour> xemDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuTour> list = new List<DoanhThuTour>();
            foreach (Tour tour in db.Tours)
            {
                DoanhThuTour row = new DoanhThuTour();
                row.tour = tour;
                row.DoanhThu = tour.DoanDuLiches.Where(d => d.NgayKhoiHanh >= tuNgay && d.NgayKhoiHanh <= denNgay).Sum(d => d.GiaTour);
                list.Add(row);
            }
            return list;
        }

        public List<ChiPhiTour> xemChiPhiTheoTour(DateTime tuNgay, DateTime denNgay)
        {
            List<ChiPhiTour> list = new List<ChiPhiTour>();
            foreach (Tour tour in db.Tours)
            {
                ChiPhiTour row = new ChiPhiTour();
                row.Tour = tour;
                row.ChiPhiUocTinh = tour.DoanDuLiches.Where(d => d.NgayKhoiHanh >= tuNgay && d.NgayKhoiHanh <= denNgay).Sum(d => d.ChiPhiDoans.Sum(cp => cp.ChiPhiThucTe));
                list.Add(row);
            }
            return list;
        }

        public List<TongChiPhiDoan> xemChiPhiTheoDoan(string MaTour, DateTime tuNgay, DateTime denNgay)
        {
            List<TongChiPhiDoan> list = new List<TongChiPhiDoan>();
            List<DoanDuLich> doans = db.Tours.Where(t => t.MaTour == MaTour).First().DoanDuLiches.Where(d => d.NgayKhoiHanh >= tuNgay && d.NgayKhoiHanh <= denNgay).ToList<DoanDuLich>();
            foreach (DoanDuLich doan in doans)
            {
                TongChiPhiDoan row = new TongChiPhiDoan();
                row.doan = doan;
                row.TongChiPhi = doan.ChiPhiDoans.Sum(cpd => cpd.ChiPhiThucTe);
                list.Add(row);
            }
            return list;
        }
    }
}

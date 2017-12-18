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
                row.TenTour = tour.TenTour;
                row.SoDoan = tour.DoanDuLiches.Where(d => d.NgayKhoiHanh >= tuNgay & d.NgayKhoiHanh <= denNgay).Count();
                list.Add(row);
            }
            return list;
        }
    }
}

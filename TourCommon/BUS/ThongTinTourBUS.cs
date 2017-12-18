using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class ThongTinTourBUS
    {
        public Tour SetValues(int ID, string MaTour, string TenTour, string DacDiem, int Gia, int LoaiHinhID) //Setvalues method for binding field values to StudentInformation Model class
        {
            Tour tour = new Tour();
            tour.ID = ID;
            tour.MaTour = MaTour;
            tour.TenTour = TenTour;
            tour.DacDiem = DacDiem;
            tour.Gia = Gia;
            tour.LoaiHinhID = LoaiHinhID;
            return tour;
        }
        public bool SaveTour(Tour tour) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.Tours.Add(tour);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateTour(Tour tour) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tour _tour = _entity.Tours.Where(x => x.ID == tour.ID).Select(x => x).FirstOrDefault();
                _tour.MaTour = tour.MaTour;
                _tour.TenTour = tour.TenTour;
                _tour.DacDiem = tour.DacDiem;
                _tour.Gia = tour.Gia;
                _tour.LoaiHinhID = tour.LoaiHinhID;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteTour(Tour tour) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tour _tour = _entity.Tours.Where(x => x.ID == tour.ID).Select(x => x).FirstOrDefault();
                _entity.Tours.Remove(_tour);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}

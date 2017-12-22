﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class ChiTietThamQuanBUS
    {
        public bool SaveChiTietThamQuan(DiaDiemTour diaDiemTour) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.DiaDiemTours.Add(diaDiemTour);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateChiTietThamQuan(DiaDiemTour diaDiemTour) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiemTour _diaDiemTour = _entity.DiaDiemTours.Where(x => x.TourID == diaDiemTour.TourID).Select(x => x).FirstOrDefault();
                _diaDiemTour.Ngay = diaDiemTour.Ngay;
                _diaDiemTour.TourID = diaDiemTour.TourID;
                _diaDiemTour.DiaDiemID = diaDiemTour.DiaDiemID;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteChiTietThamQuan(DiaDiemTour diaDiemTour) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiemTour _diaDiemTour = _entity.DiaDiemTours.Where(x => x.TourID == diaDiemTour.TourID).Select(x => x).FirstOrDefault();
                _entity.DiaDiemTours.Remove(_diaDiemTour);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public DiaDiemTour SetValues(DateTime Ngay, int TourID, int DiaDiemID) //Setvalues method for binding field values to StudentInformation Model class
        {
            DiaDiemTour ddt = new DiaDiemTour();
            ddt.Ngay = Ngay;
            ddt.TourID = TourID;
            ddt.DiaDiemID = DiaDiemID;
            return ddt;
        }
    }
}

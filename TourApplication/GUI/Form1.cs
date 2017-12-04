using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TourApplication.DAL;
using TourApplication.GUI;
using TourModel;
using System.Data.Entity;

namespace TourApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayTinh();
            DisplayNhanVien();
            DisplayDiaDiemThamQuan();
            LoadCbTinhID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ThongTinTour tt = new ThongTinTour();
            tt.Show();*/
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        
        #region Tinh
        private void btnThemTinh_Click(object sender, EventArgs e)
        {
            Tinh tinh = new Tinh();
            tinh.TenTinh = txtTenTinh.Text;
            bool result = SaveTinh(tinh);
            ClearTinh();
            DisplayTinh();

        }
        public void DisplayTinh()   // Display Method is a common method to bind the Student details in datagridview after save,update and delete operation perform.
        {
            using (TourDBEntities _entity = new TourDBEntities())
            {
                List<TinhThamQuan> _TinhThamQuanList = new List<TinhThamQuan>();
                _TinhThamQuanList = _entity.Tinhs.Select(x => new TinhThamQuan
                {
                    ID = x.ID,
                    TenTinh = x.TenTinh
                }).ToList();
                dtgvTinh.DataSource = _TinhThamQuanList;
            }
        }

        public bool SaveTinh(Tinh tinh) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.Tinhs.Add(tinh);
                _entity.SaveChanges();
                result = true;

            }
            return result;
        }

        private void dtgvTinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvTinh.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvTinh.SelectedRows) // foreach datagridview selected rows values  
                {
                    lbIDTinh.Text = row.Cells[0].Value.ToString();
                    txtTenTinh.Text = row.Cells[1].Value.ToString();
                }
            }
        }

        private void btnSuaTinh_Click(object sender, EventArgs e)
        {
            Tinh tinh = SetValues(Convert.ToInt32(lbIDTinh.Text),txtTenTinh.Text); // Binding values to StudentInformationModel  
            bool result = UpdateTinh(tinh); // calling UpdateStudentDetails Method
            ClearTinh();
            DisplayTinh();
        }
        public bool UpdateTinh(Tinh tinh) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tinh _tinh = _entity.Tinhs.Where(x => x.ID == tinh.ID).Select(x => x).FirstOrDefault();
                _tinh.TenTinh = tinh.TenTinh;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public Tinh SetValues(int ID, string TenTinh) //Setvalues method for binding field values to StudentInformation Model class
        {
            Tinh tinh = new Tinh();
            tinh.ID = ID;
            tinh.TenTinh = TenTinh;
            return tinh;
        }
        public bool DeleteTinh(Tinh tinh) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tinh _tinh = _entity.Tinhs.Where(x => x.ID == tinh.ID).Select(x => x).FirstOrDefault();
                _entity.Tinhs.Remove(_tinh);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
  
        private void btnXoaTinh_Click(object sender, EventArgs e)
        {
            Tinh tinh = SetValues(Convert.ToInt32(lbIDTinh.Text), txtTenTinh.Text); // Binding values to StudentInformationModel  
            bool result = DeleteTinh(tinh); //Calling DeleteStudentDetails Method
            ClearTinh();
            DisplayTinh();
        }
        public void ClearTinh() // Clear the fields after Insert or Update or Delete operation  
        {
            lbIDTinh.Text = "";
            txtTenTinh.Text = "";
        }
        #endregion
        #region NhanVien
        public void DisplayNhanVien()   // Display Method is a common method to bind the Student details in datagridview after save,update and delete operation perform.
        {
            using (TourDBEntities _entity = new TourDBEntities())
            {
                List<NhanVienLamViec> _NhanVienList = new List<NhanVienLamViec>();
                _NhanVienList = _entity.NhanViens.Select(x => new NhanVienLamViec
                {
                    ID = x.ID,
                    MaNhanVien = x.MaNhanVien,
                    HoTen= x.HoTen
                }).ToList();
                dtgvNhanVien.DataSource = _NhanVienList;
            }
        }
        public void ClearNhanVien() // Clear the fields after Insert or Update or Delete operation  
        {
            lbIDNv.Text = "";
            txtMaNv.Text = "";
            txtHoTenNv.Text = "";
        }
        public bool SaveNhanVien(NhanVien nv) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.NhanViens.Add(nv);
                _entity.SaveChanges();
                result = true;

            }
            return result;
        }
        public bool UpdateNhanVien(NhanVien nv) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                NhanVien _nhanvien = _entity.NhanViens.Where(x => x.ID == nv.ID).Select(x => x).FirstOrDefault();
                _nhanvien.MaNhanVien = nv.MaNhanVien;
                _nhanvien.HoTen = nv.HoTen;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public NhanVien SetValues(int ID,string MaNhanVien,string HoTen) //Setvalues method for binding field values to StudentInformation Model class
        {
            NhanVien nv = new NhanVien();
            nv.ID = ID;
            nv.MaNhanVien = MaNhanVien;
            nv.HoTen = HoTen;
            return nv;
        }
        public bool DeleteNhanVien(NhanVien nv) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                NhanVien _nhanvien = _entity.NhanViens.Where(x => x.ID == nv.ID).Select(x => x).FirstOrDefault();
                //if (_nhanvien != null)
                //{
                _entity.NhanViens.Remove(_nhanvien);
                    _entity.SaveChanges();
                    result = true;
                //}            
            }
            return result;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNv.Text;
            nv.HoTen = txtHoTenNv.Text;
            bool result = SaveNhanVien(nv);
            ClearNhanVien();
            DisplayNhanVien();
        }

        private void dtgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvNhanVien.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvNhanVien.SelectedRows) // foreach datagridview selected rows values  
                {
                    lbIDNv.Text = row.Cells[0].Value.ToString();
                    txtMaNv.Text = row.Cells[1].Value.ToString();
                    txtHoTenNv.Text = row.Cells[2].Value.ToString();
                }
            }
        }

        private void btnSuaNv_Click(object sender, EventArgs e)
        {
            NhanVien nv = SetValues(Convert.ToInt32(lbIDNv.Text),txtMaNv.Text,txtHoTenNv.Text); // Binding values to StudentInformationModel  
            bool result = UpdateNhanVien(nv); // calling UpdateStudentDetails Method
            ClearNhanVien();
            DisplayNhanVien();
        }

        private void btnXoaNv_Click(object sender, EventArgs e)
        {
            NhanVien nv = SetValues(Convert.ToInt32(lbIDNv.Text), txtMaNv.Text, txtHoTenNv.Text); // Binding values to StudentInformationModel  
            bool result = DeleteNhanVien(nv); //Calling DeleteStudentDetails Method
            ClearNhanVien();
            DisplayNhanVien();
        }
        #endregion
        #region DiaDiem
        public void LoadCbTinhID()
        {
            TourDBEntities db = new TourDBEntities();
            this.cbTinhID.DisplayMember = "ID";
            this.cbTinhID.ValueMember = "ID";
            this.cbTinhID.DataSource = db.Tinhs.ToList();
        }
        public void DisplayDiaDiemThamQuan()
        {
            using (TourDBEntities _entity = new TourDBEntities())
            {
                List<DiaDiemThamQuan> _DiaDiemThamQuanList = new List<DiaDiemThamQuan>();
                _DiaDiemThamQuanList = _entity.DiaDiems.Select(x => new DiaDiemThamQuan
                {
                    ID = x.ID,
                    TenDiaDiem = x.TenDiaDiem,
                    TinhID = x.TinhID
                }).ToList();
                dtgvDd.DataSource = _DiaDiemThamQuanList;
            }
        }
        public DiaDiem SetValues(int ID, string TenDiaDiem, int TinhID) //Setvalues method for binding field values to StudentInformation Model class
        {
            DiaDiem dd = new DiaDiem();
            dd.ID = ID;
            dd.TenDiaDiem = TenDiaDiem;
            dd.TinhID = TinhID;
            return dd;
        }
        public bool SaveDiaDiemThamQuan(DiaDiem dd) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.DiaDiems.Add(dd);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateDiaDiemThamQuan(DiaDiem dd) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _diadiem.TenDiaDiem = dd.TenDiaDiem;
                _diadiem.TinhID = dd.TinhID;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteDiaDiemThamQuan(DiaDiem dd) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _entity.DiaDiems.Remove(_diadiem);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }

        private void btnThemDd_Click(object sender, EventArgs e)
        {
            DiaDiem dd = new DiaDiem();
            dd.TenDiaDiem = txtTenDd.Text;
            dd.TinhID = Convert.ToInt32(cbTinhID.SelectedValue);
            bool result = SaveDiaDiemThamQuan(dd);
            DisplayDiaDiemThamQuan();
        }

        private void cbTinhID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSuaDd_Click(object sender, EventArgs e)
        {
            DiaDiem dd = SetValues(Convert.ToInt32(lbIDDd.Text), txtTenDd.Text, Convert.ToInt32(cbTinhID.SelectedValue));
            bool result = UpdateDiaDiemThamQuan(dd);
            ClearDiaDiemThamQuan();
            DisplayDiaDiemThamQuan();
        }

        private void dtgvDd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDd.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvDd.SelectedRows) // foreach datagridview selected rows values  
                {
                    lbIDDd.Text = row.Cells[0].Value.ToString();
                    txtTenDd.Text = row.Cells[1].Value.ToString();
                    cbTinhID.Text = row.Cells[2].Value.ToString();
                }
            }
        }
        public void ClearDiaDiemThamQuan() // Clear the fields after Insert or Update or Delete operation  
        {
            lbIDDd.Text = "";
            txtTenDd.Text = "";
            cbTinhID.Text = "";
        }

        private void btnXoaDd_Click(object sender, EventArgs e)
        {
            DiaDiem dd = SetValues(Convert.ToInt32(lbIDDd.Text), txtTenDd.Text, Convert.ToInt32(cbTinhID.SelectedValue));
            bool result = DeleteDiaDiemThamQuan(dd);
            ClearDiaDiemThamQuan();
            DisplayDiaDiemThamQuan();
        }
        #endregion
        public void LoadCbLoaiHinhID()
        {
            TourDBEntities db = new TourDBEntities();
            this.cbLoaiHinhID.DisplayMember = "ID";
            this.cbLoaiHinhID.ValueMember = "ID";
            this.cbLoaiHinhID.DataSource = db.LoaiHinhs.ToList();
        }
        public void DisplayTour()
        {
            using (TourDBEntities _entity = new TourDBEntities())
            {
                List<ThongTinTour> _TourList = new List<ThongTinTour>();
                _TourList = _entity.Tours.Select(x => new ThongTinTour
                {
                    ID = x.ID,
                    MaTour = x.MaTour,
                    TenTour = x.TenTour,
                    DacDiem = x.DacDiem,
                    Gia = x.Gia,
                    LoaiHinhID = x.LoaiHinhID,
                }).ToList();
                dtgvThongTinTour.DataSource = _TourList;
            }
        }
        public Tour SetValues(int ID, string MaTour, string TenTour, string DacDiem, int Gia, int LoaiHinhID) //Setvalues method for binding field values to StudentInformation Model class
        {
            Tour tour = new Tour();
            dd.ID = ID;
            dd.TenDiaDiem = TenDiaDiem;
            dd.TinhID = TinhID;
            return dd;
        }
        public bool SaveTour(DiaDiem dd) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.DiaDiems.Add(dd);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateTour(DiaDiem dd) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _diadiem.TenDiaDiem = dd.TenDiaDiem;
                _diadiem.TinhID = dd.TinhID;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteTour(DiaDiem dd) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _entity.DiaDiems.Remove(_diadiem);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }

    }
}

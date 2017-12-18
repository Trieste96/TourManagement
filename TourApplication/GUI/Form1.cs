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
using TourCommon.DAL;
using TourApplication.GUI;
using TourCommon.Model;
using TourCommon.BUS;

namespace TourApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayTinh();
            //DisplayNhanVien();
            DisplayDiaDiemThamQuan();
            DisplayTour();
            LoadCbLoaiHinhID();
            LoadCbTinhID();
            LoadCbDiaDiemID();
            LoadCbTourID();
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
   
        #region Tinh
        private void btnThemTinh_Click(object sender, EventArgs e)
        {
            Tinh tinh = new Tinh();
            TinhThamQuanBUS tinhBUS = new TinhThamQuanBUS();
            tinh.TenTinh = txtTenTinh.Text;
            bool result = tinhBUS.SaveTinh(tinh);
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
            TinhThamQuanBUS tinhBUS = new TinhThamQuanBUS();
            Tinh tinh = tinhBUS.SetValues(Convert.ToInt32(lbIDTinh.Text),txtTenTinh.Text); // Binding values to StudentInformationModel  
            bool result = tinhBUS.UpdateTinh(tinh); // calling UpdateStudentDetails Method
            ClearTinh();
            DisplayTinh();
        }
       
        private void btnXoaTinh_Click(object sender, EventArgs e)
        {
            TinhThamQuanBUS tinhBUS = new TinhThamQuanBUS();
            Tinh tinh = tinhBUS.SetValues(Convert.ToInt32(lbIDTinh.Text), txtTenTinh.Text); // Binding values to StudentInformationModel  
            bool result = tinhBUS.DeleteTinh(tinh); //Calling DeleteStudentDetails Method
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
        /*public void DisplayNhanVien()   // Display Method is a common method to bind the Student details in datagridview after save,update and delete operation perform.
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
        }*/

        /*private void btnSuaNv_Click(object sender, EventArgs e)
        {
            NhanVien nv = SetValues(Convert.ToInt32(lbIDNv.Text),txtMaNv.Text,txtHoTenNv.Text); // Binding values to StudentInformationModel  
            bool result = UpdateNhanVien(nv); // calling UpdateStudentDetails Method
            ClearNhanVien();
            DisplayNhanVien();
        }*/

        /*private void btnXoaNv_Click(object sender, EventArgs e)
        {
            NhanVien nv = SetValues(Convert.ToInt32(lbIDNv.Text), txtMaNv.Text, txtHoTenNv.Text); // Binding values to StudentInformationModel  
            bool result = DeleteNhanVien(nv); //Calling DeleteStudentDetails Method
            ClearNhanVien();
            DisplayNhanVien();
        }*/
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
        private void btnThemDd_Click(object sender, EventArgs e)
        {
            DiaDiemThamQuanBUS diaDiemThamQuanBUS = new DiaDiemThamQuanBUS();
            DiaDiem dd = new DiaDiem();
            dd.TenDiaDiem = txtTenDd.Text;
            dd.TinhID = Convert.ToInt32(cbTinhID.SelectedValue);
            bool result = diaDiemThamQuanBUS.SaveDiaDiemThamQuan(dd);
            DisplayDiaDiemThamQuan();
        }

        private void cbTinhID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSuaDd_Click(object sender, EventArgs e)
        {
            DiaDiemThamQuanBUS diaDiemThamQuanBUS = new DiaDiemThamQuanBUS();
            DiaDiem dd = diaDiemThamQuanBUS.SetValues(Convert.ToInt32(lbIDDd.Text), txtTenDd.Text, Convert.ToInt32(cbTinhID.SelectedValue));
            bool result = diaDiemThamQuanBUS.UpdateDiaDiemThamQuan(dd);
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
            DiaDiemThamQuanBUS diaDiemThamQuanBUS = new DiaDiemThamQuanBUS();
            DiaDiem dd = diaDiemThamQuanBUS.SetValues(Convert.ToInt32(lbIDDd.Text), txtTenDd.Text, Convert.ToInt32(cbTinhID.SelectedValue));
            bool result = diaDiemThamQuanBUS.DeleteDiaDiemThamQuan(dd);
            ClearDiaDiemThamQuan();
            DisplayDiaDiemThamQuan();
        }
        #endregion
        #region ThongTinTour
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

        public void ClearTour() // Clear the fields after Insert or Update or Delete operation  
        {
            lbIDTour.Text = "";
            txtMaTour.Text = "";
            txtTenTour.Text = "";
            txtDacDiem.Text = "";
            txtGia.Text = "";
            cbLoaiHinhID.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThongTinTourBUS thongTinTourBUS = new ThongTinTourBUS();
            Tour tour = thongTinTourBUS.SetValues(Convert.ToInt32(lbIDTour.Text), txtMaTour.Text, txtTenTour.Text, txtDacDiem.Text, Convert.ToInt32(txtGia.Text), Convert.ToInt32(cbLoaiHinhID.SelectedValue));
            bool result = thongTinTourBUS.UpdateTour(tour);
            ClearTour();
            DisplayTour();
        }

        private void btnXoaTour_Click(object sender, EventArgs e)
        {
            ThongTinTourBUS thongTinTourBUS = new ThongTinTourBUS();
            Tour tour = thongTinTourBUS.SetValues(Convert.ToInt32(lbIDTour.Text), txtMaTour.Text, txtTenTour.Text, txtDacDiem.Text, Convert.ToInt32(txtGia.Text), Convert.ToInt32(cbLoaiHinhID.SelectedValue));
            bool result = thongTinTourBUS.DeleteTour(tour);
            ClearTour();
            DisplayTour();
        }

        private void dtgvThongTinTour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvThongTinTour.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvThongTinTour.SelectedRows) // foreach datagridview selected rows values  
                {
                    lbIDTour.Text = row.Cells[0].Value.ToString();
                    txtMaTour.Text = row.Cells[1].Value.ToString();
                    txtTenTour.Text = row.Cells[2].Value.ToString();
                    txtDacDiem.Text = row.Cells[3].Value.ToString();
                    txtGia.Text = row.Cells[4].Value.ToString();
                    cbLoaiHinhID.Text = row.Cells[5].Value.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThongTinTourBUS thongTinTourBUS = new ThongTinTourBUS();
            Tour tour = new Tour();
            tour.MaTour = txtMaTour.Text;
            tour.TenTour = txtTenTour.Text;
            tour.DacDiem = txtDacDiem.Text;
            tour.Gia = Convert.ToInt32(txtGia.Text);
            tour.LoaiHinhID = Convert.ToInt32(cbLoaiHinhID.SelectedValue);
            bool result = thongTinTourBUS.SaveTour(tour);
            DisplayTour();
        }
        #endregion
        #region ChiTietTour
        private void btnThemCtTour_Click(object sender, EventArgs e)
        {
            ChiTietThamQuanBUS chiTietThamQuanBUS = new ChiTietThamQuanBUS();
            DiaDiemTour diaDiemTour = new DiaDiemTour();
            diaDiemTour.Ngay = dtpNgay.Value;
            diaDiemTour.TourID = Convert.ToInt32(cbTourID.SelectedValue);
            diaDiemTour.DiaDiemID = Convert.ToInt32(cbDiaDiemID.SelectedValue);
            bool result = chiTietThamQuanBUS.SaveChiTietTour(diaDiemTour);
        }

        public void LoadCbTourID()
        {
            TourDBEntities db = new TourDBEntities();
            this.cbTourID.DisplayMember = "ID";
            this.cbTourID.ValueMember = "ID";
            this.cbTourID.DataSource = db.Tours.ToList();
        }

        public void LoadCbDiaDiemID()
        {
            TourDBEntities db = new TourDBEntities();
            this.cbDiaDiemID.DisplayMember = "ID";
            this.cbDiaDiemID.ValueMember = "ID";
            this.cbDiaDiemID.DataSource = db.DiaDiems.ToList();
        }
        #endregion
    }
}

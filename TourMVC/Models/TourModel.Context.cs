﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TourDBEntities : DbContext
    {
        public TourDBEntities()
            : base("name=TourDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiPhiDoan> ChiPhiDoan { get; set; }
        public virtual DbSet<ChiPhiTour> ChiPhiTour { get; set; }
        public virtual DbSet<DiaDiem> DiaDiem { get; set; }
        public virtual DbSet<DoanDuLich> DoanDuLich { get; set; }
        public virtual DbSet<KhachDuLich> KhachDuLich { get; set; }
        public virtual DbSet<LoaiChiPhi> LoaiChiPhi { get; set; }
        public virtual DbSet<LoaiHinh> LoaiHinh { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhanVienDoan> NhanVienDoan { get; set; }
        public virtual DbSet<NhiemVu> NhiemVu { get; set; }
        public virtual DbSet<ThanhVienDoan> ThanhVienDoan { get; set; }
        public virtual DbSet<Tinh> Tinh { get; set; }
        public virtual DbSet<TinhTrangDoan> TinhTrangDoan { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<DiaDiemTour> DiaDiemTour { get; set; }
    }
}
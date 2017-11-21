
CREATE DATABASE TourDB
GO
USE TourDB

CREATE TABLE LoaiHinh
(
  ID INT NOT NULL identity(1,1),
  TenLoaiHinh NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID)
);
insert into LoaiHinh values(N'Du lịch di động')
insert into LoaiHinh values(N'Du lịch kết hợp nghề nghiệp')
insert into LoaiHinh values(N'Du lịch xã hội')
insert into LoaiHinh values(N'Du lịch gia đình')

CREATE TABLE Tinh
(
  ID INT NOT NULL identity(1,1),
  TenTinh NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID)
);

CREATE TABLE TinhTrangDoan
(
  ID INT NOT NULL identity(1,1),
  TenTinhTrang NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID)
);
insert into TinhTrangDoan values(N'Bình Thường')
insert into TinhTrangDoan values(N'Hoãn')
insert into TinhTrangDoan values(N'Huỷ')

CREATE TABLE KhachDuLich
(
  ID INT NOT NULL identity(1,1) ,
  MaKhach CHAR(10) NOT NULL,
  HoTen NVARCHAR(50) NOT NULL,
  CMND CHAR(15) NOT NULL,
  DiaChi NVARCHAR(50) NOT NULL,
  GioiTinh BIT NOT NULL,
  SDT CHAR(15) NOT NULL,
  PRIMARY KEY (ID),
  UNIQUE (MaKhach)
);

CREATE TABLE NhanVien
(
  ID INT NOT NULL identity(1,1),
  MaNhanVien CHAR(10) NOT NULL,
  HoTen NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID),
  UNIQUE (MaNhanVien)
);

CREATE TABLE LoaiChiPhi
(
  ID INT NOT NULL identity(1,1),
  TenLoaiCP NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID)
);
insert into LoaiChiPhi values(N'Khách sạn')
insert into LoaiChiPhi values(N'Ăn uống')
insert into LoaiChiPhi values(N'Đi lại')
insert into LoaiChiPhi values(N'Vé')

CREATE TABLE NhiemVu
(
  ID INT NOT NULL identity(1,1),
  TenNhiemVu NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ID)
);
insert into NhiemVu values(N'Lái xe')
insert into NhiemVu values(N'Hướng dẫn viên')
insert into NhiemVu values(N'Phục vụ')
insert into NhiemVu values(N'Thông dịch viên')
insert into NhiemVu values(N'Tiền trạm')

CREATE TABLE Tour
(
  ID INT NOT NULL identity(1,1),
  MaTour CHAR(10) NOT NULL,
  TenTour NVARCHAR(50) NOT NULL,
  DacDiem NVARCHAR(50),
  Gia INT NOT NULL,
  LoaiHinhID INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (LoaiHinhID) REFERENCES LoaiHinh(ID),
  UNIQUE (MaTour)
);

CREATE TABLE DiaDiem
(
  ID INT NOT NULL identity(1,1),
  TenDiaDiem NVARCHAR(50) NOT NULL,
  TinhID INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (TinhID) REFERENCES Tinh(ID)
);

CREATE TABLE DiaDiemTour
(
  Ngay DATE NOT NULL,
  TourID INT NOT NULL,
  DiaDiemID INT NOT NULL,
  FOREIGN KEY (TourID) REFERENCES Tour(ID),
  FOREIGN KEY (DiaDiemID) REFERENCES DiaDiem(ID)
);

CREATE TABLE DoanDuLich
(
  ID INT NOT NULL identity(1,1),
  TenDoan NVARCHAR(50) NOT NULL,
  NgayKhoiHanh DATE NOT NULL,
  NgayKetThuc DATE NOT NULL,
  ChiTietND NVARCHAR(50),
  GiaTour INT NOT NULL,
  MaDoan CHAR(10) NOT NULL,
  TinhTrangID INT NOT NULL,
  TourID INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (TinhTrangID) REFERENCES TinhTrangDoan(ID),
  FOREIGN KEY (TourID) REFERENCES Tour(ID),
  UNIQUE (MaDoan)
);

CREATE TABLE ThanhVienDoan
(
  ID INT NOT NULL identity(1,1),
  TyLeTraLai INT NOT NULL,
  DoanID INT NOT NULL,
  KhachID INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (DoanID) REFERENCES DoanDuLich(ID),
  FOREIGN KEY (KhachID) REFERENCES KhachDuLich(ID),
  UNIQUE (DoanID, KhachID)
);

CREATE TABLE NhanVienDoan
(
  ID INT NOT NULL identity(1,1),
  DoanID INT NOT NULL,
  NhanVienID INT NOT NULL,
  NhiemVuID INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (DoanID) REFERENCES DoanDuLich(ID),
  FOREIGN KEY (NhanVienID) REFERENCES NhanVien(ID),
  FOREIGN KEY (NhiemVuID) REFERENCES NhiemVu(ID)
);

CREATE TABLE ChiPhiTour
(
  ID INT NOT NULL identity(1,1),
  TenChiPhi NVARCHAR(50) NOT NULL,
  ChiPhiUocTinh INT NOT NULL,
  GhiChu NVARCHAR(50),
  TourID INT NOT NULL,
  LoaiCP INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (TourID) REFERENCES Tour(ID),
  FOREIGN KEY (LoaiCP) REFERENCES LoaiChiPhi(ID)
);

CREATE TABLE ChiPhiDoan
(
  ID INT NOT NULL identity(1,1),
  TenChiPhi NVARCHAR(50) NOT NULL,
  ChiPhiThucTe INT NOT NULL,
  SoLuong INT NOT NULL,
  Tong INT NOT NULL,
  GhiChu NVARCHAR(50),
  DoanID INT NOT NULL,
  LoaiCP INT NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (DoanID) REFERENCES DoanDuLich(ID),
  FOREIGN KEY (LoaiCP) REFERENCES LoaiChiPhi(ID)
);


CREATE DATABASE QuanLyNhapXuatCuaHangVatLieu ON PRIMARY
(
	NAME = N'QuanLyNhapXuatCuaHangVatLieu_DATA',
	FILENAME = N'C:\QuanLyCuaHangVatLieuXayDung\QuanLyCuaHangVatLieu.mdf',
	SIZE = 5MB,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 10%
)
LOG ON
(
	NAME = N'QuanLyNhapXuatCuaHangVatLieu_Log',
	FILENAME = N'C:\QuanLyCuaHangVatLieuXayDung\QuanLyCuaHangVatLieu.ldf',
	SIZE = 3MB,
	MAXSIZE = 512MB,
	FILEGROWTH = 10%
);
GO

USE QuanLyNhapXuatCuaHangVatLieu;
GO

CREATE TABLE DoiTac(
	DoiTac_index INT PRIMARY KEY IDENTITY(1,1),
	MaDoiTac CHAR(10) NOT NULL,
	Ten VARCHAR(100) NOT NULL,
	SoDienThoai CHAR(10) NOT NULL,
	Email VARCHAR(100),
	DiaChi VARCHAR(250) NOT NULL,
	SoTaiKhoan CHAR(20),
	TenTaiKhoan VARCHAR(100),
	LoaiDoiTac VARCHAR(20) NOT NULL,
	TrangThai BIT DEFAULT 1
);
GO

CREATE TABLE VatLieu(
	VatLieu_index INT PRIMARY KEY IDENTITY(1,1),
	MaVatLieu CHAR(10) NOT NULL,
	TenVatLieu VARCHAR(100) NOT NULL,
	NhaCungCap_index INT,
	DonVi VARCHAR(20),
	DonGiaNhap DECIMAL(18,2) NOT NULL,
	DonGiaXuat DECIMAL(18,2) NOT NULL,
	HinhAnh VARCHAR(100),
	TrangThai BIT DEFAULT 1,
	CONSTRAINT fk_NhaCungCap FOREIGN KEY (NhaCungCap_index) REFERENCES DoiTac(DoiTac_index)
);
GO

CREATE TABLE Kho(
	MaKho CHAR(10) PRIMARY KEY,
	Ten VARCHAR(100) NOT NULL,
	DiaChi VARCHAR(250) NOT NULL,
);
GO

CREATE TABLE TonKho(
	VatLieu_index INT NOT NULL,
	MaKho CHAR(10) NOT NULL,
	SoLuong FLOAT NOT NULL,
	CONSTRAINT pk_TonKho PRIMARY KEY (VatLieu_index, MaKho),
	CONSTRAINT fk_ThongTinVatLieu FOREIGN KEY (VatLieu_index) REFERENCES VatLieu(VatLieu_index),
	CONSTRAINT fk_ThongTinKho FOREIGN KEY (MaKho) REFERENCES Kho(MaKho)
);
GO

CREATE TABLE HoaDon(
	HoaDon_index INT IDENTITY (1, 1) UNIQUE NOT NULL,
	MaHoaDon CHAR(10) PRIMARY KEY,
	DoiTac_index INT,
	ThoiGianLap DATETIME NOT NULL,
	GiamChietKhau DECIMAL(18,2),
	PhuongThucThanhToan VARCHAR(50),
	TongGiaTri DECIMAL(18,2),
	CONSTRAINT fk_GiaoDich FOREIGN KEY (DoiTac_index) REFERENCES DoiTac(DoiTac_index)
);
GO

CREATE TABLE ChiTietHoaDon(
	HoaDon_index INT NOT NULL,
	VatLieu_index INT NOT NULL,
	SoLuong FLOAT NOT NULL,
	CONSTRAINT pk_ChiTietHoaDon PRIMARY KEY (HoaDon_index, VatLieu_index),
	CONSTRAINT fk_DanhSachSanPham FOREIGN KEY (VatLieu_index) REFERENCES VatLieu(VatLieu_index),
	CONSTRAINT fk_ThuocHoaDon FOREIGN KEY (HoaDon_index) REFERENCES HoaDon(HoaDon_index)
);
GO

CREATE TABLE TienNo(
	TienNo_index INT IDENTITY(1, 1) UNIQUE NOT NULL,
	MaTienNo CHAR(10) PRIMARY KEY,
	NgayNo DATE NOT NULL,
	ThoiGianThanhToan INT NOT NULL,
	SoTienNo DECIMAL(18,2) NOT NULL,
	LoaiTienNo VARCHAR(50) NOT NULL,
	TrangThai BIT DEFAULT 1
);
GO

CREATE TABLE BienLaiTraNo(
	BienLai_index INT IDENTITY(1, 1) UNIQUE NOT NULL,
	MaBienLai CHAR(10) PRIMARY KEY,
	NgayLap DATE NOT NULL,
	SoTienTra DECIMAL(18,2) NOT NULL,
	LoaiBienLai VARCHAR(50) NOT NULL
);
GO

CREATE TABLE ChiPhiPhatSinh(
	ChiPhi_index INT IDENTITY(1, 1) UNIQUE NOT NULL,
	MaChiPhi CHAR(10) PRIMARY KEY,
	NgayLap DATE NOT NULL,
	NoiDung VARCHAR(200),
	ChiPhi DECIMAL(18,2) NOT NULL,
	LoaiChiPhi VARCHAR(20)
);
GO

CREATE TABLE NhanVien(
	NhanVien_index INT UNIQUE NOT NULL,
	MaNhanVien CHAR(10) PRIMARY KEY,
	Ten VARCHAR(100) NOT NULL,
	SoDienThoai CHAR(10) NOT NULL,
	DiaChi VARCHAR(250),
	NgaySinh DATE NOT NULL,
	LuongTrenNgay DECIMAL(18,2) NOT NULL,
	VaiTro VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE BangChamCong(
	NhanVien_index CHAR(10) NOT NULL,
	NgayChamCong DATE NOT NULL,
	CONSTRAINT pk_ChamCong PRIMARY KEY (NhanVien_index, NgayChamCong),
	CONSTRAINT fk_ChamCong FOREIGN KEY (NhanVien_index) REFERENCES NhanVien(MaNhanVien)
);
GO
CREATE DATABASE CuaHangXayDung
ON
(
	NAME = N'CuaHangXayDung_Data',
	FILENAME = N'C:\CuaHangXayDung\CuaHangXayDung.mdf',
	SIZE = 5MB,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 10%
)
LOG ON
(
	NAME = N'CuaHangXayDung_Log',
	FILENAME = N'C:\CuaHangXayDung\CuaHangXayDung.ldf',
	SIZE = 3MB,
	MAXSIZE = 512MB,
	FILEGROWTH = 10%
);
GO

USE CuaHangXayDung
GO

CREATE TABLE TaiKhoan(
	MaTaiKhoan CHAR(10) PRIMARY KEY,
	TenDangNhap NVARCHAR(30) UNIQUE NOT NULL,
	MatKhau NVARCHAR(15) UNIQUE NOT NULL,
	TenCuaHang NVARCHAR(100) NOT NULL,
	SoDienThoai CHAR(10) UNIQUE NOT NULL,
	DiaChi NVARCHAR(250) NOT NULL,
	NganHang NVARCHAR(100),
	SoTaiKhoan CHAR(15),
	QR NVARCHAR(250), /*đường dẫn đến file hình ảnh*/
);

/*
	Ở quan hệ đối tác(DoiTac) có 2 loại đối tác là Khách Hàng' và Nhà Cung Cấp
	LoaiDoiTac = 1 --> Khách hàng
	LoaiDoiTac = 2 --> Nhà cung cấp
*/
CREATE TABLE DoiTac(
	MaDoiTac CHAR(10) PRIMARY KEY,
	Ten NVARCHAR(100) NOT NULL,
	SoDienThoai CHAR(10) NOT NULL,
	DiaChi NVARCHAR(250) NOT NULL,
	Email NVARCHAR(100),
	LoaiDoiTac TINYINT DEFAULT 1 NOT NULL,
	NganHang NVARCHAR(100),
	SoTaiKhoan CHAR(15),
	QR NVARCHAR(250), /*đường dẫn đến file hình ảnh*/
	CONSTRAINT CK_LoaiDoiTac CHECK (LoaiDoiTac = 1 OR LoaiDoiTac = 2)
);
GO

/*Tạo INDEX cho thuộc tính Ten của quan hệ DoiTac*/
CREATE INDEX idx_doitac_ten ON DoiTac(Ten);
GO
/*Tạo INDEX cho thuộc tính SoDienThoai của quan hệ DoiTac*/
CREATE INDEX idx_doitac_sdt ON DoiTac(SoDienThoai);
GO
/*Tạo INDEX cho thuộc tính DiaChi của quan hệ DoiTac*/
CREATE INDEX idx_doitac_diachi ON DoiTac(DiaChi);
GO
/*Tạo INDEX cho thuộc tính Email của quan hệ DoiTac*/
CREATE INDEX idx_doitac_email ON DoiTac(Email)
GO
/*Tạo INDEX cho thuộc tính LoaiDoiTac của quan hệ DoiTac*/
CREATE INDEX idx_doitac_loaidoitac ON DoiTac(LoaiDoiTac)
GO

CREATE TABLE VatLieu(
	MaVatLieu CHAR(10) PRIMARY KEY,
	Ten NVARCHAR(100) NOT NULL,
	GiaNhap DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	GiaXuat DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	DonVi NVARCHAR(15) NOT NULL,
	NgayNhap DATE DEFAULT GETDATE() NOT NULL,
	NhaCungCap CHAR(10),
	SoLuong FLOAT DEFAULT 0 NOT NULL,
	DirHinhAnh NVARCHAR(250), /*Lưu đường dẫn folder chứa danh sách hình ảnh*/
	CONSTRAINT FK_NguonGocVatLieu 
		FOREIGN KEY (NhaCungCap) REFERENCES DoiTac(MaDoiTac)
		ON UPDATE CASCADE 
		ON DELETE SET NULL, 
	CONSTRAINT CK_Gia CHECK (GiaNhap >= 0 AND GiaXuat >= 0)
);
GO

/*Tạo INDEX cho thuộc tính Ten trong quan hệ VatLieu*/
CREATE INDEX idx_vatlieu_ten ON VatLieu(Ten);
GO
/*Tạo INDEX cho thuộc tính NhaCungCap trong quan hệ VatLieu*/
CREATE INDEX idx_vatlieu_nhacungcap ON VatLieu(NhaCungCap);
GO

/*Tạo INDEX cho thuộc tính NgayNhap trong quan hệ VatLieu*/
CREATE INDEX idx_vatlieu_ngaynhap ON VatLieu(NgayNhap);
GO

/*
	*Khi giao dịch tạo ra hóa đơn(HoaDon) thì có 3 phương thức thanh toán:
	- Trả một lần (PhuongThucThanhToan = 1)
	- Trả trước (PhuongThucThanhToan = 2)
	- Ghi nợ (PhuongThucThanhToan = 3)
	*Có 2 loại giao dịch là xuất hàng và nhập hàng thì sẽ có tương ứng 2 loại hóa đơn(HoaDon):
	- Hóa đơn xuất hàng (LoaiHoaDon = 1)
	- Hóa đơn nhập hàng (LoaiHoaDon = 2)
*/
CREATE TABLE HoaDon(
	MaHoaDon CHAR(10) PRIMARY KEY,
	ThoiGianLap DATETIME DEFAULT GETDATE() NOT NULL,
	MaDoiTac CHAR(10),
	TenDoiTac NVARCHAR(100) NOT NULL, /*đảm bảo tính toàn vẹn dữ liệu*/
	SoDienThoai CHAR(10) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	DiaChi NVARCHAR(250) NOT NULL,
	TienGiam DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	PhuongThucThanhToan TINYINT DEFAULT 1 NOT NULL,
	LoaiHoaDon TINYINT DEFAULT 1 NOT NULL,
	TienThanhToan DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	CONSTRAINT FK_GiaoDichVoiDoiTac FOREIGN KEY (MaDoiTac) REFERENCES DoiTac(MaDoiTac)
		ON DELETE SET NULL,
	CONSTRAINT CK_PhuongThucThanhToan_HoaDon CHECK (PhuongThucThanhToan = 1 
													OR PhuongThucThanhToan = 2
													OR PhuongThucThanhToan = 3),
	CONSTRAINT CK_PhanLoai_HoaDon CHECK (LoaiHoaDon = 1 OR LoaiHoaDon = 2),
	CONSTRAINT CK_GiaTri_HoaDon CHECK (TienGiam >= 0 AND TienThanhToan >= 0),
);
GO

/*Tạo INDEX cho thuộc tính ThoiGianLap trong quan hệ HoaDon*/
CREATE INDEX idx_hoadon_thoigianlap ON HoaDon(ThoiGianLap);
GO
/*Tạo INDEX cho thuộc tính MaDoiTac trong quan hệ HoaDon*/
CREATE INDEX idx_hoadon_madoitac ON HoaDon(MaDoiTac);
GO
/*Tạo INDEX cho thuộc tính PhuongThucThanhToan trong quan hệ HoaDon*/
CREATE INDEX idx_hoadon_phuongthucthanhtoan ON HoaDon(PhuongThucThanhToan);
GO
/*Tạo INDEX cho thuộc tính LoaiHoaDon trong quan hệ HoaDon*/
CREATE INDEX idx_hoadon_loaihoadon ON HoaDon(LoaiHoaDon);
GO

CREATE TABLE ChiTietHoaDon(
	MaHoaDon CHAR(10) NOT NULL,
	MaVatLieu CHAR(10),
	SoLuong FLOAT DEFAULT 0 NOT NULL,
	TenVatLieu NVARCHAR(100) NOT NULL, /*đảm bảo tính toàn vẹn dữ liệu*/
	GiaNhap DECIMAL(18, 2) DEFAULT 0 NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	GiaXuat DECIMAL(18, 2) DEFAULT 0 NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	DonVi NVARCHAR(15) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	NgayNhap DATE DEFAULT GETDATE() NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	NhaCungCap CHAR(10),	/*đảm bảo tính toàn vẹn dữ liệu*/
	DirHinhAnh NVARCHAR(250) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	CONSTRAINT FK_ChiTietHoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) 
		ON DELETE CASCADE,
	CONSTRAINT FK_VatLieuGiaoDich FOREIGN KEY (MaVatLieu) REFERENCES VatLieu(MaVatLieu)
		ON DELETE SET NULL,
	CONSTRAINT CK_SoLuongGiaoDich CHECK (SoLuong >= 0)
);

/*Tạo INDEX cho thuộc tính MaHoaDon trong quan hệ ChiTietHoaDon*/
CREATE INDEX idx_chitiethoadon_mahoadon ON ChiTietHoaDon(MaHoaDon);
GO
/*Tạo INDEX cho thuộc tính MaVatLieu trong quan hệ ChiTietHoaDon*/
CREATE INDEX idx_chitiethoadon_mavatlieu ON ChiTietHoaDon(MaVatLieu);
GO

/*
	*Phiếu trả hàng(PhieuTraHang) có 2 loại là:
	- Tra hàng từ khách hàng --> LoaiPhieu = 1
	- Tra hàng cho nhà cung cấp --> LoaiPhieu = 2
*/
CREATE TABLE PhieuTraHang(
	MaPhieu CHAR(10) PRIMARY KEY,
	ThoiGianLap DATETIME DEFAULT GETDATE() NOT NULL,
	MaHoaDon CHAR(10),
	LyDo NVARCHAR(250),
	LoaiPhieu TINYINT DEFAULT 1 NOT NULL,
	TongTien DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	CONSTRAINT FK_TraHangChoHoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	CONSTRAINT CK_LoaiPhieuTraHang CHECK (LoaiPhieu = 1 OR LoaiPhieu = 2)
);
GO

/*Tạo INDEX cho thuộc tính MaHoaDon trong quan hệ PhieuTraHang*/
CREATE INDEX idx_phieutrahang_mahoadon ON ChiTietHoaDon(MaHoaDon);
GO
/*Tạo INDEX cho thuộc tính ThoiGianLap trong quan hệ PhieuTraHang*/
CREATE INDEX idx_phieutrahang_thoigianlap ON PhieuTraHang(ThoiGianLap);
GO
/*Tạo INDEX cho thuộc tính LoaiPhieu trong quan hệ PhieuTraHang*/
CREATE INDEX idx_phieutrahang_loaiphieu ON PhieuTraHang(LoaiPhieu);
GO

CREATE TABLE ChiTietTraHang(
	MaPhieuTraHang CHAR(10) NOT NULL,
	MaVatLieu CHAR(10),
	SoLuong FLOAT DEFAULT 0 NOT NULL,
	TenVatLieu NVARCHAR(100) NOT NULL, /*đảm bảo tính toàn vẹn dữ liệu*/
	GiaNhap DECIMAL(18, 2) DEFAULT 0 NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	GiaXuat DECIMAL(18, 2) DEFAULT 0 NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	DonVi NVARCHAR(15) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	NgayNhap DATE DEFAULT GETDATE() NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	NhaCungCap CHAR(10),	/*đảm bảo tính toàn vẹn dữ liệu*/
	DirHinhAnh NVARCHAR(250) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	CONSTRAINT FK_MaPhieuTraHang FOREIGN KEY (MaPhieuTraHang) REFERENCES PhieuTraHang(MaPhieu) 
		ON DELETE CASCADE,
	CONSTRAINT FK_VatLieuTraHang FOREIGN KEY (MaVatLieu) REFERENCES VatLieu(MaVatLieu)
		ON DELETE SET NULL
);
GO

/*Tạo INDEX cho thuộc tính MaPhieuTraHang trong quan hệ ChiTietTraHang*/
CREATE INDEX idx_chitiettrahang_maphieutrahang ON ChiTietTraHang(MaPhieuTraHang);
GO
/*Tạo INDEX cho thuộc tính MaVatLieu trong quan hệ ChiTietTraHang*/
CREATE INDEX idx_chitiettrahang_mavatlieu ON ChiTietTraHang(MaVatLieu);
GO

/*
	*Phiếu ghi nợ (PhieuGhiNo) có 2 loại:
	- Phiếu ghi nợ của khách hàng --> LoaiPhieu = 1
	- Phiếu ghi nợ của cửa hàng --> LoaiPhieu = 2
	*Phiếu ghi nợ (PhieuGhiNo) có 2 trạng thái là:
	- Chưa trả --> TrangThai = 0
	- Đã trả --> TrangThai = 1
*/
CREATE TABLE PhieuGhiNo (
	MaPhieu CHAR(10) PRIMARY KEY,
	MaDoiTac CHAR(10) NULL,
	MaHoaDon CHAR(10) NULL,
	ThoiGianLap DATETIME DEFAULT GETDATE() NOT NULL,
	ThoiGianTra DATETIME NOT NULL,
	TienNo DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	LoaiPhieu TINYINT DEFAULT 1 NOT NULL,
	TrangThai BIT DEFAULT 1 NOT NULL,
	TenDoiTac NVARCHAR(100) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	SoDienThoai CHAR(10) NOT NULL,		/*đảm bảo tính toàn vẹn dữ liệu*/
	DiaChi NVARCHAR(250) NOT NULL,		/*đảm bảo tính toàn vẹn dữ liệu*/
	CONSTRAINT FK_DoiTacNo FOREIGN KEY (MaDoiTac) REFERENCES DoiTac(MaDoiTac) 
		ON DELETE SET NULL,
	CONSTRAINT FK_NoTuHoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
		ON DELETE SET NULL,
	CONSTRAINT CK_TienNo CHECK (TienNo >= 0),
	CONSTRAINT CK_ThoiGianTra CHECK (ThoiGianTra > CAST(ThoiGianLap AS DATE)),
	CONSTRAINT CK_LoaiPhieuNo CHECK (LoaiPhieu = 1 OR LoaiPhieu = 2)
);
GO

/*Tạo INDEX cho thuộc tính MaDoiTac trong quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_madoitac ON PhieuGhiNo(MaDoiTac);
GO
/*Tạo INDEX cho thuộc tính MaDoiTac trong quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_mahoadon ON PhieuGhiNo(MaHoaDon);
GO
/*Tạo INDEX cho thuộc tính ThoiGianLap trong quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_thoigianlap ON PhieuGhiNo(ThoiGianLap);
GO
/*Tạo INDEX cho thuộc tính NgayTra trong quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_thoigiantra ON PhieuGhiNo(ThoiGianTra);
GO
/*Tạo INDEX cho thuộc tính NgayTra trong quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_loaiphieu ON PhieuGhiNo(LoaiPhieu);
GO
/*Tạo INDEX cho thuộc tính TenDoiTac của quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_tendoitac ON PhieuGhiNo(TenDoiTac);
GO
/*Tạo INDEX cho thuộc tính SoDienThoai của quan hệ PhieuGhiNo*/
CREATE INDEX idx_phieughino_sdt ON PhieuGhiNo(SoDienThoai);
GO

CREATE TABLE BienLaiTraNo(
	MaBienLai CHAR(10) PRIMARY KEY,
	ThoiGianTra DATETIME DEFAULT GETDATE() NOT NULL,
	TienTra DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	MaPhieuGhiNo CHAR(10) NOT NULL,
	CONSTRAINT FK_TraNoChoKhoanNoNao FOREIGN KEY (MaPhieuGhiNo) REFERENCES PhieuGhiNo(MaPhieu)
		ON DELETE CASCADE,
	CONSTRAINT CK_TienTraNo CHECK (TienTra >= 0)
);

/*Tạo INDEX cho thuộc tính ThoiGianTra của quan hệ BienLaiTraNo*/
CREATE INDEX idx_bienlaitrano_thoigiantra ON BienLaiTraNo(ThoiGianTra);
GO
/*Tạo INDEX cho thuộc tính MaPhieuGhiNo của quan hệ BienLaiTraNo*/
CREATE INDEX idx_bienlaitrano_maphieughino ON BienLaiTraNo(MaPhieuGhiNo);
GO

/*
	*Chi phí phát sinh (ChiPhiPhatSinh) có 5 loại là:
	- Chi phí dịch vụ --> LoaiChiPhi = 1
	- Chi phí vận chuyển --> LoaiChiPhi = 2
	- Chi phí nhân viên --> LoaiChiPhi = 3
	- Chi phí đối tác --> LoaiChiPhi = 4
	- Chi phí khác --> LoaiChiPhi = 5
*/
CREATE TABLE ChiPhiPhatSinh(
	MaChiPhi CHAR(10) PRIMARY KEY,
	LoaiChiPhi TINYINT DEFAULT 1 NOT NULL,
	ThoiGianLap DATETIME DEFAULT GETDATE() NOT NULL,
	ChiPhi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
	MoTa NVARCHAR(500),
	CONSTRAINT CK_LoaiChiPhi CHECK (LoaiChiPhi = 1 OR LoaiChiPhi = 2 OR LoaiChiPhi = 3 
													OR LoaiChiPhi = 4 OR LoaiChiPhi = 5),
	CONSTRAINT CK_ChiPhi CHECK (ChiPhi >= 0)
);
GO

/*Tạo INDEX cho thuộc tính LoaiChiPhi của quan hệ ChiPhiPhatSinh*/
CREATE INDEX idx_chiphiphatsinh_loaichiphi ON ChiPhiPhatSinh(LoaiChiPhi);
GO
/*Tạo INDEX cho thuộc tính ThoiGianLap của quan hệ ChiPhiPhatSinh*/
CREATE INDEX idx_chiphiphatsinh_thoigianlap ON ChiPhiPhatSinh(ThoiGianLap);
GO


CREATE TABLE NhanVien(
	MaNhanVien CHAR(10) PRIMARY KEY,
	Ten NVARCHAR(100) NOT NULL,
	SoDienThoai CHAR(10) UNIQUE NOT NULL,
	DiaChi NVARCHAR(250),
	VaiTro NVARCHAR(100) NOT NULL,
	Email NVARCHAR(100),
	LuongTrenNgay DECIMAL(18, 2) DEFAULT 250000 NOT NULL,
	CONSTRAINT CK_LuongTrenNgay CHECK (LuongTrenNgay >= 0)
);

/*Tạo INDEX cho thuộc tính Ten của quan hệ NhanVien*/
CREATE INDEX idx_nhanvien_ten ON NhanVien(Ten);
GO
/*Tạo INDEX cho thuộc tính SoDienThoai của quan hệ NhanVien*/
CREATE INDEX idx_nhanvien_sdt ON NhanVien(SoDienThoai);
GO
/*Tạo INDEX cho thuộc tính VaiTro của quan hệ NhanVien*/
CREATE INDEX idx_nhanvien_vaitro ON NhanVien(VaiTro);
GO

CREATE TABLE BangChamCong(
	ThoiGianChamCong DATETIME DEFAULT GETDATE() PRIMARY KEY,
	MaNhanVien CHAR(10) NULL,
	TenNhanVien NVARCHAR(100) NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	SoDienThoai CHAR(10) UNIQUE NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	DiaChi NVARCHAR(250),	/*đảm bảo tính toàn vẹn dữ liệu*/
	Email NVARCHAR(100),	/*đảm bảo tính toàn vẹn dữ liệu*/
	LuongTrenNgay DECIMAL(18, 2) DEFAULT 250000 NOT NULL,	/*đảm bảo tính toàn vẹn dữ liệu*/
	CONSTRAINT FK_NhanVienNaoChamCong FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
		ON DELETE SET NULL,
);
GO

/*Tạo INDEX cho thuộc tính MaNhanVien của quan hệ BangChamCong*/
CREATE INDEX idx_bangchamcong_manhanvien ON BangChamCong(MaNhanVien);
GO

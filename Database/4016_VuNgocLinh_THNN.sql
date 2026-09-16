-- ============================================================

CREATE DATABASE QuanLyDichVu_DaiDuongXanh;
GO

USE QuanLyDichVu_DaiDuongXanh;
GO



-- ============================================================
-- 1. KHACH HANG
-- ============================================================
CREATE TABLE KhachHang (
    MAKH            VARCHAR(20)     NOT NULL,
    TENKH           NVARCHAR(100)   NOT NULL,
    DIACHIKH        NVARCHAR(200)   NOT NULL,
    DIENTHOAIKH     VARCHAR(15)     NOT NULL,
    EMAILKH         VARCHAR(100)    NOT NULL,
    GIOITINHKH      NVARCHAR(10)    NULL,
    NGAYSINHKH      DATE            NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Hoạt động',
    NGAYDANGKY      DATE            NOT NULL DEFAULT CONVERT(DATE, GETDATE()),

    CONSTRAINT PK_KhachHang         PRIMARY KEY (MAKH),
    CONSTRAINT UQ_KhachHang_DIENTHOAI UNIQUE (DIENTHOAIKH),
    CONSTRAINT UQ_KhachHang_EMAIL   UNIQUE (EMAILKH),
    CONSTRAINT CK_KhachHang_TRANGTHAI  CHECK (TRANGTHAI IN (N'Hoạt động', N'Khóa')),
    CONSTRAINT CK_KhachHang_EMAIL      CHECK (EMAILKH LIKE '%@%.%'),
    CONSTRAINT CK_KhachHang_SDT        CHECK (DIENTHOAIKH NOT LIKE '%[^0-9]%'),
    CONSTRAINT CK_KhachHang_GIOITINH   CHECK (GIOITINHKH IS NULL OR GIOITINHKH IN (N'Nam', N'Nữ', N'Khác'))
);
GO

-- ============================================================
-- 2. NHAN VIEN
CREATE TABLE NhanVien (
    MANV            VARCHAR(20)     NOT NULL,
    TENNV           NVARCHAR(100)   NOT NULL,
    NGAYSINHNV      DATE            NULL,
    GIOITINHNV      NVARCHAR(10)    NULL,
    DIACHINV        NVARCHAR(200)   NULL,
    SDTNV           VARCHAR(15)     NOT NULL,
    EMAILNV         VARCHAR(100)    NOT NULL,
    VAITRO          NVARCHAR(50)    NOT NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Đang làm việc',
    NGAYVAOLV       DATE            NOT NULL DEFAULT CONVERT(DATE, GETDATE()),

    CONSTRAINT PK_NhanVien PRIMARY KEY (MANV),
    CONSTRAINT UQ_NhanVien_SDTNV UNIQUE (SDTNV),
    CONSTRAINT UQ_NhanVien_EMAILNV UNIQUE (EMAILNV),
    CONSTRAINT CK_NhanVien_EMAIL CHECK (EMAILNV LIKE '%@%.%'),
    CONSTRAINT CK_NhanVien_SDT CHECK (SDTNV NOT LIKE '%[^0-9]%'),
    CONSTRAINT CK_NhanVien_GIOITINH CHECK (GIOITINHNV IS NULL OR GIOITINHNV IN (N'Nam', N'Nữ', N'Khác')),
    CONSTRAINT CK_NhanVien_TRANGTHAI CHECK (TRANGTHAI IN (N'Đang làm việc', N'Nghỉ việc')),
    CONSTRAINT CK_NhanVien_VAITRO CHECK (VAITRO IN (
        N'Nhân viên bán hàng',
        N'Nhân viên văn phòng',
        N'Nhân viên quản lý hệ thống',
        N'Chủ doanh nghiệp'
    )),
    CONSTRAINT CK_NhanVien_NGAYSINH CHECK (NGAYSINHNV IS NULL OR NGAYSINHNV < NGAYVAOLV)
);
GO

-- ============================================================
-- 3. TAI KHOAN
-- Tai khoan co the thuoc ve khach hang hoac nhan vien, nhung khong dong thoi ca hai.
-- ============================================================
CREATE TABLE TaiKhoan (
    MATK            VARCHAR(20)     NOT NULL,
    TENDANGNHAP     VARCHAR(100)    NOT NULL,
    MATKHAU_HASH    NVARCHAR(200)   NOT NULL,
    LOAITAIKHOAN    NVARCHAR(50)    NOT NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Hoạt động',
    MAKH            VARCHAR(20)     NULL,
    MANV            VARCHAR(20)     NULL,

    CONSTRAINT PK_TaiKhoan PRIMARY KEY (MATK),
    CONSTRAINT FK_TaiKhoan_KhachHang FOREIGN KEY (MAKH) REFERENCES KhachHang(MAKH),
    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MANV) REFERENCES NhanVien(MANV),
    CONSTRAINT UQ_TaiKhoan_TENDANGNHAP UNIQUE (TENDANGNHAP),
    CONSTRAINT CK_TaiKhoan_TRANGTHAI CHECK (TRANGTHAI IN (N'Hoạt động', N'Khóa')),
    CONSTRAINT CK_TaiKhoan_LOAI CHECK (LOAITAIKHOAN IN (
        N'Khách hàng',
        N'Nhân viên bán hàng',
        N'Nhân viên văn phòng',
        N'Nhân viên quản lý hệ thống',
        N'Chủ doanh nghiệp'
    )),
    CONSTRAINT CK_TaiKhoan_NGUOIDUNG CHECK (
        (LOAITAIKHOAN = N'Khách hàng' AND MAKH IS NOT NULL AND MANV IS NULL) OR
        (LOAITAIKHOAN IN (
            N'Nhân viên bán hàng',
            N'Nhân viên văn phòng',
            N'Nhân viên quản lý hệ thống',
            N'Chủ doanh nghiệp'
        ) AND MANV IS NOT NULL AND MAKH IS NULL)
    )
);
GO

CREATE UNIQUE INDEX UX_TaiKhoan_MAKH_NotNull
ON TaiKhoan(MAKH)
WHERE MAKH IS NOT NULL;
GO

CREATE UNIQUE INDEX UX_TaiKhoan_MANV_NotNull
ON TaiKhoan(MANV)
WHERE MANV IS NOT NULL;
GO




-- ============================================================
-- 4. NHOM DICH VU
-- ============================================================
CREATE TABLE NhomDichVu (
    MANHOM          VARCHAR(20)     NOT NULL,
    TENNHOM         NVARCHAR(100)   NOT NULL,
    MOTA            NVARCHAR(500)   NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Hoạt động',

    CONSTRAINT PK_NhomDichVu PRIMARY KEY (MANHOM),
    CONSTRAINT UQ_NhomDichVu_TENNHOM UNIQUE (TENNHOM),
    CONSTRAINT CK_NhomDichVu_TRANGTHAI CHECK (TRANGTHAI IN (N'Hoạt động', N'Ẩn'))
);
GO

CREATE TABLE DichVu (
    MADV            VARCHAR(20)     NOT NULL,
    TENDV           NVARCHAR(100)   NOT NULL,
    GIABAN          DECIMAL(18,2)   NOT NULL,
    DONVITINH       NVARCHAR(50)    NOT NULL,
    MOTA            NVARCHAR(500)   NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Đang cung cấp',
    MANHOM          VARCHAR(20)     NOT NULL,

    CONSTRAINT PK_DichVu PRIMARY KEY (MADV),
    CONSTRAINT FK_DichVu_NhomDichVu FOREIGN KEY (MANHOM) REFERENCES NhomDichVu(MANHOM),
    CONSTRAINT UQ_DichVu_TENDV UNIQUE (TENDV),
    CONSTRAINT CK_DichVu_GIABAN CHECK (GIABAN >= 0),
    CONSTRAINT CK_DichVu_TRANGTHAI CHECK (TRANGTHAI IN (N'Đang cung cấp', N'Ngừng cung cấp'))
);
GO

-- ============================================================
-- 5. DON DICH VU
-- ============================================================
CREATE TABLE DonDichVu (
    MADON           VARCHAR(20)     NOT NULL,
    NGAYDAT         DATETIME        NOT NULL DEFAULT GETDATE(),
    NGAYTHUCHIEN    DATETIME        NOT NULL,
    DIEMDI          NVARCHAR(200)   NOT NULL,
    DIEMDEN         NVARCHAR(200)   NOT NULL,
    GHICHU          NVARCHAR(1000)  NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Chờ xác nhận',
    MAKH            VARCHAR(20)     NOT NULL,
    MANV_TIEPNHAN   VARCHAR(20)     NULL,

    CONSTRAINT PK_DonDichVu PRIMARY KEY (MADON),
    CONSTRAINT FK_DonDichVu_KhachHang FOREIGN KEY (MAKH) REFERENCES KhachHang(MAKH),
    CONSTRAINT FK_DonDichVu_NhanVien FOREIGN KEY (MANV_TIEPNHAN) REFERENCES NhanVien(MANV),
    CONSTRAINT CK_DonDichVu_NGAY CHECK (NGAYTHUCHIEN >= NGAYDAT),
    CONSTRAINT CK_DonDichVu_TRANGTHAI CHECK (TRANGTHAI IN (
        N'Chờ xác nhận',
        N'Đã xác nhận',
        N'Đang xử lý',
        N'Hoàn thành',
        N'Hủy'
    ))
);
GO

CREATE TABLE ChiTietDonDichVu (
    MADON           VARCHAR(20)     NOT NULL,
    MADV            VARCHAR(20)     NOT NULL,
    SOLUONG         INT             NOT NULL,
    DONGIA          DECIMAL(18,2)   NOT NULL,
    THANHTIEN       AS (CONVERT(DECIMAL(18,2), SOLUONG * DONGIA)) PERSISTED,
    GHICHU          NVARCHAR(500)   NULL,

    CONSTRAINT PK_ChiTietDonDichVu PRIMARY KEY (MADON, MADV),
    CONSTRAINT FK_ChiTietDon_DonDichVu FOREIGN KEY (MADON) REFERENCES DonDichVu(MADON),
    CONSTRAINT FK_ChiTietDon_DichVu FOREIGN KEY (MADV) REFERENCES DichVu(MADV),
    CONSTRAINT CK_ChiTietDon_SOLUONG CHECK (SOLUONG > 0),
    CONSTRAINT CK_ChiTietDon_DONGIA CHECK (DONGIA >= 0)
);
GO

-- ============================================================
-- 6. HOA DON
-- ============================================================
CREATE TABLE HoaDon (
    MAHD                    VARCHAR(20)     NOT NULL,
    NGAYHD                  DATETIME        NOT NULL DEFAULT GETDATE(),
    TONGTIEN                DECIMAL(18,2)   NOT NULL DEFAULT 0,
    THUEVAT                 DECIMAL(5,2)    NOT NULL DEFAULT 10,
    CHIETKHAU               DECIMAL(5,2)    NOT NULL DEFAULT 0,
    THANHTIEN               DECIMAL(18,2)   NOT NULL DEFAULT 0,
    PHUONGTHUCTHANHTOAN     NVARCHAR(50)    NOT NULL,
    TINHTRANGTHANHTOAN      NVARCHAR(50)    NOT NULL DEFAULT N'Chưa thanh toán',
    MADON                   VARCHAR(20)     NOT NULL,
    MANV_LAP                VARCHAR(20)     NOT NULL,

    CONSTRAINT PK_HoaDon PRIMARY KEY (MAHD),
    CONSTRAINT FK_HoaDon_DonDichVu FOREIGN KEY (MADON) REFERENCES DonDichVu(MADON),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MANV_LAP) REFERENCES NhanVien(MANV),
    CONSTRAINT UQ_HoaDon_MADON UNIQUE (MADON),
    CONSTRAINT CK_HoaDon_TONGTIEN CHECK (TONGTIEN >= 0),
    CONSTRAINT CK_HoaDon_THANHTIEN CHECK (THANHTIEN >= 0),
    CONSTRAINT CK_HoaDon_THUEVAT CHECK (THUEVAT BETWEEN 0 AND 100),
    CONSTRAINT CK_HoaDon_CHIETKHAU CHECK (CHIETKHAU BETWEEN 0 AND 100),
    CONSTRAINT CK_HoaDon_PHUONGTHUC CHECK (PHUONGTHUCTHANHTOAN IN (
        N'Tiền mặt',
        N'Chuyển khoản',
        N'Online'
    )),
    CONSTRAINT CK_HoaDon_TINHTRANG CHECK (TINHTRANGTHANHTOAN IN (
        N'Chưa thanh toán',
        N'Thanh toán một phần',
        N'Đã thanh toán'
    ))
);
GO

-- ============================================================
-- 7. CHUNG TU
-- ============================================================
CREATE TABLE ChungTu (
    MACT            VARCHAR(20)     NOT NULL,
    LOAICHUNGTU     NVARCHAR(100)   NOT NULL,
    SOCHUNGTU       NVARCHAR(50)    NOT NULL,
    NGAYLAP         DATE            NOT NULL DEFAULT CONVERT(DATE, GETDATE()),
    TONGTIEN        DECIMAL(18,2)   NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Chờ kiểm tra',
    MADON           VARCHAR(20)     NOT NULL,
    MANV_KIEMTRA    VARCHAR(20)     NULL,

    GHICHU          NVARCHAR(500)   NULL,
    NGAYDUYET       DATETIME        NULL,

    CONSTRAINT PK_ChungTu PRIMARY KEY (MACT),
    CONSTRAINT FK_ChungTu_DonDichVu FOREIGN KEY (MADON) REFERENCES DonDichVu(MADON),
    CONSTRAINT FK_ChungTu_NhanVien FOREIGN KEY (MANV_KIEMTRA) REFERENCES NhanVien(MANV),
    CONSTRAINT UQ_ChungTu_SOCHUNGTU UNIQUE (SOCHUNGTU),
    CONSTRAINT CK_ChungTu_TONGTIEN CHECK (TONGTIEN IS NULL OR TONGTIEN >= 0),
    CONSTRAINT CK_ChungTu_LOAI CHECK (LOAICHUNGTU IN (
        N'Vận đơn',
        N'Hợp đồng',
        N'Biên bản giao nhận',
        N'Chứng từ xuất nhập khẩu',
        N'Khác'
    )),
     CONSTRAINT CK_ChungTu_TRANGTHAI CHECK (TRANGTHAI IN
            (
                N'Chờ duyệt',
                N'Đã duyệt',
                N'Trả lại',
                N'Từ chối'
            )
        )
);
GO



CREATE TABLE LichSuTrangThaiDon (
    MALICHSU        INT IDENTITY(1,1) NOT NULL,
    MADON           VARCHAR(20)       NOT NULL,
    TRANGTHAI_CU    NVARCHAR(50)      NULL,
    TRANGTHAI_MOI   NVARCHAR(50)      NOT NULL,
    MANV_CAPNHAT    VARCHAR(20)       NULL,
    THOIGIANCAPNHAT DATETIME          NOT NULL DEFAULT GETDATE(),
    GHICHU          NVARCHAR(500)     NULL,

    CONSTRAINT PK_LichSuTrangThaiDon PRIMARY KEY (MALICHSU),
    CONSTRAINT FK_LichSuTrangThaiDon_Don FOREIGN KEY (MADON) REFERENCES DonDichVu(MADON),
    CONSTRAINT FK_LichSuTrangThaiDon_NhanVien FOREIGN KEY (MANV_CAPNHAT) REFERENCES NhanVien(MANV)
);
GO

CREATE TABLE CongTy (
    MACTY           VARCHAR(20)     NOT NULL,
    TENCONGTY       NVARCHAR(250)   NOT NULL,
    TENVIETTAT      NVARCHAR(100)   NULL,
    TENQUOCTE       NVARCHAR(300)   NULL,
    MASOTHUE        VARCHAR(20)     NOT NULL,
    NGAYTHANHLAP    DATE            NULL,

    NGUOIDAIDIEN    NVARCHAR(100)   NULL,
    DIACHI          NVARCHAR(300)   NOT NULL,
    DIENTHOAI       VARCHAR(15)     NULL,
    EMAIL           VARCHAR(100)    NULL,
    WEBSITE         VARCHAR(200)    NULL,

    LINHVUC         NVARCHAR(200)   NULL,
    TRANGTHAI       NVARCHAR(50)    NOT NULL DEFAULT N'Hoạt động',

    CONSTRAINT PK_CongTy PRIMARY KEY (MACTY),
    CONSTRAINT UQ_CongTy_MST UNIQUE (MASOTHUE)
);
SELECT SUM(THANHTIEN)
FROM HoaDon
SELECT DB_NAME()
-- ============================================================
-- 8. INDEX PHUC VU TRUY VAN NGHIEP VU
-- ============================================================
CREATE INDEX IX_NhanVien_VAITRO ON NhanVien(VAITRO);
CREATE INDEX IX_DonDichVu_MAKH ON DonDichVu(MAKH);
CREATE INDEX IX_DonDichVu_MANV_TIEPNHAN ON DonDichVu(MANV_TIEPNHAN);
CREATE INDEX IX_DonDichVu_TRANGTHAI ON DonDichVu(TRANGTHAI);
CREATE INDEX IX_DonDichVu_NGAYDAT ON DonDichVu(NGAYDAT);
CREATE INDEX IX_ChiTietDonDichVu_MADV ON ChiTietDonDichVu(MADV);
CREATE INDEX IX_HoaDon_TINHTRANG ON HoaDon(TINHTRANGTHANHTOAN);
CREATE INDEX IX_ChungTu_MANV_KIEMTRA ON ChungTu(MANV_KIEMTRA);
GO

-- ============================================================
-- 9. TRIGGER RANG BUOC NGHIEP VU
-- ============================================================

-- Khach hang dat don phai dang hoat dong.
-- Nhan vien tiep nhan, neu co, phai dang lam viec va co vai tro nhan vien ban hang.
CREATE TRIGGER tg_DonDichVu_KiemTraNguoiLienQuan
ON DonDichVu
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted I
        JOIN KhachHang KH ON KH.MAKH = I.MAKH
        WHERE KH.TRANGTHAI <> N'Hoạt động'
    )
    BEGIN
        RAISERROR(N'Khách hàng đặt dịch vụ phải đang hoạt động.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM inserted I
        JOIN NhanVien NV ON NV.MANV = I.MANV_TIEPNHAN
        WHERE I.MANV_TIEPNHAN IS NOT NULL
          AND (
              NV.TRANGTHAI <> N'Đang làm việc'
              OR NV.VAITRO <> N'Nhân viên bán hàng'
          )
    )
    BEGIN
        RAISERROR(N'Nhân viên tiếp nhận đơn phải là nhân viên bán hàng đang làm việc.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO

-- Khi xac nhan don, don phai co it nhat mot dich vu va co nhan vien tiep nhan.
CREATE TRIGGER tg_DonDichVu_KiemTraKhiXacNhan
ON DonDichVu
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TRANGTHAI)
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM inserted I
            JOIN deleted D ON D.MADON = I.MADON
            WHERE I.TRANGTHAI = N'Đã xác nhận'
              AND D.TRANGTHAI <> N'Đã xác nhận'
              AND (
                  I.MANV_TIEPNHAN IS NULL
                  OR NOT EXISTS (
                      SELECT 1
                      FROM ChiTietDonDichVu CT
                      WHERE CT.MADON = I.MADON
                  )
              )
        )
        BEGIN
            RAISERROR(N'Đơn phải có nhân viên tiếp nhận và ít nhất một chi tiết trước khi xác nhận.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;
    END;
END;
GO

-- Khong duoc xoa het chi tiet cua don da xac nhan hoac dang xu ly.
CREATE TRIGGER tg_ChiTietDon_KhongXoaHetChiTiet
ON ChiTietDonDichVu
FOR DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted D
        JOIN DonDichVu DDV ON DDV.MADON = D.MADON
        WHERE DDV.TRANGTHAI IN (N'Đã xác nhận', N'Đang xử lý')
          AND NOT EXISTS (
              SELECT 1
              FROM ChiTietDonDichVu CT
              WHERE CT.MADON = D.MADON
          )
    )
    BEGIN
        RAISERROR(N'Không được xóa hết chi tiết của đơn đã xác nhận hoặc đang xử lý.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO

-- ============================================================
--  Chỉ lập hóa đơn cho đơn đã hoàn thành
-- ============================================================
CREATE TRIGGER tg_HoaDon_ChiLapChoDonHoanThanh
ON HoaDon
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted I
        JOIN DonDichVu D ON I.MADON = D.MADON
        WHERE D.TRANGTHAI <> N'Hoàn thành'
    )
    BEGIN
        RAISERROR(N'Chỉ được lập hóa đơn cho đơn dịch vụ đã hoàn thành.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO
-- Nguoi kiem tra chung tu phai la nhan vien van phong hoac chu doanh nghiep dang lam viec.
CREATE TRIGGER tg_ChungTu_KiemTraNguoiKiemTra
ON ChungTu
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted I
        JOIN NhanVien NV ON NV.MANV = I.MANV_KIEMTRA
        WHERE I.MANV_KIEMTRA IS NOT NULL
          AND (
              NV.TRANGTHAI <> N'Đang làm việc'
              OR NV.VAITRO NOT IN (N'Chủ doanh nghiệp')
          )
    )
       BEGIN
        RAISERROR(N'Chỉ Chủ doanh nghiệp được phép duyệt chứng từ.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO

-- Cap nhat tong tien hoa don khi chi tiet don thay doi.
CREATE TRIGGER tg_ChiTietDon_CapNhatHoaDon
ON ChiTietDonDichVu
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE HD
    SET
        TONGTIEN = ISNULL(T.TONGTIEN, 0),
        THANHTIEN = ISNULL(T.TONGTIEN, 0)
                    + ISNULL(T.TONGTIEN, 0) * HD.THUEVAT / 100
                    - ISNULL(T.TONGTIEN, 0) * HD.CHIETKHAU / 100
    FROM HoaDon HD
    JOIN (
        SELECT MADON FROM inserted
        UNION
        SELECT MADON FROM deleted
    ) X ON X.MADON = HD.MADON
    OUTER APPLY (
        SELECT SUM(THANHTIEN) AS TONGTIEN
        FROM ChiTietDonDichVu CT
        WHERE CT.MADON = HD.MADON
    ) T;
END;
GO

-- Ghi nhan lich su moi khi trang thai don thay doi.
CREATE TRIGGER tg_DonDichVu_GhiLichSuTrangThai
ON DonDichVu
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TRANGTHAI)
    BEGIN
        INSERT INTO LichSuTrangThaiDon (MADON, TRANGTHAI_CU, TRANGTHAI_MOI, MANV_CAPNHAT)
        SELECT I.MADON, D.TRANGTHAI, I.TRANGTHAI, I.MANV_TIEPNHAN
        FROM inserted I
        JOIN deleted D ON D.MADON = I.MADON
        WHERE ISNULL(I.TRANGTHAI, N'') <> ISNULL(D.TRANGTHAI, N'');
    END;
END;
GO

-- Khong xoa khach hang con don chua ket thuc.
CREATE TRIGGER tg_KhachHang_KhongXoaKhiConDonMo
ON KhachHang
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted KH
        JOIN DonDichVu D ON D.MAKH = KH.MAKH
        WHERE D.TRANGTHAI NOT IN (N'Hoàn thành', N'Hủy')
    )
    BEGIN
        RAISERROR(N'Không được xóa khách hàng còn đơn chưa hoàn tất.', 16, 1);
        RETURN;
    END;

    DELETE TK
    FROM TaiKhoan TK
    JOIN deleted D ON D.MAKH = TK.MAKH;

    DELETE KH
    FROM KhachHang KH
    JOIN deleted D ON D.MAKH = KH.MAKH;
END;
GO

-- Khong xoa nhan vien da phat sinh nghiep vu.
CREATE TRIGGER tg_NhanVien_KhongXoaKhiDaPhatSinh
ON NhanVien
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted NV
        WHERE EXISTS (SELECT 1 FROM DonDichVu D WHERE D.MANV_TIEPNHAN = NV.MANV)
           OR EXISTS (SELECT 1 FROM HoaDon HD WHERE HD.MANV_LAP = NV.MANV)
           OR EXISTS (SELECT 1 FROM ChungTu CT WHERE CT.MANV_KIEMTRA = NV.MANV)
    )
    BEGIN
        RAISERROR(N'Không được xóa nhân viên đã phát sinh đơn, hóa đơn hoặc chứng từ.', 16, 1);
        RETURN;
    END;

    DELETE TK
    FROM TaiKhoan TK
    JOIN deleted D ON D.MANV = TK.MANV;

    DELETE NV
    FROM NhanVien NV
    JOIN deleted D ON D.MANV = NV.MANV;
END;
GO



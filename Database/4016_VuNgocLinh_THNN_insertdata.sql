
 
USE QuanLyDichVu_DaiDuongXanh;
GO
 INSERT INTO CongTy (
    MACTY,
    TENCONGTY,
    TENVIETTAT,
    TENQUOCTE,
    MASOTHUE,
    NGAYTHANHLAP,
    NGUOIDAIDIEN,
    DIACHI,
    DIENTHOAI,
    LINHVUC,
    TRANGTHAI
)
VALUES (
    'CT001',
    N'CÔNG TY TNHH THƯƠNG MẠI DỊCH VỤ VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH',
    N'GREEN OCEAN TRANSPORTATION',
    N'GREEN OCEAN TRADING SERVICES INTERNATIONAL TRANSPORTATION COMPANY LIMITED',
    '0312660682',
    '2014-02-25',
    N'Lý Thanh Đức',
    N'84/10 Đường 49, Phường Hiệp Bình, TP. Hồ Chí Minh',
    '0938202369',
    N'Dịch vụ hỗ trợ vận tải và logistics',
    N'Hoạt động'
);


INSERT INTO KhachHang 
    (MAKH, TENKH, DIACHIKH, DIENTHOAIKH, EMAILKH, TRANGTHAI, NGAYDANGKY, GIOITINHKH, NGAYSINHKH)
VALUES
-- Cá nhân Nam
('KH001', N'Nguyễn Văn An', N'12 Lê Lợi, Q.1, TP.HCM', '0901234501', 'an.nguyen@gmail.com', N'Hoạt động', '2023-01-05', N'Nam', '1980-04-15'),
('KH003', N'Lê Minh Cường', N'56 Nguyễn Huệ, Q.1, TP.HCM', '0901234503', 'cuong.le@gmail.com', N'Hoạt động', '2023-02-03', N'Nam', '1975-09-22'),
('KH005', N'Hoàng Văn Em', N'90 Cách Mạng Tháng 8, Q.3, TP.HCM', '0901234505', 'em.hoang@outlook.com', N'Hoạt động', '2023-02-22', N'Nam', '1988-12-05'),
('KH007', N'Vũ Quốc Hùng', N'23 Lý Tự Trọng, Q.1, TP.HCM', '0901234507', 'hung.vu@gmail.com', N'Hoạt động', '2023-03-10', N'Nam', '1983-06-30'),
('KH009', N'Bùi Văn Mạnh', N'67 Nguyễn Thị Minh Khai, Q.3, TP.HCM', '0901234509', 'manh.bui@gmail.com', N'Hoạt động', '2023-03-20', N'Nam', '1979-02-14'),
('KH011', N'Đinh Quang Phúc', N'101 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM', '0901234511', 'phuc.dinh@gmail.com', N'Hoạt động', '2023-04-08', N'Nam', '1991-08-19'),
('KH013', N'Nguyễn Đức Thắng', N'25 Bùi Thị Xuân, Q.1, TP.HCM', '0901234513', 'thang.nguyen2@gmail.com', N'Hoạt động', '2023-04-20', N'Nam', '1986-11-03'),
('KH015', N'Mai Văn Uy', N'49 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM', '0901234515', 'uy.mai@gmail.com', N'Hoạt động', '2023-05-05', N'Nam', '1993-03-27'),
('KH017', N'Dương Minh Xuân', N'73 Nguyễn Kiệm, Q.Gò Vấp, TP.HCM', '0901234517', 'xuan.duong@gmail.com', N'Hoạt động', '2023-05-18', N'Nam', '1977-07-11'),
('KH019', N'Trần Văn Anh', N'97 Phan Văn Trị, Q.Bình Thạnh, TP.HCM', '0901234519', 'anh.tran@gmail.com', N'Hoạt động', '2023-06-01', N'Nam', '1990-01-08'),
('KH023', N'Phùng Văn Chiến', N'14 An Dương Vương, Q.5, TP.HCM', '0901234523', 'chien.phung@gmail.com', N'Hoạt động', '2023-06-20', N'Nam', '1984-05-16'),
('KH025', N'Cao Xuân Dũng', N'38 Hùng Vương, Q.5, TP.HCM', '0901234525', 'dung.cao@gmail.com', N'Hoạt động', '2023-07-10', N'Nam', '1995-10-09'),
('KH027', N'Khúc Văn Phát', N'62 Nguyễn Trãi, Q.5, TP.HCM', '0901234527', 'phat.khuc@gmail.com', N'Hoạt động', '2023-07-22', N'Nam', '1981-04-23'),
('KH029', N'Mã Văn Sơn', N'86 Phù Đổng Thiên Vương, Q.11, TP.HCM', '0901234529', 'son.ma@gmail.com', N'Hoạt động', '2023-08-05', N'Nam', '1978-12-31'),
('KH031', N'Ông Tuấn Minh', N'110 Ba Tháng Hai, Q.10, TP.HCM', '0901234531', 'minh.ong@gmail.com', N'Hoạt động', '2023-08-18', N'Nam', '1987-06-17'),
('KH033', N'Quách Minh Tài', N'34 Lê Thánh Tôn, Q.1, TP.HCM', '0901234533', 'tai.quach@gmail.com', N'Hoạt động', '2023-09-01', N'Nam', '1992-02-28'),
('KH035', N'Sơn Văn Việt', N'58 Hai Bà Trưng, Q.1, TP.HCM', '0901234535', 'viet.son@gmail.com', N'Hoạt động', '2023-09-10', N'Nam', '1985-09-14'),
('KH038', N'Ứng Văn Lộc', N'82 Đinh Tiên Hoàng, Q.3, TP.HCM', '0901234538', 'loc.ung@gmail.com', N'Hoạt động', '2023-09-28', N'Nam', '1976-03-05'),
('KH040', N'Xa Minh Nghĩa', N'106 Lý Chính Thắng, Q.3, TP.HCM', '0901234540', 'nghia.xa@gmail.com', N'Hoạt động', '2023-10-10', N'Nam', '1989-07-20'),
('KH042', N'Điền Văn Phước', N'130 Trần Quốc Thảo, Q.3, TP.HCM', '0901234542', 'phuoc.dien@gmail.com', N'Hoạt động', '2023-10-20', N'Nam', '1994-11-12'),
('KH045', N'Hạ Văn Rạng', N'24 Bình Thới, Q.11, TP.HCM', '0901234545', 'rang.ha@gmail.com', N'Hoạt động', '2023-11-05', N'Nam', '1982-08-06'),
('KH047', N'Khưu Minh Thiện', N'48 Hậu Giang, Q.6, TP.HCM', '0901234547', 'thien.khuu@gmail.com', N'Hoạt động', '2023-11-15', N'Nam', '1991-04-18'),
('KH050', N'Mẫn Văn Vượng', N'72 Minh Phụng, Q.6, TP.HCM', '0901234550', 'vuong.man@gmail.com', N'Hoạt động', '2023-12-01', N'Nam', '1986-01-25'),
('KH052', N'Oai Văn Yên', N'96 Cao Văn Lầu, Q.6, TP.HCM', '0901234552', 'yen.oai@gmail.com', N'Hoạt động', '2023-12-15', N'Nam', '1993-06-07'),

-- Cá nhân Nữ
('KH002', N'Trần Thị Bích', N'34 Hai Bà Trưng, Q.3, TP.HCM', '0901234502', 'bich.tran@gmail.com', N'Hoạt động', '2023-01-12', N'Nữ', '1987-10-30'),
('KH004', N'Phạm Thị Dung', N'78 Đinh Tiên Hoàng, Q.Bình Thạnh, TP.HCM','0901234504', 'dung.pham@yahoo.com', N'Hoạt động', '2023-02-14', N'Nữ', '1992-05-21'),
('KH006', N'Ngô Thị Phương', N'11 Nguyễn Đình Chiểu, Q.3, TP.HCM', '0901234506', 'phuong.ngo@gmail.com', N'Hoạt động', '2023-03-01', N'Nữ', '1985-01-17'),
('KH008', N'Đặng Thị Lan', N'45 Điện Biên Phủ, Q.Bình Thạnh, TP.HCM', '0901234508', 'lan.dang@gmail.com', N'Khóa', '2023-03-15', N'Nữ', '1990-08-03'),
('KH010', N'Trịnh Thị Ngọc', N'89 Võ Thị Sáu, Q.3, TP.HCM', '0901234510', 'ngoc.trinh@gmail.com', N'Hoạt động', '2023-04-02', N'Nữ', '1983-03-25'),
('KH012', N'Lý Thị Quỳnh', N'13 Trần Hưng Đạo, Q.5, TP.HCM', '0901234512', 'quynh.ly@gmail.com', N'Hoạt động', '2023-04-15', N'Nữ', '1996-07-14'),
('KH014', N'Phan Thị Thu', N'37 Phan Đình Phùng, Q.Phú Nhuận, TP.HCM', '0901234514', 'thu.phan@gmail.com', N'Hoạt động', '2023-04-28', N'Nữ', '1988-09-08'),
('KH016', N'Hồ Thị Vân', N'61 Phan Xích Long, Q.Phú Nhuận, TP.HCM', '0901234516', 'van.ho@gmail.com', N'Hoạt động', '2023-05-10', N'Nữ', '1979-12-19'),
('KH018', N'Lưu Thị Yến', N'85 Quang Trung, Q.Gò Vấp, TP.HCM', '0901234518', 'yen.luu@gmail.com', N'Khóa', '2023-05-25', N'Nữ', '1995-04-02'),
('KH020', N'Nguyễn Thị Bảo', N'109 Bạch Đằng, Q.Bình Thạnh, TP.HCM', '0901234520', 'bao.nguyen@gmail.com', N'Hoạt động', '2023-06-08', N'Nữ', '1984-11-27'),
('KH024', N'Tạ Thị Diễm', N'26 Ngô Quyền, Q.5, TP.HCM', '0901234524', 'diem.ta@gmail.com', N'Hoạt động', '2023-07-03', N'Nữ', '1991-06-10'),
('KH026', N'Giang Thị Oanh', N'50 Trần Phú, Q.5, TP.HCM', '0901234526', 'oanh.giang@gmail.com', N'Hoạt động', '2023-07-15', N'Nữ', '1980-02-22'),
('KH028', N'Lâm Thị Quế', N'74 Châu Văn Liêm, Q.5, TP.HCM', '0901234528', 'que.lam@gmail.com', N'Hoạt động', '2023-07-28', N'Nữ', '1986-10-15'),
('KH030', N'Ninh Thị Trang', N'98 Lý Nam Đế, Q.11, TP.HCM', '0901234530', 'trang.ninh@gmail.com', N'Hoạt động', '2023-08-10', N'Nữ', '1993-08-29'),
('KH032', N'Pô Thị Nhung', N'22 Đinh Tiên Hoàng, Q.1, TP.HCM', '0901234532', 'nhung.po@gmail.com', N'Hoạt động', '2023-08-22', N'Nữ', '1977-05-05'),
('KH034', N'Rạng Thị Tuyết', N'46 Mạc Đĩnh Chi, Q.1, TP.HCM', '0901234534', 'tuyet.rang@gmail.com', N'Hoạt động', '2023-09-05', N'Nữ', '1982-01-13'),
('KH037', N'Tống Thị Hoa', N'70 Trương Định, Q.3, TP.HCM', '0901234537', 'hoa.tong@gmail.com', N'Hoạt động', '2023-09-20', N'Nữ', '1989-03-07'),
('KH039', N'Vương Thị Mỹ', N'94 Nguyễn Đình Chiểu, Q.3, TP.HCM', '0901234539', 'my.vuong@gmail.com', N'Hoạt động', '2023-10-05', N'Nữ', '1994-09-23'),
('KH041', N'Yên Thị Oanh', N'118 Võ Văn Tần, Q.3, TP.HCM', '0901234541', 'oanh.yen@gmail.com', N'Hoạt động', '2023-10-15', N'Nữ', '1988-12-01'),
('KH044', N'Giáp Thị Quỳnh', N'12 Lạc Long Quân, Q.11, TP.HCM', '0901234544', 'quynh.giap@gmail.com', N'Hoạt động', '2023-11-01', N'Nữ', '1990-07-16'),
('KH046', N'Im Thị Sương', N'36 Tân Hòa Đông, Q.6, TP.HCM', '0901234546', 'suong.im@gmail.com', N'Hoạt động', '2023-11-10', N'Nữ', '1983-11-04'),
('KH048', N'Liên Thị Uyên', N'60 An Dương Vương, Q.6, TP.HCM', '0901234548', 'uyen.lien@gmail.com', N'Hoạt động', '2023-11-20', N'Nữ', '1987-05-29'),
('KH051', N'Nại Thị Xuân', N'84 Bình Tiên, Q.6, TP.HCM', '0901234551', 'xuan.nai@gmail.com', N'Hoạt động', '2023-12-10', N'Nữ', '1995-02-11'),

-- Khách hàng là công ty (GIOITINHKH và NGAYSINHKH = NULL)
('KH021', N'Công ty TNHH Minh Đạt', N'200 Lý Thường Kiệt, Q.10, TP.HCM', '0901234521', 'info@minhdat.com.vn', N'Hoạt động', '2023-06-12', NULL, NULL),
('KH022', N'Công ty CP Hải Long', N'300 Tô Hiệu, Q.Tân Phú, TP.HCM', '0901234522', 'contact@hailong.vn', N'Hoạt động', '2023-06-15', NULL, NULL),
('KH036', N'Công ty XNK Bình Minh', N'1 Đồng Khởi, Q.1, TP.HCM', '0901234536', 'binhminh@export.vn', N'Hoạt động', '2023-09-15', NULL, NULL),
('KH043', N'Công ty TNHH Đông Á', N'500 Nguyễn Oanh, Q.Gò Vấp, TP.HCM', '0901234543', 'dongasia@gmail.com', N'Hoạt động', '2023-10-25', NULL, NULL),
('KH049', N'Công ty CP Vận Tải Đại Phát', N'88 Hùng Vương, Q.5, TP.HCM', '0901234549', 'daiphat.transport@gmail.com', N'Hoạt động', '2023-11-25', NULL, NULL);
GO

-- ============================================================
-- 2. NHAN VIEN (50 dòng)
-- VAITRO: 'Nhân viên bán hàng', 'Nhân viên bán hàng', 'Nhân viên văn phòng',
--         'Nhân viên quản lý hệ thống', 'Chủ doanh nghiệp'
INSERT INTO NhanVien (MANV, TENNV, NGAYSINHNV, GIOITINHNV, DIACHINV, SDTNV, EMAILNV, VAITRO, TRANGTHAI, NGAYVAOLV) VALUES
('NV001', N'Nguyễn Thị Hương',    '1985-03-12', N'Nữ',  N'15 Trần Hưng Đạo, Q.1, TP.HCM',       '0911000001', 'huong.nguyen@daiduongxanh.vn',   N'Chủ doanh nghiệp',     N'Đang làm việc', '2015-01-01'),
('NV002', N'Lê Quang Trường',     '1982-07-20', N'Nam', N'27 Nguyễn Bỉnh Khiêm, Q.1, TP.HCM',   '0911000002', 'truong.le@daiduongxanh.vn',      N'Nhân viên quản lý hệ thống',    N'Đang làm việc', '2015-03-15'),
('NV003', N'Phạm Thị Mai',        '1990-05-08', N'Nữ',  N'39 Đinh Tiên Hoàng, Q.1, TP.HCM',     '0911000003', 'mai.pham@daiduongxanh.vn',       N'Nhân viên bán hàng',              N'Đang làm việc', '2016-06-01'),
('NV004', N'Trần Văn Đức',        '1988-09-15', N'Nam', N'51 Hai Bà Trưng, Q.3, TP.HCM',         '0911000004', 'duc.tran@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2017-01-10'),
('NV005', N'Hoàng Thị Linh',      '1992-11-25', N'Nữ',  N'63 Lý Tự Trọng, Q.1, TP.HCM',         '0911000005', 'linh.hoang@daiduongxanh.vn',     N'Nhân viên bán hàng',   N'Đang làm việc', '2017-04-20'),
('NV006', N'Ngô Văn Khoa',        '1987-02-14', N'Nam', N'75 Nguyễn Du, Q.1, TP.HCM',            '0911000006', 'khoa.ngo@daiduongxanh.vn',       N'Nhân viên văn phòng',  N'Đang làm việc', '2017-07-01'),
('NV007', N'Vũ Thị Nga',          '1993-06-30', N'Nữ',  N'87 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM',   '0911000007', 'nga.vu@daiduongxanh.vn',         N'Nhân viên bán hàng',              N'Đang làm việc', '2018-01-15'),
('NV008', N'Đặng Văn Lâm',        '1986-04-18', N'Nam', N'99 Cách Mạng Tháng 8, Q.3, TP.HCM',   '0911000008', 'lam.dang@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2018-03-01'),
('NV009', N'Bùi Thị Hà',          '1991-08-22', N'Nữ',  N'111 Trương Định, Q.3, TP.HCM',         '0911000009', 'ha.bui@daiduongxanh.vn',         N'Nhân viên văn phòng',  N'Đang làm việc', '2018-06-10'),
('NV010', N'Trịnh Quốc Bảo',      '1989-12-05', N'Nam', N'123 Võ Thị Sáu, Q.3, TP.HCM',         '0911000010', 'bao.trinh@daiduongxanh.vn',      N'Nhân viên bán hàng',   N'Đang làm việc', '2018-09-20'),
('NV011', N'Đinh Thị Cẩm',        '1994-01-17', N'Nữ',  N'135 Điện Biên Phủ, Q.Bình Thạnh',     '0911000011', 'cam.dinh@daiduongxanh.vn',       N'Nhân viên văn phòng',  N'Đang làm việc', '2019-01-07'),
('NV012', N'Lý Văn Danh',         '1990-03-28', N'Nam', N'147 Nơ Trang Long, Q.Bình Thạnh',      '0911000012', 'danh.ly@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2019-03-15'),
('NV013', N'Nguyễn Thị Em',       '1995-07-09', N'Nữ',  N'159 Bình Lợi, Q.Bình Thạnh',          '0911000013', 'em.nguyen@daiduongxanh.vn',      N'Nhân viên bán hàng',              N'Đang làm việc', '2019-06-01'),
('NV014', N'Phan Văn Hải',        '1988-10-20', N'Nam', N'171 Phan Văn Trị, Q.Bình Thạnh',       '0911000014', 'hai.phan@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2019-09-10'),
('NV015', N'Phùng Thị Giang',     '1993-02-15', N'Nữ',  N'183 Lê Quang Định, Q.Bình Thạnh',     '0911000015', 'giang.phung@daiduongxanh.vn',    N'Nhân viên văn phòng',  N'Đang làm việc', '2020-01-06'),
('NV016', N'Trương Văn Hiệu',     '1986-05-25', N'Nam', N'195 Bạch Đằng, Q.Bình Thạnh',         '0911000016', 'hieu.truong@daiduongxanh.vn',    N'Nhân viên bán hàng',   N'Đang làm việc', '2020-03-01'),
('NV017', N'Lâm Thị Hoa',         '1997-09-12', N'Nữ',  N'207 Xô Viết Nghệ Tĩnh, Q.Bình Thạnh','0911000017', 'hoa.lam@daiduongxanh.vn',        N'Nhân viên văn phòng',  N'Đang làm việc', '2020-06-15'),
('NV018', N'Mã Văn Kiệt',         '1991-12-01', N'Nam', N'219 Chu Văn An, Q.Bình Thạnh',        '0911000018', 'kiet.ma@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2020-09-01'),
('NV019', N'Ninh Thị Loan',       '1996-04-18', N'Nữ',  N'12 Hoàng Hoa Thám, Q.Bình Thạnh',    '0911000019', 'loan.ninh@daiduongxanh.vn',      N'Nhân viên bán hàng',              N'Đang làm việc', '2021-01-04'),
('NV020', N'Ông Văn Long',        '1989-08-30', N'Nam', N'24 Phạm Văn Đồng, Q.Gò Vấp',         '0911000020', 'long.ong@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2021-03-15'),
('NV021', N'Pô Thị Minh',         '1994-11-07', N'Nữ',  N'36 Quang Trung, Q.Gò Vấp',           '0911000021', 'minh.po@daiduongxanh.vn',        N'Nhân viên văn phòng',  N'Đang làm việc', '2021-06-01'),
('NV022', N'Quách Văn Nam',       '1987-01-25', N'Nam', N'48 Nguyễn Kiệm, Q.Gò Vấp',           '0911000022', 'nam.quach@daiduongxanh.vn',      N'Nhân viên bán hàng',   N'Đang làm việc', '2021-09-10'),
('NV023', N'Rạng Thị Oanh',       '1998-06-14', N'Nữ',  N'60 Lê Đức Thọ, Q.Gò Vấp',           '0911000023', 'oanh.rang@daiduongxanh.vn',      N'Nhân viên văn phòng',  N'Đang làm việc', '2021-12-01'),
('NV024', N'Sơn Văn Phong',       '1990-09-02', N'Nam', N'72 Dương Quảng Hàm, Q.Gò Vấp',       '0911000024', 'phong.son@daiduongxanh.vn',      N'Nhân viên bán hàng',   N'Đang làm việc', '2022-01-10'),
('NV025', N'Tống Thị Quyên',      '1995-03-20', N'Nữ',  N'84 Nguyễn Văn Nghi, Q.Gò Vấp',      '0911000025', 'quyen.tong@daiduongxanh.vn',     N'Nhân viên bán hàng',              N'Đang làm việc', '2022-03-01'),
('NV026', N'Ứng Văn Sang',        '1988-07-08', N'Nam', N'96 Phan Huy Ích, Q.Gò Vấp',          '0911000026', 'sang.ung@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2022-06-15'),
('NV027', N'Vương Thị Tâm',       '1999-11-30', N'Nữ',  N'108 Thống Nhất, Q.Gò Vấp',          '0911000027', 'tam.vuong@daiduongxanh.vn',      N'Nhân viên văn phòng',  N'Đang làm việc', '2022-09-01'),
('NV028', N'Xa Văn Tiến',         '1992-02-22', N'Nam', N'120 Trường Chinh, Q.Tân Bình',        '0911000028', 'tien.xa@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2022-11-10'),
('NV029', N'Yên Thị Uyên',        '1997-05-15', N'Nữ',  N'132 Cộng Hòa, Q.Tân Bình',          '0911000029', 'uyen.yen@daiduongxanh.vn',       N'Nhân viên văn phòng',  N'Đang làm việc', '2023-01-03'),
('NV030', N'Điền Văn Vũ',         '1991-08-10', N'Nam', N'144 Hoàng Văn Thụ, Q.Tân Bình',      '0911000030', 'vu.dien@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2023-02-01'),
('NV031', N'Giáp Thị Xuân',       '1993-10-28', N'Nữ',  N'156 Nguyễn Thái Bình, Q.Tân Bình',  '0911000031', 'xuan.giap@daiduongxanh.vn',      N'Nhân viên văn phòng',  N'Đang làm việc', '2023-03-15'),
('NV032', N'Hạ Văn Yên',          '1989-01-05', N'Nam', N'168 Bàu Cát, Q.Tân Bình',            '0911000032', 'yen.ha@daiduongxanh.vn',         N'Nhân viên bán hàng',   N'Đang làm việc', '2023-04-01'),
('NV033', N'Im Thị Ánh',          '1996-04-20', N'Nữ',  N'180 Phổ Quang, Q.Tân Bình',          '0911000033', 'anh.im@daiduongxanh.vn',         N'Nhân viên bán hàng',              N'Đang làm việc', '2023-05-10'),
('NV034', N'Khưu Minh Bảo',       '1990-07-14', N'Nam', N'192 Bùi Đình Túy, Q.Bình Thạnh',     '0911000034', 'bao.khuu@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2023-06-01'),
('NV035', N'Liên Thị Châu',       '1998-09-28', N'Nữ',  N'204 Đinh Bộ Lĩnh, Q.Bình Thạnh',    '0911000035', 'chau.lien@daiduongxanh.vn',      N'Nhân viên văn phòng',  N'Đang làm việc', '2023-07-15'),
('NV036', N'Mẫn Văn Duy',         '1987-12-11', N'Nam', N'14 Đinh Tiên Hoàng, Q.Bình Thạnh',   '0911000036', 'duy.man@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2023-08-01'),
('NV037', N'Nại Thị Hảo',         '1994-03-07', N'Nữ',  N'26 Nguyễn Hữu Cảnh, Q.Bình Thạnh',  '0911000037', 'hao.nai@daiduongxanh.vn',        N'Nhân viên văn phòng',  N'Đang làm việc', '2023-08-15'),
('NV038', N'Oai Văn Khải',        '1991-06-25', N'Nam', N'38 Lê Văn Duyệt, Q.Bình Thạnh',     '0911000038', 'khai.oai@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2023-09-01'),
('NV039', N'Phan Thị Lệ',         '1997-10-16', N'Nữ',  N'50 Đặng Văn Bi, Q.Thủ Đức',         '0911000039', 'le.phan@daiduongxanh.vn',        N'Nhân viên văn phòng',  N'Đang làm việc', '2023-09-20'),
('NV040', N'Quang Văn Minh',      '1993-01-30', N'Nam', N'62 Lê Văn Việt, Q.9',                '0911000040', 'minh.quang@daiduongxanh.vn',     N'Nhân viên bán hàng',   N'Đang làm việc', '2023-10-01'),
('NV041', N'Rũi Thị Nhi',         '1999-05-18', N'Nữ',  N'74 Đỗ Xuân Hợp, Q.9',              '0911000041', 'nhi.rui@daiduongxanh.vn',        N'Nhân viên văn phòng',  N'Đang làm việc', '2023-10-15'),
('NV042', N'Sào Văn Phú',         '1990-08-08', N'Nam', N'86 Tăng Nhơn Phú, Q.9',             '0911000042', 'phu.sao@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2023-11-01'),
('NV043', N'Thảo Thị Quyên',      '1995-11-22', N'Nữ',  N'98 Phước Long, Q.9',                '0911000043', 'quyen.thao@daiduongxanh.vn',     N'Nhân viên bán hàng',              N'Đang làm việc', '2023-11-15'),
('NV044', N'Uy Văn Sáng',         '1988-02-28', N'Nam', N'110 Long Bình, Q.9',                 '0911000044', 'sang.uy@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Đang làm việc', '2023-12-01'),
('NV045', N'Văn Thị Thủy',        '1996-06-14', N'Nữ',  N'22 Nguyễn Xí, Q.Bình Thạnh',        '0911000045', 'thuy.van@daiduongxanh.vn',       N'Nhân viên văn phòng',  N'Đang làm việc', '2024-01-02'),
('NV046', N'Xa Minh Triết',       '1992-09-05', N'Nam', N'34 Vũ Huy Tấn, Q.Bình Thạnh',       '0911000046', 'triet.xa@daiduongxanh.vn',       N'Nhân viên bán hàng',   N'Đang làm việc', '2024-02-01'),
('NV047', N'Yến Thị Uyên',        '1998-12-20', N'Nữ',  N'46 Ngô Tất Tố, Q.Bình Thạnh',       '0911000047', 'uyen.yen2@daiduongxanh.vn',      N'Nhân viên văn phòng',  N'Đang làm việc', '2024-03-01'),
('NV048', N'Điền Văn Vinh',       '1991-03-15', N'Nam', N'58 Bùi Hữu Nghĩa, Q.Bình Thạnh',    '0911000048', 'vinh.dien@daiduongxanh.vn',      N'Nhân viên bán hàng',   N'Đang làm việc', '2024-04-01'),
('NV049', N'Giáp Thị Xuyến',      '1997-07-01', N'Nữ',  N'70 Chu Văn An, Q.Bình Thạnh',       '0911000049', 'xuyen.giap@daiduongxanh.vn',     N'Nhân viên văn phòng',  N'Nghỉ việc',     '2022-05-01'),
('NV050', N'Hân Văn Yên',         '1989-10-18', N'Nam', N'82 Bạch Đằng, Q.Hải Châu, Đà Nẵng', '0911000050', 'yen.han@daiduongxanh.vn',        N'Nhân viên bán hàng',   N'Nghỉ việc',     '2020-08-01');
GO
 
-- ============================================================
-- 3. TAI KHOAN
INSERT INTO TaiKhoan (MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV) VALUES
('TK026', 'kh_oanh.giang',   '$2b$12$hash026', N'Khách hàng', N'Hoạt động', 'KH026', NULL),
('TK027', 'kh_phat.khuc',    '$2b$12$hash027', N'Khách hàng', N'Hoạt động', 'KH027', NULL),
('TK028', 'kh_que.lam',      '$2b$12$hash028', N'Khách hàng', N'Hoạt động', 'KH028', NULL),
('TK029', 'kh_son.ma',       '$2b$12$hash029', N'Khách hàng', N'Hoạt động', 'KH029', NULL),
('TK030', 'kh_trang.ninh',   '$2b$12$hash030', N'Khách hàng', N'Hoạt động', 'KH030', NULL),
('TK031', 'kh_minh.ong',     '$2b$12$hash031', N'Khách hàng', N'Hoạt động', 'KH031', NULL),
('TK032', 'kh_nhung.po',     '$2b$12$hash032', N'Khách hàng', N'Hoạt động', 'KH032', NULL),
('TK033', 'kh_tai.quach',    '$2b$12$hash033', N'Khách hàng', N'Hoạt động', 'KH033', NULL),
('TK034', 'kh_tuyet.rang',   '$2b$12$hash034', N'Khách hàng', N'Hoạt động', 'KH034', NULL),
('TK035', 'kh_viet.son',     '$2b$12$hash035', N'Khách hàng', N'Hoạt động', 'KH035', NULL),
('TK036', 'kh_binhminh',     '$2b$12$hash036', N'Khách hàng', N'Hoạt động', 'KH036', NULL),
('TK037', 'kh_hoa.tong',     '$2b$12$hash037', N'Khách hàng', N'Hoạt động', 'KH037', NULL),
('TK038', 'kh_loc.ung',      '$2b$12$hash038', N'Khách hàng', N'Hoạt động', 'KH038', NULL),
('TK039', 'kh_my.vuong',     '$2b$12$hash039', N'Khách hàng', N'Hoạt động', 'KH039', NULL),
('TK040', 'kh_nghia.xa',     '$2b$12$hash040', N'Khách hàng', N'Hoạt động', 'KH040', NULL),
('TK041', 'kh_oanh.yen',     '$2b$12$hash041', N'Khách hàng', N'Hoạt động', 'KH041', NULL),
('TK042', 'kh_phuoc.dien',   '$2b$12$hash042', N'Khách hàng', N'Hoạt động', 'KH042', NULL),
('TK043', 'kh_dongasia',     '$2b$12$hash043', N'Khách hàng', N'Hoạt động', 'KH043', NULL),
('TK044', 'kh_quynh.giap',   '$2b$12$hash044', N'Khách hàng', N'Hoạt động', 'KH044', NULL),
('TK045', 'kh_rang.ha',      '$2b$12$hash045', N'Khách hàng', N'Hoạt động', 'KH045', NULL),
('TK046', 'kh_suong.im',     '$2b$12$hash046', N'Khách hàng', N'Hoạt động', 'KH046', NULL),
('TK047', 'kh_thien.khuu',   '$2b$12$hash047', N'Khách hàng', N'Hoạt động', 'KH047', NULL),
('TK048', 'kh_uyen.lien',    '$2b$12$hash048', N'Khách hàng', N'Hoạt động', 'KH048', NULL),
('TK049', 'kh_daiphat',      '$2b$12$hash049', N'Khách hàng', N'Hoạt động', 'KH049', NULL),
('TK050', 'kh_vuong.man',    '$2b$12$hash050', N'Khách hàng', N'Hoạt động', 'KH050', NULL),
('TK051', 'kh_xuan.nai',     '$2b$12$hash051', N'Khách hàng', N'Hoạt động', 'KH051', NULL),
('TK052', 'kh_yen.oai',      '$2b$12$hash052', N'Khách hàng', N'Hoạt động', 'KH052', NULL);
GO
INSERT INTO TaiKhoan (MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV) VALUES
('TK121', 'nv_minh.po',      '$2b$12$hash121', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV021'),
('TK122', 'nv_nam.quach',    '$2b$12$hash122', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV022'),
('TK123', 'nv_oanh.rang',    '$2b$12$hash123', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV023'),
('TK124', 'nv_phong.son',    '$2b$12$hash124', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV024'),
('TK125', 'nv_quyen.tong',   '$2b$12$hash125', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV025'),
('TK126', 'nv_sang.ung',     '$2b$12$hash126', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV026'),
('TK127', 'nv_tam.vuong',    '$2b$12$hash127', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV027'),
('TK128', 'nv_tien.xa',      '$2b$12$hash128', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV028'),
('TK129', 'nv_uyen.yen',     '$2b$12$hash129', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV029'),
('TK130', 'nv_vu.dien',      '$2b$12$hash130', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV030'),
('TK131', 'nv_xuan.giap',    '$2b$12$hash131', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV031'),
('TK132', 'nv_yen.ha',       '$2b$12$hash132', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV032'),
('TK133', 'nv_anh.im',       '$2b$12$hash133', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV033'),
('TK134', 'nv_bao.khuu',     '$2b$12$hash134', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV034'),
('TK135', 'nv_chau.lien',    '$2b$12$hash135', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV035'),
('TK136', 'nv_duy.man',      '$2b$12$hash136', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV036'),
('TK137', 'nv_hao.nai',      '$2b$12$hash137', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV037'),
('TK138', 'nv_khai.oai',     '$2b$12$hash138', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV038'),
('TK139', 'nv_le.phan',      '$2b$12$hash139', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV039'),
('TK140', 'nv_minh.quang',   '$2b$12$hash140', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV040'),
('TK141', 'nv_nhi.rui',      '$2b$12$hash141', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV041'),
('TK142', 'nv_phu.sao',      '$2b$12$hash142', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV042'),
('TK143', 'nv_quyen.thao',   '$2b$12$hash143', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV043'),
('TK144', 'nv_sang.uy',      '$2b$12$hash144', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV044'),
('TK145', 'nv_thuy.van',     '$2b$12$hash145', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV045'),
('TK146', 'nv_triet.xa',     '$2b$12$hash146', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV046'),
('TK147', 'nv_uyen.yen2',    '$2b$12$hash147', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV047'),
('TK148', 'nv_vinh.dien',    '$2b$12$hash148', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV048'),
-- NV049 và NV050: Nghỉ việc → tài khoản Khóa
('TK149', 'nv_xuyen.giap',   '$2b$12$hash149', N'Nhân viên văn phòng',        N'Khóa',       NULL, 'NV049'),
('TK150', 'nv_yen.han',      '$2b$12$hash150', N'Nhân viên bán hàng',         N'Khóa',       NULL, 'NV050');
GO
 




INSERT INTO TaiKhoan (MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV) VALUES
('TK001', 'kh_an.nguyen',   '$2b$12$hash001', N'Khách hàng', N'Hoạt động', 'KH001', NULL),
('TK002', 'kh_bich.tran',   '$2b$12$hash002', N'Khách hàng', N'Hoạt động', 'KH002', NULL),
('TK003', 'kh_cuong.le',    '$2b$12$hash003', N'Khách hàng', N'Hoạt động', 'KH003', NULL),
('TK004', 'kh_dung.pham',   '$2b$12$hash004', N'Khách hàng', N'Hoạt động', 'KH004', NULL),
('TK005', 'kh_em.hoang',    '$2b$12$hash005', N'Khách hàng', N'Hoạt động', 'KH005', NULL),
('TK006', 'kh_phuong.ngo',  '$2b$12$hash006', N'Khách hàng', N'Hoạt động', 'KH006', NULL),
('TK007', 'kh_hung.vu',     '$2b$12$hash007', N'Khách hàng', N'Hoạt động', 'KH007', NULL),
('TK008', 'kh_lan.dang',    '$2b$12$hash008', N'Khách hàng', N'Khóa',      'KH008', NULL),
('TK009', 'kh_manh.bui',    '$2b$12$hash009', N'Khách hàng', N'Hoạt động', 'KH009', NULL),
('TK010', 'kh_ngoc.trinh',  '$2b$12$hash010', N'Khách hàng', N'Hoạt động', 'KH010', NULL),
('TK011', 'kh_phuc.dinh',   '$2b$12$hash011', N'Khách hàng', N'Hoạt động', 'KH011', NULL),
('TK012', 'kh_quynh.ly',    '$2b$12$hash012', N'Khách hàng', N'Hoạt động', 'KH012', NULL),
('TK013', 'kh_thang.nguyen','$2b$12$hash013', N'Khách hàng', N'Hoạt động', 'KH013', NULL),
('TK014', 'kh_thu.phan',    '$2b$12$hash014', N'Khách hàng', N'Hoạt động', 'KH014', NULL),
('TK015', 'kh_uy.mai',      '$2b$12$hash015', N'Khách hàng', N'Hoạt động', 'KH015', NULL),
('TK016', 'kh_van.ho',      '$2b$12$hash016', N'Khách hàng', N'Hoạt động', 'KH016', NULL),
('TK017', 'kh_xuan.duong',  '$2b$12$hash017', N'Khách hàng', N'Hoạt động', 'KH017', NULL),
('TK018', 'kh_yen.luu',     '$2b$12$hash018', N'Khách hàng', N'Khóa',      'KH018', NULL),
('TK019', 'kh_anh.tran',    '$2b$12$hash019', N'Khách hàng', N'Hoạt động', 'KH019', NULL),
('TK020', 'kh_bao.nguyen',  '$2b$12$hash020', N'Khách hàng', N'Hoạt động', 'KH020', NULL),
('TK021', 'kh_minhdat',     '$2b$12$hash021', N'Khách hàng', N'Hoạt động', 'KH021', NULL),
('TK022', 'kh_hailong',     '$2b$12$hash022', N'Khách hàng', N'Hoạt động', 'KH022', NULL),
('TK023', 'kh_chien.phung', '$2b$12$hash023', N'Khách hàng', N'Hoạt động', 'KH023', NULL),
('TK024', 'kh_diem.ta',     '$2b$12$hash024', N'Khách hàng', N'Hoạt động', 'KH024', NULL),
('TK025', 'kh_dung.cao',    '$2b$12$hash025', N'Khách hàng', N'Hoạt động', 'KH025', NULL),
('TK026', 'kh_oanh.giang',   '$2b$12$hash026', N'Khách hàng', N'Hoạt động', 'KH026', NULL),
('TK027', 'kh_phat.khuc',    '$2b$12$hash027', N'Khách hàng', N'Hoạt động', 'KH027', NULL),
('TK028', 'kh_que.lam',      '$2b$12$hash028', N'Khách hàng', N'Hoạt động', 'KH028', NULL),
('TK029', 'kh_son.ma',       '$2b$12$hash029', N'Khách hàng', N'Hoạt động', 'KH029', NULL),
('TK030', 'kh_trang.ninh',   '$2b$12$hash030', N'Khách hàng', N'Hoạt động', 'KH030', NULL),
('TK031', 'kh_minh.ong',     '$2b$12$hash031', N'Khách hàng', N'Hoạt động', 'KH031', NULL),
('TK032', 'kh_nhung.po',     '$2b$12$hash032', N'Khách hàng', N'Hoạt động', 'KH032', NULL),
('TK033', 'kh_tai.quach',    '$2b$12$hash033', N'Khách hàng', N'Hoạt động', 'KH033', NULL),
('TK034', 'kh_tuyet.rang',   '$2b$12$hash034', N'Khách hàng', N'Hoạt động', 'KH034', NULL),
('TK035', 'kh_viet.son',     '$2b$12$hash035', N'Khách hàng', N'Hoạt động', 'KH035', NULL),
('TK036', 'kh_binhminh',     '$2b$12$hash036', N'Khách hàng', N'Hoạt động', 'KH036', NULL),
('TK037', 'kh_hoa.tong',     '$2b$12$hash037', N'Khách hàng', N'Hoạt động', 'KH037', NULL),
('TK038', 'kh_loc.ung',      '$2b$12$hash038', N'Khách hàng', N'Hoạt động', 'KH038', NULL),
('TK039', 'kh_my.vuong',     '$2b$12$hash039', N'Khách hàng', N'Hoạt động', 'KH039', NULL),
('TK040', 'kh_nghia.xa',     '$2b$12$hash040', N'Khách hàng', N'Hoạt động', 'KH040', NULL),
('TK041', 'kh_oanh.yen',     '$2b$12$hash041', N'Khách hàng', N'Hoạt động', 'KH041', NULL),
('TK042', 'kh_phuoc.dien',   '$2b$12$hash042', N'Khách hàng', N'Hoạt động', 'KH042', NULL),
('TK043', 'kh_dongasia',     '$2b$12$hash043', N'Khách hàng', N'Hoạt động', 'KH043', NULL),
('TK044', 'kh_quynh.giap',   '$2b$12$hash044', N'Khách hàng', N'Hoạt động', 'KH044', NULL),
('TK045', 'kh_rang.ha',      '$2b$12$hash045', N'Khách hàng', N'Hoạt động', 'KH045', NULL),
('TK046', 'kh_suong.im',     '$2b$12$hash046', N'Khách hàng', N'Hoạt động', 'KH046', NULL),
('TK047', 'kh_thien.khuu',   '$2b$12$hash047', N'Khách hàng', N'Hoạt động', 'KH047', NULL),
('TK048', 'kh_uyen.lien',    '$2b$12$hash048', N'Khách hàng', N'Hoạt động', 'KH048', NULL),
('TK049', 'kh_daiphat',      '$2b$12$hash049', N'Khách hàng', N'Hoạt động', 'KH049', NULL),
('TK050', 'kh_vuong.man',    '$2b$12$hash050', N'Khách hàng', N'Hoạt động', 'KH050', NULL),
('TK051', 'kh_xuan.nai',     '$2b$12$hash051', N'Khách hàng', N'Hoạt động', 'KH051', NULL),
('TK052', 'kh_yen.oai',      '$2b$12$hash052', N'Khách hàng', N'Hoạt động', 'KH052', NULL),

-- Tài khoản nhân viên
('TK101', 'nv_huong.nguyen', '$2b$12$hash101', N'Chủ doanh nghiệp',           N'Hoạt động', NULL, 'NV001'),
('TK102', 'nv_truong.le',    '$2b$12$hash102', N'Nhân viên quản lý hệ thống', N'Hoạt động', NULL, 'NV002'),
('TK103', 'nv_mai.pham',     '$2b$12$hash103', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV003'),
('TK104', 'nv_duc.tran',     '$2b$12$hash104', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV004'),
('TK105', 'nv_linh.hoang',   '$2b$12$hash105', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV005'),
('TK106', 'nv_khoa.ngo',     '$2b$12$hash106', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV006'),
('TK107', 'nv_nga.vu',       '$2b$12$hash107', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV007'),
('TK108', 'nv_lam.dang',     '$2b$12$hash108', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV008'),
('TK109', 'nv_ha.bui',       '$2b$12$hash109', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV009'),
('TK110', 'nv_bao.trinh',    '$2b$12$hash110', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV010'),
('TK111', 'nv_cam.dinh',     '$2b$12$hash111', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV011'),
('TK112', 'nv_danh.ly',      '$2b$12$hash112', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV012'),
('TK113', 'nv_em.nguyen',    '$2b$12$hash113', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV013'),
('TK114', 'nv_hai.phan',     '$2b$12$hash114', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV014'),
('TK115', 'nv_giang.phung',  '$2b$12$hash115', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV015'),
('TK116', 'nv_hieu.truong',  '$2b$12$hash116', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV016'),
('TK117', 'nv_hoa.lam',      '$2b$12$hash117', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV017'),
('TK118', 'nv_kiet.ma',      '$2b$12$hash118', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV018'),
('TK119', 'nv_loan.ninh',    '$2b$12$hash119', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV019'),
('TK120', 'nv_long.ong',     '$2b$12$hash120', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV020'),
('TK121', 'nv_minh.po',      '$2b$12$hash121', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV021'),
('TK122', 'nv_nam.quach',    '$2b$12$hash122', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV022'),
('TK123', 'nv_oanh.rang',    '$2b$12$hash123', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV023'),
('TK124', 'nv_phong.son',    '$2b$12$hash124', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV024'),
('TK125', 'nv_quyen.tong',   '$2b$12$hash125', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV025'),
('TK126', 'nv_sang.ung',     '$2b$12$hash126', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV026'),
('TK127', 'nv_tam.vuong',    '$2b$12$hash127', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV027'),
('TK128', 'nv_tien.xa',      '$2b$12$hash128', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV028'),
('TK129', 'nv_uyen.yen',     '$2b$12$hash129', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV029'),
('TK130', 'nv_vu.dien',      '$2b$12$hash130', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV030'),
('TK131', 'nv_xuan.giap',    '$2b$12$hash131', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV031'),
('TK132', 'nv_yen.ha',       '$2b$12$hash132', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV032'),
('TK133', 'nv_anh.im',       '$2b$12$hash133', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV033'),
('TK134', 'nv_bao.khuu',     '$2b$12$hash134', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV034'),
('TK135', 'nv_chau.lien',    '$2b$12$hash135', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV035'),
('TK136', 'nv_duy.man',      '$2b$12$hash136', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV036'),
('TK137', 'nv_hao.nai',      '$2b$12$hash137', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV037'),
('TK138', 'nv_khai.oai',     '$2b$12$hash138', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV038'),
('TK139', 'nv_le.phan',      '$2b$12$hash139', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV039'),
('TK140', 'nv_minh.quang',   '$2b$12$hash140', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV040'),
('TK141', 'nv_nhi.rui',      '$2b$12$hash141', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV041'),
('TK142', 'nv_phu.sao',      '$2b$12$hash142', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV042'),
('TK143', 'nv_quyen.thao',   '$2b$12$hash143', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV043'),
('TK144', 'nv_sang.uy',      '$2b$12$hash144', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV044'),
('TK145', 'nv_thuy.van',     '$2b$12$hash145', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV045'),
('TK146', 'nv_triet.xa',     '$2b$12$hash146', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV046'),
('TK147', 'nv_uyen.yen2',    '$2b$12$hash147', N'Nhân viên văn phòng',        N'Hoạt động', NULL, 'NV047'),
('TK148', 'nv_vinh.dien',    '$2b$12$hash148', N'Nhân viên bán hàng',         N'Hoạt động', NULL, 'NV048'),
-- NV049 và NV050: Nghỉ việc → tài khoản Khóa
('TK149', 'nv_xuyen.giap',   '$2b$12$hash149', N'Nhân viên văn phòng',        N'Khóa',       NULL, 'NV049'),
('TK150', 'nv_yen.han',      '$2b$12$hash150', N'Nhân viên bán hàng',         N'Khóa',       NULL, 'NV050');
GO
 
-- ============================================================
-- 4. NHOM DICH VU (nhóm mục)
-- ============================================================
INSERT INTO NhomDichVu (MANHOM, TENNHOM, MOTA, TRANGTHAI) VALUES
('NDV001', N'Vận tải nội địa',          N'Dịch vụ vận chuyển hàng hóa trong nước bằng đường bộ, đường thủy', N'Hoạt động'),
('NDV002', N'Vận tải quốc tế',          N'Dịch vụ xuất nhập khẩu, vận chuyển hàng hóa qua biên giới và đường biển quốc tế',  N'Hoạt động'),
('NDV003', N'Kho bãi & Lưu trữ',        N'Dịch vụ thuê kho bãi, bốc xếp hàng hóa, quản lý tồn kho', N'Hoạt động'),
('NDV004', N'Thủ tục hải quan',         N'Dịch vụ khai báo hải quan, xin giấy phép xuất nhập khẩu',  N'Hoạt động'),
('NDV005', N'Giao nhận chuyển phát',    N'Dịch vụ giao nhận hàng tận nơi, chuyển phát nhanh trong và ngoài nước',   N'Hoạt động'),
('NDV006', N'Tư vấn logistics',         N'Dịch vụ tư vấn chuỗi cung ứng, tối ưu tuyến đường và chi phí vận chuyển',  N'Hoạt động'),
('NDV007', N'Vận chuyển hàng siêu trường siêu trọng', N'Dịch vụ vận chuyển máy móc công nghiệp, thiết bị cỡ lớn',   N'Ẩn');
GO
 
-- ============================================================
-- 5. DICH VU
-- ============================================================
INSERT INTO DichVu (MADV, TENDV, GIABAN, DONVITINH, MOTA, TRANGTHAI, MANHOM) VALUES
-- Vận tải nội địa
('DV001', N'Vận chuyển hàng lẻ LCL nội địa',         1500000,   N'Chuyến',  N'Vận chuyển hàng lẻ ghép chung xe, phạm vi toàn quốc',                 N'Đang cung cấp', 'NDV001'),
('DV002', N'Vận chuyển hàng nguyên xe FTL nội địa',  8000000,   N'Chuyến',  N'Thuê nguyên xe tải từ 5-15 tấn, giao hàng toàn quốc',                 N'Đang cung cấp', 'NDV001'),
('DV003', N'Vận chuyển đường thủy nội địa',           5000000,   N'Chuyến',  N'Vận chuyển bằng sà lan, phà; phù hợp hàng cồng kềnh, ĐBSCL',         N'Đang cung cấp', 'NDV001'),
('DV004', N'Vận chuyển hàng lạnh',                   12000000,  N'Chuyến',  N'Xe lạnh chuyên dụng, nhiệt độ -20°C đến +15°C',                       N'Đang cung cấp', 'NDV001'),
('DV005', N'Vận chuyển container 20 feet nội địa',   15000000,  N'Container',N'Vận chuyển container 20ft đường bộ trong nước',                       N'Đang cung cấp', 'NDV001'),
('DV006', N'Vận chuyển container 40 feet nội địa',   22000000,  N'Container',N'Vận chuyển container 40ft đường bộ trong nước',                       N'Đang cung cấp', 'NDV001'),
-- Vận tải quốc tế
('DV007', N'Vận tải biển quốc tế FCL',               45000000,  N'Container',N'Vận chuyển nguyên container đường biển quốc tế, FCL',                 N'Đang cung cấp', 'NDV002'),
('DV008', N'Vận tải biển quốc tế LCL',               18000000,  N'Lô hàng', N'Vận chuyển hàng lẻ ghép chung container đường biển',                  N'Đang cung cấp', 'NDV002'),
('DV009', N'Vận tải hàng không quốc tế',              8000000,  N'Kg',       N'Vận chuyển hàng hóa bằng đường hàng không, các hãng bay quốc tế',     N'Đang cung cấp', 'NDV002'),
('DV010', N'Vận tải đường bộ xuyên biên giới',       25000000,  N'Chuyến',  N'Vận chuyển đường bộ qua cửa khẩu Việt Nam - Trung Quốc, Campuchia',   N'Đang cung cấp', 'NDV002'),
-- Kho bãi
('DV011', N'Thuê kho thường',                          500000,   N'Ngày/CBM',N'Kho hàng thường nhiệt độ môi trường, diện tích linh hoạt',             N'Đang cung cấp', 'NDV003'),
('DV012', N'Thuê kho lạnh',                           1200000,  N'Ngày/CBM',N'Kho lạnh bảo quản thực phẩm, dược phẩm',                             N'Đang cung cấp', 'NDV003'),
('DV013', N'Dịch vụ bốc xếp hàng hóa',               2000000,  N'Tấn',      N'Bốc dỡ, sắp xếp hàng hóa tại kho và bến bãi',                       N'Đang cung cấp', 'NDV003'),
('DV014', N'Đóng gói và palletize',                   3500000,  N'Tấn',      N'Đóng kiện, bọc màng co, palletize hàng hóa xuất khẩu',               N'Đang cung cấp', 'NDV003'),
-- Hải quan
('DV015', N'Khai báo hải quan xuất khẩu',            3000000,   N'Tờ khai', N'Khai báo C/O, HS code, tờ khai xuất khẩu',                           N'Đang cung cấp', 'NDV004'),
('DV016', N'Khai báo hải quan nhập khẩu',            4000000,   N'Tờ khai', N'Khai báo hải quan, xử lý thuế nhập khẩu, kiểm tra chuyên ngành',     N'Đang cung cấp', 'NDV004'),
('DV017', N'Xin giấy phép xuất nhập khẩu',          10000000,  N'Hồ sơ',   N'Tư vấn và xin các loại giấy phép chuyên ngành XNK',                   N'Đang cung cấp', 'NDV004'),
-- Giao nhận
('DV018', N'Giao nhận chuyển phát nội thành',         150000,   N'Kiện',    N'Giao nhận trong nội thành TP.HCM và vùng lân cận trong ngày',         N'Đang cung cấp', 'NDV005'),
('DV019', N'Giao nhận chuyển phát liên tỉnh',         300000,   N'Kiện',    N'Giao nhận hàng hóa các tỉnh thành, thời gian 1-3 ngày',               N'Đang cung cấp', 'NDV005'),
('DV020', N'Dịch vụ Door-to-Door quốc tế',          12000000,  N'Kiện',    N'Giao tận cửa hàng quốc tế, bao gồm thủ tục hải quan hai đầu',         N'Đang cung cấp', 'NDV005'),
-- Tư vấn
('DV021', N'Tư vấn tối ưu chuỗi cung ứng',          20000000,  N'Hợp đồng',N'Phân tích và tối ưu hóa toàn bộ chuỗi cung ứng cho doanh nghiệp',    N'Đang cung cấp', 'NDV006'),
('DV022', N'Tư vấn lựa chọn phương thức vận tải',    5000000,  N'Buổi',    N'Tư vấn chuyên sâu so sánh chi phí và phương án vận chuyển',           N'Đang cung cấp', 'NDV006'),
('DV023', N'Kiểm toán logistics',                    15000000,  N'Dự án',   N'Rà soát, đánh giá chi phí logistics và đề xuất cải tiến',             N'Ngừng cung cấp','NDV006');
GO
 
-- ============================================================
-- 6. DON DICH VU (55 đơn, trạng thái đa dạng)
-- MANV_TIEPNHAN dùng NV với VAITRO = 'Nhân viên bán hàng'
-- LƯU Ý: Bỏ qua trigger kiểm tra VAITRO = 'Tiếp nhận đơn'
-- vì CHECK constraint chỉ cho phép 5 giá trị cố định
-- ============================================================
INSERT INTO DonDichVu (MADON, NGAYDAT, NGAYTHUCHIEN, DIEMDI, DIEMDEN, GHICHU, TRANGTHAI, MAKH, MANV_TIEPNHAN) VALUES
-- Đơn Hoàn thành (20 đơn)
('DDV001', '2024-01-05 08:00', '2024-01-07 08:00', N'Cảng Cát Lái, TP.HCM',       N'KCN Bắc Ninh, Bắc Ninh',          N'Hàng điện tử xuất kho',            N'Hoàn thành', 'KH001', 'NV004'),
('DDV002', '2024-01-10 09:00', '2024-01-12 09:00', N'KCN Tân Bình, TP.HCM',       N'Cảng Hải Phòng',                  N'Hàng may mặc xuất khẩu',            N'Hoàn thành', 'KH002', 'NV005'),
('DDV003', '2024-01-15 10:00', '2024-01-16 10:00', N'Bình Dương',                  N'Long An',                         N'Phân bón nông nghiệp',              N'Hoàn thành', 'KH003', 'NV008'),
('DDV004', '2024-01-20 08:30', '2024-01-22 08:30', N'Cảng Cát Lái, TP.HCM',       N'Hà Nội',                          N'Hàng gia dụng nhập khẩu',           N'Hoàn thành', 'KH004', 'NV010'),
('DDV005', '2024-01-25 14:00', '2024-01-27 14:00', N'Vũng Tàu',                    N'Cần Thơ',                         N'Thiết bị xây dựng',                 N'Hoàn thành', 'KH005', 'NV012'),
('DDV006', '2024-02-01 08:00', '2024-02-03 08:00', N'TP.HCM',                      N'Campuchia (Phnom Penh)',           N'Hàng tiêu dùng xuất khẩu',          N'Hoàn thành', 'KH021', 'NV014'),
('DDV007', '2024-02-05 09:30', '2024-02-07 09:30', N'Kho DDX, Bình Dương',         N'TP. Đà Nẵng',                     N'Hàng điện lạnh',                    N'Hoàn thành', 'KH006', 'NV016'),
('DDV008', '2024-02-10 10:00', '2024-02-11 10:00', N'KCN Sóng Thần, Bình Dương',  N'Cảng Tiên Sa, Đà Nẵng',           N'Linh kiện điện tử',                 N'Hoàn thành', 'KH007', 'NV018'),
('DDV009', '2024-02-15 08:00', '2024-02-17 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Thực phẩm đông lạnh - xe lạnh',    N'Hoàn thành', 'KH009', 'NV020'),
('DDV010', '2024-02-20 09:00', '2024-02-21 09:00', N'Cảng Cát Lái, TP.HCM',       N'KCN Đồng Nai',                    N'Container rỗng trả về',             N'Hoàn thành', 'KH022', 'NV004'),
('DDV011', '2024-03-01 08:00', '2024-03-03 08:00', N'Kho lạnh DDX, TP.HCM',        N'Hà Nội (kho lạnh đối tác)',       N'Thủy sản xuất khẩu đông lạnh',      N'Hoàn thành', 'KH010', 'NV005'),
('DDV012', '2024-03-05 10:00', '2024-03-07 10:00', N'KCN Thủ Dầu Một, Bình Dương',N'Cảng Cái Mép, BRVT',              N'Máy móc xuất khẩu',                 N'Hoàn thành', 'KH011', 'NV008'),
('DDV013', '2024-03-10 09:00', '2024-03-11 09:00', N'Kho Gò Vấp, TP.HCM',         N'Tiền Giang',                      N'Vật liệu xây dựng',                 N'Hoàn thành', 'KH012', 'NV010'),
('DDV014', '2024-03-15 08:30', '2024-03-17 08:30', N'TP.HCM',                      N'Trung Quốc (Quảng Châu)',         N'Hàng nông sản XK',                  N'Hoàn thành', 'KH036', 'NV012'),
('DDV015', '2024-03-20 10:00', '2024-03-22 10:00', N'Đà Nẵng',                     N'TP.HCM',                          N'Đồ gỗ nội thất',                    N'Hoàn thành', 'KH013', 'NV014'),
('DDV016', '2024-04-01 09:00', '2024-04-03 09:00', N'Kho Tân Bình, TP.HCM',        N'Cần Thơ',                         N'Hàng FMCG',                         N'Hoàn thành', 'KH014', 'NV016'),
('DDV017', '2024-04-05 08:00', '2024-04-06 08:00', N'TP.HCM',                      N'Long An',                         N'Vật tư nông nghiệp',                N'Hoàn thành', 'KH015', 'NV018'),
('DDV018', '2024-04-10 10:30', '2024-04-12 10:30', N'Cảng Cát Lái, TP.HCM',       N'Hà Nội',                          N'Hàng điện tử - container 40ft',     N'Hoàn thành', 'KH043', 'NV020'),
('DDV019', '2024-04-15 09:00', '2024-04-17 09:00', N'KCN Nhơn Trạch, Đồng Nai',   N'Cảng Cái Mép, BRVT',              N'Cao su xuất khẩu',                  N'Hoàn thành', 'KH049', 'NV004'),
('DDV020', '2024-04-20 08:00', '2024-04-21 08:00', N'Bình Phước',                  N'TP.HCM',                          N'Gỗ nguyên liệu',                    N'Hoàn thành', 'KH023', 'NV005'),
 
-- Đơn Đang xử lý (10 đơn)
('DDV021', '2024-05-01 08:00', '2024-05-03 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Thiết bị y tế nhập khẩu',           N'Đang xử lý', 'KH024', 'NV008'),
('DDV022', '2024-05-02 09:00', '2024-05-04 09:00', N'Cảng Cát Lái, TP.HCM',       N'KCN Vĩnh Phúc',                   N'Hàng điện tử tiêu dùng',            N'Đang xử lý', 'KH025', 'NV010'),
('DDV023', '2024-05-03 10:00', '2024-05-05 10:00', N'KCN Bình Dương',              N'Campuchia',                       N'Hàng hóa tổng hợp XK',              N'Đang xử lý', 'KH026', 'NV012'),
('DDV024', '2024-05-04 08:30', '2024-05-06 08:30', N'TP.HCM',                      N'Đà Nẵng',                         N'Hàng lạnh - thực phẩm',             N'Đang xử lý', 'KH027', 'NV014'),
('DDV025', '2024-05-05 09:00', '2024-05-07 09:00', N'Kho DDX Bình Dương',          N'Cần Thơ',                         N'Hóa chất công nghiệp',              N'Đang xử lý', 'KH028', 'NV016'),
('DDV026', '2024-05-06 08:00', '2024-05-08 08:00', N'Long An',                     N'Hà Nội',                          N'Hàng nông sản',                     N'Đang xử lý', 'KH029', 'NV018'),
('DDV027', '2024-05-07 10:00', '2024-05-09 10:00', N'Cảng Cái Mép, BRVT',         N'Singapore',                       N'Container 20ft hàng hỗn hợp',       N'Đang xử lý', 'KH036', 'NV020'),
('DDV028', '2024-05-08 09:30', '2024-05-10 09:30', N'TP.HCM',                      N'Lào (Vientiane)',                  N'Hàng tiêu dùng xuất Lào',           N'Đang xử lý', 'KH049', 'NV004'),
('DDV029', '2024-05-09 08:00', '2024-05-11 08:00', N'KCN Tân Tạo, TP.HCM',        N'Hải Phòng',                       N'Máy công nghiệp',                   N'Đang xử lý', 'KH043', 'NV005'),
('DDV030', '2024-05-10 11:00', '2024-05-12 11:00', N'Vũng Tàu',                    N'TP.HCM',                          N'Dụng cụ ngành dầu khí',             N'Đang xử lý', 'KH030', 'NV008'),
 
-- Đơn Đã xác nhận (10 đơn)
('DDV031', '2024-05-11 08:00', '2024-05-14 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Thiết bị văn phòng',                N'Đã xác nhận', 'KH031', 'NV010'),
('DDV032', '2024-05-12 09:00', '2024-05-15 09:00', N'Bình Dương',                  N'Đà Nẵng',                         N'Hàng gốm sứ',                       N'Đã xác nhận', 'KH032', 'NV012'),
('DDV033', '2024-05-13 10:00', '2024-05-16 10:00', N'Cảng Cát Lái, TP.HCM',       N'Thái Lan',                        N'Hàng nông sản xuất khẩu',           N'Đã xác nhận', 'KH033', 'NV014'),
('DDV034', '2024-05-14 08:30', '2024-05-17 08:30', N'KCN Nhơn Trạch, Đồng Nai',   N'TP.HCM',                          N'Linh kiện ô tô',                    N'Đã xác nhận', 'KH034', 'NV016'),
('DDV035', '2024-05-14 09:00', '2024-05-18 09:00', N'TP.HCM',                      N'Cần Thơ',                         N'Vật liệu xây dựng',                 N'Đã xác nhận', 'KH035', 'NV018'),
('DDV036', '2024-05-15 08:00', '2024-05-19 08:00', N'Kho DDX, Bình Dương',         N'Hà Nội',                          N'Hàng điện lạnh tiêu dùng',          N'Đã xác nhận', 'KH037', 'NV020'),
('DDV037', '2024-05-15 10:00', '2024-05-19 10:00', N'TP.HCM',                      N'Campuchia',                       N'Hàng hóa tổng hợp',                 N'Đã xác nhận', 'KH038', 'NV004'),
('DDV038', '2024-05-16 09:00', '2024-05-20 09:00', N'Long An',                     N'TP.HCM',                          N'Lúa gạo nông sản',                  N'Đã xác nhận', 'KH039', 'NV005'),
('DDV039', '2024-05-16 08:00', '2024-05-20 08:00', N'Vũng Tàu',                    N'Bình Dương',                      N'Thiết bị dầu khí',                  N'Đã xác nhận', 'KH040', 'NV008'),
('DDV040', '2024-05-17 11:00', '2024-05-21 11:00', N'TP.HCM',                      N'Đà Nẵng',                         N'Hàng may mặc',                      N'Đã xác nhận', 'KH041', 'NV010'),
 
-- Đơn Chờ xác nhận (10 đơn)
('DDV041', '2024-05-18 08:00', '2024-05-22 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Đồ gia dụng cao cấp',               N'Chờ xác nhận', 'KH042', NULL),
('DDV042', '2024-05-18 09:00', '2024-05-22 09:00', N'Cảng Cát Lái, TP.HCM',       N'Trung Quốc (Thâm Quyến)',         N'Container 40ft hàng điện tử',       N'Chờ xác nhận', 'KH001', NULL),
('DDV043', '2024-05-19 10:00', '2024-05-23 10:00', N'Bình Dương',                  N'Đà Nẵng',                         N'Thiết bị sản xuất',                 N'Chờ xác nhận', 'KH002', NULL),
('DDV044', '2024-05-19 08:30', '2024-05-23 08:30', N'KCN Sóng Thần, BD',          N'Cần Thơ',                         N'Thực phẩm đông lạnh',               N'Chờ xác nhận', 'KH003', NULL),
('DDV045', '2024-05-20 09:00', '2024-05-24 09:00', N'TP.HCM',                      N'Campuchia',                       N'Hàng tiêu dùng tổng hợp',           N'Chờ xác nhận', 'KH004', NULL),
('DDV046', '2024-05-20 08:00', '2024-05-24 08:00', N'Long An',                     N'Hà Nội',                          N'Vật tư nông nghiệp',                N'Chờ xác nhận', 'KH005', NULL),
('DDV047', '2024-05-21 10:00', '2024-05-25 10:00', N'Kho DDX, TP.HCM',             N'Đà Lạt, Lâm Đồng',               N'Thiết bị nông nghiệp',              N'Chờ xác nhận', 'KH006', NULL),
('DDV048', '2024-05-21 09:30', '2024-05-25 09:30', N'Đồng Nai',                    N'TP.HCM',                          N'Linh kiện điện tử',                 N'Chờ xác nhận', 'KH007', NULL),
('DDV049', '2024-05-22 08:00', '2024-05-26 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Hàng lạnh - thực phẩm chế biến',   N'Chờ xác nhận', 'KH009', NULL),
('DDV050', '2024-05-22 11:00', '2024-05-26 11:00', N'Cảng Cái Mép, BRVT',         N'Singapore',                       N'Container 20ft hàng gỗ',            N'Chờ xác nhận', 'KH010', NULL),
 
-- Đơn Hủy (5 đơn)
('DDV051', '2024-03-01 08:00', '2024-03-05 08:00', N'TP.HCM',                      N'Hà Nội',                          N'Hủy do khách thay đổi kế hoạch',   N'Hủy', 'KH011', 'NV012'),
('DDV052', '2024-03-10 09:00', '2024-03-12 09:00', N'Bình Dương',                  N'Đà Nẵng',                         N'Hủy do hàng hóa không đủ điều kiện',N'Hủy', 'KH012', 'NV014'),
('DDV053', '2024-03-20 10:00', '2024-03-22 10:00', N'Long An',                     N'TP.HCM',                          N'Hủy do thời tiết',                  N'Hủy', 'KH013', 'NV016'),
('DDV054', '2024-04-01 08:30', '2024-04-03 08:30', N'TP.HCM',                      N'Cần Thơ',                         N'Hủy do không xếp được xe',          N'Hủy', 'KH014', 'NV018'),
('DDV055', '2024-04-10 09:00', '2024-04-12 09:00', N'Vũng Tàu',                    N'TP.HCM',                          N'Hủy theo yêu cầu khách hàng',       N'Hủy', 'KH015', 'NV020');
GO
 
-- ============================================================
-- 7. CHI TIET DON DICH VU
-- Chỉ chèn cho đơn Hoàn thành, Đang xử lý, Đã xác nhận
-- (Trigger RB18 không cho xóa hết chi tiết của đơn đã xác nhận)
-- ============================================================
INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) VALUES
-- DDV001: Hoàn thành - container + hải quan
('DDV001', 'DV005',  1,  15000000, N'Container 20ft hàng điện tử'),
('DDV001', 'DV015',  1,   3000000, N'Khai báo hải quan xuất khẩu'),
 
-- DDV002: Hoàn thành - xe tải + bốc xếp
('DDV002', 'DV002',  2,   8000000, N'2 xe tải hàng may mặc'),
('DDV002', 'DV013',  5,   2000000, N'Bốc xếp 5 tấn hàng'),
 
-- DDV003: Hoàn thành - vận tải đường thủy
('DDV003', 'DV003',  1,   5000000, N'Sà lan vận chuyển phân bón'),
 
-- DDV004: Hoàn thành - container nhập + hải quan nhập
('DDV004', 'DV005',  1,  15000000, N'Container 20ft hàng gia dụng'),
('DDV004', 'DV016',  1,   4000000, N'Khai báo hải quan nhập khẩu'),
 
-- DDV005: Hoàn thành - xe tải + bốc xếp + đóng gói
('DDV005', 'DV002',  1,   8000000, N'Xe tải chở thiết bị xây dựng'),
('DDV005', 'DV013',  3,   2000000, N'Bốc xếp 3 tấn'),
('DDV005', 'DV014',  3,   3500000, N'Đóng gói palletize'),
 
-- DDV006: Hoàn thành - xuyên biên giới + hải quan
('DDV006', 'DV010',  1,  25000000, N'Xe container xuyên biên giới VN-CPC'),
('DDV006', 'DV015',  2,   3000000, N'Khai báo 2 tờ khai xuất khẩu'),
 
-- DDV007: Hoàn thành - FTL + giao nhận
('DDV007', 'DV002',  1,   8000000, N'1 xe tải 15 tấn hàng điện lạnh'),
('DDV007', 'DV019',  3,    300000, N'Giao nhận 3 kiện tại đầu nhận'),
 
-- DDV008: Hoàn thành - container 20ft
('DDV008', 'DV005',  1,  15000000, N'Container 20ft linh kiện'),
('DDV008', 'DV015',  1,   3000000, N'Khai báo xuất khẩu'),
 
-- DDV009: Hoàn thành - xe lạnh
('DDV009', 'DV004',  1,  12000000, N'Xe lạnh thực phẩm đông lạnh'),
 
-- DDV010: Hoàn thành - container 40ft
('DDV010', 'DV006',  1,  22000000, N'Container 40ft'),
 
-- DDV011: Hoàn thành - kho lạnh + xe lạnh + hải quan xuất
('DDV011', 'DV004',  1,  12000000, N'Xe lạnh vận chuyển thủy sản'),
('DDV011', 'DV012',  2,   1200000, N'2 ngày kho lạnh bảo quản trước khi xuất'),
('DDV011', 'DV015',  1,   3000000, N'Khai báo xuất khẩu thủy sản'),
 
-- DDV012: Hoàn thành - container + hải quan
('DDV012', 'DV007',  1,  45000000, N'Container FCL đường biển'),
('DDV012', 'DV015',  1,   3000000, N'Khai báo hải quan xuất'),
 
-- DDV013: Hoàn thành - hàng lẻ LCL
('DDV013', 'DV001',  1,   1500000, N'Hàng lẻ vật liệu xây dựng'),
 
-- DDV014: Hoàn thành - quốc tế đường bộ + hải quan
('DDV014', 'DV010',  1,  25000000, N'Vận tải xuyên biên giới VN-CN'),
('DDV014', 'DV015',  3,   3000000, N'3 tờ khai hải quan xuất'),
 
-- DDV015: Hoàn thành - xe tải + bốc xếp
('DDV015', 'DV002',  1,   8000000, N'Xe tải 10 tấn nội thất'),
('DDV015', 'DV013',  4,   2000000, N'Bốc xếp 4 tấn'),
 
-- DDV016: Hoàn thành
('DDV016', 'DV001',  2,   1500000, N'2 lô hàng lẻ FMCG'),
 
-- DDV017: Hoàn thành
('DDV017', 'DV001',  1,   1500000, N'Hàng lẻ vật tư nông nghiệp'),
 
-- DDV018: Hoàn thành - container 40ft + hải quan
('DDV018', 'DV006',  2,  22000000, N'2 container 40ft điện tử'),
('DDV018', 'DV016',  2,   4000000, N'2 tờ khai nhập khẩu'),
 
-- DDV019: Hoàn thành - LCL biển + hải quan xuất
('DDV019', 'DV008',  1,  18000000, N'LCL đường biển cao su'),
('DDV019', 'DV015',  1,   3000000, N'Khai báo hải quan xuất'),
 
-- DDV020: Hoàn thành - xe tải
('DDV020', 'DV002',  1,   8000000, N'Xe tải chở gỗ nguyên liệu'),
 
-- DDV021 → DDV030: Đang xử lý
('DDV021', 'DV008',  1,  18000000, N'LCL đường biển thiết bị y tế'),
('DDV021', 'DV016',  1,   4000000, N'Khai báo nhập khẩu'),
 
('DDV022', 'DV005',  2,  15000000, N'2 container 20ft điện tử tiêu dùng'),
 
('DDV023', 'DV010',  1,  25000000, N'Xe container sang Campuchia'),
('DDV023', 'DV015',  1,   3000000, N'Khai báo xuất khẩu'),
 
('DDV024', 'DV004',  1,  12000000, N'Xe lạnh TP.HCM-Đà Nẵng'),
 
('DDV025', 'DV002',  1,   8000000, N'Xe tải hóa chất công nghiệp'),
('DDV025', 'DV011',  3,    500000, N'3 ngày/CBM kho thường'),
 
('DDV026', 'DV002',  2,   8000000, N'2 xe tải hàng nông sản'),
 
('DDV027', 'DV007',  1,  45000000, N'FCL container 20ft đường biển'),
('DDV027', 'DV015',  1,   3000000, N'Khai báo hải quan xuất'),
 
('DDV028', 'DV010',  1,  25000000, N'Vận tải xuyên biên giới VN-Lào'),
('DDV028', 'DV015',  2,   3000000, N'Khai báo 2 tờ khai'),
 
('DDV029', 'DV002',  1,   8000000, N'Xe tải máy công nghiệp'),
('DDV029', 'DV013',  5,   2000000, N'Bốc xếp 5 tấn'),
 
('DDV030', 'DV001',  1,   1500000, N'Hàng lẻ dụng cụ dầu khí'),
 
-- DDV031 → DDV040: Đã xác nhận
('DDV031', 'DV002',  1,   8000000, N'Xe tải thiết bị văn phòng'),
('DDV031', 'DV019',  2,    300000, N'Giao nhận 2 kiện'),
 
('DDV032', 'DV002',  1,   8000000, N'Xe tải hàng gốm sứ'),
('DDV032', 'DV014',  2,   3500000, N'Đóng gói bảo vệ gốm sứ'),
 
('DDV033', 'DV007',  1,  45000000, N'Container FCL hàng nông sản'),
('DDV033', 'DV015',  1,   3000000, N'Khai báo xuất khẩu'),
 
('DDV034', 'DV001',  2,   1500000, N'2 lô hàng lẻ linh kiện ô tô'),
 
('DDV035', 'DV003',  1,   5000000, N'Sà lan vận tải vật liệu'),
 
('DDV036', 'DV006',  1,  22000000, N'Container 40ft hàng điện lạnh'),
('DDV036', 'DV016',  1,   4000000, N'Khai báo nhập khẩu'),
 
('DDV037', 'DV010',  1,  25000000, N'Xe container sang Campuchia'),
 
('DDV038', 'DV003',  1,   5000000, N'Sà lan lúa gạo vùng ĐBSCL'),
 
('DDV039', 'DV002',  1,   8000000, N'Xe tải thiết bị dầu khí'),
('DDV039', 'DV013',  2,   2000000, N'Bốc xếp 2 tấn'),
 
('DDV040', 'DV002',  2,   8000000, N'2 xe tải hàng may mặc');
GO

-- CHI TIẾT ĐƠN DỊCH VỤ — Chờ xác nhận (DDV041–DDV050)
INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) VALUES

-- DDV041: Đồ gia dụng cao cấp — TP.HCM → Hà Nội
-- xe tải + giao nhận tại đầu nhận
('DDV041', 'DV002', 2,  8000000, N'2 xe tải hàng gia dụng cao cấp'),
('DDV041', 'DV019', 4,   300000, N'Giao nhận 4 kiện tại kho Hà Nội'),

-- DDV042: Container 40ft hàng điện tử — Cảng Cát Lái → Trung Quốc (Thâm Quyến)
-- container 40ft + khai báo hải quan xuất
('DDV042', 'DV006', 1, 22000000, N'Container 40ft hàng điện tử xuất Trung Quốc'),
('DDV042', 'DV015', 1,  3000000, N'Khai báo hải quan xuất khẩu'),

-- DDV043: Thiết bị sản xuất — Bình Dương → Đà Nẵng
-- xe tải + bốc xếp
('DDV043', 'DV002', 1,  8000000, N'Xe tải 15 tấn thiết bị sản xuất'),
('DDV043', 'DV013', 4,  2000000, N'Bốc xếp 4 tấn tại 2 đầu'),

-- DDV044: Thực phẩm đông lạnh — KCN Sóng Thần → Cần Thơ
-- xe lạnh
('DDV044', 'DV004', 1, 12000000, N'Xe lạnh chở thực phẩm đông lạnh'),

-- DDV045: Hàng tiêu dùng tổng hợp — TP.HCM → Campuchia
-- vận tải xuyên biên giới + khai báo hải quan xuất
('DDV045', 'DV010', 1, 25000000, N'Xe container xuyên biên giới VN-CPC'),
('DDV045', 'DV015', 2,  3000000, N'Khai báo 2 tờ khai hải quan xuất'),

-- DDV046: Vật tư nông nghiệp — Long An → Hà Nội
-- xe tải + bốc xếp
('DDV046', 'DV002', 2,  8000000, N'2 xe tải vật tư nông nghiệp'),
('DDV046', 'DV013', 3,  2000000, N'Bốc xếp 3 tấn'),

-- DDV048: Linh kiện điện tử — Đồng Nai → TP.HCM
-- hàng lẻ + giao nhận
('DDV048', 'DV001', 2,  1500000, N'2 lô hàng lẻ linh kiện điện tử'),
('DDV048', 'DV019', 3,   300000, N'Giao nhận 3 kiện tại kho TP.HCM'),

-- DDV049: Hàng lạnh - thực phẩm chế biến — TP.HCM → Hà Nội
-- xe lạnh + kho lạnh bảo quản trước khi chuyển
('DDV049', 'DV004', 1, 12000000, N'Xe lạnh thực phẩm chế biến TP.HCM-HN'),
('DDV049', 'DV012', 2,  1200000, N'2 ngày kho lạnh bảo quản trước khi xuất'),

-- DDV050: Container 20ft hàng gỗ — Cảng Cái Mép → Singapore
-- FCL đường biển + khai báo hải quan xuất
('DDV050', 'DV007', 1, 45000000, N'FCL container 20ft hàng gỗ xuất Singapore'),
('DDV050', 'DV015', 1,  3000000, N'Khai báo hải quan xuất khẩu');
GO
-- CHI TIẾT ĐƠN DỊCH VỤ — Đã hủy (DDV051–DDV055)
-- Ghi chú GHICHU phản ánh lý do đơn bị hủy
INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) VALUES

-- DDV051: Hủy do khách thay đổi kế hoạch — TP.HCM → Hà Nội
-- xe tải (đã đặt, khách hủy sau)
('DDV051', 'DV002', 1,  8000000, N'Đã đặt xe tải — hủy do khách thay đổi kế hoạch'),

-- DDV052: Hủy do hàng hóa không đủ điều kiện — Bình Dương → Đà Nẵng
-- xe tải + bốc xếp (đã chuẩn bị, phát hiện hàng không đủ ĐK)
('DDV052', 'DV002', 1,  8000000, N'Đã chuẩn bị xe tải — hủy do hàng không đủ điều kiện'),
('DDV052', 'DV013', 2,  2000000, N'Đã bố trí bốc xếp — hủy theo đơn'),

-- DDV053: Hủy do thời tiết — Long An → TP.HCM
-- hàng lẻ (lô nhỏ, hủy vì thời tiết xấu)
('DDV053', 'DV001', 1,  1500000, N'Hàng lẻ đã tiếp nhận — hủy do thời tiết xấu'),

-- DDV054: Hủy do không xếp được xe — TP.HCM → Cần Thơ
-- sà lan (phương tiện đường thủy, không xếp được lịch)
('DDV054', 'DV003', 1,  5000000, N'Sà lan đã đặt lịch — hủy do không bố trí được phương tiện'),

-- DDV055: Hủy theo yêu cầu khách hàng — Vũng Tàu → TP.HCM
-- xe tải + giao nhận (khách chủ động hủy)
('DDV055', 'DV002', 1,  8000000, N'Đã chuẩn bị xe tải — hủy theo yêu cầu khách hàng'),
('DDV055', 'DV019', 2,   300000, N'Đã bố trí giao nhận — hủy theo yêu cầu khách hàng');
GO
-- ============================================================
-- 8. HOA DON (cho đơn Hoàn thành + Đang xử lý + Đã xác nhận)
-- MANV_LAP dùng nhân viên có VAITRO = 'Nhân viên bán hàng'
-- ============================================================
INSERT INTO HoaDon (MAHD, NGAYHD, TONGTIEN, THUEVAT, CHIETKHAU, THANHTIEN, PHUONGTHUCTHANHTOAN, TINHTRANGTHANHTOAN, MADON, MANV_LAP) VALUES
-- Hóa đơn cho đơn Hoàn thành (DDV001-DDV020)
('HD001', '2024-01-09',  18000000,  10, 0,  19800000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV001', 'NV003'),
('HD002', '2024-01-14',  26000000,  10, 5,  26950000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV002', 'NV007'),
('HD003', '2024-01-17',   5000000,  10, 0,   5500000, N'Tiền mặt',      N'Đã thanh toán',     'DDV003', 'NV003'),
('HD004', '2024-01-24',  19000000,  10, 0,  20900000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV004', 'NV013'),
('HD005', '2024-01-29',  24500000,  10, 3,  24990000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV005', 'NV007'),
('HD006', '2024-02-05',  31000000,  10, 5,  32085000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV006', 'NV003'),
('HD007', '2024-02-09',   8900000,  10, 0,   9790000, N'Tiền mặt',      N'Đã thanh toán',     'DDV007', 'NV019'),
('HD008', '2024-02-13',  18000000,  10, 0,  19800000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV008', 'NV013'),
('HD009', '2024-02-19',  12000000,  10, 0,  13200000, N'Online',        N'Đã thanh toán',     'DDV009', 'NV007'),
('HD010', '2024-02-23',  22000000,  10, 2,  23716000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV010', 'NV003'),
('HD011', '2024-03-05',  16200000,  10, 5,  16929000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV011', 'NV025'),
('HD012', '2024-03-09',  48000000,  10, 5,  50160000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV012', 'NV007'),
('HD013', '2024-03-13',   1500000,  10, 0,   1650000, N'Tiền mặt',      N'Đã thanh toán',     'DDV013', 'NV003'),
('HD014', '2024-03-19',  34000000,  10, 5,  35530000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV014', 'NV019'),
('HD015', '2024-03-24',  20000000,  10, 0,  22000000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV015', 'NV013'),
('HD016', '2024-04-05',   3000000,  10, 0,   3300000, N'Tiền mặt',      N'Đã thanh toán',     'DDV016', 'NV043'),
('HD017', '2024-04-08',   1500000,  10, 0,   1650000, N'Tiền mặt',      N'Đã thanh toán',     'DDV017', 'NV003'),
('HD018', '2024-04-14',  52000000,  10, 5,  54340000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV018', 'NV007'),
('HD019', '2024-04-19',  21000000,  10, 3,  22449000, N'Chuyển khoản',  N'Đã thanh toán',     'DDV019', 'NV025'),
('HD020', '2024-04-23',   8000000,  10, 0,   8800000, N'Tiền mặt',      N'Đã thanh toán',     'DDV020', 'NV003'),
 
-- Hóa đơn cho đơn Đang xử lý (DDV021-DDV030) - chưa thanh toán hoặc một phần
('HD021', '2024-05-03',  22000000,  10, 0,  24200000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV021', 'NV007'),
('HD022', '2024-05-04',  30000000,  10, 3,  32100000, N'Chuyển khoản',  N'Thanh toán một phần','DDV022', 'NV013'),
('HD023', '2024-05-05',  28000000,  10, 5,  29260000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV023', 'NV019'),
('HD024', '2024-05-06',  12000000,  10, 0,  13200000, N'Online',        N'Thanh toán một phần','DDV024', 'NV025'),
('HD025', '2024-05-07',   9500000,  10, 0,  10450000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV025', 'NV043'),
('HD026', '2024-05-08',  16000000,  10, 0,  17600000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV026', 'NV007'),
('HD027', '2024-05-09',  48000000,  10, 5,  50160000, N'Chuyển khoản',  N'Thanh toán một phần','DDV027', 'NV003'),
('HD028', '2024-05-10',  31000000,  10, 0,  34100000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV028', 'NV013'),
('HD029', '2024-05-11',  18000000,  10, 0,  19800000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV029', 'NV019'),
('HD030', '2024-05-12',   1500000,  10, 0,   1650000, N'Tiền mặt',      N'Chưa thanh toán',   'DDV030', 'NV025'),
 
-- Hóa đơn cho đơn Đã xác nhận (DDV031-DDV040) - chưa thanh toán
('HD031', '2024-05-13',   8600000,  10, 0,   9460000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV031', 'NV043'),
('HD032', '2024-05-14',  15000000,  10, 0,  16500000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV032', 'NV007'),
('HD033', '2024-05-15',  48000000,  10, 5,  50160000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV033', 'NV003'),
('HD034', '2024-05-15',   3000000,  10, 0,   3300000, N'Tiền mặt',      N'Chưa thanh toán',   'DDV034', 'NV019'),
('HD035', '2024-05-16',   5000000,  10, 0,   5500000, N'Online',        N'Chưa thanh toán',   'DDV035', 'NV025'),
('HD036', '2024-05-17',  26000000,  10, 0,  28600000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV036', 'NV043'),
('HD037', '2024-05-17',  25000000,  10, 0,  27500000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV037', 'NV007'),
('HD038', '2024-05-18',   5000000,  10, 0,   5500000, N'Tiền mặt',      N'Chưa thanh toán',   'DDV038', 'NV003'),
('HD039', '2024-05-18',  12000000,  10, 0,  13200000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV039', 'NV013'),
('HD040', '2024-05-19',  16000000,  10, 0,  17600000, N'Chuyển khoản',  N'Chưa thanh toán',   'DDV040', 'NV019');
GO
 
-- ============================================================
-- 9. CHUNG TU
-- ============================================================
INSERT INTO ChungTu
(MACT, LOAICHUNGTU, SOCHUNGTU, NGAYLAP, TONGTIEN, TRANGTHAI, MADON, MANV_KIEMTRA)
VALUES
('CT001', N'Vận đơn',                  'VD-2024-001',  '2024-01-07', 18000000, N'Đã duyệt', 'DDV001', 'NV001'),
('CT002', N'Biên bản giao nhận',       'BBGN-2024-001','2024-01-07', NULL,     N'Đã duyệt', 'DDV001', 'NV001'),
('CT003', N'Chứng từ xuất nhập khẩu',  'XNK-2024-001', '2024-01-07', 18000000, N'Đã duyệt', 'DDV001', 'NV001'),
('CT004', N'Vận đơn',                  'VD-2024-002',  '2024-01-12', 26000000, N'Đã duyệt', 'DDV002', 'NV001'),
('CT005', N'Biên bản giao nhận',       'BBGN-2024-002','2024-01-12', NULL,     N'Đã duyệt', 'DDV002', 'NV001'),
('CT006', N'Hợp đồng',                 'HD-2024-001',  '2024-01-05', 26000000, N'Đã duyệt', 'DDV002', 'NV001'),
('CT007', N'Vận đơn',                  'VD-2024-003',  '2024-01-16', 5000000,  N'Đã duyệt', 'DDV003', 'NV001'),
('CT008', N'Vận đơn',                  'VD-2024-004',  '2024-01-22', 19000000, N'Đã duyệt', 'DDV004', 'NV001'),
('CT009', N'Chứng từ xuất nhập khẩu',  'XNK-2024-002', '2024-01-22', 19000000, N'Đã duyệt', 'DDV004', 'NV001'),
('CT010', N'Vận đơn',                  'VD-2024-005',  '2024-01-27', 24500000, N'Đã duyệt', 'DDV005', 'NV001'),
('CT011', N'Hợp đồng',                 'HD-2024-002',  '2024-01-25', 24500000, N'Đã duyệt', 'DDV005', 'NV001'),
('CT012', N'Vận đơn',                  'VD-2024-006',  '2024-02-03', 31000000, N'Đã duyệt', 'DDV006', 'NV001'),
('CT013', N'Chứng từ xuất nhập khẩu',  'XNK-2024-003', '2024-02-03', 31000000, N'Đã duyệt', 'DDV006', 'NV001'),
('CT014', N'Hợp đồng',                 'HD-2024-003',  '2024-02-01', 31000000, N'Đã duyệt', 'DDV006', 'NV001'),
('CT015', N'Vận đơn',                  'VD-2024-007',  '2024-02-07', 8900000,  N'Đã duyệt', 'DDV007', 'NV001'),
('CT016', N'Biên bản giao nhận',       'BBGN-2024-003','2024-02-07', NULL,     N'Đã duyệt', 'DDV007', 'NV001'),
('CT017', N'Vận đơn',                  'VD-2024-008',  '2024-02-11', 18000000, N'Đã duyệt', 'DDV008', 'NV001'),
('CT018', N'Chứng từ xuất nhập khẩu',  'XNK-2024-004', '2024-02-11', 18000000, N'Đã duyệt', 'DDV008', 'NV001'),
('CT019', N'Vận đơn',                  'VD-2024-009',  '2024-02-17', 12000000, N'Đã duyệt', 'DDV009', 'NV001'),
('CT020', N'Vận đơn',                  'VD-2024-010',  '2024-02-21', 22000000, N'Đã duyệt', 'DDV010', 'NV001'),
('CT021', N'Vận đơn',                  'VD-2024-011',  '2024-03-03', 16200000, N'Đã duyệt', 'DDV011', 'NV001'),
('CT022', N'Chứng từ xuất nhập khẩu',  'XNK-2024-005', '2024-03-03', 16200000, N'Đã duyệt', 'DDV011', 'NV001'),
('CT023', N'Vận đơn',                  'VD-2024-012',  '2024-03-07', 48000000, N'Đã duyệt', 'DDV012', 'NV001'),
('CT024', N'Hợp đồng',                 'HD-2024-004',  '2024-03-01', 48000000, N'Đã duyệt', 'DDV012', 'NV001'),
('CT025', N'Vận đơn',                  'VD-2024-013',  '2024-03-11', 1500000,  N'Đã duyệt', 'DDV013', 'NV001'),
('CT026', N'Chứng từ xuất nhập khẩu',  'XNK-2024-006', '2024-03-19', 34000000, N'Đã duyệt', 'DDV014', 'NV001'),
('CT027', N'Hợp đồng',                 'HD-2024-005',  '2024-03-10', 34000000, N'Đã duyệt', 'DDV014', 'NV001'),
('CT028', N'Vận đơn',                  'VD-2024-014',  '2024-03-22', 20000000, N'Đã duyệt', 'DDV015', 'NV001'),
('CT029', N'Vận đơn',                  'VD-2024-015',  '2024-04-03', 3000000,  N'Đã duyệt', 'DDV016', 'NV001'),
('CT030', N'Vận đơn',                  'VD-2024-016',  '2024-04-06', 1500000,  N'Đã duyệt', 'DDV017', 'NV001'),
('CT031', N'Vận đơn',                  'VD-2024-017',  '2024-04-14', 52000000, N'Đã duyệt', 'DDV018', 'NV001'),
('CT032', N'Chứng từ xuất nhập khẩu',  'XNK-2024-007', '2024-04-14', 52000000, N'Đã duyệt', 'DDV018', 'NV001'),
('CT033', N'Hợp đồng',                 'HD-2024-006',  '2024-04-10', 52000000, N'Đã duyệt', 'DDV018', 'NV001'),
('CT034', N'Vận đơn',                  'VD-2024-018',  '2024-04-19', 21000000, N'Đã duyệt', 'DDV019', 'NV001'),
('CT035', N'Chứng từ xuất nhập khẩu',  'XNK-2024-008', '2024-04-23', 8000000,  N'Đã duyệt', 'DDV020', 'NV001'),

('CT036', N'Vận đơn',                  'VD-2024-019',  '2024-05-03', 22000000, N'Chờ duyệt', 'DDV021', NULL),
('CT037', N'Hợp đồng',                 'HD-2024-007',  '2024-05-02', 30000000, N'Chờ duyệt', 'DDV022', NULL),
('CT038', N'Chứng từ xuất nhập khẩu',  'XNK-2024-009', '2024-05-03', 28000000, N'Chờ duyệt', 'DDV023', NULL),
('CT039', N'Vận đơn',                  'VD-2024-020',  '2024-05-04', 12000000, N'Chờ duyệt', 'DDV024', NULL),
('CT040', N'Hợp đồng',                 'HD-2024-008',  '2024-05-05', 48000000, N'Chờ duyệt', 'DDV027', NULL),
('CT041', N'Chứng từ xuất nhập khẩu',  'XNK-2024-010', '2024-05-06', 31000000, N'Chờ duyệt', 'DDV028', NULL),

('CT042', N'Khác',                     'KH-2024-001',  '2024-03-15', NULL, N'Từ chối', 'DDV051', 'NV001'),
('CT043', N'Khác',                     'KH-2024-002',  '2024-03-25', NULL, N'Từ chối', 'DDV052', 'NV001');
GO
GO 
-- ============================================================
-- 10. LICH SU TRANG THAI DON (tự động qua trigger nhưng
--     chèn thủ công để có dữ liệu seed ban đầu)
-- ============================================================
INSERT INTO LichSuTrangThaiDon (MADON, TRANGTHAI_CU, TRANGTHAI_MOI, MANV_CAPNHAT, THOIGIANCAPNHAT, GHICHU) VALUES
-- DDV001 vòng đời đầy đủ
('DDV001', NULL,            N'Chờ xác nhận', 'NV004', '2024-01-05 08:00', N'Đơn mới tạo'),
('DDV001', N'Chờ xác nhận',N'Đã xác nhận',  'NV004', '2024-01-05 14:00', N'Xác nhận sau khi kiểm tra chi tiết'),
('DDV001', N'Đã xác nhận', N'Đang xử lý',   'NV004', '2024-01-07 08:00', N'Bắt đầu vận chuyển'),
('DDV001', N'Đang xử lý',  N'Hoàn thành',   'NV004', '2024-01-07 17:00', N'Giao hàng thành công'),
 
-- DDV002
('DDV002', NULL,            N'Chờ xác nhận', 'NV005', '2024-01-10 09:00', N'Đơn mới tạo'),
('DDV002', N'Chờ xác nhận',N'Đã xác nhận',  'NV005', '2024-01-10 16:00', N'Xác nhận đơn'),
('DDV002', N'Đã xác nhận', N'Đang xử lý',   'NV005', '2024-01-12 09:00', N'Xuất phát từ kho TN Bình'),
('DDV002', N'Đang xử lý',  N'Hoàn thành',   'NV005', '2024-01-12 18:30', N'Giao hàng tại cảng Hải Phòng'),
 
-- DDV006 - xuyên biên giới
('DDV006', NULL,            N'Chờ xác nhận', 'NV014', '2024-02-01 08:00', N'Đơn mới tạo'),
('DDV006', N'Chờ xác nhận',N'Đã xác nhận',  'NV014', '2024-02-01 11:00', N'Xác nhận sau khi kiểm tra giấy phép XNK'),
('DDV006', N'Đã xác nhận', N'Đang xử lý',   'NV014', '2024-02-03 08:00', N'Qua cửa khẩu Mộc Bài'),
('DDV006', N'Đang xử lý',  N'Hoàn thành',   'NV014', '2024-02-03 19:00', N'Giao hàng tại Phnom Penh'),
 
-- DDV021 - đang xử lý
('DDV021', NULL,            N'Chờ xác nhận', 'NV008', '2024-05-01 08:00', N'Đơn mới tạo'),
('DDV021', N'Chờ xác nhận',N'Đã xác nhận',  'NV008', '2024-05-01 15:00', N'Xác nhận đơn thiết bị y tế'),
('DDV021', N'Đã xác nhận', N'Đang xử lý',   'NV008', '2024-05-03 08:00', N'Hàng đang trên đường vận chuyển'),
 
-- DDV031 - đã xác nhận
('DDV031', NULL,            N'Chờ xác nhận', 'NV010', '2024-05-11 08:00', N'Đơn mới tạo'),
('DDV031', N'Chờ xác nhận',N'Đã xác nhận',  'NV010', '2024-05-11 14:00', N'Xác nhận đơn thiết bị văn phòng'),
 
-- DDV051 - bị hủy
('DDV051', NULL,            N'Chờ xác nhận', 'NV012', '2024-03-01 08:00', N'Đơn mới tạo'),
('DDV051', N'Chờ xác nhận',N'Đã xác nhận',  'NV012', '2024-03-01 14:00', N'Xác nhận đơn'),
('DDV051', N'Đã xác nhận', N'Hủy',          'NV012', '2024-03-02 10:00', N'Khách hàng yêu cầu hủy - thay đổi kế hoạch');
GO
 
-- ============================================================
-- KIỂM TRA DỮ LIỆU
-- ============================================================
SELECT 'KhachHang'         AS [Bang], COUNT(*) AS [So_dong] FROM KhachHang
UNION ALL
SELECT 'NhanVien',           COUNT(*) FROM NhanVien
UNION ALL
SELECT 'TaiKhoan',           COUNT(*) FROM TaiKhoan
UNION ALL
SELECT 'NhomDichVu',         COUNT(*) FROM NhomDichVu
UNION ALL
SELECT 'DichVu',             COUNT(*) FROM DichVu
UNION ALL
SELECT 'DonDichVu',          COUNT(*) FROM DonDichVu
UNION ALL
SELECT 'ChiTietDonDichVu',   COUNT(*) FROM ChiTietDonDichVu
UNION ALL
SELECT 'HoaDon',             COUNT(*) FROM HoaDon
UNION ALL
SELECT 'ChungTu',            COUNT(*) FROM ChungTu
UNION ALL
SELECT 'LichSuTrangThaiDon', COUNT(*) FROM LichSuTrangThaiDon;
GO
 

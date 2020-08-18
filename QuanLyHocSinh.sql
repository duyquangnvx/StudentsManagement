USE [master]
GO
/****** Object:  Database [StudentManagement]    Script Date: 8/17/2020 11:38:10 AM ******/

drop database [StudentManagement]
go

CREATE DATABASE [StudentManagement]
GO
ALTER DATABASE [StudentManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StudentManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudentManagement]
GO
/****** Object:  Table [dbo].[BangDiem]    Script Date: 8/17/2020 11:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiem](
	[IdMonHoc] [int] NOT NULL,
	[IdHocSinh] [int] NOT NULL,
	[IdHocKy] [int] NOT NULL,
	[IdNamHoc] [int] NOT NULL,
	[IdHeSo] [int] NOT NULL,
	[Diem] [float] NULL,
 CONSTRAINT [PK_BangDiem_1] PRIMARY KEY CLUSTERED 
(
	[IdMonHoc] ASC,
	[IdHocSinh] ASC,
	[IdHocKy] ASC,
	[IdNamHoc] ASC,
	[IdHeSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](100) NOT NULL,
	[Mota] [nvarchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeSo]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeSo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenHeSo] [nvarchar](100) NULL,
	[HeSo] [float] NULL,
 CONSTRAINT [PK_HeSo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocKy]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenHocKy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocSinh_LopHoc]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh_LopHoc](
	[IdHocSinh] [int] NOT NULL,
	[IdLopHoc] [int] NOT NULL,
 CONSTRAINT [PK_HocSinh_LopHoc] PRIMARY KEY CLUSTERED 
(
	[IdHocSinh] ASC,
	[IdLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoi]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoi](
	[Id] [int] NOT NULL,
	[TenKhoi] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](100) NOT NULL,
	[IdGiaoVien] [int] NULL,
	[IdKhoi] [int] NULL,
	[IdNamHoc] [int] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenMonHoc] [nvarchar](100) NOT NULL,
	[DiemChuan] [float] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NamHoc]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NamHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_SchoolYear] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[IdGiaoVien] [int] NOT NULL,
	[IdLopHoc] [int] NOT NULL,
	[IdMonHoc] [int] NOT NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[IdGiaoVien] ASC,
	[IdLopHoc] ASC,
	[IdMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/17/2020 11:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[IdChucVu] [int] NOT NULL,
	[IsDelete] [bit] NULL,
	[CreateOn] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([Id], [TenChucVu], [Mota]) VALUES (1, N'Ban Giám Hiệu', N'Quản trị viên (Hiệu trưởng, Ban Giám Hiệu)')
INSERT [dbo].[ChucVu] ([Id], [TenChucVu], [Mota]) VALUES (2, N'Giáo Vụ', N'Giáo Vụ')
INSERT [dbo].[ChucVu] ([Id], [TenChucVu], [Mota]) VALUES (3, N'Giáo Viên', N'Giáo Viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
INSERT [dbo].[GiaoVien] ([Id]) VALUES (1003)
INSERT [dbo].[GiaoVien] ([Id]) VALUES (2003)
SET IDENTITY_INSERT [dbo].[HeSo] ON 

INSERT [dbo].[HeSo] ([Id], [TenHeSo], [HeSo]) VALUES (1, N'Trả bài', 1)
INSERT [dbo].[HeSo] ([Id], [TenHeSo], [HeSo]) VALUES (2, N'15 phút', 1)
INSERT [dbo].[HeSo] ([Id], [TenHeSo], [HeSo]) VALUES (3, N'Giữa kỳ', 1)
INSERT [dbo].[HeSo] ([Id], [TenHeSo], [HeSo]) VALUES (4, N'Cuối kỳ', 1)
SET IDENTITY_INSERT [dbo].[HeSo] OFF
SET IDENTITY_INSERT [dbo].[HocKy] ON 

INSERT [dbo].[HocKy] ([Id], [TenHocKy]) VALUES (1, N'Học kỳ 1')
INSERT [dbo].[HocKy] ([Id], [TenHocKy]) VALUES (2, N'Học kỳ 2')
SET IDENTITY_INSERT [dbo].[HocKy] OFF
SET IDENTITY_INSERT [dbo].[HocSinh] ON 

INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (3, N'Ung Hưng Trực', N'7961 Phố Triệu, Ấp Lều Thời, Huyện Thông ThoaHà Nội', N'uhtruc@gmail.com', CAST(N'2003-03-04' AS Date), 0)
INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (5, N'Đào Nương', N'4527 Phố Hạ Dân Thường, Phường 3, Huyện Nhàn NgânKon Tum', N'daonuong@gmail.com', CAST(N'2003-11-25' AS Date), 1)
INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (6, N'Lê Sương Điệp', N'7849 Phố Phó Lễ Trâm, Xã Triệu, Quận Mạc Sỹ OanhHồ Chí Minh', N'lediep@gmail.com', CAST(N'2003-10-23' AS Date), 1)
INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (7, N'Khưu Chiến Nhã', N'7900 Phố Bùi, Phường 09, Huyện Nghiêm Thạc HàHồ Chí Minh', N'chiennha@gmail.com', CAST(N'2003-08-20' AS Date), 0)
INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (8, N'Bạch Công', N'903 Phố Vọng, Xã Siêu Thào, Huyện 9Đắk Lắk', N'bachcong@gmail.com', CAST(N'2003-06-07' AS Date), 0)
INSERT [dbo].[HocSinh] ([Id], [HoTen], [DiaChi], [Email], [NgaySinh], [GioiTinh]) VALUES (9, N'Diệp Nghi Thục', N'6386 Phố Diệp Vỹ Vĩnh, Xã 04, Huyện 60Nghệ An', N'thucnghi@gmail.com', CAST(N'2003-02-14' AS Date), 1)
SET IDENTITY_INSERT [dbo].[HocSinh] OFF
INSERT [dbo].[Khoi] ([Id], [TenKhoi]) VALUES (10, N'Khối 10')
INSERT [dbo].[Khoi] ([Id], [TenKhoi]) VALUES (11, N'Khối 11')
INSERT [dbo].[Khoi] ([Id], [TenKhoi]) VALUES (12, N'Khối 12')
SET IDENTITY_INSERT [dbo].[LopHoc] ON 

INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (1, N'K10 - Chưa phân lớp', NULL, 10, NULL)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (2, N'K11 - Chưa phân lớp', NULL, 11, NULL)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (3, N'K12 - Chưa phân lớp', NULL, 12, NULL)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (4, N'10A1', NULL, 10, 1)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (5, N'10A2', 2003, 10, 1)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (6, N'11A1', NULL, 11, 1)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (7, N'11A2', NULL, 11, 1)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (8, N'12A1', NULL, 12, 1)
INSERT [dbo].[LopHoc] ([Id], [TenLop], [IdGiaoVien], [IdKhoi], [IdNamHoc]) VALUES (9, N'12A2', NULL, 12, 1)
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (1, N'Toán 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (2, N'Ngữ văn 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (3, N'Vật lý 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (4, N'Hóa học 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (5, N'Sinh học 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (6, N'Lịch sử 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (7, N'Địa lí 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (8, N'GDCD 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (9, N'Tin học 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (10, N'Thể dục 10', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (11, N'Toán 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (12, N'Ngữ văn 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (13, N'Vật lý 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (14, N'Hóa học 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (15, N'Sinh học 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (16, N'Lịch sử 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (17, N'Địa lí 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (18, N'GDCD 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (19, N'Tin học 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (20, N'Thể dục 11', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (21, N'Toán 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (22, N'Ngữ văn 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (23, N'Vật lý 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (24, N'Hóa học 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (25, N'Sinh học 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (26, N'Lịch sử 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (27, N'Địa lí 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (28, N'GDCD 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (29, N'Tin học 12', 5)
INSERT [dbo].[MonHoc] ([Id], [TenMonHoc], [DiemChuan]) VALUES (30, N'Thể dục 12', 5)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
SET IDENTITY_INSERT [dbo].[NamHoc] ON 

INSERT [dbo].[NamHoc] ([Id], [NgayBatDau], [NgayKetThuc]) VALUES (1, CAST(N'2019-01-09' AS Date), CAST(N'2020-01-05' AS Date))
INSERT [dbo].[NamHoc] ([Id], [NgayBatDau], [NgayKetThuc]) VALUES (2, CAST(N'2020-01-09' AS Date), CAST(N'2021-01-05' AS Date))
SET IDENTITY_INSERT [dbo].[NamHoc] OFF
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 1, 1)
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 2, 1)
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 3, 11)
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 4, 11)
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 5, 21)
INSERT [dbo].[PhanCong] ([IdGiaoVien], [IdLopHoc], [IdMonHoc]) VALUES (1003, 6, 21)
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [IdChucVu], [IsDelete], [CreateOn]) VALUES (12, N'admin', N'admin', N'Admin', CAST(N'1999-01-01' AS Date), 0, N'Không rõ', NULL, N'admin@gmail.com', 1, 0, CAST(N'2020-08-15T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [Username], [Password], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [IdChucVu], [IsDelete], [CreateOn]) VALUES (1002, N'giaovu', N'giaovu', N'Giáo vụ', CAST(N'1990-05-06' AS Date), 0, N'Không rõ', NULL, N'giaovu@gmail.com', 2, 0, CAST(N'2020-08-15T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [Username], [Password], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [IdChucVu], [IsDelete], [CreateOn]) VALUES (1003, N'duyquang', N'duyquang', N'Vũ Duy Quang', CAST(N'1999-03-29' AS Date), 0, N'189i/32A Tôn Thất Thuyết - Phường 3 - Quận 4 - TP.HCM', N'0377910968', N'duyquangnvx@gmail.com', 3, 0, CAST(N'2020-08-15T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [Username], [Password], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [IdChucVu], [IsDelete], [CreateOn]) VALUES (2003, N'unggiac', N'unggiac', N'Ung Giác', CAST(N'1995-10-15' AS Date), 0, N'0053, Thôn Dung Vũ, Xã Khâu, Quận Khiêm HậuKiên Giang', NULL, N'unggiac@gmail.com', 3, 0, CAST(N'2020-08-15T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [Username], [Password], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [IdChucVu], [IsDelete], [CreateOn]) VALUES (2004, N'duyquang01', N'duyquang', N'Vũ Duy Quanga', CAST(N'1999-03-29' AS Date), 0, N'189i/32A Tôn Thất Thuyết - Phường 3 - Quận 4 - TP.HCM', NULL, N'duyquangnvx@gmail.com', 3, 0, CAST(N'2020-08-16T20:06:08.633' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF

INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (3, 1)
INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (5, 1)
INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (6, 2)
INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (7, 2)
INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (8, 3)
INSERT [dbo].[HocSinh_LopHoc] ([IdHocSinh], [IdLopHoc]) VALUES (9, 3)

ALTER TABLE [dbo].[HocSinh] ADD  CONSTRAINT [DF_Student_Sex]  DEFAULT ((0)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[MonHoc] ADD  CONSTRAINT [DF_Subject_BenchMark]  DEFAULT ((5.0)) FOR [DiemChuan]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Sex]  DEFAULT ((0)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_HeSo] FOREIGN KEY([IdHeSo])
REFERENCES [dbo].[HeSo] ([Id])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_HeSo]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_HocKy] FOREIGN KEY([IdHocKy])
REFERENCES [dbo].[HocKy] ([Id])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_HocKy]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_HocSinh] FOREIGN KEY([IdHocSinh])
REFERENCES [dbo].[HocSinh] ([Id])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_HocSinh]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_MonHoc] FOREIGN KEY([IdMonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_MonHoc]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_NamHoc] FOREIGN KEY([IdNamHoc])
REFERENCES [dbo].[NamHoc] ([Id])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_NamHoc]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_User] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_User]
GO
ALTER TABLE [dbo].[HocSinh_LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_LopHoc_HocSinh] FOREIGN KEY([IdHocSinh])
REFERENCES [dbo].[HocSinh] ([Id])
GO
ALTER TABLE [dbo].[HocSinh_LopHoc] CHECK CONSTRAINT [FK_HocSinh_LopHoc_HocSinh]
GO
ALTER TABLE [dbo].[HocSinh_LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_LopHoc_LopHoc] FOREIGN KEY([IdLopHoc])
REFERENCES [dbo].[LopHoc] ([Id])
GO
ALTER TABLE [dbo].[HocSinh_LopHoc] CHECK CONSTRAINT [FK_HocSinh_LopHoc_LopHoc]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_GiaoVien] FOREIGN KEY([IdGiaoVien])
REFERENCES [dbo].[GiaoVien] ([Id])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_GiaoVien]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_Khoi] FOREIGN KEY([IdKhoi])
REFERENCES [dbo].[Khoi] ([Id])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_Khoi]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_NamHoc] FOREIGN KEY([IdNamHoc])
REFERENCES [dbo].[NamHoc] ([Id])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_NamHoc]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GiaoVien] FOREIGN KEY([IdGiaoVien])
REFERENCES [dbo].[GiaoVien] ([Id])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_GiaoVien]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_LopHoc] FOREIGN KEY([IdLopHoc])
REFERENCES [dbo].[LopHoc] ([Id])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_LopHoc]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_MonHoc] FOREIGN KEY([IdMonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_MonHoc]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_ChucVu] FOREIGN KEY([IdChucVu])
REFERENCES [dbo].[ChucVu] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_ChucVu]
GO
USE [master]
GO
ALTER DATABASE [StudentManagement] SET  READ_WRITE 
GO

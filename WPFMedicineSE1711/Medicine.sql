USE [master]
GO
/****** Object:  Database [Medicine]    Script Date: 11/30/2023 9:16:49 PM ******/
CREATE DATABASE [Medicine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Medicine', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medicine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Medicine_log', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medicine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Medicine] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Medicine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Medicine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Medicine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Medicine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Medicine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Medicine] SET ARITHABORT OFF 
GO
ALTER DATABASE [Medicine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Medicine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Medicine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Medicine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Medicine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Medicine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Medicine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Medicine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Medicine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Medicine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Medicine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Medicine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Medicine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Medicine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Medicine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Medicine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Medicine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Medicine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Medicine] SET  MULTI_USER 
GO
ALTER DATABASE [Medicine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Medicine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Medicine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Medicine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Medicine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Medicine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Medicine] SET QUERY_STORE = OFF
GO
USE [Medicine]
GO
/****** Object:  Table [dbo].[GroupMedicine]    Script Date: 11/30/2023 9:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMedicine](
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_GroupMedicine] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 11/30/2023 9:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineID] [nvarchar](10) NOT NULL,
	[GroupID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[MedicineName] [nvarchar](100) NOT NULL,
	[Price] [money] NULL,
	[Amount] [float] NULL,
	[ExpiriDate] [date] NULL,
	[Preserve] [nvarchar](100) NULL,
	[UserManual] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[MedicineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 11/30/2023 9:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NULL,
	[Address] [nvarchar](300) NULL,
	[Phone] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (1, N'Nhóm thuốc cúm', N'theo mùa')
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (2, N'Nhóm thuốc ho', N'Theo thời tiết')
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (3, N'Nhóm thuốc dạ dày', N'kiểm tra phản vệ')
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (4, N'Nhóm thuốc sát trùng', N'rửa sạch trước khi sử dụng')
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (5, N'Nhóm thuốc giải độc', N'chú ý liều dùng')
INSERT [dbo].[GroupMedicine] ([GroupID], [GroupName], [Note]) VALUES (6, N'Nhóm Kháng sinh', N'liều lượng')
GO
INSERT [dbo].[Medicine] ([MedicineID], [GroupID], [SupplierID], [MedicineName], [Price], [Amount], [ExpiriDate], [Preserve], [UserManual]) VALUES (N'C1', 1, 2, N'Cảm xuyên hương', 6000.0000, 1000000, CAST(N'2025-12-12' AS Date), N'no', N'Thành phần
Hoạt chất: Xuyên khung 132 mg, Bạch chỉ 165 mg, Hương phụ 132 mg, Quế chi 6 mg, Sinh khương 15 mg, Cam thảo bắc 5 mg.

Tá dược: Ethanol 96% 0.1ml, PVP 6mg, bột talc 10mg vừa đủ 1 viên

Công dụng (Chỉ định)
Điều trị các trường hợp cảm cúm, cảm lạnh, nhức đầu, hắt hơi, sổ mũi do cảm lạnh, do thay đổi thời tiết đột ngột.

Tăng cường sức đề kháng, ngăn cảm cúm quay trở lại.')
INSERT [dbo].[Medicine] ([MedicineID], [GroupID], [SupplierID], [MedicineName], [Price], [Amount], [ExpiriDate], [Preserve], [UserManual]) VALUES (N'G1', 5, 1, N'Giải độc gan Detox', 255000.0000, 1000, CAST(N'2026-12-02' AS Date), N'no', N'Thành phần
Cho 1 viên:

Taurine 150mg, Psyllium Hux Powder 100mg, Silybum marianumseed Milk Thistle Extract 7000 mg, Schizandra chinensis fruit dry 160mg, Taraxacum officinale root dry 200mg kết hợp với Lecithin, Magnesium, stearate, maltodextrin, bột Barley grass.

Công dụng
Hỗ trợ bổ gan, tăng cường chức năng gan như hạ men gan, ngăn ngừa viêm gan siêu vi, gan nhiễm mỡ, giúp bảo vệ phục hồi các tế bào gan bị thương tổn do uống nhiều rượu bia và tiếp xúc với các hóa chất môi trường độc hại.

Tăng khả năng miễn dịch, thanh lọc, giải độc cơ thể, khi gan và cơ thể bị nhiễm độc.')
INSERT [dbo].[Medicine] ([MedicineID], [GroupID], [SupplierID], [MedicineName], [Price], [Amount], [ExpiriDate], [Preserve], [UserManual]) VALUES (N'H1', 3, 4, N'Siro traphaco', 45000.0000, 12000, CAST(N'2024-04-04' AS Date), N'no', N'CÔNG DỤNG: Hỗ trợ

Giảm ho, giảm đờm
Giảm đau rát họng
Khản tiếng do viêm họng
Viêm phế quản
THÀNH PHẦN: Mỗi 05 ml siro chứa:

Chiết xuất lá Thường xuân (Hedera helix leaf Extract) ... 30 mg;
Keo ong ... 25 mg;
Chiết xuất rễ Marshmallow (Althaea officinalis root Extract) ... 25 mg;
Phụ liệu: Sorbitol (INS 420(i)), Kali sorbat (INS 202), Polyethylen glycol (INS 1521); Xanthan gôm (INS 415), Propylen glycol (INS 1520), Aspartame (INS 951); Hương tổng hợp (hương dâu, hương chuối, hương vani) vừa đủ.')
INSERT [dbo].[Medicine] ([MedicineID], [GroupID], [SupplierID], [MedicineName], [Price], [Amount], [ExpiriDate], [Preserve], [UserManual]) VALUES (N'H2', 2, 5, N'Thuốc ho prospan đức', 90000.0000, 10000, CAST(N'2025-03-07' AS Date), N'no', N'Chỉ định
Thuốc Prospan Đức được chỉ định dùng trong các trường hợp sau:

Ðiều trị viêm đường hô hấp cấp có kèm theo ho.
Ðiều trị triệu chứng trong các bệnh lý viêm phế quản mạn tính.')
INSERT [dbo].[Medicine] ([MedicineID], [GroupID], [SupplierID], [MedicineName], [Price], [Amount], [ExpiriDate], [Preserve], [UserManual]) VALUES (N'K1', 6, 3, N'Penicillin', 20000.0000, 100000, CAST(N'2025-06-06' AS Date), N'no', N'Các Penicillin phổ kháng khuẩn hẹp: Penicillin G, Penicillin V.
Các Penicillin phổ kháng khuẩn hẹp đồng thời có tác dụng lên tụ cầu (Penicillinase – kháng penicillins): Methicillin, Oxacillin, Cloxacillin, Dicloxacillin, Nafcillin.
Các Penicillin phổ kháng khuẩn trung bình: Ampicillin, Amoxicillin.
Các Penicillin phổ kháng khuẩn rộng đồng thời có tác dụng lên trực khuẩn mủ xanh: Carbenicillin, Ticarcillin, Mezlocillin, Piperacillin.')
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [Fax], [Email], [Note]) VALUES (1, N'Dược Hậu Giang', N'Hậu Giang', N'0324.416.333        ', N'0324.416.336        ', N'contact@dhd.vn                                                                                      ', N'đặt sớm 1 tuần')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [Fax], [Email], [Note]) VALUES (2, N'Dược Hà Tây', N'Hà Tây', N'0242.118.238        ', N'0242.118.210        ', N'support@dht.com.vn                                                                                  ', N'đặt trước 3 ngày')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [Fax], [Email], [Note]) VALUES (3, N'Long Châu ', N'Vn', N'0333.666.999        ', N'no                  ', N'callme@longchau.com.vn                                                                              ', N'gọi là có ngay')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [Fax], [Email], [Note]) VALUES (4, N'Hà Tuyên', N'In city', N'0932.222.868        ', N'no                  ', N'hatuyen@gmail.com                                                                                   ', N'ở huyện gọi trước 1 ngày')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [Fax], [Email], [Note]) VALUES (5, N'Phúc Long', N'VN', N'0836.111.555        ', N'no                  ', N'support@dht.com.vn                                                                                  ', N'gọi là mang tới')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_GroupMedicine1] FOREIGN KEY([GroupID])
REFERENCES [dbo].[GroupMedicine] ([GroupID])
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_GroupMedicine1]
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_Supplier]
GO
USE [master]
GO
ALTER DATABASE [Medicine] SET  READ_WRITE 
GO

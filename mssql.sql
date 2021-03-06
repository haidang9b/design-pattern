USE [QUANLYBANHANG]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[SDTKH] [char](11) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[TONGTIEN] [int] NULL,
	[EMAIL] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[MAKH] [int] NOT NULL,
	[NVBAN] [nvarchar](200) NULL,
	[TGMUA] [date] NOT NULL,
	[TONGTIEN] [int] NULL,
	[STATUS] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BILLVIEW]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---ViewBill
CREATE VIEW [dbo].[BILLVIEW]
AS
SELECT MAHD, KH.TENKH, KH.SDTKH, TGMUA, HD.TONGTIEN
FROM HOADON HD 
INNER JOIN KHACHHANG KH ON KH.MAKH = HD.MAKH 
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [int] IDENTITY(1,1) NOT NULL,
	[TENSP] [nvarchar](100) NULL,
	[LOAISP] [int] NOT NULL,
	[SOLUONGTON] [int] NULL,
	[DONGIA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAHD] [int] NULL,
	[MASP] [int] NULL,
	[SL] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VIEWBILLINFO]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VIEWBILLINFO]
AS
SELECT        dbo.SANPHAM.TENSP, CT.SL, dbo.SANPHAM.DONGIA, dbo.SANPHAM.DONGIA * CT.SL AS TONGGIA
FROM            dbo.CHITIETHOADON AS CT INNER JOIN
                         dbo.SANPHAM ON dbo.SANPHAM.MASP = CT.MASP INNER JOIN
                         dbo.HOADON ON dbo.HOADON.MAHD = CT.MAHD INNER JOIN
                         dbo.KHACHHANG ON dbo.HOADON.MAKH = dbo.KHACHHANG.MAKH
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [char](50) NOT NULL,
	[PASSWORD] [char](200) NULL,
	[TYPE] [int] NOT NULL,
	[FULLNAME] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISP]    Script Date: 1/5/2022 11:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISP](
	[MALOAI] [int] IDENTITY(1,1) NOT NULL,
	[TENLOAI] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACCOUNT] ON 

INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORD], [TYPE], [FULLNAME]) VALUES (1, N'admin                                             ', N'123456                                                                                                                                                                                                  ', 0, N'Qu???n l?? 1')
INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORD], [TYPE], [FULLNAME]) VALUES (2, N'teo                                               ', N'123456                                                                                                                                                                                                  ', 0, N'T??o222')
INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORD], [TYPE], [FULLNAME]) VALUES (3, N'staff                                             ', N'123456                                                                                                                                                                                                  ', 1, N'Nh??n vi??n 1')
INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORD], [TYPE], [FULLNAME]) VALUES (9, N'test                                              ', N'1212121                                                                                                                                                                                                 ', 1, N'Nh??n vi??n A')
INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORD], [TYPE], [FULLNAME]) VALUES (10, N'test2                                             ', N'2222                                                                                                                                                                                                    ', 1, N'Nh??n vi??n B')
SET IDENTITY_INSERT [dbo].[ACCOUNT] OFF
GO
SET IDENTITY_INSERT [dbo].[CHITIETHOADON] ON 

INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (1, 1, 6, 4)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (2, 2, 9, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (3, 2, 27, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (4, 2, 29, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (5, 3, 11, 4)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (6, 3, 16, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (7, 4, 13, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (8, 5, 34, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (9, 6, 33, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (10, 7, 19, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (11, 8, 20, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (12, 8, 17, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (13, 9, 25, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (14, 10, 25, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (15, 11, 25, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (16, 12, 25, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (17, 13, 25, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (29, 14, 1, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (30, 15, 1, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (31, 16, 1, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (32, 16, 8, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (33, 17, 1, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (34, 18, 1, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (35, 19, 1, 15)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (36, 19, 25, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (44, 20, 17, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (45, 21, 1, 5)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (46, 22, 1, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (47, 23, 1, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (48, 24, 1, 5)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (49, 20, 1, 4)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (50, 20, 19, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (52, 26, 1, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (53, 25, 2, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (54, 25, 1, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (55, 27, 1, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (56, 28, 3, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (57, 29, 3, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (58, 30, 6, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (59, 31, 6, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (60, 32, 6, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (61, 33, 7, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (62, 34, 9, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (63, 35, 10, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (64, 36, 34, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (65, 37, 33, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (66, 38, 41, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (67, 39, 17, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (68, 40, 8, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (69, 41, 8, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (70, 42, 7, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (71, 43, 8, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (72, 44, 7, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (73, 45, 6, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (74, 46, 16, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (75, 47, 37, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (76, 48, 37, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (77, 49, 37, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (78, 50, 34, 3)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (79, 51, 34, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (80, 51, 20, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (81, 51, 30, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (82, 52, 31, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (83, 53, 5, 2)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (84, 54, 10, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (85, 55, 23, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (86, 56, 32, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (87, 57, 6, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (88, 58, 8, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (89, 59, 4, 1)
INSERT [dbo].[CHITIETHOADON] ([ID], [MAHD], [MASP], [SL]) VALUES (90, 60, 5, 1)
SET IDENTITY_INSERT [dbo].[CHITIETHOADON] OFF
GO
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (1, 1, N'admin                                             ', CAST(N'2020-12-05' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (2, 2, N'admin                                             ', CAST(N'2020-12-05' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (3, 3, N'admin                                             ', CAST(N'2020-12-05' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (4, 3, N'admin                                             ', CAST(N'2020-12-05' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (5, 4, N'admin                                             ', CAST(N'2020-12-05' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (6, 4, N'admin                                             ', CAST(N'2020-12-05' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (7, 9, N'admin                                             ', CAST(N'2020-12-05' AS Date), 210000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (8, 5, N'admin                                             ', CAST(N'2020-12-05' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (9, 6, N'admin                                             ', CAST(N'2020-12-05' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (10, 7, N'admin                                             ', CAST(N'2020-12-05' AS Date), 399998, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (11, 8, N'admin                                             ', CAST(N'2020-12-05' AS Date), 573590, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (12, 8, N'admin                                             ', CAST(N'2020-12-05' AS Date), 573590, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (13, 1, N'admin                                             ', CAST(N'2020-12-05' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (14, 1, N'admin                                             ', CAST(N'2020-12-05' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (15, 1, N'admin                                             ', CAST(N'2021-11-28' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (16, 1, N'admin                                             ', CAST(N'2021-11-30' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (17, 1, N'admin                                             ', CAST(N'2021-11-30' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (18, 7, N'admin                                             ', CAST(N'2021-11-30' AS Date), 399998, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (19, 2, N'admin', CAST(N'2021-12-03' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (20, 3, N'admin', CAST(N'2021-12-03' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (21, 1, N'admin', CAST(N'2021-12-03' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (22, 12, N'admin', CAST(N'2021-12-03' AS Date), 6133690, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (23, 2, N'admin', CAST(N'2021-12-03' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (24, 12, N'admin', CAST(N'2021-12-03' AS Date), 6133690, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (25, 3, N'admin', CAST(N'2021-12-08' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (26, 7, N'admin', CAST(N'2021-12-08' AS Date), 399998, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (27, 1, N'admin', CAST(N'2021-12-11' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (28, 1, N'admin', CAST(N'2021-12-14' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (29, 13, N'admin', CAST(N'2021-12-16' AS Date), 350000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (30, 1, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 980000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (31, 3, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (32, 2, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (33, 3, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 205000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (34, 13, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 350000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (35, 4, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (36, 13, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 350000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (37, 8, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 573590, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (38, 6, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (39, 12, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 6133690, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (40, 5, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (41, 13, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 350000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (42, 5, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (43, 4, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (44, 4, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (45, 4, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (46, 24, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (47, 24, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (48, 24, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (49, 4, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 22, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (50, 24, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (51, 9, N'Qu???n l?? 1', CAST(N'2021-12-26' AS Date), 210000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (52, 12, N'Qu???n l?? 1', CAST(N'2021-12-27' AS Date), 6133690, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (53, 6, N'Qu???n l?? 1', CAST(N'2021-12-27' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (54, 6, N'Qu???n l?? 1', CAST(N'2021-12-27' AS Date), 150000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (55, 24, N'Nh??n vi??n 1', CAST(N'2021-12-28' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (56, 24, N'Qu???n l?? 1', CAST(N'2021-12-28' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (57, 24, N'Qu???n l?? 1', CAST(N'2021-12-28' AS Date), 490000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (58, 9, N'Qu???n l?? 1', CAST(N'2021-12-28' AS Date), 210000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (59, 13, N'Qu???n l?? 1', CAST(N'2021-12-28' AS Date), 350000, 1)
INSERT [dbo].[HOADON] ([MAHD], [MAKH], [NVBAN], [TGMUA], [TONGTIEN], [STATUS]) VALUES (60, 5, N'Nh??n vi??n 1', CAST(N'2021-12-28' AS Date), 150000, 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (1, N'????ng2', N'0326889240 ', N'Qu???n 7', 10329988, N'cunkul35@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (2, N'Trung', N'0323456789 ', N'Qu???n8', 8571984, N'')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (3, N'Th??y', N'0323456789 ', N'Qu???n 9', 20789992, N'')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (4, N'Huy', N'0999999999 ', N'Qu???n 6', 4596097, N'drom97977@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (5, N'H???nh', N'0259678949 ', N'B??nh D????ng', 2863000, N'drom97977@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (6, N'L??m', N'0323456789 ', N'B??nh Ph?????c', 1840022, N'drom97977@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (7, N'Hu???nh', N'0804351796 ', N'?????ng Nai', 3579996, N'drom97977@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (8, N'B??nh', N'7053770318 ', N'V??ng T??u', 6133590, N'drom97977@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (9, N'Ngh??a', N'0321456987 ', N'L??m ?????ng', 3406930, N'cunkul35@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (12, N'Tonny', N'0123456789 ', N'??ssssss', 9432682, N'cunkul35@gmail.com')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (13, N'admin', N'0326889240 ', N'adssdd', 2317965, N'')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDTKH], [DIACHI], [TONGTIEN], [EMAIL]) VALUES (24, N'testt', N'0326889240 ', N'a', 8106242, N'')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAISP] ON 

INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (1, N'DI???T VIRUS')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (2, N'WINDOWS')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (3, N'V??N PH??NG')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (4, N'GAME')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (5, N'????? h???a')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (7, N'Lo???i VIP')
INSERT [dbo].[LOAISP] ([MALOAI], [TENLOAI]) VALUES (8, N'H???c t???p')
SET IDENTITY_INSERT [dbo].[LOAISP] OFF
GO
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (1, N'Bitdefender Antivirus Plus', 3, 99, 199999)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (2, N'Kaspersky Anti-Virus', 4, 5, 299999)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (3, N'Webroot SecureAnywhere AntiVirus', 2, 88, 200000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (4, N'McAfee AntiVirus Plus', 1, 3, 350000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (5, N'ESET NOD32 Antivirus', 1, 2, 150000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (6, N'Norton AntiVirus Plus', 1, 2, 490000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (7, N'Emsisoft Anti-Malware', 2, 99, 205000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (8, N'F-Secure Anti-Virus', 2, 99, 210000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (9, N'Malwarebytes Premium', 2, 99, 170000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (10, N'Sophos Home Premium', 2, 99, 150000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (11, N'Windows 7 - 1 n??m', 2, 2, 1500000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (12, N'Windows 7 - 2 n??m', 2, 7, 2900000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (13, N'Windows 8 - 1 n??m', 2, 4, 1600000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (14, N'Windows 8 - 2 n??m', 2, 3, 3100000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (15, N'Windows 10 - 1 n??m', 2, 10, 2000000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (16, N'Windows 8 - 2 n??m', 2, 2, 3600000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (17, N'Microsoft Office 365 2 n??m', 3, 5, 1699000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (18, N'Microsoft Office 365 1 n??m', 3, 4, 986000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (19, N'Teamview 14 - 1 n??m', 3, 7, 199000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (20, N'WPS Office 1 n??m', 3, 2, 599000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (21, N'Dead Cell', 4, 5, 140000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (22, N'????a Game PS4 Final Fantasy XII: The Zodiac Age', 4, 5, 580000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (23, N'????a Game PS4 Pes 2021 H??? EU', 4, 4, 680000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (24, N'????a Game PS4 Pes 2021 H??? Asia', 4, 2, 780000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (25, N'????a Game PS4 Fifa 21 H??? Asia', 4, 5, 1390000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (26, N'8-Bit Armies', 4, 15, 82000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (27, N'Rise of the Tomb Raider: 20 Year Celebration', 4, 28, 310000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (28, N'Pummel Party', 4, 15, 108000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (29, N'Warhammer: Vermintide 2', 4, 15, 62000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (30, N'Killing Floor 2 Digital Deluxe Edition', 4, 16, 102000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (31, N'Adobe Creative Cloud (PC) - 1 Year - Adobe Key GLOBAL', 5, 6, 3066845)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (32, N'3D Sprite Renderer Steam Gift GLOBAL', 5, 7, 942259)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (33, N'Shadron Steam Gift GLOBAL', 5, 12, 573590)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (34, N'PD Howler 9.6 Digital Painter and Visual FX box Steam Key GLOBAL', 7, 99, 797965)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (36, N'Ph???n m???m t??u', 3, 12, 199999)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (37, N'test', 7, 2217, 22)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [LOAISP], [SOLUONGTON], [DONGIA]) VALUES (41, N'test', 5, 21, 22)
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
GO
/****** Object:  Index [UQ__LOAISP__2F633F22D58880A8]    Script Date: 1/5/2022 11:15:31 PM ******/
ALTER TABLE [dbo].[LOAISP] ADD UNIQUE NONCLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACCOUNT] ADD  DEFAULT ((0)) FOR [TYPE]
GO
ALTER TABLE [dbo].[CHITIETHOADON] ADD  DEFAULT ((1)) FOR [SL]
GO
ALTER TABLE [dbo].[HOADON] ADD  DEFAULT (getdate()) FOR [TGMUA]
GO
ALTER TABLE [dbo].[HOADON] ADD  DEFAULT ((0)) FOR [STATUS]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((0)) FOR [TONGTIEN]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD FOREIGN KEY([LOAISP])
REFERENCES [dbo].[LOAISP] ([MALOAI])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SANPHAM"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HOADON"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "KHACHHANG"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEWBILLINFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEWBILLINFO'
GO

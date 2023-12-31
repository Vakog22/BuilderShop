

USE [Builder]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nchar](15) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](10) NOT NULL,
	[Height] [decimal](5, 2) NOT NULL,
	[Width] [decimal](5, 2) NOT NULL,
	[Length] [decimal](5, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[IdManufacturer] [int] NOT NULL,
	[IdGroup] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[IdClient] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleProduct]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleProduct](
	[IdSale] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_SaleProduct] PRIMARY KEY CLUSTERED 
(
	[IdSale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.11.2023 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[LName] [nvarchar](50) NOT NULL,
	[PName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Group] ([Id], [Title]) VALUES (1, N'Материалы')
INSERT [dbo].[Group] ([Id], [Title]) VALUES (2, N'Крепления')
INSERT [dbo].[Group] ([Id], [Title]) VALUES (3, N'Инструменты')
GO
INSERT [dbo].[Manufacturer] ([Id], [Name], [Phone], [Address]) VALUES (1, N'Пилорама', N'12345          ', N'Нигде')
INSERT [dbo].[Manufacturer] ([Id], [Name], [Phone], [Address]) VALUES (2, N'Плавильня', N'54321          ', N'Там')
INSERT [dbo].[Manufacturer] ([Id], [Name], [Phone], [Address]) VALUES (3, N'Завод', N'0              ', N'Где-то')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FName], [LName], [PName], [Phone], [DateOfBirth], [Login], [Password], [IsAdmin]) VALUES (1, N'1', N'1', N'1', N'1', CAST(N'2001-01-01' AS Date), N'1', N'1', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Group]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([IdManufacturer])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_User] FOREIGN KEY([IdClient])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_User]
GO
ALTER TABLE [dbo].[SaleProduct]  WITH CHECK ADD  CONSTRAINT [FK_SaleProduct_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SaleProduct] CHECK CONSTRAINT [FK_SaleProduct_Product]
GO
ALTER TABLE [dbo].[SaleProduct]  WITH CHECK ADD  CONSTRAINT [FK_SaleProduct_Sale] FOREIGN KEY([IdSale])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[SaleProduct] CHECK CONSTRAINT [FK_SaleProduct_Sale]
GO

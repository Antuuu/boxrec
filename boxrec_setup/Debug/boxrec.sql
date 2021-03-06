USE [master]
GO
/****** Object:  Database [boxrec]    Script Date: 6/29/2022 6:23:29 PM ******/
CREATE DATABASE [boxrec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'boxrec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\boxrec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'boxrec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\boxrec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [boxrec] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [boxrec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [boxrec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [boxrec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [boxrec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [boxrec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [boxrec] SET ARITHABORT OFF 
GO
ALTER DATABASE [boxrec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [boxrec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [boxrec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [boxrec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [boxrec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [boxrec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [boxrec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [boxrec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [boxrec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [boxrec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [boxrec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [boxrec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [boxrec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [boxrec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [boxrec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [boxrec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [boxrec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [boxrec] SET RECOVERY FULL 
GO
ALTER DATABASE [boxrec] SET  MULTI_USER 
GO
ALTER DATABASE [boxrec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [boxrec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [boxrec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [boxrec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [boxrec] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [boxrec] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'boxrec', N'ON'
GO
ALTER DATABASE [boxrec] SET QUERY_STORE = OFF
GO
USE [boxrec]
GO
/****** Object:  Table [dbo].[Boxers]    Script Date: 6/29/2022 6:23:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Division_ID] [int] NOT NULL,
	[Photo_Url] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 6/29/2022 6:23:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fights]    Script Date: 6/29/2022 6:23:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fights](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Boxer1_ID] [int] NOT NULL,
	[Boxer2_ID] [int] NOT NULL,
	[Winner_ID] [int] NULL,
	[DateOfFight] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/29/2022 6:23:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Boxers] ON 

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (1, N'Tyson', N'Fury', CAST(N'1988-09-20' AS Date), 6, N'https://boxrec.com/media/images/thumb/3/3a/TysonFury12.jpg/200px-TysonFury12.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (2, N'Oleksandr', N'Usyk', CAST(N'1990-02-03' AS Date), 6, N'https://boxrec.com/media/images/thumb/2/26/659772.jpg/200px-659772.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (3, N'Deontay', N'Wilder', CAST(N'1979-12-20' AS Date), 6, N'https://boxrec.com/media/images/thumb/e/e0/DeontayWilder123.jpg/200px-DeontayWilder123.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (4, N'Anthony', N'Joshua', CAST(N'1990-07-09' AS Date), 6, N'https://boxrec.com/media/images/thumb/3/38/659461.jpeg/200px-659461.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (5, N'Dillian', N'Whyte', CAST(N'1984-05-24' AS Date), 6, N'https://boxrec.com/media/images/thumb/5/5c/Dwhyte.jpg/200px-Dwhyte.jpg')

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (6, N'Mairis', N'Briedis', CAST(N'1988-09-20' AS Date), 5, N'https://boxrec.com/media/images/thumb/7/7c/MairisBriedis.jpeg/200px-MairisBriedis.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (7, N'Ilunga', N'Makabu', CAST(N'1990-02-03' AS Date), 5, N'https://boxrec.com/media/images/thumb/c/ce/457720.jpeg/200px-457720.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (8, N'Lawrence', N'Okolie', CAST(N'1979-12-20' AS Date), 5, N'https://boxrec.com/media/images/thumb/5/5e/Lawrence_Okolie.jpg/200px-Lawrence_Okolie.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (9, N'Thabiso', N'Mchunu', CAST(N'1990-07-09' AS Date), 5, N'https://boxrec.com/media/images/thumb/9/91/438266.jpeg/200px-438266.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (10, N'Yuniel', N'Dorticos', CAST(N'1984-05-24' AS Date), 5, N'https://boxrec.com/media/images/thumb/d/d8/Dorticos_Head.jpg/200px-Dorticos_Head.jpg')

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (11, N'Dmitrii', N'Bivol', CAST(N'1988-09-20' AS Date), 4, N'https://boxrec.com/media/images/thumb/5/51/DmitryBivol1.jpg/200px-DmitryBivol1.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (12, N'Artur', N'Beterbiev', CAST(N'1990-02-03' AS Date), 4, N'https://boxrec.com/media/images/thumb/2/20/Artur_Beterbiev.jpeg/200px-Artur_Beterbiev.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (13, N'Gilberto', N'Ramirez', CAST(N'1979-12-20' AS Date), 4, N'https://boxrec.com/media/images/thumb/6/6f/GilbertoRamirezSanchez1.JPG/200px-GilbertoRamirezSanchez1.JPG')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (14, N'Callum', N'Smith', CAST(N'1990-07-09' AS Date), 4, N'https://boxrec.com/media/images/thumb/8/81/631178.jpeg/200px-631178.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (15, N'Joe', N'Smith Jr', CAST(N'1984-05-24' AS Date), 4, N'https://boxrec.com/media/images/thumb/7/7b/513839.jpg/200px-513839.jpg')

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (16, N'Saul', N'Alvarez', CAST(N'1988-09-20' AS Date), 3, N'https://boxrec.com/media/images/thumb/7/74/Santos_Saul_Alvarez_Barragan1.jpg/200px-Santos_Saul_Alvarez_Barragan1.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (17, N'Demetrius', N'Andrade', CAST(N'1990-02-03' AS Date), 3, N'https://boxrec.com/media/images/thumb/b/bc/Demetrius_Andrade_2019.JPG/200px-Demetrius_Andrade_2019.JPG')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (18, N'John', N'Ryder', CAST(N'1979-12-20' AS Date), 3, N'https://boxrec.com/media/images/thumb/8/86/John_Ryder11.jpg/200px-John_Ryder11.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (19, N'Daniel', N'Jacobs', CAST(N'1990-07-09' AS Date), 3, N'https://boxrec.com/media/images/thumb/1/1e/DannyJacobs1.jpg/200px-DannyJacobs1.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (20, N'David', N'Benavidez', CAST(N'1984-05-24' AS Date), 3, N'https://boxrec.com/media/images/thumb/0/08/DavidBenavidez1.jpg/200px-DavidBenavidez1.jpg')

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (21, N'Gennadiy', N'Golovkin', CAST(N'1988-09-20' AS Date), 2, N'https://boxrec.com/media/images/thumb/b/b9/GGG.jpg/200px-GGG.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (22, N'Chris', N'Eubank', CAST(N'1990-02-03' AS Date), 2, N'https://boxrec.com/media/images/thumb/f/f9/Eubankjr588468.jpeg/200px-Eubankjr588468.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (23, N'Jaime', N'Munguia', CAST(N'1979-12-20' AS Date), 2, N'https://boxrec.com/media/images/thumb/b/be/659924.jpg/200px-659924.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (24, N'Carlos', N'Adames', CAST(N'1990-07-09' AS Date), 2, N'https://boxrec.com/media/images/thumb/4/43/Cadames.jpg/200px-Cadames.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (25, N'Michael', N'Zerafa', CAST(N'1984-05-24' AS Date), 2, N'https://boxrec.com/media/images/thumb/5/57/0A8C655F-9DAD-44BE-AA30-A06CB205B09C.jpeg/200px-0A8C655F-9DAD-44BE-AA30-A06CB205B09C.jpeg')

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (26, N'Gervonta', N'Davis', CAST(N'1988-09-20' AS Date), 2, N'https://boxrec.com/media/images/thumb/e/e6/643387.jpeg/200px-643387.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (27, N'Devin', N'Haney', CAST(N'1990-02-03' AS Date), 2, N'https://boxrec.com/media/images/thumb/7/7b/DevinHaney.jpg/200px-DevinHaney.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (28, N'George', N'Kambosos', CAST(N'1979-12-20' AS Date), 2, N'https://boxrec.com/media/images/thumb/d/dc/646781.jpeg/200px-646781.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (29, N'Teofimo', N'Lopez', CAST(N'1990-07-09' AS Date), 2, N'https://boxrec.com/media/images/thumb/a/a4/TeofimoLopez.jpeg/200px-TeofimoLopez.jpeg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (30, N'Vasyl', N'Lomachenko', CAST(N'1984-05-24' AS Date), 2, N'https://boxrec.com/media/images/thumb/6/68/Vasyl_Lomachenko1.JPG/200px-Vasyl_Lomachenko1.JPG')

SET IDENTITY_INSERT [dbo].[Boxers] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 

INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (1, N'Lightweight')
INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (2, N'Middleweight')
INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (3, N'Supermiddleweight')
INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (4, N'Lightheavyweight')
INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (5, N'Cruiserweight')
INSERT [dbo].[Divisions] ([ID], [Name]) VALUES (6, N'Heavyweight')
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[Fights] ON 

INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (1, 1, 2, 1, CAST(N'2017-05-21' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (2, 2, 4, 4, CAST(N'2020-09-29' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (3, 2, 5, 5, CAST(N'2015-07-12' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (4, 4, 5, 0, CAST(N'2019-01-12' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (5, 4, 3, 3, CAST(N'2022-02-02' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (6, 4, 5, 5, CAST(N'2017-06-05' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (7, 2, 3, 2, CAST(N'2019-04-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (8, 4, 5, 5, CAST(N'2019-01-24' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (9, 2, 5, 2, CAST(N'2019-03-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (10, 2, 3, 2, CAST(N'2019-04-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (11, 2, 3, 2, CAST(N'2016-07-14' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (12, 2, 3, 2, CAST(N'2016-06-07' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (13, 4, 5, 5, CAST(N'2016-10-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (14, 2, 5, 2, CAST(N'2016-11-05' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (15, 2, 3, 2, CAST(N'2009-12-04' AS Date))

INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (16, 7, 6, 6, CAST(N'2017-05-21' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (17, 9, 8, 8, CAST(N'2020-09-29' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (18, 9, 7, 7, CAST(N'2015-07-12' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (19, 7, 8, 0, CAST(N'2019-01-12' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (20, 8, 6, 3, CAST(N'2022-02-02' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (21, 6, 8, 5, CAST(N'2017-06-05' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (22, 10, 11, 10, CAST(N'2018-04-15' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (23, 14, 15, 0, CAST(N'2019-01-24' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (24, 12, 13, 12, CAST(N'2019-03-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (25, 15, 16, 15, CAST(N'2019-04-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (26, 19, 17, 17, CAST(N'2016-07-14' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (27, 18, 16, 18, CAST(N'2016-06-07' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (28, 17, 20, 0, CAST(N'2016-10-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (29, 21, 22, 22, CAST(N'2016-11-05' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (30, 23, 24, 24, CAST(N'2019-04-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (31, 26, 27, 27, CAST(N'2019-04-16' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (32, 29, 30, 0, CAST(N'2009-12-04' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (33, 27, 25, 25, CAST(N'2018-04-15' AS Date))

SET IDENTITY_INSERT [dbo].[Fights] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Fights]  WITH CHECK ADD FOREIGN KEY([Boxer1_ID])
REFERENCES [dbo].[Boxers] ([ID])
GO
ALTER TABLE [dbo].[Fights]  WITH CHECK ADD FOREIGN KEY([Boxer2_ID])
REFERENCES [dbo].[Boxers] ([ID])
GO
ALTER TABLE [dbo].[Fights]  WITH CHECK ADD FOREIGN KEY([Winner_ID])
REFERENCES [dbo].[Boxers] ([ID])
GO
ALTER TABLE [dbo].[Boxers]  WITH CHECK ADD FOREIGN KEY([Division_ID])
REFERENCES [dbo].[Divisions] ([ID])
GO
ALTER TABLE [dbo].[Boxers]  WITH CHECK ADD  CONSTRAINT [DateOfBirthConstraint] CHECK  (([DateOfBirth]<getdate() AND [DateOfBirth]>'1900-01-01'))
GO
ALTER TABLE [dbo].[Boxers] CHECK CONSTRAINT [DateOfBirthConstraint]
GO
ALTER TABLE [dbo].[Fights]  WITH CHECK ADD  CONSTRAINT [DateOfFightConstraint] CHECK  (([DateOfFight]<getdate() AND [DateOfFight]>'1900-01-01'))
GO
ALTER TABLE [dbo].[Fights] CHECK CONSTRAINT [DateOfFightConstraint]
GO
USE [master]
GO
ALTER DATABASE [boxrec] SET  READ_WRITE 
GO

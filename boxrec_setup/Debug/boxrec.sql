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

INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (1, N'Tyson', N'Fury', CAST(N'1998-09-20' AS Date), 6, N'https://static.prsa.pl/images/193a44e4-e9c6-49b1-88d5-65a13055494c.jpg?format=500')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (2, N'Endrju', N'Golara', CAST(N'1998-09-20' AS Date), 6, N'https://i.iplsc.com/deontay-wilder/0007Y9AZLGH1QO6S-C122-F4.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (3, N'Dillian', N'Whyte', CAST(N'1998-09-20' AS Date), 6, N'https://bi.im-g.pl/im/aa/0d/1b/z28367530Q,Britain-Boxing.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (4, N'Anthony', N'Joshua', CAST(N'1998-09-20' AS Date), 6, N'https://d-art.ppstatic.pl/kadry/k/r/1/de/89/614c8090ea0a2_o_original.jpg')
INSERT [dbo].[Boxers] ([ID], [Name], [Surname], [DateOfBirth], [Division_ID], [Photo_Url]) VALUES (5, N'Dereck', N'Chisora', CAST(N'1998-09-20' AS Date), 6, N'https://ipla.pluscdn.pl/dituel/cp/3o/3om1mmgxghojn4u95b2vnjwciav9rqfb.jpg')
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

INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (1, 1, 2, 1, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (2, 2, 4, 4, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (3, 2, 5, 5, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (4, 4, 5, NULL, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (5, 4, 3, 3, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (6, 4, 5, 5, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (7, 2, 3, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (8, 4, 5, 5, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (9, 2, 5, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (10, 2, 3, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (11, 2, 3, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (12, 2, 3, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (13, 4, 5, 5, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (14, 2, 5, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (15, 2, 3, 2, CAST(N'1998-09-20' AS Date))
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID], [DateOfFight]) VALUES (16, 2, 3, 2, CAST(N'1998-09-20' AS Date))
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

USE [master]
GO
/****** Object:  Database [boxrec]    Script Date: 6/24/2022 12:09:31 AM ******/
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
/****** Object:  User [segal]    Script Date: 6/24/2022 12:09:31 AM ******/
CREATE USER [segal] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Belts]    Script Date: 6/24/2022 12:09:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Belts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Organization] [nvarchar](20) NOT NULL,
	[Division] [int] NOT NULL,
	[Boxer_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boxers]    Script Date: 6/24/2022 12:09:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[surname] [nvarchar](100) NOT NULL,
	[dateofbirth] [date] NOT NULL,
	[division] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 6/24/2022 12:09:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Division] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fights]    Script Date: 6/24/2022 12:09:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fights](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Boxer1_ID] [int] NOT NULL,
	[Boxer2_ID] [int] NOT NULL,
	[Winner_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/24/2022 12:09:32 AM ******/
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
SET IDENTITY_INSERT [dbo].[Belts] ON 

INSERT [dbo].[Belts] ([ID], [Organization], [Division], [Boxer_ID]) VALUES (1, N'WBA WORLD', 6, 2)
INSERT [dbo].[Belts] ([ID], [Organization], [Division], [Boxer_ID]) VALUES (2, N'WBC WORLD', 6, 2)
INSERT [dbo].[Belts] ([ID], [Organization], [Division], [Boxer_ID]) VALUES (3, N'WBO WORLD', 6, 2)
INSERT [dbo].[Belts] ([ID], [Organization], [Division], [Boxer_ID]) VALUES (4, N'IBF WORLD', 6, 2)
SET IDENTITY_INSERT [dbo].[Belts] OFF
GO
SET IDENTITY_INSERT [dbo].[Boxers] ON 

INSERT [dbo].[Boxers] ([ID], [name], [surname], [dateofbirth], [division]) VALUES (2, N'Tyson', N'Fury', CAST(N'1998-09-20' AS Date), 6)
INSERT [dbo].[Boxers] ([ID], [name], [surname], [dateofbirth], [division]) VALUES (3, N'Deontay', N'Wilder', CAST(N'1998-09-20' AS Date), 6)
INSERT [dbo].[Boxers] ([ID], [name], [surname], [dateofbirth], [division]) VALUES (5, N'Dillian', N'Whyte', CAST(N'1998-09-20' AS Date), 6)
INSERT [dbo].[Boxers] ([ID], [name], [surname], [dateofbirth], [division]) VALUES (6, N'Anthony', N'Joshua', CAST(N'1998-09-20' AS Date), 6)

SET IDENTITY_INSERT [dbo].[Boxers] OFF
GO
SET IDENTITY_INSERT [dbo].[Division] ON 

INSERT [dbo].[Division] ([ID], [Division]) VALUES (1, N'Lightweight')
INSERT [dbo].[Division] ([ID], [Division]) VALUES (2, N'Middleweight')
INSERT [dbo].[Division] ([ID], [Division]) VALUES (3, N'Supermiddleweight')
INSERT [dbo].[Division] ([ID], [Division]) VALUES (4, N'Lightheavyweight')
INSERT [dbo].[Division] ([ID], [Division]) VALUES (5, N'Cruiserweight')
INSERT [dbo].[Division] ([ID], [Division]) VALUES (6, N'Heavyweight')
SET IDENTITY_INSERT [dbo].[Division] OFF
GO
SET IDENTITY_INSERT [dbo].[Fights] ON 

INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (1, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (2, 2, 4, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (3, 2, 5, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (4, 4, 5, NULL)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (5, 4, 3, 3)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (6, 4, 5, 5)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (7, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (8, 4, 5, 5)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (9, 2, 5, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (10, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (11, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (12, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (13, 4, 5, 5)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (14, 2, 5, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (15, 2, 3, 2)
INSERT [dbo].[Fights] ([ID], [Boxer1_ID], [Boxer2_ID], [Winner_ID]) VALUES (16, 2, 3, 2)
SET IDENTITY_INSERT [dbo].[Fights] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Boxers]  WITH CHECK ADD FOREIGN KEY([division])
REFERENCES [dbo].[Division] ([ID])
GO
ALTER TABLE [dbo].[Boxers]  WITH CHECK ADD FOREIGN KEY([division])
REFERENCES [dbo].[Division] ([ID])
GO
USE [master]
GO
ALTER DATABASE [boxrec] SET  READ_WRITE 
GO

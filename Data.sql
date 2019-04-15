USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 4/15/2019 1:18:24 PM ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookStore.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookStore_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/15/2019 1:18:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](50) NULL,
	[BookPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/15/2019 1:18:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [char](10) NOT NULL,
	[EmpPassword] [char](15) NULL,
	[EmpRole] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (1, N'Java', 1000)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (2, N'C#', 150)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (3, N'JavaScript', 200)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (4, N'C++', 100)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (5, N'Python', 80)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (6, N'Ruby', 1500)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (7, N'NodeJS', 150)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (8, N'C', 150)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (9, N'.Net', 100)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (10, N'React', 150)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (11, N'JQuery', 1005)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (13, N'Node', 1500)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (14, N'Python-2', 80)
INSERT [dbo].[Books] ([BookID], [BookName], [BookPrice]) VALUES (15, N'abc', 100000)
SET IDENTITY_INSERT [dbo].[Books] OFF
INSERT [dbo].[Employee] ([EmpID], [EmpPassword], [EmpRole]) VALUES (N'hauloan   ', N'123151         ', 0)
INSERT [dbo].[Employee] ([EmpID], [EmpPassword], [EmpRole]) VALUES (N'loanhau   ', N'151123         ', 1)
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO

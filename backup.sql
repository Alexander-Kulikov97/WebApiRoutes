USE [master]
GO
/****** Object:  Database [WebApiRoutesDB]    Script Date: 18.04.2021 20:29:05 ******/
CREATE DATABASE [WebApiRoutesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebApiRoutesDB_Data', FILENAME = N'c:\dzsqls\WebApiRoutesDB.mdf' , SIZE = 8192KB , MAXSIZE = 30720KB , FILEGROWTH = 22528KB )
 LOG ON 
( NAME = N'WebApiRoutesDB_Logs', FILENAME = N'c:\dzsqls\WebApiRoutesDB.ldf' , SIZE = 8192KB , MAXSIZE = 30720KB , FILEGROWTH = 22528KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebApiRoutesDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebApiRoutesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebApiRoutesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebApiRoutesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebApiRoutesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebApiRoutesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebApiRoutesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebApiRoutesDB] SET  MULTI_USER 
GO
ALTER DATABASE [WebApiRoutesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebApiRoutesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebApiRoutesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebApiRoutesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebApiRoutesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebApiRoutesDB] SET QUERY_STORE = OFF
GO
USE [WebApiRoutesDB]
GO
/****** Object:  User [Artem9989_SQLLogin_1]    Script Date: 18.04.2021 20:29:07 ******/
CREATE USER [Artem9989_SQLLogin_1] FOR LOGIN [Artem9989_SQLLogin_1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Artem9989_SQLLogin_1]
GO
/****** Object:  Schema [Artem9989_SQLLogin_1]    Script Date: 18.04.2021 20:29:08 ******/
CREATE SCHEMA [Artem9989_SQLLogin_1]
GO
/****** Object:  Table [dbo].[t_drivers]    Script Date: 18.04.2021 20:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_drivers](
	[userId] [int] NOT NULL,
	[vehiclenumber] [nvarchar](20) NOT NULL,
	[vehicletype] [nvarchar](50) NOT NULL,
	[status] [varchar](40) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_point]    Script Date: 18.04.2021 20:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_point](
	[id_point] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[id_route] [uniqueidentifier] NOT NULL,
	[lat] [numeric](18, 5) NOT NULL,
	[lng] [numeric](18, 5) NOT NULL,
	[speed] [nvarchar](50) NULL,
 CONSTRAINT [PK_t_point] PRIMARY KEY CLUSTERED 
(
	[id_point] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_role]    Script Date: 18.04.2021 20:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_role](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[nameRu] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_routes]    Script Date: 18.04.2021 20:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_routes](
	[id_route] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[id_drivers] [int] NULL,
	[start_coord] [uniqueidentifier] NULL,
	[end_coord] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_routes] PRIMARY KEY CLUSTERED 
(
	[id_route] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_user]    Script Date: 18.04.2021 20:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_user](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NULL,
	[last_name] [nvarchar](100) NULL,
	[middle_name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[login] [nvarchar](100) NOT NULL,
	[role_id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_point] ADD  CONSTRAINT [DF_t_point_id_point]  DEFAULT (newid()) FOR [id_point]
GO
ALTER TABLE [dbo].[t_role] ADD  CONSTRAINT [DF_t_role_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[t_routes] ADD  CONSTRAINT [DF_t_routes_id_route]  DEFAULT (newid()) FOR [id_route]
GO
USE [master]
GO
ALTER DATABASE [WebApiRoutesDB] SET  READ_WRITE 
GO

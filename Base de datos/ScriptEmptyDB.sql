USE [master]
GO
/****** Object:  Database [ParkingDBEmpty]    Script Date: 11/21/19 8:36:39 PM ******/
CREATE DATABASE [ParkingDBEmpty]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ParkingDBE', FILENAME = N'C:\Users\sebaban99\ParkingDBE.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ParkingDBE_log', FILENAME = N'C:\Users\sebaban99\ParkingDBE_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ParkingDBEmpty] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParkingDBEmpty].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParkingDBEmpty] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ParkingDBEmpty] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ParkingDBEmpty] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParkingDBEmpty] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ParkingDBEmpty] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParkingDBEmpty] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ParkingDBEmpty] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ParkingDBEmpty] SET  MULTI_USER 
GO
ALTER DATABASE [ParkingDBEmpty] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ParkingDBEmpty] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ParkingDBEmpty] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ParkingDBEmpty] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ParkingDBEmpty] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ParkingDBEmpty]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/21/19 8:36:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/21/19 8:36:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Balance] [int] NOT NULL,
	[CountryTag] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CostsPerMinute]    Script Date: 11/21/19 8:36:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostsPerMinute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
	[CountryTag] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CostsPerMinute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 11/21/19 8:36:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](max) NULL,
	[StartingHour] [datetime] NOT NULL,
	[FinishingHour] [datetime] NOT NULL,
	[AmountOfMinutes] [int] NOT NULL,
	[CountryTag] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Purchases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ParkingDBEmpty] SET  READ_WRITE 
GO

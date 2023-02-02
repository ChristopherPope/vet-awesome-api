USE [master]
GO
/****** Object:  Database [VET-AWESOME-DEV]    Script Date: 2/2/2023 7:26:22 AM ******/
CREATE DATABASE [VET-AWESOME-DEV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VET-AWESOME-DEV', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VET-AWESOME-DEV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VET-AWESOME-DEV_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VET-AWESOME-DEV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VET-AWESOME-DEV] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VET-AWESOME-DEV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ARITHABORT OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET RECOVERY FULL 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET  MULTI_USER 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VET-AWESOME-DEV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VET-AWESOME-DEV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'VET-AWESOME-DEV', N'ON'
GO
ALTER DATABASE [VET-AWESOME-DEV] SET QUERY_STORE = OFF
GO
USE [VET-AWESOME-DEV]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[PetId] [int] NOT NULL,
	[VeterinarianId] [int] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StreetAddress1] [varchar](50) NOT NULL,
	[StreetAddress2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[StateId] [int] NOT NULL,
	[CellPhone] [varchar](15) NULL,
	[HomePhone] [varchar](15) NULL,
	[WorkPhone] [varchar](15) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetBreeds]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetBreeds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PetTypeId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PetBreeds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pets]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PetBreedId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetTypes]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PetTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Abbreviation] [varchar](2) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/2/2023 7:26:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[UserRoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Pets] FOREIGN KEY([PetId])
REFERENCES [dbo].[Pets] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Pets]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users] FOREIGN KEY([VeterinarianId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_States]
GO
ALTER TABLE [dbo].[PetBreeds]  WITH CHECK ADD  CONSTRAINT [FK_PetBreeds_PetTypes] FOREIGN KEY([PetTypeId])
REFERENCES [dbo].[PetTypes] ([Id])
GO
ALTER TABLE [dbo].[PetBreeds] CHECK CONSTRAINT [FK_PetBreeds_PetTypes]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_Customers]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_PetBreeds] FOREIGN KEY([PetBreedId])
REFERENCES [dbo].[PetBreeds] ([Id])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_PetBreeds]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRoles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
USE [master]
GO
ALTER DATABASE [VET-AWESOME-DEV] SET  READ_WRITE 
GO

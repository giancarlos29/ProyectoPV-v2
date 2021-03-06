USE [master]
GO
/****** Object:  Database [SistemaPrestamosPV]    Script Date: 4/26/2019 9:46:19 PM ******/
CREATE DATABASE [SistemaPrestamosPV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaPrestamosPV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SistemaPrestamosPV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaPrestamosPV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SistemaPrestamosPV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SistemaPrestamosPV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaPrestamosPV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaPrestamosPV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaPrestamosPV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaPrestamosPV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaPrestamosPV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaPrestamosPV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaPrestamosPV] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaPrestamosPV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaPrestamosPV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaPrestamosPV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaPrestamosPV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaPrestamosPV] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaPrestamosPV', N'ON'
GO
ALTER DATABASE [SistemaPrestamosPV] SET QUERY_STORE = OFF
GO
USE [SistemaPrestamosPV]
GO
/****** Object:  Table [dbo].[BackUps]    Script Date: 4/26/2019 9:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackUps](
	[IDBackUp] [nchar](10) NOT NULL,
	[UltimoBackUp] [datetime] NULL,
 CONSTRAINT [PK_BackUps] PRIMARY KEY CLUSTERED 
(
	[IDBackUp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deudores]    Script Date: 4/26/2019 9:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deudores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Capital] [float] NOT NULL,
	[Interes] [float] NULL,
	[ReditoMensual] [float] NULL,
	[CuotasVencidas] [int] NULL,
	[ReditoAcumulado] [float] NULL,
	[FechaInicializacionPrestamo] [date] NOT NULL,
	[CuotasGeneradas] [int] NULL,
	[UltimoPago] [date] NOT NULL,
	[CuotasPagadas] [int] NULL,
	[CuotasPagadasATiempo] [int] NULL,
	[Score] [int] NULL,
	[Cedula] [varchar](11) NULL,
	[Telefono] [varchar](15) NULL,
	[Telefono2] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[Direccion] [varchar](200) NULL,
 CONSTRAINT [PK_Deudores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saldadores]    Script Date: 4/26/2019 9:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saldadores](
	[IDSaldador] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[CapitalSaldado] [float] NULL,
	[FechaInicializacionPrestamo] [date] NULL,
	[FechaFinalizacionPrestamo] [date] NULL,
	[CuotasGeneradas] [int] NULL,
	[CuotasPagadasATiempo] [int] NULL,
	[Score] [int] NULL,
	[Telefono] [varchar](50) NULL,
	[Direccion] [varchar](250) NULL,
	[Cedula] [varchar](11) NULL,
 CONSTRAINT [PK_Saldadores] PRIMARY KEY CLUSTERED 
(
	[IDSaldador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/26/2019 9:46:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[backupdb]    Script Date: 4/26/2019 9:46:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[backupdb]
as
BACKUP DATABASE [SistemaPrestamosPV] TO  DISK =N'C:\BackUP\BackUPBaseDatos.bak'
WITH NOFORMAT, NOINIT,  NAME = N'test-Completa Base de datos Copia de seguridad', SKIP,NOREWIND, NOUNLOAD,  STATS = 10



GO
/****** Object:  StoredProcedure [dbo].[spSumCuotasVencidas]    Script Date: 4/26/2019 9:46:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spSumCuotasVencidas]
as
select sum(CuotasVencidas)
from Deudores
GO
USE [master]
GO
ALTER DATABASE [SistemaPrestamosPV] SET  READ_WRITE 
GO

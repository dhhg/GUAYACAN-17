USE [master]
GO
/****** Object:  Database [CP_Ocean_Recibo]    Script Date: 23/10/2017 02:26:00 p. m. ******/
CREATE DATABASE [CP_Ocean_Recibo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cyberzone', FILENAME = N'C:\instancia\COMPAC\MSSQL11.COMPAC\MSSQL\DATA\cyberzone.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'cyberzone_log', FILENAME = N'C:\instancia\COMPAC\MSSQL11.COMPAC\MSSQL\DATA\cyberzone_log.ldf' , SIZE = 43264KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CP_Ocean_Recibo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CP_Ocean_Recibo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ARITHABORT OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET RECOVERY FULL 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET  MULTI_USER 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CP_Ocean_Recibo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CP_Ocean_Recibo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CP_Ocean_Recibo', N'ON'
GO
USE [CP_Ocean_Recibo]
GO
/****** Object:  StoredProcedure [dbo].[SumaPerDec]    Script Date: 23/10/2017 02:26:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SumaPerDec] @guidarchivo varchar(50) as
	declare @rfcemi varchar(15)
	declare @db varchar(50)
	declare @persepcion varchar(max)
	set @rfcemi = (select t1.rfcemisro  from recibos t1 where GUIDArchivo=@guidarchivo)
	set @db= (select t1.BaseDatos from tbEmpresa t1 where t1.RFCEmpresa=@rfcemi)
	set @persepcion = (CONCAT('select sum(t2.importetotal) from ',@db,'.dbo.nom10043 t1, ',@db,'.dbo.nom10007 t2 inner join ',@db,'.dbo.nom10004 t3 on t2.idConcepto=t3.idConcepto where t1.IdEmpleado=t2.IdEmpleado and t1.IdPeriodo=t2.IdPeriodo and t3.ClaveAgrupadoraSAT<>'''' and t1.GUIDDocumentoDSL=',''',@guidarchivo,'''))
	execute @persepcion;
GO
/****** Object:  Table [dbo].[Email]    Script Date: 23/10/2017 02:26:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[id] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[servidorsalida] [varchar](50) NOT NULL,
	[servidorentrante] [varchar](50) NOT NULL,
	[puerto] [int] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[pwd] [varchar](50) NOT NULL,
	[autoidentificacion] [int] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recibos]    Script Date: 23/10/2017 02:26:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recibos](
	[GUIDArchivo] [varchar](255) NOT NULL,
	[numeroempleado] [varchar](50) NOT NULL,
	[preriodo] [varchar](50) NOT NULL,
	[fechapago] [varchar](50) NOT NULL,
	[seriecertificadoemisor] [varchar](255) NOT NULL,
	[foliofiscal] [varchar](255) NOT NULL,
	[seriesertificadosat] [varchar](255) NOT NULL,
	[cadenaoriginal] [text] NOT NULL,
	[version] [varchar](255) NOT NULL,
	[sello] [text] NOT NULL,
	[ruta] [varchar](255) NOT NULL,
	[archivopdf] [varchar](255) NOT NULL,
	[archivoxml] [varchar](255) NOT NULL,
	[enviado] [int] NOT NULL,
	[impreso] [int] NOT NULL,
	[pdf] [int] NOT NULL,
	[FechaTimbrado] [varchar](50) NOT NULL,
	[qrcode] [varchar](255) NOT NULL,
	[cletra] [varchar](255) NOT NULL,
	[emisor] [varchar](255) NOT NULL,
	[rfcemisro] [varchar](255) NOT NULL,
	[rfcprovcertif] [varbinary](255) NULL,
	[sellosat] [text] NOT NULL,
	[RutaPublicar] [varchar](255) NOT NULL,
	[FormaDePago] [varchar](255) NOT NULL,
	[MetodoPago] [varchar](255) NOT NULL,
	[Complemento] [varchar](255) NOT NULL,
	[VersionCFDi] [varchar](50) NOT NULL,
	[FTP] [int] NOT NULL,
	[NumeroPeriodo] [int] NOT NULL,
	[Receptor] [varchar](255) NOT NULL,
	[imgqrcode] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Recibos] PRIMARY KEY CLUSTERED 
(
	[GUIDArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Recibos__9F738A369F9B1D94] UNIQUE NONCLUSTERED 
(
	[GUIDArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbEmpresa]    Script Date: 23/10/2017 02:26:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbEmpresa](
	[RFCEmpresa] [varchar](20) NOT NULL,
	[Empresa] [varchar](250) NOT NULL,
	[BaseDatos] [varchar](250) NOT NULL,
	[Recibo] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tbEmpresa] PRIMARY KEY CLUSTERED 
(
	[RFCEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tbEmpresa] UNIQUE NONCLUSTERED 
(
	[RFCEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__FechaTi__164452B1]  DEFAULT ('') FOR [FechaTimbrado]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__qrcode__173876EA]  DEFAULT ('') FOR [qrcode]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__cletra__182C9B23]  DEFAULT ('') FOR [cletra]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__emisor__1920BF5C]  DEFAULT ('') FOR [emisor]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__rfcemis__1A14E395]  DEFAULT ('') FOR [rfcemisro]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF__Recibos__sellosa__1B0907CE]  DEFAULT ('') FOR [sellosat]
GO
ALTER TABLE [dbo].[Recibos] ADD  CONSTRAINT [DF_Recibos_FTP]  DEFAULT ((0)) FOR [FTP]
GO
USE [master]
GO
ALTER DATABASE [CP_Ocean_Recibo] SET  READ_WRITE 
GO

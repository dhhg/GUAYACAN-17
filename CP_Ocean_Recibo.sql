USE master
GO
CREATE DATABASE [CP_Ocean_Recibo]
GO
USE [CP_Ocean_Recibo]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 07/12/2016 12:31:25 p. m. ******/
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
/****** Object:  Table [dbo].[Recibos]    Script Date: 07/12/2016 12:31:25 p. m. ******/
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
	[cadenaoriginal] [varchar](255) NOT NULL,
	[version] [varchar](50) NOT NULL,
	[sello] [varchar](255) NOT NULL,
	[ruta] [varchar](255) NOT NULL,
	[archivopdf] [varchar](50) NOT NULL,
	[archivoxml] [varchar](50) NOT NULL,
	[enviado] [int] NOT NULL,
	[impreso] [int] NOT NULL,
	[pdf] [int] NOT NULL,
	[FechaTimbrado] [varchar](50) NOT NULL,
	[qrcode] [varchar](255) NOT NULL,
	[cletra] [varchar](255) NOT NULL,
	[emisor] [varchar](255) NOT NULL,
	[rfcemisro] [varchar](50) NOT NULL,
	[sellosat] [varchar](255) NOT NULL,
	[RutaPublicar] [varchar](255) NOT NULL,
	[FormaDePago] [varchar](255) NOT NULL,
	[MetodoPago] [varchar](255) NOT NULL,
	[Complemento] [varchar](50) NOT NULL,
	[VersionCFDi] [varchar](50) NOT NULL,
	[FTP] [int] NOT NULL,
	[NumeroPeriodo] [int] NOT NULL,
	[Receptor] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Recibos] PRIMARY KEY CLUSTERED 
(
	[GUIDArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Recibos__9F738A369F9B1D94] UNIQUE NONCLUSTERED 
(
	[GUIDArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbEmpresa]    Script Date: 07/12/2016 12:31:25 p. m. ******/
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

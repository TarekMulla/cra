/*
Script generado por Aqua Data Studio 9.0.11 en mar-27-2014 10:19:52 PM
Base de datos: scctest
Esquema: dbo
Objetos: TABLE
*/
DROP INDEX [dbo].[CLIENTES_FOLLOW_UP].[IDX_ClientesFollowUp_Visita]
GO
IF OBJECT_ID('dbo.CLIENTES_FOLLOW_UP') IS NOT NULL
DROP TABLE [dbo].[CLIENTES_FOLLOW_UP]
GO

CREATE TABLE [dbo].[CLIENTES_FOLLOW_UP]  ( 
	[Id]                      	bigint IDENTITY(1,1) NOT NULL,
	[IdInformeVisita]         	bigint NULL,
	[IdLlamadaTelefonica]     	bigint NULL,
	[FechaFollowUp]           	datetime NULL,
	[IdTipoActividadSiguiente]	int NULL,
	[IdClienteMaster]         	bigint NULL,
	[Descripcion]             	nvarchar(4000) NULL,
	[FechaCreacion]           	datetime NULL,
	[IdUsuario]               	int NULL,
	[activo]                  	bit NULL CONSTRAINT [DF__CLIENTES___activ__1411F17C]  DEFAULT ((1)),
	[idTarget]                	bigint NULL,
	[idSLead]                 	int NULL,
	[idCotizacion]            	bigint NULL,
	CONSTRAINT [PK_CLIENTES_FOLLOW_UP] PRIMARY KEY CLUSTERED([Id])
)
GO

SET IDENTITY_INSERT [dbo].[CLIENTES_FOLLOW_UP] ON
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(3, 141, NULL, '20111123 00:00:00.0', 3, 240, N'', '20111103 16:44:36.970', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(4, 142, NULL, '20111115 00:00:00.0', 3, 71, N'', '20111104 16:15:47.710', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(5, 143, NULL, '20111116 00:00:00.0', NULL, 43, N'', '20111104 16:31:16.543', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(6, 144, NULL, '20111219 00:00:00.0', NULL, 117, N'', '20111109 15:51:31.210', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(7, 145, NULL, '20111117 00:00:00.0', 3, 24, N'', '20111110 09:32:51.890', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(8, 146, NULL, '20111117 00:00:00.0', 3, 151, N'DEMOSTRACION E-SERVICE', '20111110 09:44:02.157', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(9, 147, NULL, '20111129 00:00:00.0', NULL, 42, N'', '20111110 10:17:00.393', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(10, 148, NULL, '20111125 00:00:00.0', 3, 53, N'', '20111111 12:30:19.180', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(11, 149, NULL, '99990101 00:00:00.0', -1, 49, N'', '20111116 14:59:46.410', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(12, 150, NULL, '20111130 00:00:00.0', NULL, 68, N'', '20111116 15:34:16.220', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(13, 151, NULL, '20111130 00:00:00.0', -1, 78, N'', '20111116 15:40:40.157', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(14, 152, NULL, '20111219 00:00:00.0', 3, 212, N'', '20111117 09:12:30.227', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(15, 153, NULL, '20111124 00:00:00.0', 3, 106, N'RESUMEN AEREO', '20111117 09:30:22.243', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(16, 154, NULL, '20111219 00:00:00.0', 3, 40, N'', '20111121 10:35:32.203', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(17, 155, NULL, '20111227 00:00:00.0', NULL, 72, N'', '20111121 11:06:06.367', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(18, 156, NULL, '20111222 00:00:00.0', NULL, 58, N'', '20111122 10:00:08.680', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(19, 157, NULL, '20111128 00:00:00.0', NULL, 75, N'', '20111122 11:25:35.400', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(20, 158, NULL, '20111130 00:00:00.0', NULL, 236, N'', '20111122 12:02:30.0', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(21, 159, NULL, '20111130 00:00:00.0', NULL, 206, N'', '20111122 14:41:39.203', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(22, 160, NULL, '20111218 00:00:00.0', NULL, 177, N'', '20111123 10:01:48.057', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(23, 161, NULL, '20111204 00:00:00.0', 3, 59, N'', '20111123 12:23:43.820', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(24, 162, NULL, '20111202 00:00:00.0', NULL, 42, N'', '20111124 12:59:00.670', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(25, 163, NULL, '20111219 00:00:00.0', 1, 31, N'', '20111128 16:52:37.333', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(26, 164, NULL, '20111219 00:00:00.0', NULL, 26, N'', '20111128 16:58:07.610', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(27, 165, NULL, '20111219 00:00:00.0', 1, 7, N'', '20111128 17:44:31.833', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(28, 166, NULL, '20111130 00:00:00.0', 3, 14, N'VISITA CON AGENTE TRANSGLOBAL', '20111129 12:24:24.360', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(29, 167, NULL, '20111227 00:00:00.0', NULL, 41, N'', '20111129 15:15:58.197', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(30, 168, NULL, '20111228 00:00:00.0', NULL, 105, N'', '20111129 15:31:27.707', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(31, 169, NULL, '20111229 00:00:00.0', NULL, 111, N'', '20111129 15:41:48.123', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(32, 170, NULL, '20111214 00:00:00.0', 1, 83, N'', '20111129 21:08:37.413', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(33, 171, NULL, '20120109 00:00:00.0', NULL, 218, N'', '20111130 10:14:41.003', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(34, 172, NULL, '20111130 00:00:00.0', NULL, 254, N'', '20111130 10:32:11.383', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(35, 173, NULL, '20111214 00:00:00.0', NULL, 40, N'', '20111130 16:50:02.533', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(36, 174, NULL, '20111214 00:00:00.0', NULL, 125, N'', '20111130 16:56:17.867', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(37, 175, NULL, '20111228 00:00:00.0', NULL, 52, N'', '20111201 09:28:24.807', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(38, 176, NULL, '20120115 00:00:00.0', NULL, 8, N'', '20111201 11:16:53.307', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(39, 177, NULL, '20111215 00:00:00.0', 3, 24, N'VISITA AGENTE TILBURY', '20111201 17:31:20.430', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(40, 178, NULL, '20111215 00:00:00.0', NULL, 24, N'SISTEMA E-SERVICE', '20111201 17:41:09.633', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(41, 179, NULL, '20111209 00:00:00.0', 3, 45, N'', '20111202 10:20:19.673', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(42, 180, NULL, '20111214 00:00:00.0', NULL, 255, N'', '20111202 15:51:24.663', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(43, 181, NULL, '20111228 00:00:00.0', NULL, 5, N'', '20111205 10:27:55.867', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(44, 182, NULL, '20111228 00:00:00.0', NULL, 18, N'', '20111205 10:32:33.357', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(45, 183, NULL, '20111212 00:00:00.0', 3, 10, N'', '20111205 11:34:13.413', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(46, 184, NULL, '20111227 00:00:00.0', 3, 168, N'', '20111205 12:20:44.557', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(47, 185, NULL, '20111229 00:00:00.0', NULL, 29, N'', '20111205 17:48:32.357', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(48, 186, NULL, '20111224 00:00:00.0', NULL, 56, N'', '20111206 13:01:32.410', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(49, 187, NULL, '20120108 00:00:00.0', 3, 43, N'', '20111207 12:52:25.750', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(50, 188, NULL, '20111221 00:00:00.0', 3, 28, N'', '20111207 17:29:58.577', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(51, 189, NULL, '20111228 00:00:00.0', NULL, 6, N'', '20111207 18:19:04.573', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(52, 190, NULL, '20111219 00:00:00.0', -1, 219, N'', '20111212 10:37:00.663', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(53, 191, NULL, '20111219 00:00:00.0', NULL, 258, N'', '20111212 12:00:14.150', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(54, 192, NULL, '20111219 00:00:00.0', NULL, 11, N'', '20111212 12:28:20.463', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(55, 193, NULL, '20111230 00:00:00.0', NULL, 7, N'', '20111213 13:38:57.870', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(56, 194, NULL, '20120102 00:00:00.0', NULL, 216, N'', '20111220 13:56:41.683', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(57, 195, NULL, '20120125 00:00:00.0', NULL, 26, N'', '20111227 10:11:43.010', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(58, 196, NULL, '20120125 00:00:00.0', NULL, 278, N'', '20111228 11:50:32.053', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(59, 197, NULL, '20120111 00:00:00.0', 3, 281, N'CLIENTE ESTARA DE REGRESO EN ESA FECHA EN CHILE.', '20111229 11:21:39.760', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(60, 198, NULL, '20120111 00:00:00.0', 3, 24, N'REUNION ALMUERZO', '20120104 11:43:42.800', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(61, 199, NULL, '20120117 00:00:00.0', 3, 49, N'', '20120105 15:22:27.677', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(62, 200, NULL, '20120123 00:00:00.0', NULL, 8, N'', '20120109 15:28:34.970', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(63, 201, NULL, '20120118 00:00:00.0', NULL, 62, N'', '20120111 12:22:56.980', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(64, 202, NULL, '20120118 00:00:00.0', NULL, 38, N'', '20120111 12:37:21.577', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(65, 203, NULL, '20120118 00:00:00.0', NULL, 130, N'', '20120111 13:28:54.623', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(66, 204, NULL, '20120118 00:00:00.0', NULL, 10, N'', '20120111 14:09:41.153', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(67, 205, NULL, '20120118 00:00:00.0', NULL, 66, N'', '20120111 14:48:43.087', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(68, 206, NULL, '20120124 00:00:00.0', NULL, 71, N'', '20120112 15:44:29.780', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(69, 207, NULL, '20120131 00:00:00.0', NULL, 52, N'', '20120112 16:03:35.160', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(70, 208, NULL, '20120125 00:00:00.0', -1, 212, N'', '20120112 16:35:21.100', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(71, 209, NULL, '20120131 00:00:00.0', NULL, 43, N'', '20120112 16:46:18.983', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(72, 210, NULL, '20120131 00:00:00.0', NULL, 12, N'', '20120112 17:07:51.977', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(73, 211, NULL, '20120131 00:00:00.0', NULL, 257, N'', '20120113 11:18:41.180', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(74, 212, NULL, '20120131 00:00:00.0', NULL, 49, N'', '20120113 11:24:40.307', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(75, 213, NULL, '20120213 00:00:00.0', 3, 101, N'', '20120116 09:07:52.613', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(76, 214, NULL, '99990101 00:00:00.0', -1, 32, N'', '20120118 12:17:28.267', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(77, 215, NULL, '20120130 00:00:00.0', NULL, 316, N'', '20120123 10:26:08.993', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(78, 216, NULL, '20120130 00:00:00.0', 1, 16, N'', '20120123 10:42:11.867', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(79, 217, NULL, '20120206 00:00:00.0', 3, 108, N'', '20120125 14:52:10.497', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(80, 218, NULL, '20120221 00:00:00.0', 3, 11, N'', '20120125 14:57:15.737', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(81, 219, NULL, '20120213 00:00:00.0', 3, 90, N'', '20120125 15:05:04.090', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(82, 220, NULL, '20120225 00:00:00.0', 3, 3, N'', '20120125 15:14:16.667', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(83, 221, NULL, '20120226 00:00:00.0', 3, 55, N'', '20120126 09:34:26.710', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(84, 222, NULL, '20120220 00:00:00.0', 3, 163, N'', '20120127 11:38:45.707', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(85, 223, NULL, '20120206 00:00:00.0', 3, 8, N'', '20120127 11:52:46.767', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(86, 224, NULL, '20120131 00:00:00.0', 3, 105, N'', '20120127 12:00:47.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(87, 225, NULL, '20120305 00:00:00.0', 3, 254, N'', '20120130 10:31:34.387', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(88, 226, NULL, '20120307 00:00:00.0', 3, 29, N'', '20120130 10:42:55.777', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(89, 227, NULL, '20120215 00:00:00.0', 3, 1, N'', '20120130 11:10:29.303', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(90, 228, NULL, '20120229 00:00:00.0', 3, 40, N'', '20120130 11:22:50.077', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(91, 229, NULL, '20120206 00:00:00.0', 3, 43, N'', '20120130 16:22:19.250', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(92, 230, NULL, '20120206 00:00:00.0', 3, 42, N'', '20120130 16:50:35.070', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(93, 231, NULL, '20120312 00:00:00.0', 3, 79, N'', '20120131 12:54:43.373', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(94, 232, NULL, '20120204 00:00:00.0', 3, 121, N'PROXIMA VISITA 21/02', '20120131 15:20:51.793', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(95, 233, NULL, '20120221 00:00:00.0', 3, 30, N'22 de febrero 2012', '20120131 15:48:00.920', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(96, 234, NULL, '20120229 00:00:00.0', NULL, 319, N'VISITAR A FINES DE FEBRERO', '20120131 16:05:54.053', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(97, 235, NULL, '20120307 00:00:00.0', 3, 31, N'', '20120131 18:02:07.537', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(98, 236, NULL, '20120215 00:00:00.0', 3, 49, N'', '20120202 14:37:22.430', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(99, 237, NULL, '20120306 00:00:00.0', 3, 78, N'', '20120202 14:42:56.350', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(100, 238, NULL, '20120215 00:00:00.0', NULL, 236, N'', '20120202 14:46:13.840', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(101, 239, NULL, '20120213 00:00:00.0', 3, 22, N'', '20120202 15:30:40.533', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(102, 240, NULL, '20120227 00:00:00.0', 3, 8, N'', '20120202 15:53:26.077', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(103, 241, NULL, '20120220 00:00:00.0', 3, 63, N'', '20120202 16:06:32.977', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(104, 242, NULL, '20120313 00:00:00.0', 3, 13, N'', '20120202 16:09:28.390', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(105, 243, NULL, '20120210 00:00:00.0', 3, 30, N'PROXIMA VISITA PRIMERA SEMANA DE MARZO', '20120203 17:29:36.503', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(106, 244, NULL, '20120217 00:00:00.0', 3, 53, N'proxima visita abril 2012', '20120203 17:36:25.190', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(107, 246, NULL, '20120210 00:00:00.0', 1, 30, N'', '20120203 17:52:50.773', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(108, 247, NULL, '20120227 00:00:00.0', 3, 158, N'', '20120206 09:20:39.397', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(109, 248, NULL, '20120227 00:00:00.0', 3, 71, N'', '20120207 16:13:22.920', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(110, 249, NULL, '20120227 00:00:00.0', 3, 176, N'', '20120207 16:28:44.357', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(111, 250, NULL, '20120227 00:00:00.0', 3, 256, N'', '20120210 15:28:52.007', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(112, 251, NULL, '20120308 00:00:00.0', NULL, 201, N'', '20120210 15:30:17.300', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(113, 252, NULL, '20120213 00:00:00.0', NULL, 257, N'', '20120210 15:46:27.587', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(114, 253, NULL, '20120214 00:00:00.0', NULL, 209, N'', '20120210 15:55:45.860', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(115, 254, NULL, '20120319 00:00:00.0', 3, 175, N'', '20120210 16:22:43.743', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(116, 255, NULL, '20120302 00:00:00.0', 3, 102, N'', '20120213 11:00:04.230', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(117, 256, NULL, '20120227 00:00:00.0', 3, 52, N'', '20120214 17:15:08.537', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(118, 257, NULL, '20120305 00:00:00.0', 3, 101, N'', '20120217 10:59:54.560', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(119, 258, NULL, '20120329 00:00:00.0', NULL, 18, N'', '20120217 16:10:36.007', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(120, 259, NULL, '20120320 00:00:00.0', NULL, 51, N'', '20120217 17:07:36.467', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(121, 260, NULL, '20120307 00:00:00.0', 3, 38, N'PROXIMA VISITA PRIMERA SEMANA DE MARZO', '20120221 12:47:23.683', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(122, 261, NULL, '20120302 00:00:00.0', 3, 42, N'', '20120222 16:51:36.750', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(123, 262, NULL, '20120306 00:00:00.0', 3, 240, N'', '20120223 14:57:40.390', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(124, 263, NULL, '20120229 00:00:00.0', 3, 8, N'', '20120223 15:27:05.060', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(125, 264, NULL, '20120305 00:00:00.0', 3, 30, N'marzo 15', '20120227 10:21:15.473', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(126, 265, NULL, '20120314 00:00:00.0', 3, 28, N'', '20120227 10:37:44.647', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(127, 266, NULL, '20120306 00:00:00.0', 3, 39, N'', '20120227 11:10:06.057', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(128, 267, NULL, '20120313 00:00:00.0', 1, 165, N'', '20120228 09:24:17.220', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(129, 268, NULL, '20120314 00:00:00.0', 3, 59, N'', '20120228 09:34:36.443', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(130, 269, NULL, '20120320 00:00:00.0', 3, 99, N'', '20120228 09:46:22.427', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(131, 270, NULL, '20120318 00:00:00.0', 3, 58, N'', '20120228 16:14:07.780', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(132, 271, NULL, '20120313 00:00:00.0', NULL, 147, N'', '20120228 19:05:34.380', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(133, 272, NULL, '20120301 00:00:00.0', 3, 150, N'', '20120229 16:07:32.347', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(134, 273, NULL, '20120306 00:00:00.0', 3, 213, N'', '20120229 16:15:55.567', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(135, 274, NULL, '20120305 00:00:00.0', 1, 167, N'', '20120229 16:24:09.557', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(136, 275, NULL, '20120319 00:00:00.0', NULL, 112, N'', '20120229 16:30:05.547', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(137, 276, NULL, '20120307 00:00:00.0', 1, 215, N'', '20120229 17:17:14.907', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(138, 277, NULL, '20120329 00:00:00.0', NULL, 29, N'', '20120302 08:32:01.300', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(139, 278, NULL, '20120329 00:00:00.0', NULL, 5, N'', '20120302 08:45:37.600', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(140, 279, NULL, '20120329 00:00:00.0', NULL, 40, N'', '20120302 08:56:16.893', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(141, NULL, NULL, '20111229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:05:52.987', 4, 1, 3, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(142, NULL, NULL, '20111229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:20:13.903', 4, 1, 4, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(143, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:28:42.657', 4, 1, 5, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(144, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:35:37.327', 4, 1, 6, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(145, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:49:09.683', 4, 1, 7, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(146, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111215 18:49:09.683', 4, 1, 8, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(147, NULL, NULL, '20111227 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20111220 08:34:22.803', 4, 1, 9, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(148, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111220 13:27:09.003', 4, 1, 10, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(149, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111221 09:21:56.480', 4, 1, 11, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(150, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111221 09:27:55.680', 4, 1, 12, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(151, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111221 09:42:47.190', 4, 1, 13, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(152, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111221 09:49:46.697', 4, 1, 14, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(153, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111221 09:58:38.880', 4, 1, 15, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(154, NULL, NULL, '20111227 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111223 11:57:54.453', 4, 1, 19, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(155, NULL, NULL, '20120102 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111226 17:44:02.750', 4, 1, 20, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(156, NULL, NULL, '20120109 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111226 18:11:31.127', 4, 1, 21, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(157, NULL, NULL, '20120105 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20111226 18:44:15.040', 4, 1, 22, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(158, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111226 18:59:58.077', 4, 1, 23, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(159, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 09:26:23.850', 4, 1, 24, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(160, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 09:26:23.850', 4, 1, 25, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(161, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 09:35:19.787', 4, 1, 29, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(162, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 09:47:38.013', 4, 1, 35, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(163, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 09:53:42.630', 4, 1, 36, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(164, NULL, NULL, '20120103 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 10:18:18.350', 4, 1, 38, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(165, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 12:38:48.997', 4, 1, 39, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(166, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111227 14:49:33.873', 4, 1, 40, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(167, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111228 08:28:07.443', 4, 1, 41, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(168, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111229 18:22:53.120', 4, 1, 49, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(169, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111229 18:31:31.027', 4, 1, 50, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(170, NULL, NULL, '20120105 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20111229 18:36:11.640', 4, 1, 51, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(171, NULL, NULL, '20120104 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120103 18:54:14.993', 4, 1, 52, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(172, NULL, NULL, '20120111 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120104 18:55:52.897', 4, 1, 53, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(173, NULL, NULL, '20120111 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120104 19:15:42.780', 4, 1, 54, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(174, NULL, NULL, '20120126 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120104 19:38:33.103', 4, 1, 55, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(175, NULL, NULL, '20120111 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120104 19:41:12.150', 4, 1, 56, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(176, NULL, NULL, '20120112 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120105 17:11:17.467', 4, 1, 57, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(177, NULL, NULL, '20120112 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120105 18:17:49.397', 4, 1, 58, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(178, NULL, NULL, '20120112 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120105 18:32:27.657', 4, 1, 59, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(179, NULL, NULL, '20120112 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120105 18:48:25.570', 4, 1, 60, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(180, NULL, NULL, '20120118 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120111 19:27:06.503', 4, 1, 61, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(181, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 18:30:11.713', 4, 1, 62, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(182, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 18:32:32.800', 4, 1, 63, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(183, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 18:32:32.800', 4, 1, 64, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(184, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 19:06:06.270', 4, 1, 65, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(185, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 19:15:38.270', 4, 1, 66, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(186, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120116 19:29:06.073', 4, 1, 67, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(187, NULL, NULL, '20120123 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120117 17:27:18.900', 4, 1, 72, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(188, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120117 17:32:39.820', 4, 1, 73, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(189, NULL, NULL, '20120120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120117 17:34:01.470', 4, 1, 74, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(190, NULL, NULL, '20120123 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120117 17:39:16.827', 4, 1, 75, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(191, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120118 15:38:30.493', 19, 1, 76, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(192, NULL, NULL, '20120126 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120119 19:07:00.147', 4, 1, 77, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(193, NULL, NULL, '20120130 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120119 19:17:52.100', 4, 1, 78, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(194, NULL, NULL, '20120126 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120119 19:26:19.043', 4, 1, 79, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(195, NULL, NULL, '20120130 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 09:02:53.270', 4, 1, 80, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(196, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 09:32:24.837', 4, 1, 81, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(197, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 09:41:00.547', 4, 1, 82, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(198, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 11:33:03.797', 4, 1, 83, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(199, NULL, NULL, '20120130 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 12:30:12.220', 4, 1, 84, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(200, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 17:28:16.167', 4, 1, 85, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(201, NULL, NULL, '20120127 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120120 17:38:24.467', 4, 1, 86, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(202, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 17:50:49.903', 4, 1, 87, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(203, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:01:15.033', 4, 1, 88, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(204, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:10:42.053', 4, 1, 89, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(205, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:22:18.033', 4, 1, 90, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(206, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:38:32.180', 4, 1, 91, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(207, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:49:33.353', 4, 1, 92, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(208, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 18:57:29.160', 4, 1, 93, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(209, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120120 19:09:39.823', 4, 1, 94, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(210, NULL, NULL, '20120127 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120120 19:27:40.643', 4, 1, 95, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(211, NULL, NULL, '20120130 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120123 19:10:40.713', 4, 1, 96, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(212, NULL, NULL, '20120130 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120125 07:58:59.010', 4, 1, 97, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(213, NULL, NULL, '20120127 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120125 08:26:58.183', 4, 1, 98, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(214, NULL, NULL, '20120131 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120125 08:50:02.067', 4, 1, 99, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(215, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 09:49:44.520', 4, 1, 100, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(216, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 09:54:49.777', 4, 1, 101, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(217, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 12:29:00.650', 4, 1, 102, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(218, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 12:40:28.817', 4, 1, 103, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(219, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 12:57:21.093', 4, 1, 104, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(220, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 13:01:14.130', 4, 1, 105, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(221, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 13:05:08.227', 4, 1, 106, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(222, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 13:17:12.123', 4, 1, 107, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(223, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 18:03:41.250', 4, 1, 108, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(224, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 18:54:21.537', 4, 1, 109, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(225, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 19:17:25.273', 4, 1, 110, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(226, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 19:36:19.313', 4, 1, 111, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(227, NULL, NULL, '20120202 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120126 19:54:59.403', 4, 1, 112, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(228, NULL, NULL, '20120203 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120131 16:58:25.470', 4, 1, 113, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(229, NULL, NULL, '20120203 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120131 18:17:45.360', 4, 1, 114, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(230, NULL, NULL, '20120224 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120203 15:11:03.627', 4, 1, 115, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(231, NULL, NULL, '20120210 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120203 16:16:15.540', 4, 1, 116, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(232, NULL, NULL, '20120210 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120203 16:41:18.607', 4, 1, 117, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(233, NULL, NULL, '20120210 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120203 18:01:49.123', 4, 1, 118, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(234, NULL, NULL, '20120210 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120203 18:11:56.460', 4, 1, 119, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(235, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 10:40:33.623', 4, 1, 120, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(236, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 10:54:24.130', 4, 1, 121, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(237, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 11:08:27.447', 4, 1, 122, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(238, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 11:53:14.917', 4, 1, 123, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(239, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 12:11:36.570', 4, 1, 124, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(240, NULL, NULL, '20120213 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120206 12:39:50.083', 4, 1, 125, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(241, NULL, NULL, '20120220 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120212 20:46:08.937', 4, 1, 126, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(242, NULL, NULL, '20120222 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120221 15:27:40.410', 4, 1, 127, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(243, NULL, NULL, '20120229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120222 16:28:37.143', 4, 1, 128, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(244, NULL, NULL, '20120229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120222 16:56:16.340', 4, 1, 129, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(245, NULL, NULL, '20120229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120222 17:16:01.343', 4, 1, 130, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(246, NULL, NULL, '20120229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120222 18:07:00.687', 4, 1, 131, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(247, NULL, NULL, '20120229 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120222 18:28:59.727', 4, 1, 132, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(248, NULL, NULL, '20120305 00:00:00.0', NULL, NULL, N'Primera reunión de seguimiento', '20120227 17:21:38.010', 4, 1, 133, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(249, NULL, 1002, '20120304 17:55:30.507', 1, 8, N'Prueba', '20120304 17:56:24.963', 3, 0, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(250, NULL, 1006, '20120416 00:00:00.0', 1, 230, N'INSISTIR POR ESTA CARGA', '20120305 12:14:02.633', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(251, NULL, 1009, '20120319 12:45:46.067', 1, 24, N'recordar reunion pendiente.', '20120305 12:48:43.990', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(252, 280, NULL, '20120314 00:00:00.0', 3, 42, N'', '20120305 15:42:45.860', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(253, 281, NULL, '20120320 00:00:00.0', NULL, 198, N'', '20120306 15:42:22.103', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(254, 283, NULL, '20120320 00:00:00.0', 1, 429, N'', '20120306 16:46:59.073', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(255, 284, NULL, '20120313 00:00:00.0', NULL, 8, N'', '20120306 17:19:55.150', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(256, 285, NULL, '20120320 00:00:00.0', 3, 240, N'', '20120307 08:54:10.387', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(257, 286, NULL, '20120320 00:00:00.0', 3, 69, N'', '20120307 10:35:09.317', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(258, 287, NULL, '20120328 00:00:00.0', 3, 83, N'', '20120307 10:44:54.900', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(259, 288, NULL, '20120327 00:00:00.0', 3, 71, N'', '20120307 14:26:26.767', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(260, 289, NULL, '20120411 00:00:00.0', 3, 76, N'', '20120307 21:36:18.287', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(261, 290, NULL, '20120418 00:00:00.0', NULL, 278, N'', '20120307 21:47:19.287', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(262, 291, NULL, '20120327 00:00:00.0', 3, 105, N'', '20120308 10:39:26.317', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(263, 292, NULL, '20120320 00:00:00.0', 3, 172, N'', '20120308 10:51:44.533', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(264, 293, NULL, '20120315 00:00:00.0', 1, 62, N'', '20120308 12:13:19.803', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(265, 294, NULL, '20120322 00:00:00.0', 1, 60, N'', '20120308 13:00:05.183', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(266, 295, NULL, '20120322 00:00:00.0', 1, 37, N'', '20120308 15:35:05.267', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(267, 296, NULL, '20120322 00:00:00.0', 1, 151, N'', '20120308 15:45:20.530', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(268, 297, NULL, '20120323 00:00:00.0', 3, 362, N'', '20120309 16:37:50.530', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(269, 299, NULL, '20120323 00:00:00.0', 1, 14, N'', '20120309 17:23:32.977', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(270, 300, NULL, '20120328 00:00:00.0', 3, 439, N'', '20120309 17:59:40.363', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(271, NULL, NULL, '20120326 16:57:26.673', 1, 0, N'preguntar por embarque fcl', '20120312 16:57:52.627', 6, 1, 74, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(272, 301, NULL, '20120327 00:00:00.0', 3, 42, N'', '20120314 14:56:08.087', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(273, 302, NULL, '20120327 00:00:00.0', 3, 43, N'', '20120315 16:47:53.810', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(274, 303, NULL, '20120327 00:00:00.0', 3, 63, N'', '20120315 17:00:10.730', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(275, 304, NULL, '20120402 00:00:00.0', NULL, 56, N'', '20120316 09:15:26.107', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(276, 305, NULL, '20120331 00:00:00.0', NULL, 40, N'', '20120316 09:22:57.650', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(277, 306, NULL, '20120320 00:00:00.0', NULL, 68, N'', '20120316 16:54:05.493', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(278, 307, NULL, '20120416 00:00:00.0', 3, 157, N'', '20120319 17:23:01.190', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(279, 308, NULL, '20120330 00:00:00.0', 3, 108, N'', '20120322 08:23:31.570', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(280, 309, NULL, '20120402 00:00:00.0', 3, 85, N'', '20120323 09:10:44.433', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(281, 310, NULL, '20120409 00:00:00.0', 3, 240, N'', '20120323 09:39:30.310', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(282, 311, NULL, '20120402 00:00:00.0', 3, 170, N'', '20120323 09:59:41.447', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(283, 313, NULL, '20120409 00:00:00.0', 3, 644, N'', '20120323 12:13:30.890', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(284, 314, NULL, '20120402 00:00:00.0', 3, 678, N'', '20120326 11:09:03.293', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(285, 315, NULL, '20120403 00:00:00.0', NULL, 49, N'', '20120327 14:24:05.500', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(286, 316, NULL, '20120403 00:00:00.0', 3, 626, N'', '20120328 08:51:01.607', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(287, 317, NULL, '20120416 00:00:00.0', 3, 163, N'', '20120328 09:06:56.427', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(288, 318, NULL, '20120410 00:00:00.0', 3, 71, N'', '20120328 16:41:49.500', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(289, 319, NULL, '20120416 00:00:00.0', 3, 82, N'', '20120330 09:08:06.967', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(290, 320, NULL, '20120424 00:00:00.0', 3, 695, N'', '20120404 08:45:20.160', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(291, 321, NULL, '20120423 00:00:00.0', 3, 42, N'', '20120404 17:02:47.737', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(292, 322, NULL, '20120416 00:00:00.0', 3, 241, N'', '20120404 17:16:21.743', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(293, 323, NULL, '20120423 00:00:00.0', 3, 8, N'', '20120405 12:19:53.827', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(294, 324, NULL, '20120424 00:00:00.0', 3, 71, N'', '20120410 16:22:39.130', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(295, 325, NULL, '20120424 00:00:00.0', 3, 42, N'', '20120410 17:39:08.287', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(296, 326, NULL, '20120418 00:00:00.0', NULL, 894, N'', '20120411 16:56:37.677', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(297, 327, NULL, '20120514 00:00:00.0', NULL, 76, N'', '20120416 09:11:38.383', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(298, 328, NULL, '20120425 00:00:00.0', 3, 43, N'', '20120418 14:29:20.400', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(299, 329, NULL, '20120425 00:00:00.0', 3, 52, N'', '20120418 14:56:53.987', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(300, 330, NULL, '20120426 00:00:00.0', 1, 893, N'', '20120419 12:30:26.530', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(301, 331, NULL, '20120503 00:00:00.0', 1, 50, N'', '20120419 12:49:12.047', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(302, 332, NULL, '20120509 00:00:00.0', NULL, 29, N'', '20120419 14:41:40.823', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(303, 333, NULL, '20120503 00:00:00.0', 1, 536, N'', '20120419 15:31:59.250', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(304, 334, NULL, '20120430 00:00:00.0', 3, 12, N'', '20120420 12:48:35.233', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(305, 335, NULL, '20120424 00:00:00.0', 3, 105, N'', '20120420 14:26:04.040', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(306, 336, NULL, '20120425 00:00:00.0', NULL, 131, N'', '20120420 14:52:45.687', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(307, 337, NULL, '20120426 00:00:00.0', NULL, 203, N'', '20120420 15:00:52.067', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(308, NULL, NULL, '20120423 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 19:50:10.723', 3, 1, NULL, 1, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(309, NULL, NULL, '20120417 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 20:00:10.567', 3, 1, NULL, 2, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(310, NULL, NULL, '20120416 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 20:02:41.907', 5, 1, NULL, 3, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(311, NULL, NULL, '20120417 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 20:29:32.410', 3, 1, NULL, 4, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(312, NULL, NULL, '20120417 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 20:31:24.823', 3, 1, NULL, 5, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(313, NULL, NULL, '20120410 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120422 20:39:19.233', 3, 1, NULL, 6, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(314, 338, NULL, '20120507 00:00:00.0', 3, 85, N'', '20120423 10:45:19.767', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(315, 339, NULL, '20120514 00:00:00.0', 3, 102, N'', '20120423 10:55:26.373', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(316, 340, NULL, '20120430 00:00:00.0', 3, 43, N'', '20120423 17:24:30.760', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(317, 341, NULL, '20120504 00:00:00.0', NULL, 88, N'', '20120424 13:21:38.407', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(318, 342, NULL, '20120521 00:00:00.0', 3, 1006, N'', '20120424 14:44:05.660', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(319, NULL, NULL, '20120427 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120424 17:17:38.517', 4, 1, NULL, 7, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(320, NULL, NULL, '20120427 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120424 17:17:39.187', 4, 1, NULL, 8, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(321, NULL, NULL, '20120427 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120424 17:23:53.473', 4, 1, NULL, 9, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(322, NULL, NULL, '20120427 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120424 17:46:33.073', 19, 1, NULL, 10, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(323, NULL, NULL, '20120425 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120425 10:19:33.770', 34, 1, NULL, 11, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(324, NULL, NULL, '20120427 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120425 10:51:42.340', 19, 1, NULL, 12, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(325, NULL, NULL, '20120425 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120425 12:40:52.350', 4, 1, NULL, 13, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(326, 343, NULL, '20120507 00:00:00.0', 3, 71, N'', '20120425 13:01:44.853', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(327, 344, NULL, '20120514 00:00:00.0', 3, 176, N'', '20120425 13:09:48.417', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(328, 345, NULL, '20120521 00:00:00.0', 3, 136, N'', '20120425 13:20:38.927', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(329, 346, NULL, '20120521 00:00:00.0', 3, 100, N'', '20120426 17:09:34.947', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(330, NULL, NULL, '20120502 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120501 20:21:10.323', 4, 1, 134, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(331, 347, NULL, '20120529 00:00:00.0', 3, 22, N'', '20120508 09:15:57.180', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(332, 348, NULL, '20120522 00:00:00.0', 3, 42, N'', '20120510 08:13:37.033', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(333, 349, NULL, '20120522 00:00:00.0', 3, 105, N'', '20120510 08:21:56.387', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(334, 350, NULL, '20120528 00:00:00.0', 3, 1284, N'', '20120511 11:29:52.840', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(335, 351, NULL, '20120522 00:00:00.0', 3, 56, N'', '20120511 13:19:43.357', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(336, 352, NULL, '20120521 00:00:00.0', 3, 137, N'', '20120511 15:17:45.623', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(337, 353, NULL, '20120528 00:00:00.0', 3, 18, N'', '20120511 16:03:32.340', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(338, 354, NULL, '20120516 00:00:00.0', 3, 8, N'', '20120515 08:15:47.453', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(339, 355, NULL, '20120529 00:00:00.0', 3, 1284, N'', '20120515 09:26:09.523', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(340, 356, NULL, '20120529 00:00:00.0', 3, 63, N'', '20120517 10:48:59.880', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(341, 357, NULL, '20120627 00:00:00.0', 1, 1237, N'', '20120523 10:02:14.577', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(342, 358, NULL, '20120530 00:00:00.0', NULL, 1271, N'', '20120523 10:14:51.867', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(343, 359, NULL, '20120529 00:00:00.0', NULL, 49, N'', '20120523 10:44:54.503', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(344, 360, NULL, '20120606 00:00:00.0', NULL, 83, N'', '20120523 11:01:27.530', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(345, 361, NULL, '20120606 00:00:00.0', NULL, 894, N'', '20120523 11:15:50.193', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(346, 362, NULL, '20120605 00:00:00.0', 3, 240, N'', '20120523 14:56:40.333', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(347, 363, NULL, '20120531 00:00:00.0', 1, 39, N'', '20120523 15:21:13.850', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(348, 364, NULL, '20120611 00:00:00.0', 3, 170, N'', '20120523 15:48:20.573', 7, NULL, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(349, 365, NULL, '20120607 00:00:00.0', 1, 536, N'', '20120523 18:22:56.200', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(350, 366, NULL, '20120607 00:00:00.0', 1, 1368, N'', '20120524 12:59:15.947', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(351, 368, NULL, '20120531 00:00:00.0', -1, 13, N'', '20120524 14:47:11.613', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(352, 369, NULL, '20120612 00:00:00.0', 3, 47, N'', '20120524 16:29:02.333', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(353, 370, NULL, '20120605 00:00:00.0', 1, 1341, N'', '20120525 18:00:45.570', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(354, 372, NULL, '20120607 00:00:00.0', 3, 52, N'', '20120528 09:29:19.480', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(355, 373, NULL, '20120607 00:00:00.0', 3, 108, N'', '20120528 09:37:52.533', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(356, 374, NULL, '99990101 00:00:00.0', NULL, 24, N'', '20120528 09:39:50.413', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(357, 375, NULL, '20120618 00:00:00.0', 3, 81, N'', '20120528 09:54:29.097', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(358, 376, NULL, '20120530 00:00:00.0', NULL, 45, N'', '20120528 16:11:47.783', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(359, 377, NULL, '20120530 00:00:00.0', 1, 87, N'', '20120528 16:25:05.630', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(360, NULL, 1207, '20120615 00:00:00.0', 1, 920, N'Hacer seguimiento a orden lista para el 20 de Junio (1x20)', '20120529 10:52:40.870', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(361, 378, NULL, '20120531 00:00:00.0', 1, 51, N'andrea toro', '20120530 13:13:25.777', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(362, 379, NULL, '20120607 00:00:00.0', 3, 105, N'', '20120531 09:01:02.080', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(363, 380, NULL, '20120618 00:00:00.0', 3, 8, N'', '20120531 09:10:52.960', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(364, 381, NULL, '20120608 00:00:00.0', 3, 42, N'', '20120531 09:17:37.317', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(365, 382, NULL, '20120618 00:00:00.0', 3, 71, N'', '20120531 16:06:12.663', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(366, 383, NULL, '20120611 00:00:00.0', 3, 12, N'', '20120531 16:27:53.180', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(367, 384, NULL, '20120615 00:00:00.0', NULL, 366, N'', '20120601 08:52:35.903', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(368, 385, NULL, '20120604 00:00:00.0', 1, 1519, N'', '20120601 12:24:31.540', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(369, 386, NULL, '20120625 00:00:00.0', 1, 148, N'', '20120604 17:58:29.923', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(370, 387, NULL, '20120704 00:00:00.0', 3, 55, N'', '20120606 14:24:08.0', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(371, 388, NULL, '20120709 00:00:00.0', NULL, 58, N'', '20120606 14:36:43.810', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(372, 389, NULL, '20120620 00:00:00.0', 1, 153, N'', '20120606 14:43:57.343', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(373, 390, NULL, '20120614 00:00:00.0', NULL, 364, N'', '20120606 14:52:53.153', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(374, 391, NULL, '20120625 00:00:00.0', 3, 27, N'', '20120606 17:37:42.387', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(375, 392, NULL, '20120625 00:00:00.0', 3, 52, N'', '20120606 17:49:19.913', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(376, 393, NULL, '20120627 00:00:00.0', 3, 63, N'', '20120607 17:35:22.203', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(377, 394, NULL, '20120716 00:00:00.0', 3, 85, N'', '20120607 17:42:01.370', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(378, 395, NULL, '20120710 00:00:00.0', 3, 240, N'', '20120607 17:47:17.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(379, 396, NULL, '20120703 00:00:00.0', 3, 170, N'', '20120607 17:53:43.290', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(380, 397, NULL, '20120702 00:00:00.0', 3, 42, N'', '20120607 18:01:13.850', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(381, 398, NULL, '20120626 00:00:00.0', 3, 26, N'', '20120608 10:02:55.107', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(382, 399, NULL, '20120628 00:00:00.0', NULL, 134, N'', '20120608 14:26:44.240', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(383, 400, NULL, '20120709 00:00:00.0', 3, 18, N'', '20120611 09:35:35.497', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(384, 401, NULL, '20120709 00:00:00.0', 3, 1284, N'', '20120611 09:51:14.623', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(385, NULL, NULL, '20120620 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120613 17:02:36.707', 4, 1, NULL, 14, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(386, NULL, NULL, '20120630 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120615 15:57:36.567', 5, 1, 135, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(387, 404, NULL, '20120703 00:00:00.0', NULL, 49, N'', '20120620 12:57:21.567', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(388, 405, NULL, '20120716 00:00:00.0', 3, 29, N'', '20120620 16:49:46.723', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(389, 406, NULL, '20120628 00:00:00.0', 1, 45, N'', '20120621 12:54:32.280', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(390, 407, NULL, '20120628 00:00:00.0', 1, 151, N'', '20120621 13:00:33.643', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(391, 408, NULL, '20120701 00:00:00.0', 1, 1041, N'Chequear situacion de contenedor de prueba, Brasil.', '20120621 17:00:48.323', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(392, 409, NULL, '20120705 00:00:00.0', 1, 1765, N'', '20120621 17:11:55.130', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(393, 410, NULL, '20120705 00:00:00.0', NULL, 73, N'', '20120621 17:25:13.017', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(394, 411, NULL, '20120709 00:00:00.0', 3, 8, N'', '20120621 17:26:17.373', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(395, 412, NULL, '20120709 00:00:00.0', 3, 43, N'', '20120621 17:37:05.063', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(396, 413, NULL, '20120629 00:00:00.0', 1, 45, N'test', '20120622 09:57:07.937', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(397, 414, NULL, '20120626 00:00:00.0', 1, 151, N'', '20120625 10:46:46.960', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(398, 415, NULL, '20120626 00:00:00.0', 1, 24, N'', '20120625 11:10:11.950', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(399, 416, NULL, '20120703 00:00:00.0', 1, 28, N'', '20120625 11:14:07.517', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(400, 417, NULL, '20120627 00:00:00.0', 1, 13, N'', '20120625 11:18:19.657', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(401, 418, NULL, '20120627 00:00:00.0', 1, 40, N'', '20120625 11:21:42.823', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(402, 419, NULL, '20120626 00:00:00.0', 1, 232, N'', '20120625 11:36:07.853', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(403, 420, NULL, '20120626 00:00:00.0', NULL, 45, N'', '20120625 12:05:59.390', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(404, 421, NULL, '20120627 00:00:00.0', 2, 30, N'', '20120625 12:16:31.947', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(405, 423, NULL, '20120626 00:00:00.0', NULL, 26, N'', '20120626 19:09:50.867', 27, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(406, 424, NULL, '20120628 00:00:00.0', 3, 105, N'', '20120627 15:35:57.463', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(407, 425, NULL, '20120710 00:00:00.0', 3, 100, N'', '20120627 15:52:42.820', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(408, 426, NULL, '20120710 00:00:00.0', 3, 240, N'', '20120627 17:49:25.303', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(409, 427, NULL, '20120706 00:00:00.0', NULL, 135, N'', '20120628 16:54:20.977', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(410, 428, NULL, '20120710 00:00:00.0', NULL, 78, N'', '20120628 17:08:06.520', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(411, 429, NULL, '20120705 00:00:00.0', NULL, 209, N'', '20120628 17:21:35.260', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(412, 430, NULL, '20120710 00:00:00.0', 3, 42, N'', '20120629 11:46:16.820', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(413, 431, NULL, '20120716 00:00:00.0', 3, 56, N'', '20120629 11:58:15.183', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(414, 432, NULL, '20120709 00:00:00.0', 3, 101, N'', '20120629 12:08:18.360', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(415, NULL, NULL, '20120703 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120629 16:29:49.003', 27, 1, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(416, 433, NULL, '20120712 00:00:00.0', 1, 1374, N'', '20120703 12:07:17.743', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(417, 435, NULL, '99990101 00:00:00.0', NULL, 38, N'', '20120703 18:56:16.603', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(418, 436, NULL, '20120704 00:00:00.0', 1, 4, N'', '20120704 18:36:44.177', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(419, 437, NULL, '20120704 00:00:00.0', 1, 13, N'', '20120704 19:17:01.107', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(420, NULL, NULL, '20120709 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120705 18:10:58.333', 4, 1, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(421, NULL, NULL, '20120709 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120705 18:38:36.783', 4, 1, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(422, NULL, NULL, '20120709 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120705 18:58:09.810', 4, 1, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(423, 438, NULL, '20120713 00:00:00.0', 1, 24, N'', '20120706 11:39:31.490', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(424, 439, NULL, '20120720 00:00:00.0', 1, 30, N'', '20120706 11:44:34.230', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(425, 440, NULL, '20120720 00:00:00.0', 1, 39, N'', '20120706 12:08:07.287', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(426, 441, NULL, '20120720 00:00:00.0', 1, 28, N'', '20120706 12:16:42.173', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(427, 442, NULL, '20120720 00:00:00.0', NULL, 181, N'', '20120706 12:27:36.970', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(428, 443, NULL, '20120720 00:00:00.0', 1, 215, N'', '20120706 12:47:04.870', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(429, 444, NULL, '20120806 00:00:00.0', 3, 102, N'', '20120706 12:58:23.473', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(430, 445, NULL, '20120720 00:00:00.0', 1, 10, N'', '20120706 13:09:12.233', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(431, 446, NULL, '20120720 00:00:00.0', 1, 319, N'', '20120706 15:49:11.137', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(432, 447, NULL, '20120720 00:00:00.0', 1, 16, N'', '20120706 16:00:43.440', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(433, 448, NULL, '20120720 00:00:00.0', 1, 24, N'', '20120706 16:16:25.987', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(434, 449, NULL, '20120720 00:00:00.0', 2, 45, N'', '20120706 16:25:30.240', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(435, 450, NULL, '20120723 00:00:00.0', 3, 29, N'', '20120706 16:47:55.867', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(436, 451, NULL, '20120730 00:00:00.0', 3, 117, N'', '20120706 17:07:50.200', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(437, 452, NULL, '20120730 00:00:00.0', 3, 42, N'', '20120706 17:18:15.807', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(438, 453, NULL, '20120730 00:00:00.0', 3, 12, N'', '20120706 17:32:52.713', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(439, NULL, NULL, '20120710 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120706 19:00:55.057', 27, 1, NULL, 19, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(440, 454, NULL, '20120730 00:00:00.0', 3, 176, N'', '20120709 08:48:13.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(441, 455, NULL, '20120730 00:00:00.0', 3, 8, N'', '20120709 08:57:30.103', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(442, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120709 10:58:10.507', 5, 1, 136, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(443, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120709 11:41:30.747', 5, 1, 137, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(444, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120709 11:56:00.777', 5, 1, 138, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(445, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120709 12:08:01.393', 5, 1, 139, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(446, 456, NULL, '20120730 00:00:00.0', 3, 1, N'', '20120710 12:57:24.237', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(447, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120711 14:12:06.573', 5, 1, 140, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(448, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120711 15:07:05.803', 5, 1, 141, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(449, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120711 15:11:05.330', 5, 1, 142, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(450, 457, NULL, '20120719 00:00:00.0', 1, 3, N'', '20120712 12:11:50.117', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(451, 458, NULL, '20120813 00:00:00.0', 3, 5, N'', '20120712 12:59:23.807', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(452, 459, NULL, '20120814 00:00:00.0', NULL, 1271, N'', '20120712 13:16:08.393', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(453, 460, NULL, '20120815 00:00:00.0', 1, 50, N'', '20120712 14:54:10.823', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(454, NULL, NULL, '20120717 00:00:00.0', 0, 66, N'Primera reunión de seguimiento', '20120712 15:40:38.180', 4, 1, 143, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(455, NULL, NULL, '20120718 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120712 15:49:32.033', 4, 1, 144, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(456, 461, NULL, '20120730 00:00:00.0', 3, 71, N'', '20120712 16:54:24.687', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(457, 462, NULL, '20120726 00:00:00.0', 1, 28, N'', '20120712 17:00:30.477', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(458, 463, NULL, '20120731 00:00:00.0', NULL, 894, N'', '20120712 17:45:16.267', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(459, NULL, NULL, '20120719 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120712 18:12:47.423', 4, 1, NULL, 20, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(460, NULL, NULL, '20120712 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120712 18:18:10.397', 27, 1, NULL, 21, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(461, NULL, NULL, '20120712 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120712 18:18:10.443', 27, 1, NULL, 22, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(462, NULL, NULL, '20120720 00:00:00.0', 0, 104, N'Primera reunión de seguimiento', '20120713 09:07:01.040', 4, 1, 145, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(463, 464, NULL, '20120731 00:00:00.0', 3, 125, N'', '20120713 15:22:29.657', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(464, 465, NULL, '20120720 00:00:00.0', 1, 1886, N'', '20120713 16:34:38.220', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(465, 466, NULL, '20120727 00:00:00.0', 1, 164, N'', '20120713 16:53:36.720', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(466, 467, NULL, '20120720 00:00:00.0', 2, 72, N'', '20120713 17:17:47.387', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(467, 468, NULL, '20120720 00:00:00.0', 1, 1887, N'', '20120713 17:33:52.813', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(468, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120717 10:33:22.143', 5, 1, 146, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(469, NULL, NULL, '20120712 18:21:21.313', 2, 0, N'Se envía Sales Lead a Intecom, Contacto Ana Erika Herrera', '20120717 18:21:45.410', 27, 1, NULL, 21, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(470, NULL, NULL, '20120713 18:21:57.480', 2, 0, N'Ana Acusa Recibo de Sales Lead y queda comprometida a enviarnos novedades, insistiremos con ella el 18-07 am (hora local)', '20120717 18:22:47.713', 27, 1, NULL, 21, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(471, NULL, NULL, '20120706 18:24:22.657', 2, 0, N'Se envía Sales Lead a Intercom a contacto Ana Erika Herrera.', '20120717 18:25:49.030', 27, 1, NULL, 19, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(472, NULL, NULL, '20120709 18:24:56.877', 2, 0, N'Ana Erika Herrera acusa recibo de Sales Lead. Queda comprometida a enviar novedades.', '20120717 18:25:49.047', 27, 1, NULL, 19, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(473, NULL, NULL, '20120717 18:25:28.130', 2, 0, N'Insistimos con Ana Erika Herrera para que nos indique status de este Sales Lead', '20120717 18:25:49.063', 27, 1, NULL, 19, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(474, NULL, NULL, '20120706 18:27:00.613', 2, 0, N'Se envía Sales lead A Intercom, contacto Ana Erika Herrera.', '20120717 18:28:43.757', 27, 0, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(475, NULL, NULL, '20120709 18:27:45.750', 2, 0, N'Ana Erika Herrera acusa recibo de correo. 
Quedamos a la espera de novedades.', '20120717 18:28:43.787', 27, 0, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(476, NULL, NULL, '20120706 18:27:00.613', 2, 0, N'Se envía Sales lead A Intercom, contacto Ana Erika Herrera.', '20120717 18:28:48.930', 27, 0, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(477, NULL, NULL, '20120709 18:27:45.750', 2, 0, N'Ana Erika Herrera acusa recibo de correo. 
Quedamos a la espera de novedades.', '20120717 18:28:48.947', 27, 0, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(478, NULL, NULL, '20120709 18:28:12.687', 2, 0, N'Ana Erika Herrera nos informa que han consegudo cita para el 16 de Julio.
', '20120717 18:28:48.963', 27, 0, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(479, NULL, NULL, '20120706 18:27:00.613', 2, 0, N'Se envía Sales lead A Intercom, contacto Ana Erika Herrera.', '20120717 18:29:23.257', 27, 1, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(480, NULL, NULL, '20120709 18:27:45.750', 2, 0, N'Ana Erika Herrera acusa recibo de correo. 
Quedamos a la espera de novedades.', '20120717 18:29:23.287', 27, 1, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(481, NULL, NULL, '20120709 18:28:12.687', 2, 0, N'Ana Erika Herrera nos informa que han consegudo cita para el 16 de Julio.
', '20120717 18:29:23.303', 27, 1, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(482, NULL, NULL, '20120717 18:28:47.357', 2, 0, N'Enviamos recordatorio a Ana Erika Herrera a fin de saber los resultados de la reunion del 16 de Junio', '20120717 18:29:23.320', 27, 1, NULL, 18, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(483, NULL, NULL, '20120706 18:30:57.367', 2, 0, N'Se envía Sales Lead a Intercom, contacto Ana Erika Herrera. ', '20120717 18:33:42.303', 27, 0, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(484, NULL, NULL, '20120709 18:33:11.080', 2, 0, N'Ana Erika Herrera acusa recibo de Sales Lead. Quedamos atentos a novedades.', '20120717 18:33:42.317', 27, 0, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(485, NULL, NULL, '20120706 18:30:57.367', 2, 0, N'Se envía Sales Lead a Intercom, contacto Ana Erika Herrera. ', '20120717 18:34:04.647', 27, 1, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(486, NULL, NULL, '20120709 18:33:11.080', 2, 0, N'Ana Erika Herrera acusa recibo de Sales Lead. Quedamos atentos a novedades.', '20120717 18:34:04.677', 27, 1, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(487, NULL, NULL, '20120717 18:33:41.680', 2, 0, N'Solicitamos actualización de status a Intercom (Ana Erika Herrera)', '20120717 18:34:04.693', 27, 1, NULL, 17, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(488, NULL, NULL, '20120706 18:34:49.687', 2, 0, N'Enviamos Sales Lead a Intercom Ana Erika Herrera.
', '20120717 18:35:32.757', 27, 0, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(489, NULL, NULL, '20120706 18:34:49.687', 2, 0, N'Enviamos Sales Lead a Intercom Ana Erika Herrera.
', '20120717 18:35:45.973', 27, 0, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(490, NULL, NULL, '20120709 18:35:10.263', 2, 0, N'Ana Erika Herrera acusa recibo de Sales Lead y nos avisará novedades.', '20120717 18:35:46.003', 27, 0, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(491, NULL, NULL, '20120706 18:34:49.687', 2, 0, N'Enviamos Sales Lead a Intercom Ana Erika Herrera.
', '20120717 18:35:51.940', 27, 1, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(492, NULL, NULL, '20120709 18:35:10.263', 2, 0, N'Ana Erika Herrera acusa recibo de Sales Lead y nos avisará novedades.', '20120717 18:35:51.970', 27, 1, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(493, NULL, NULL, '20120717 18:35:35.007', 2, 0, N'Solicitamos a Ana Erika Herrera Status de este sales lead.', '20120717 18:35:51.970', 27, 1, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(494, NULL, NULL, '20120629 18:37:49.837', 2, 0, N'Se envía Sales Lead a WSL Ningbo.
', '20120717 18:42:55.687', 27, 0, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(495, NULL, NULL, '20120629 18:37:49.837', 2, 0, N'Se envía Sales Lead a WSL Ningbo.
', '20120717 18:44:32.153', 27, 1, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(496, NULL, NULL, '20120705 18:38:26.200', 2, 0, N'Producto de algunas desinteligencias en Origen, Daniel Sanhueza explica procedimiento de Sales Lead a WSL.', '20120717 18:44:32.183', 27, 1, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(497, NULL, NULL, '20120706 18:42:57.567', 2, 0, N'WSL nos informa que proveedor tiene carga en producción y apuntan a quedarse con ese embarque, pero la producción de esta tomará varías semanas.', '20120717 18:44:32.230', 27, 1, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(498, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120718 09:44:33.447', 5, 1, 147, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(512, NULL, NULL, '20120731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120718 11:36:32.547', 5, 1, 161, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(513, NULL, NULL, '20120718 16:47:30.300', 2, 0, N'Agente indica que la carga estará lista dentro de estos días, shipper insiste en utilizar otro F/F para este embarque.


', '20120718 16:48:45.567', 27, 1, NULL, 15, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(514, NULL, NULL, '20120718 16:49:06.307', 2, 0, N'Nos informa  la señorita Tania Alcalá de Donaldson que sus clientes deciden con quien embarcar. Nos piden chequear con cliente.', '20120718 16:49:33.803', 27, 1, NULL, 19, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(515, 469, NULL, '20120821 00:00:00.0', 3, 536, N'', '20120719 12:11:30.773', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(516, 470, NULL, '20120731 00:00:00.0', 1, 1986, N'', '20120719 12:18:34.183', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(517, 471, NULL, '20120720 00:00:00.0', 1, 364, N'', '20120719 17:24:27.843', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(518, 472, NULL, '20120806 00:00:00.0', 3, 1998, N'', '20120720 12:55:49.677', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(519, 473, NULL, '20120806 00:00:00.0', 3, 240, N'', '20120720 13:09:21.703', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(520, 474, NULL, '20120724 00:00:00.0', 1, 1703, N'', '20120720 17:32:53.953', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(521, 475, NULL, '20120815 00:00:00.0', NULL, 148, N'', '20120720 17:56:48.553', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(522, 476, NULL, '20120801 00:00:00.0', 1, 1931, N'', '20120720 19:40:06.003', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(523, NULL, NULL, '20120803 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120723 12:47:50.337', 8, 1, 162, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(528, NULL, NULL, '20120803 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120723 12:53:36.967', 8, 1, 167, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(529, NULL, NULL, '20120803 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120723 12:56:26.300', 8, 1, 168, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(530, 477, NULL, '20120820 00:00:00.0', 3, 58, N'', '20120724 08:37:27.397', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(531, 478, NULL, '20120827 00:00:00.0', 3, 132, N'', '20120724 08:41:17.773', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(532, 479, NULL, '20120802 00:00:00.0', 1, 99, N'', '20120725 08:31:50.583', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(533, 480, NULL, '20120802 00:00:00.0', 1, 65, N'', '20120725 08:35:55.440', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(534, 481, NULL, '20120807 00:00:00.0', 1, 2005, N'', '20120725 10:09:18.287', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(535, 482, NULL, '20120807 00:00:00.0', 1, 138, N'', '20120725 10:58:07.737', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(536, 483, NULL, '20120806 00:00:00.0', 3, 154, N'', '20120725 17:07:29.510', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(537, 484, NULL, '20120802 00:00:00.0', 3, 102, N'', '20120725 17:16:39.550', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(538, 485, NULL, '20120813 00:00:00.0', 1, 77, N'', '20120726 08:52:43.050', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(539, NULL, NULL, '20120731 00:00:00.0', 0, 241, N'Primera reunión de seguimiento', '20120726 12:49:21.750', 4, 1, 169, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(540, 486, NULL, '20120815 00:00:00.0', 3, 1237, N'', '20120726 15:47:43.143', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(541, 487, NULL, '20120815 00:00:00.0', 3, 148, N'', '20120726 15:55:13.803', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(542, 488, NULL, '20120731 00:00:00.0', 1, 60, N'', '20120726 17:13:48.420', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(543, 489, NULL, '20120801 00:00:00.0', 1, 84, N'', '20120726 17:43:01.390', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(544, 490, NULL, '20120813 00:00:00.0', 3, 169, N'', '20120727 08:40:32.263', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(545, 491, NULL, '20120814 00:00:00.0', 3, 98, N'', '20120727 08:42:58.030', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(546, NULL, NULL, '20120803 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120727 09:43:21.410', 4, 1, NULL, 23, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(547, NULL, NULL, '20120803 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120727 09:43:21.503', 4, 1, NULL, 24, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(548, 492, NULL, '20120808 00:00:00.0', 1, 150, N'', '20120727 12:42:30.620', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(549, 493, NULL, '20120731 00:00:00.0', 2, 32, N'', '20120730 10:40:50.963', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(550, 494, NULL, '20120820 00:00:00.0', 3, 42, N'', '20120730 15:51:54.020', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(551, NULL, NULL, '20120803 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120731 00:02:01.587', 19, 1, 170, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(552, NULL, NULL, '20120803 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120731 00:15:21.013', 19, 1, 171, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(553, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120731 09:25:36.157', 5, 1, 172, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(554, NULL, NULL, '20120815 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120731 10:38:35.870', 5, 1, 173, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(555, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120731 12:37:39.913', 5, 1, 174, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(556, 495, NULL, '20120806 00:00:00.0', 1, 14, N'', '20120731 16:57:40.073', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(557, 496, NULL, '20120808 00:00:00.0', 1, 439, N'', '20120731 17:26:53.033', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(558, 497, NULL, '20120808 00:00:00.0', 1, 151, N'', '20120731 17:34:37.797', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(559, 498, NULL, '20120813 00:00:00.0', 3, 1, N'', '20120801 09:37:13.107', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(560, 499, NULL, '20120820 00:00:00.0', 3, 1006, N'', '20120801 09:47:43.110', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(561, 500, NULL, '20120917 00:00:00.0', 3, 25, N'', '20120801 09:57:34.713', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(562, NULL, NULL, '20120830 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120801 09:58:00.733', 5, 1, 175, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(563, 501, NULL, '20120820 00:00:00.0', 3, 241, N'', '20120801 10:26:51.500', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(564, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120801 16:19:59.750', 5, 1, 176, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(565, 502, NULL, '20120822 00:00:00.0', NULL, 201, N'', '20120801 17:15:45.317', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(566, 503, NULL, '20120822 00:00:00.0', NULL, 1566, N'', '20120801 17:32:25.317', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(567, 504, NULL, '20120813 00:00:00.0', 3, 52, N'', '20120802 08:37:20.173', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(568, 505, NULL, '20120820 00:00:00.0', 3, 8, N'', '20120802 08:50:45.940', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(569, 506, NULL, '20120820 00:00:00.0', 3, 18, N'', '20120802 09:28:19.920', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(570, 507, NULL, '20120830 00:00:00.0', 3, 76, N'', '20120802 19:35:35.860', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(571, 508, NULL, '20120831 00:00:00.0', 3, 1368, N'', '20120802 20:03:36.903', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(572, 509, NULL, '20120829 00:00:00.0', 3, 130, N'', '20120803 08:42:47.040', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(573, 510, NULL, '20120829 00:00:00.0', 2, 192, N'', '20120803 08:49:02.817', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(574, 511, NULL, '20120829 00:00:00.0', 3, 46, N'', '20120803 08:56:42.767', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(575, 512, NULL, '20120829 00:00:00.0', 1, 46, N'', '20120803 09:03:44.063', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(576, 513, NULL, '20120813 00:00:00.0', 3, 1994, N'', '20120803 09:20:39.343', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(577, NULL, NULL, '20120830 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120803 11:39:27.400', 5, 1, 177, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(578, 514, NULL, '20120827 00:00:00.0', 3, 678, N'', '20120803 15:04:20.680', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(579, 515, NULL, '20120806 00:00:00.0', NULL, 75, N'', '20120803 16:26:34.200', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(580, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120803 16:58:13.150', 5, 1, 178, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(581, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120803 17:21:35.430', 5, 1, 179, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(582, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120803 18:38:15.517', 5, 1, 180, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(583, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 09:10:28.643', 56, 1, 181, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(584, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 09:36:21.663', 56, 1, 182, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(585, 516, NULL, '20120830 00:00:00.0', 3, 83, N'', '20120806 10:00:45.220', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(592, NULL, NULL, '20120810 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 14:59:56.967', 19, 1, 189, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(593, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 15:18:27.003', 5, 1, 190, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(594, NULL, NULL, '20120830 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 15:24:22.423', 5, 1, 191, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(595, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 15:39:35.907', 5, 1, 192, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(596, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 16:03:49.497', 5, 1, 193, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(597, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 16:06:24.793', 5, 1, 194, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(598, NULL, NULL, '20120813 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120806 16:18:07.630', 4, 1, 195, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(599, 517, NULL, '20120903 00:00:00.0', 1, 1994, N'', '20120807 09:05:52.067', 8, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(600, 518, NULL, '20120814 00:00:00.0', NULL, 364, N'', '20120807 09:10:31.433', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(601, 519, NULL, '20120827 00:00:00.0', 3, 63, N'', '20120808 09:25:16.783', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(602, 520, NULL, '20120831 00:00:00.0', 3, 2005, N'', '20120808 15:48:56.150', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(603, 521, NULL, '20120831 00:00:00.0', 3, 140, N'', '20120808 17:41:16.913', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(604, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120808 17:43:51.893', 5, 1, 196, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(605, 522, NULL, '20120810 00:00:00.0', NULL, 49, N'', '20120809 14:40:46.563', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(606, 523, NULL, '20120810 00:00:00.0', NULL, 78, N'', '20120809 14:55:35.283', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(607, 524, NULL, '20120810 00:00:00.0', NULL, 1566, N'', '20120809 15:01:45.750', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(608, 525, NULL, '20120827 00:00:00.0', 3, 240, N'', '20120809 16:42:33.097', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(609, 526, NULL, '20120827 00:00:00.0', 3, 170, N'', '20120809 16:56:26.077', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(610, 527, NULL, '20120910 00:00:00.0', 3, 207, N'', '20120809 17:04:23.287', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(611, 528, NULL, '20120827 00:00:00.0', 3, 111, N'', '20120809 17:10:45.597', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(612, 529, NULL, '20120827 00:00:00.0', 3, 2143, N'', '20120810 08:42:50.340', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(613, 530, NULL, '20120827 00:00:00.0', 3, 43, N'', '20120810 08:53:12.137', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(614, 531, NULL, '20120817 00:00:00.0', 1, 30, N'', '20120810 11:58:16.107', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(615, 532, NULL, '20120817 00:00:00.0', 1, 87, N'', '20120810 12:53:32.960', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(616, 533, NULL, '20120817 00:00:00.0', 1, 7, N'', '20120810 16:40:37.927', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(617, 534, NULL, '20120824 00:00:00.0', NULL, 32, N'', '20120810 17:21:14.743', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(618, 535, NULL, '20120817 00:00:00.0', 1, 37, N'', '20120810 17:33:13.253', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(619, 536, NULL, '20120817 00:00:00.0', 1, 2146, N'', '20120810 18:03:52.173', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(620, 537, NULL, '20120817 00:00:00.0', 1, 2158, N'', '20120810 18:26:02.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(621, 538, NULL, '20120820 00:00:00.0', 1, 45, N'', '20120813 10:41:46.807', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(622, 539, NULL, '20120820 00:00:00.0', 1, 258, N'', '20120813 10:56:37.843', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(623, 540, NULL, '20120911 00:00:00.0', 3, 155, N'', '20120813 11:11:28.140', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(624, 541, NULL, '20120820 00:00:00.0', NULL, 16, N'', '20120813 11:38:23.063', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(625, 542, NULL, '20120820 00:00:00.0', 1, 51, N'', '20120813 11:41:36.123', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(626, 543, NULL, '20120820 00:00:00.0', 1, 31, N'', '20120813 11:47:51.593', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(627, 544, NULL, '20120831 00:00:00.0', 3, 50, N'', '20120813 18:21:36.133', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(628, 545, NULL, '20120823 00:00:00.0', 1, 86, N'', '20120816 10:01:18.227', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(629, 546, NULL, '20120903 00:00:00.0', 3, 12, N'', '20120816 10:17:08.667', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(630, 547, NULL, '20120823 00:00:00.0', 1, 24, N'', '20120816 11:39:26.893', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(631, 548, NULL, '20120823 00:00:00.0', 1, 62, N'', '20120816 12:08:24.537', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(632, 549, NULL, '20120823 00:00:00.0', 1, 1519, N'', '20120816 12:22:20.470', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(633, 550, NULL, '20120912 00:00:00.0', 3, 191, N'', '20120816 12:51:57.617', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(634, 551, NULL, '20120910 00:00:00.0', 3, 176, N'', '20120816 12:52:55.110', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(635, 552, NULL, '20120823 00:00:00.0', 1, 40, N'', '20120816 15:13:12.807', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(636, 553, NULL, '20120910 00:00:00.0', 3, 71, N'', '20120816 15:48:25.887', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(637, 554, NULL, '20120827 00:00:00.0', 3, 163, N'', '20120816 17:23:00.790', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(638, NULL, NULL, '20120817 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120816 17:32:29.927', 27, 1, NULL, 25, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(639, NULL, NULL, '20120817 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120816 18:27:44.933', 27, 1, NULL, 26, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(640, 555, NULL, '20120905 00:00:00.0', 3, 73, N'', '20120817 16:19:18.633', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(641, NULL, 1808, '20120914 00:00:00.0', 1, 191, N'debemos llamar para saber definitivamente si tenemos opción en el terrestre o no! ', '20120820 10:14:26.807', 48, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(642, 556, NULL, '20120827 00:00:00.0', 1, 53, N'', '20120820 10:24:56.573', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(643, 557, NULL, '20120827 00:00:00.0', 1, 181, N'', '20120820 10:28:40.230', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(644, 558, NULL, '20120827 00:00:00.0', 1, 11, N'', '20120820 10:41:15.870', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(645, 559, NULL, '20120827 00:00:00.0', 1, 28, N'', '20120820 11:04:59.847', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(646, 560, NULL, '20120827 00:00:00.0', 1, 35, N'', '20120820 11:14:31.910', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(647, 561, NULL, '20120830 00:00:00.0', NULL, 131, N'', '20120820 11:48:51.690', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(648, 562, NULL, '20120821 00:00:00.0', NULL, 364, N'', '20120820 11:54:43.697', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(649, 563, NULL, '20120910 00:00:00.0', 3, 42, N'', '20120821 15:17:42.877', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(650, 564, NULL, '20120910 00:00:00.0', NULL, 108, N'', '20120821 15:28:23.633', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(651, NULL, NULL, '20120828 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20120821 17:21:39.800', 61, 1, NULL, 27, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(652, NULL, NULL, '20120823 17:54:32.383', 1, 0, N'llamar', '20120822 17:54:45.590', 59, 1, 95, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(653, 565, NULL, '20120910 00:00:00.0', 3, 56, N'l', '20120823 08:55:22.910', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(654, 566, NULL, '20120910 00:00:00.0', 3, 54, N'', '20120823 09:09:50.980', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(655, 567, NULL, '20120910 00:00:00.0', 3, 71, N'', '20120823 09:24:29.837', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(656, 568, NULL, '20120813 00:00:00.0', 3, 26, N'', '20120823 09:38:58.923', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(657, 569, NULL, '20120910 00:00:00.0', 3, 41, N'', '20120824 12:40:48.700', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(658, 570, NULL, '20120910 00:00:00.0', 3, 137, N'', '20120824 14:53:37.493', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(659, 571, NULL, '20120903 00:00:00.0', 3, 18, N'', '20120824 15:21:15.657', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(660, 572, NULL, '20120827 00:00:00.0', 3, 101, N'', '20120824 15:52:02.667', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(661, 573, NULL, '20120910 00:00:00.0', 3, 305, N'', '20120824 16:01:54.137', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(662, 574, NULL, '20120903 00:00:00.0', 2, 30, N'', '20120827 09:06:29.450', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(663, 575, NULL, '20120903 00:00:00.0', 2, 13, N'', '20120827 09:12:16.560', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(664, 576, NULL, '20120903 00:00:00.0', 1, 1796, N'', '20120827 09:27:45.467', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(665, 577, NULL, '20120903 00:00:00.0', 2, 60, N'', '20120827 09:33:12.300', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(666, 578, NULL, '20120903 00:00:00.0', 1, 33, N'', '20120827 09:51:21.107', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(667, 579, NULL, '20120903 00:00:00.0', 1, 1887, N'', '20120827 10:03:27.593', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(668, 580, NULL, '20120903 00:00:00.0', 2, 2142, N'', '20120827 10:18:06.810', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(669, 581, NULL, '20120903 00:00:00.0', 2, 121, N'', '20120827 10:28:09.467', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(670, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 11:29:37.930', 5, 1, 197, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(671, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 15:20:11.840', 5, 1, 198, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(672, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 15:21:16.957', 5, 1, 199, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(673, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 15:22:46.930', 5, 1, 200, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(674, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 15:35:52.653', 5, 1, 201, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(675, NULL, NULL, '20120828 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120827 15:37:22.560', 5, 1, 202, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(681, 582, NULL, '20120910 00:00:00.0', 3, 52, N'', '20120829 10:17:12.867', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(682, NULL, NULL, '20120830 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120829 12:28:59.877', 5, 1, 208, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(683, NULL, NULL, '20120830 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120829 12:29:55.630', 5, 1, 209, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(684, 583, NULL, '20120917 00:00:00.0', 3, 176, N'', '20120829 12:31:47.903', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(685, 584, NULL, '20120910 00:00:00.0', 3, 1998, N'', '20120829 15:50:57.350', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(686, 585, NULL, '20120910 00:00:00.0', 3, 8, N'', '20120830 11:00:17.653', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(687, NULL, NULL, '20120831 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120830 12:26:36.513', 59, 1, 210, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(688, 586, NULL, '20120907 00:00:00.0', 2, 62, N'', '20120831 09:28:38.110', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(689, 587, NULL, '20120907 00:00:00.0', 2, 2168, N'', '20120831 09:40:24.923', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(690, 588, NULL, '20120910 00:00:00.0', 3, 18, N'', '20120831 09:48:38.147', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(691, 589, NULL, '20120907 00:00:00.0', 1, 32, N'', '20120831 11:05:51.547', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(692, 590, NULL, '20120907 00:00:00.0', 2, 219, N'', '20120831 11:21:07.290', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(693, 591, NULL, '20120907 00:00:00.0', 2, 2320, N'', '20120831 12:02:20.113', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(694, NULL, NULL, '20120901 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120831 12:04:40.147', 59, 1, 211, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(695, 592, NULL, '20120913 00:00:00.0', 2, 44, N'', '20120906 17:11:12.317', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(696, 593, NULL, '20120920 00:00:00.0', 2, 24, N'', '20120906 17:38:47.507', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(697, 594, NULL, '20120920 00:00:00.0', 2, 40, N'', '20120906 17:59:11.583', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(698, 595, NULL, '20120920 00:00:00.0', 2, 106, N'', '20120906 18:11:30.970', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(699, 596, NULL, '20120924 00:00:00.0', 3, 56, N'', '20120907 12:00:24.593', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(700, 597, NULL, '20120924 00:00:00.0', 3, 102, N'', '20120907 12:13:05.150', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(701, 598, NULL, '20120924 00:00:00.0', 3, 42, N'', '20120907 15:06:29.260', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(702, 599, NULL, '20120921 00:00:00.0', 2, 87, N'', '20120907 16:09:11.070', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(703, NULL, NULL, '20120930 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120910 11:31:13.533', 59, 1, 212, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(704, NULL, NULL, '20120930 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120910 14:44:17.063', 5, 1, 213, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(705, NULL, NULL, '20120930 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120910 15:04:41.087', 5, 1, 214, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(706, NULL, NULL, '20120930 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120910 17:25:29.193', 59, 1, 215, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(707, 600, NULL, '20121008 00:00:00.0', 3, 71, N'', '20120911 10:08:37.993', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(708, 601, NULL, '20120926 00:00:00.0', NULL, 142, N'', '20120912 15:15:37.597', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(709, 602, NULL, '20121015 00:00:00.0', 3, 18, N'', '20120914 11:28:27.773', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(710, 603, NULL, '20121015 00:00:00.0', 3, 29, N'', '20120914 11:46:49.047', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(711, 604, NULL, '20121008 00:00:00.0', 3, 52, N'', '20120914 11:59:53.790', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(712, NULL, NULL, '20120930 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120920 12:03:57.037', 59, 1, 216, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(713, NULL, NULL, '20120921 00:00:00.0', 0, 429, N'Primera reunión de seguimiento', '20120920 12:13:54.357', 4, 1, 217, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(714, 605, NULL, '20120927 00:00:00.0', NULL, 165, N'', '20120921 15:34:17.387', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(715, NULL, NULL, '20121031 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120924 12:40:42.073', 59, 1, 218, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(716, 606, NULL, '20121022 00:00:00.0', 3, 2268, N'Almuerzo con Militza y don Raul.', '20120924 16:50:55.970', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(717, NULL, NULL, '20121003 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120925 14:48:27.513', 5, 1, 219, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(718, 607, NULL, '20121016 00:00:00.0', 3, 12, N'', '20120925 16:05:22.707', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(719, NULL, NULL, '20121003 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120926 11:18:37.570', 5, 1, 220, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(720, NULL, NULL, '20121003 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120926 11:23:02.247', 5, 1, 221, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(721, NULL, NULL, '20121003 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20120926 11:27:05.330', 5, 1, 222, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(722, 608, NULL, '20121008 00:00:00.0', 3, 56, N'', '20120926 16:04:33.697', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(723, 609, NULL, '20121015 00:00:00.0', 3, 240, N'', '20120926 16:24:05.217', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(724, 610, NULL, '20121015 00:00:00.0', 3, 43, N'', '20120926 17:36:01.563', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(725, 611, NULL, '20121003 00:00:00.0', 1, 151, N'', '20120926 23:53:42.800', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(726, 612, NULL, '20121011 00:00:00.0', NULL, 65, N'', '20120927 14:45:16.547', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(727, 613, NULL, '20121015 00:00:00.0', 3, 59, N'', '20120927 14:59:58.760', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(728, 614, NULL, '20121015 00:00:00.0', 3, 136, N'', '20120927 15:41:55.590', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(729, 615, NULL, '20121022 00:00:00.0', 3, 176, N'', '20120927 15:51:56.130', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(730, NULL, NULL, '20130211 00:00:00.0', 1, 0, N'CHECK LICITACION', '20120928 10:56:27.627', 59, 1, 138, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(731, NULL, NULL, '20130210 00:00:00.0', 1, 0, N'CHECK LICITACION', '20120928 11:23:17.413', 59, 1, 138, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(732, NULL, NULL, '20121107 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121001 11:33:30.957', 5, 1, 223, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(733, NULL, NULL, '20121030 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121001 17:23:40.860', 5, 1, 224, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(734, 616, NULL, '20121022 00:00:00.0', 3, 18, N'', '20121002 17:34:43.047', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(735, 617, NULL, '20121017 00:00:00.0', NULL, 110, N'', '20121003 15:11:13.173', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(736, 618, NULL, '20121017 00:00:00.0', 1, 38, N'', '20121003 16:03:08.553', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(737, 619, NULL, '20121017 00:00:00.0', 1, 1244, N'', '20121003 16:10:18.430', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(738, 620, NULL, '20121017 00:00:00.0', 2, 219, N'', '20121003 16:17:32.377', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(739, 621, NULL, '20121029 00:00:00.0', 3, 22, N'', '20121003 16:52:51.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(740, 622, NULL, '20121017 00:00:00.0', 2, 6, N'', '20121003 17:11:54.593', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(741, 623, NULL, '20121017 00:00:00.0', 1, 3, N'', '20121003 17:19:32.600', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(742, 624, NULL, '20121017 00:00:00.0', 2, 46, N'', '20121003 17:27:01.703', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(743, 625, NULL, '20121019 00:00:00.0', 2, 39, N'', '20121005 09:16:14.010', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(744, 626, NULL, '20121012 00:00:00.0', 2, 119, N'', '20121005 09:21:17.243', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(745, 627, NULL, '20121019 00:00:00.0', 2, 14, N'', '20121005 09:26:38.277', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(746, 628, NULL, '20121029 00:00:00.0', 3, 27, N'', '20121005 15:57:05.160', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(747, 629, NULL, '20121022 00:00:00.0', 3, 63, N'', '20121005 16:04:20.453', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(748, 630, NULL, '20121029 00:00:00.0', 3, 176, N'', '20121005 16:12:55.163', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(749, 631, NULL, '20121022 00:00:00.0', 3, 47, N'', '20121009 11:41:47.363', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(750, 632, NULL, '20121029 00:00:00.0', 3, 56, N'', '20121009 17:06:02.603', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(751, 633, NULL, '20121024 00:00:00.0', 3, 2327, N'', '20121010 11:25:31.037', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(752, 634, NULL, '20121024 00:00:00.0', 3, 49, N'', '20121010 16:10:56.737', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(756, NULL, NULL, '20121031 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121011 11:54:56.407', 59, 1, 228, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(757, 635, NULL, '20121029 00:00:00.0', 3, 71, N'', '20121011 12:34:54.533', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(758, NULL, NULL, '20121030 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121011 15:41:51.017', 59, 1, 229, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(759, 636, NULL, '20121029 00:00:00.0', 3, 5, N'', '20121011 17:13:02.273', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(760, 637, NULL, '20121017 00:00:00.0', NULL, 131, N'', '20121012 15:45:58.237', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(761, NULL, 2208, '20121018 13:03:54.987', 1, 1566, N'llamar por confirmación', '20121012 14:57:25.010', 48, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(762, NULL, 2209, '20121016 10:00:16.070', 1, 1566, N'llamar por contraoferta ', '20121012 15:57:32.443', 48, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(763, 638, NULL, '20121029 00:00:00.0', 3, 2547, N'', '20121016 10:01:56.730', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(764, 639, NULL, '20121029 00:00:00.0', 3, 102, N'', '20121016 10:12:59.430', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(765, 640, NULL, '20121029 00:00:00.0', 3, 154, N'', '20121016 10:50:18.187', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(766, 641, NULL, '20121029 00:00:00.0', 3, 18, N'', '20121016 11:14:35.343', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(767, 642, NULL, '20121029 00:00:00.0', 3, 42, N'', '20121016 15:26:03.270', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(768, 643, NULL, '20121029 00:00:00.0', 3, 18, N'', '20121017 17:32:48.737', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(769, NULL, 2232, '20121019 11:08:03.143', 1, 1566, N'llamar por resultados ', '20121018 11:12:16.110', 48, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(770, 644, NULL, '20121031 00:00:00.0', NULL, 210, N'', '20121019 16:17:01.770', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(771, 645, NULL, '20121030 00:00:00.0', 1, 84, N'', '20121022 10:49:00.723', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(772, 646, NULL, '20121030 00:00:00.0', NULL, 51, N'', '20121022 11:03:22.467', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(773, 647, NULL, '20121023 00:00:00.0', 2, 24, N'', '20121022 11:32:32.433', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(774, 648, NULL, '20121030 00:00:00.0', 1, 13, N'', '20121022 12:19:20.920', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(775, 649, NULL, '20121030 00:00:00.0', NULL, 55, N'', '20121022 18:46:32.167', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(778, NULL, NULL, '20121105 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121023 14:56:18.407', 59, 1, 232, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(779, NULL, NULL, '20121105 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121023 14:57:13.673', 59, 1, 233, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(780, 650, NULL, '20121113 00:00:00.0', NULL, 8, N'', '20121031 12:03:17.897', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(781, 651, NULL, '20121112 00:00:00.0', NULL, 71, N'', '20121031 12:20:59.470', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(782, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121105 17:20:07.960', 5, 1, 234, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(783, NULL, NULL, '20121128 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121105 17:51:44.320', 5, 1, 235, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(784, NULL, NULL, '20121126 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121105 17:54:36.247', 5, 1, 236, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(785, 652, NULL, '20121120 00:00:00.0', 3, 2327, N'', '20121106 11:03:39.077', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(786, 653, NULL, '20121126 00:00:00.0', 3, 18, N'', '20121107 09:41:03.973', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(787, 654, NULL, '20121126 00:00:00.0', 3, 101, N'', '20121107 09:50:53.160', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(788, 655, NULL, '20121126 00:00:00.0', 3, 52, N'', '20121107 09:59:28.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(789, 656, NULL, '20121126 00:00:00.0', 3, 1, N'', '20121107 10:14:37.100', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(790, 657, NULL, '20121126 00:00:00.0', NULL, 49, N'', '20121107 13:40:58.830', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(791, 658, NULL, '20121126 00:00:00.0', NULL, 144, N'', '20121107 13:50:03.310', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(792, 659, NULL, '20121126 00:00:00.0', 3, 12, N'', '20121108 10:51:34.780', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(793, 660, NULL, '20121116 00:00:00.0', 1, 31, N'', '20121109 10:27:19.343', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(794, 661, NULL, '20121116 00:00:00.0', NULL, 198, N'', '20121109 10:37:47.627', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(795, 662, NULL, '20121123 00:00:00.0', 2, 130, N'', '20121109 11:12:12.700', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(796, 663, NULL, '20121123 00:00:00.0', 2, 86, N'', '20121109 11:23:04.807', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(797, 664, NULL, '20121116 00:00:00.0', NULL, 30, N'', '20121109 12:12:30.080', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(798, 665, NULL, '20121119 00:00:00.0', NULL, 2662, N'', '20121109 16:38:52.740', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(799, 666, NULL, '20121123 00:00:00.0', 1, 28, N'', '20121109 15:46:19.360', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(800, NULL, NULL, '20121116 00:00:00.0', 0, 39, N'Primera reunión de seguimiento', '20121113 09:06:25.603', 4, 1, 237, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(801, NULL, NULL, '20121116 00:00:00.0', 0, 39, N'Primera reunión de seguimiento', '20121113 09:11:12.577', 4, 1, 238, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(802, NULL, NULL, '20121116 00:00:00.0', 0, 35, N'Primera reunión de seguimiento', '20121113 09:15:20.437', 4, 1, 239, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(803, NULL, NULL, '20121116 00:00:00.0', 0, 305, N'Primera reunión de seguimiento', '20121113 09:22:08.663', 4, 1, 240, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(804, NULL, NULL, '20121116 00:00:00.0', 0, 27, N'Primera reunión de seguimiento', '20121113 09:33:41.477', 4, 1, 241, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(805, NULL, NULL, '20121116 00:00:00.0', 0, 12, N'Primera reunión de seguimiento', '20121113 09:41:46.063', 4, 1, 242, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(806, 667, NULL, '20121226 00:00:00.0', 1, 1931, N'', '20121113 14:14:13.317', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(807, 668, NULL, '20121126 00:00:00.0', 3, 56, N'', '20121113 16:51:06.887', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(808, 669, NULL, '20121203 00:00:00.0', 3, 54, N'', '20121113 16:57:46.623', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(809, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121113 17:22:12.540', 59, 1, 243, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(810, 670, NULL, '20121126 00:00:00.0', 3, 161, N'', '20121113 17:31:04.503', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(811, 671, NULL, '20121126 00:00:00.0', 3, 71, N'', '20121113 17:45:10.927', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(812, NULL, NULL, '20121128 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121114 12:06:11.853', 5, 1, 244, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(813, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121114 12:36:35.823', 59, 1, 245, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(814, 672, NULL, '20121122 00:00:00.0', 1, 198, N'', '20121115 11:14:13.370', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(815, 673, NULL, '20121126 00:00:00.0', 3, 63, N'', '20121115 15:52:31.870', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(816, 674, NULL, '20121126 00:00:00.0', 3, 43, N'', '20121115 16:18:28.410', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(817, 675, NULL, '20121123 00:00:00.0', 3, 1994, N'', '20121115 18:08:45.013', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(818, 676, NULL, '20121130 00:00:00.0', 1, 2067, N'', '20121119 11:27:25.083', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(819, 677, NULL, '20121203 00:00:00.0', 3, 105, N'', '20121119 17:09:17.960', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(820, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121120 10:39:03.170', 59, 1, 246, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(821, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121120 11:38:51.230', 59, 1, 247, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(822, NULL, NULL, '20121130 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121120 12:58:38.067', 59, 1, 248, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(823, 678, NULL, '20121210 00:00:00.0', 3, 240, N'', '20121121 09:40:23.990', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(824, 679, NULL, '20121217 00:00:00.0', 3, 85, N'', '20121121 09:55:52.087', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(825, 680, NULL, '20121210 00:00:00.0', 3, 100, N'', '20121121 10:28:21.093', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(826, NULL, NULL, '20121128 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121121 15:29:54.673', 4, 1, 249, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(829, NULL, NULL, '20121129 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121122 08:35:20.280', 4, 1, 252, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(830, 681, NULL, '20121203 00:00:00.0', 3, 170, N'', '20121122 15:44:04.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(831, 682, NULL, '20121210 00:00:00.0', 3, 26, N'', '20121122 16:02:33.567', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(832, NULL, NULL, '20121129 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121122 16:05:55.667', 4, 1, 253, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(833, 683, NULL, '20121210 00:00:00.0', 3, 41, N'', '20121122 16:38:20.830', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(834, 684, NULL, '20121130 00:00:00.0', 2, 45, N'', '20121123 08:55:22.570', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(835, 685, NULL, '20121130 00:00:00.0', 1, 46, N'', '20121123 09:07:05.100', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(836, 686, NULL, '20121130 00:00:00.0', 2, 16, N'', '20121123 09:14:34.603', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(837, 687, NULL, '20121130 00:00:00.0', 2, 220, N'', '20121123 12:44:29.860', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(838, 688, NULL, '20121130 00:00:00.0', 2, 1887, N'', '20121123 13:02:57.667', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(839, 689, NULL, '20121210 00:00:00.0', 3, 5, N'', '20121130 11:49:08.423', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(840, 690, NULL, '20121217 00:00:00.0', 3, 102, N'', '20121130 11:58:47.957', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(841, 691, NULL, '20121217 00:00:00.0', 3, 42, N'', '20121130 12:42:30.430', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(842, 692, NULL, '20121218 00:00:00.0', 2, 32, N'', '20121204 08:45:14.003', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(843, 693, NULL, '20121218 00:00:00.0', 2, 87, N'', '20121204 08:58:22.830', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(844, 694, NULL, '20121211 00:00:00.0', 1, 30, N'', '20121204 10:27:56.623', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(845, 695, NULL, '20121211 00:00:00.0', 1, 33, N'', '20121204 11:43:23.853', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(846, 696, NULL, '20121218 00:00:00.0', 2, 31, N'', '20121204 12:17:52.607', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(847, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:23:42.733', 59, 1, 254, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(848, 697, NULL, '20121211 00:00:00.0', 2, 151, N'', '20121204 12:27:16.463', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(849, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:29:56.300', 59, 1, 255, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(850, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:31:42.830', 59, 1, 256, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(851, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:32:58.710', 59, 1, 257, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(852, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:34:22.207', 59, 1, 258, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(853, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:35:35.560', 59, 1, 259, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(854, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:37:20.550', 59, 1, 260, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(855, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:39:00.427', 59, 1, 261, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(856, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:40:15.043', 59, 1, 262, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(857, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:41:06.933', 59, 1, 263, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(858, NULL, NULL, '20121214 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121204 12:42:29.627', 59, 1, 264, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(859, 698, NULL, '20130107 00:00:00.0', 3, 42, N'', '20121207 10:12:46.383', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(860, 699, NULL, '20121217 00:00:00.0', 3, 12, N'', '20121207 10:19:17.033', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(861, NULL, NULL, '20121223 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 08:58:20.003', 59, 1, 265, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(862, NULL, NULL, '20121223 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:09:42.567', 59, 1, 266, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(863, NULL, NULL, '20121223 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:10:58.343', 59, 1, 267, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(864, NULL, NULL, '20121224 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:13:19.267', 59, 1, 268, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(865, NULL, NULL, '20121224 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:17:54.890', 59, 1, 269, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(866, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:20:35.557', 59, 1, 270, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(867, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:52:20.090', 59, 1, 271, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(868, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:53:26.780', 59, 1, 272, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(869, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 09:56:38.153', 59, 1, 273, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(870, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:01:13.647', 59, 1, 274, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(871, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:11:34.257', 59, 1, 275, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(872, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:13:18.157', 59, 1, 276, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(873, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:15:50.427', 59, 1, 277, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(874, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:29:46.640', 59, 1, 278, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(875, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:30:57.193', 59, 1, 279, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(876, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:45:13.257', 59, 1, 280, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(877, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:47:18.193', 59, 1, 281, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(878, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:48:10.593', 59, 1, 282, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(879, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:53:56.150', 59, 1, 283, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(880, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:55:02.580', 59, 1, 284, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(881, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:56:25.560', 59, 1, 285, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(882, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 10:57:17.913', 59, 1, 286, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(883, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 11:01:46.597', 59, 1, 287, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(884, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 11:03:02.253', 59, 1, 288, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(885, NULL, NULL, '20121217 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121210 11:04:31.423', 59, 1, 289, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(886, 700, NULL, '20121219 00:00:00.0', 1, 2908, N'Llamar por nuevas ordenes de Winhop', '20121211 10:09:36.190', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(887, 701, NULL, '20130107 00:00:00.0', 3, 1, N'', '20121212 15:49:49.380', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(888, 702, NULL, '20130114 00:00:00.0', 3, 56, N'', '20121212 16:31:16.890', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(889, 703, NULL, '20121227 00:00:00.0', 1, 2876, N'Llamar para nueva orden', '20121212 17:54:22.020', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(890, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 10:20:55.470', 59, 1, 290, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(891, NULL, NULL, '20121230 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 10:56:14.457', 59, 1, 291, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(892, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 11:05:59.447', 59, 1, 292, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(893, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 11:58:54.970', 59, 1, 293, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(894, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 12:06:18.753', 59, 1, 294, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(895, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121214 12:53:56.037', 59, 1, 295, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(896, 704, NULL, '20121221 00:00:00.0', 1, 2907, N'Consultar como le fue en su viaje a Brasil', '20121214 16:01:30.183', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(897, 705, NULL, '20130107 00:00:00.0', 3, 27, N'', '20121218 14:55:49.843', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(898, 706, NULL, '20130114 00:00:00.0', 3, 47, N'', '20121220 13:01:58.980', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(899, 707, NULL, '20130114 00:00:00.0', 3, 18, N'', '20121220 13:10:02.460', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(900, 708, NULL, '20121227 00:00:00.0', 1, 2874, N'', '20121221 11:01:50.703', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(901, 709, NULL, '20130114 00:00:00.0', 3, 43, N'', '20121221 15:31:03.487', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(902, 710, NULL, '20130120 00:00:00.0', 1, 2374, N'', '20121226 11:55:58.443', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(903, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:25:19.187', 59, 1, 296, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(904, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:26:20.643', 59, 1, 297, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(905, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:27:16.947', 59, 1, 298, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(906, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:28:12.543', 59, 1, 299, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(907, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:29:18.523', 59, 1, 300, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(908, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121226 14:30:16.483', 59, 1, 301, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(909, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121227 15:04:59.110', 59, 1, 302, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(910, 711, NULL, '20130109 00:00:00.0', 1, 2875, N'PREGUNTAR POR NUEVAS ORDENES', '20121227 15:18:37.173', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(911, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121228 16:49:57.217', 59, 1, 303, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(912, NULL, NULL, '20121231 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20121228 16:50:57.157', 59, 1, 304, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(913, NULL, NULL, '20130131 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130102 12:38:35.740', 59, 1, 305, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(914, 712, NULL, '99990122 00:00:00.0', 3, 24, N'', '20130102 12:59:56.380', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(915, NULL, NULL, '20130131 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130103 17:11:35.570', 59, 1, 306, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(916, NULL, NULL, '20130109 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20130104 14:52:15.900', 4, 1, NULL, 28, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(917, NULL, NULL, '20130110 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20130104 15:33:44.967', 4, 1, NULL, 29, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(918, NULL, NULL, '20130110 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20130104 15:33:44.980', 4, 1, NULL, 30, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(919, NULL, NULL, '20130110 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20130104 15:33:44.997', 4, 1, NULL, 31, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(920, 713, NULL, '20130121 00:00:00.0', 3, 1998, N'', '20130107 15:18:27.370', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(921, 714, NULL, '20130121 00:00:00.0', 1, 2913, N'Volver a contactar, dice que tendrá nuevas ordenes', '20130108 12:15:14.490', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(922, 715, NULL, '20130121 00:00:00.0', 3, 56, N'', '20130108 15:00:38.933', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(923, 716, NULL, '20130128 00:00:00.0', 3, 241, N'', '20130109 08:59:57.050', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(924, 717, NULL, '20130128 00:00:00.0', NULL, 1566, N'', '20130109 11:28:30.020', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(925, 718, NULL, '20130130 00:00:00.0', NULL, 1566, N'', '20130109 11:40:42.277', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(926, 719, NULL, '20130130 00:00:00.0', NULL, 142, N'', '20130109 12:00:32.807', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(927, 720, NULL, '20130206 00:00:00.0', 3, 73, N'Preguntar por FCL Japon.', '20130109 12:41:09.243', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(928, 721, NULL, '20130128 00:00:00.0', 3, 63, N'', '20130109 15:43:58.030', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(929, 722, NULL, '20130128 00:00:00.0', 3, 47, N'', '20130109 16:13:08.393', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(930, 723, NULL, '20130207 00:00:00.0', NULL, 152, N'', '20130110 09:29:31.340', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(931, 724, NULL, '20130207 00:00:00.0', 3, 83, N'', '20130110 10:26:58.840', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(932, 725, NULL, '20130206 00:00:00.0', 3, 83, N'', '20130110 12:10:30.863', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(933, 726, NULL, '20130128 00:00:00.0', 3, 71, N'', '20130110 17:16:44.377', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(934, 727, NULL, '20130128 00:00:00.0', 3, 90, N'', '20130110 17:24:27.817', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(935, 728, NULL, '20130128 00:00:00.0', 3, 27, N'', '20130110 18:03:26.323', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(936, 729, NULL, '20130116 00:00:00.0', 3, 176, N'', '20130110 18:34:38.070', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(937, 730, NULL, '20130115 00:00:00.0', NULL, 1566, N'', '20130111 10:52:38.200', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(938, 731, NULL, '20130131 00:00:00.0', NULL, 131, N'', '20130111 11:00:31.750', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(939, 732, NULL, '20130125 00:00:00.0', 2, 30, N'', '20130111 11:50:49.730', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(940, NULL, NULL, '20130131 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130111 12:16:52.893', 59, 1, 307, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(941, 733, NULL, '20130125 00:00:00.0', 2, 30, N'', '20130111 12:20:32.287', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(942, 734, NULL, '20130125 00:00:00.0', 2, 106, N'', '20130111 16:02:14.710', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(943, 735, NULL, '20130125 00:00:00.0', 3, 245, N'', '20130111 16:11:26.660', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(944, 736, NULL, '20130118 00:00:00.0', 1, 219, N'', '20130111 16:29:32.363', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(945, 737, NULL, '20130206 00:00:00.0', 3, 2160, N'', '20130114 09:13:25.013', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(946, 738, NULL, '20130208 00:00:00.0', 3, 2159, N'', '20130114 09:33:41.667', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(947, 739, NULL, '20130205 00:00:00.0', 3, 50, N'', '20130114 09:47:28.040', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(948, 740, NULL, '20130128 00:00:00.0', 1, 2435, N'Llamar a Maria Ester para informar de mi salida a vacaciones, indicarle nombre y datos de contacto de mi reemplazo.', '20130114 10:47:12.470', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(949, 741, NULL, '20130121 00:00:00.0', 2, 16, N'', '20130114 16:56:41.050', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(950, 742, NULL, '20130206 00:00:00.0', 3, 41, N'', '20130116 15:49:00.597', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(951, 743, NULL, '20130206 00:00:00.0', 3, 137, N'', '20130116 15:57:39.863', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(952, 744, NULL, '20130124 00:00:00.0', 3, 18, N'', '20130116 16:14:28.577', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(953, 745, NULL, '20130204 00:00:00.0', 3, 101, N'', '20130116 16:30:13.540', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(954, 746, NULL, '20130128 00:00:00.0', 3, 42, N'', '20130116 17:42:41.293', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(955, 747, NULL, '20130124 00:00:00.0', 1, 2908, N'Llamar por lo de Qingdao', '20130117 08:41:26.517', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(956, 748, NULL, '20130131 00:00:00.0', 3, 99, N'', '20130117 09:31:01.473', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(957, 749, NULL, '20130207 00:00:00.0', 3, 150, N'', '20130117 09:38:32.247', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(958, 750, NULL, '20130213 00:00:00.0', NULL, 1271, N'', '20130117 09:53:21.733', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(959, 751, NULL, '20130124 00:00:00.0', 1, 45, N'', '20130117 09:58:29.503', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(960, 752, NULL, '20130124 00:00:00.0', 2, 37, N'', '20130117 10:14:45.503', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(961, 753, NULL, '20130124 00:00:00.0', 1, 31, N'', '20130117 11:11:27.937', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(962, 754, NULL, '20130124 00:00:00.0', 2, 39, N'', '20130117 12:41:12.453', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(963, 755, NULL, '20130207 00:00:00.0', NULL, 1994, N'', '20130117 15:12:58.480', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(964, 756, NULL, '20130131 00:00:00.0', NULL, 1566, N'', '20130117 15:26:47.467', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(965, 757, NULL, '20130128 00:00:00.0', 3, 176, N'', '20130117 14:44:11.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(966, 758, NULL, '20130128 00:00:00.0', 3, 105, N'', '20130117 15:01:18.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(967, 759, NULL, '20130128 00:00:00.0', 3, 100, N'', '20130117 15:09:56.730', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(968, 760, NULL, '20130131 00:00:00.0', 1, 3116, N'', '20130117 16:02:28.573', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(969, 761, NULL, '20130131 00:00:00.0', 3, 1041, N'', '20130117 17:01:54.420', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(970, 762, NULL, '20130122 00:00:00.0', NULL, 1566, N'', '20130118 15:49:28.400', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(971, 763, NULL, '20130122 00:00:00.0', NULL, 49, N'', '20130118 15:56:52.410', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(972, 764, NULL, '20130212 00:00:00.0', NULL, 1566, N'', '20130118 16:05:18.780', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(973, 765, NULL, '20130122 00:00:00.0', NULL, 144, N'', '20130118 16:19:13.727', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(974, 766, NULL, '20130129 00:00:00.0', 1, 53, N'', '20130121 11:16:55.840', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(975, 767, NULL, '20130128 00:00:00.0', 2, 151, N'', '20130121 11:44:16.443', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(976, 768, NULL, '20130131 00:00:00.0', 1, 2327, N'', '20130122 12:09:07.820', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(977, NULL, NULL, '20130208 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 12:55:28.930', 5, 1, 308, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(978, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:43:10.600', 5, 1, 309, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(979, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:45:23.900', 5, 1, 310, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(980, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:47:20.653', 5, 1, 311, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(981, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:49:37.310', 5, 1, 312, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(982, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:51:48.477', 5, 1, 313, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(983, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:53:56.030', 5, 1, 314, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(984, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:56:09.697', 5, 1, 315, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(985, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 14:59:24.717', 5, 1, 316, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(986, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:01:10.893', 5, 1, 317, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(987, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:03:19.503', 5, 1, 318, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(988, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:05:35.790', 5, 1, 319, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(989, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:08:34.363', 5, 1, 320, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(990, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:09:59.340', 5, 1, 321, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(991, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:11:38.400', 5, 1, 322, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(992, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:16:15.363', 5, 1, 323, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(993, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:17:46.110', 5, 1, 324, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(994, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:19:57.703', 5, 1, 325, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(995, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:22:31.490', 5, 1, 326, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(996, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:28:47.763', 5, 1, 327, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(997, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:31:42.097', 5, 1, 328, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(998, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:32:54.597', 5, 1, 329, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(999, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:35:57.320', 5, 1, 330, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1000, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130122 15:52:36.073', 5, 1, 331, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1001, 769, NULL, '20130204 00:00:00.0', 3, 22, N'', '20130123 16:12:13.153', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1002, 770, NULL, '20130204 00:00:00.0', 1, 2875, N'Tiene nuevas ordenes', '20130123 16:24:23.853', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1003, 771, NULL, '20130204 00:00:00.0', 1, 2924, N'VER POR LAS ORDENES MARITIMAS FCL', '20130123 16:27:45.723', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1004, 772, NULL, '20130211 00:00:00.0', 3, 59, N'', '20130123 16:41:38.500', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1005, 773, NULL, '20130131 00:00:00.0', NULL, 88, N'', '20130123 17:50:19.730', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1006, 774, NULL, '20130205 00:00:00.0', NULL, 203, N'', '20130123 17:56:21.517', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1007, 775, NULL, '20130131 00:00:00.0', 2, 198, N'', '20130124 09:32:36.120', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1008, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 11:59:57.153', 5, 1, 332, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1009, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 12:02:21.100', 5, 1, 333, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1010, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 12:06:14.997', 5, 1, 334, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1011, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 12:10:32.627', 5, 1, 335, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1012, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 12:12:24.810', 5, 1, 336, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1013, 776, NULL, '20130211 00:00:00.0', 3, 2167, N'', '20130124 14:51:00.743', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1014, 777, NULL, '20130204 00:00:00.0', 3, 8, N'', '20130124 15:03:28.167', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1015, 778, NULL, '20130125 00:00:00.0', NULL, 1566, N'', '20130124 16:51:40.910', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1016, 779, NULL, '20130312 00:00:00.0', NULL, 1566, N'', '20130124 17:02:50.490', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1017, 780, NULL, '20130211 00:00:00.0', 3, 43, N'', '20130124 16:09:50.010', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1018, 781, NULL, '20130211 00:00:00.0', NULL, 1566, N'', '20130124 17:10:27.483', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1019, 782, NULL, '20130306 00:00:00.0', NULL, 1566, N'', '20130124 17:18:51.537', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1020, NULL, NULL, '20130218 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130124 17:22:15.250', 5, 1, 337, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1021, 783, NULL, '20130211 00:00:00.0', NULL, 209, N'', '20130125 15:23:32.680', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1022, 784, NULL, '20130201 00:00:00.0', 3, 24, N'', '20130125 16:30:54.253', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1023, 785, NULL, '20130205 00:00:00.0', 2, 3202, N'', '20130129 10:09:37.523', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1024, 786, NULL, '20130205 00:00:00.0', 1, 62, N'', '20130129 10:20:40.720', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1025, 787, NULL, '20130205 00:00:00.0', 2, 46, N'', '20130129 10:28:14.927', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1026, 788, NULL, '20130129 00:00:00.0', 2, 220, N'', '20130129 14:58:48.817', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1027, 789, NULL, '20130211 00:00:00.0', 3, 27, N'', '20130129 16:33:06.067', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1028, 790, NULL, '20130211 00:00:00.0', 3, 54, N'', '20130129 16:45:03.867', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1029, 791, NULL, '20130304 00:00:00.0', 3, 161, N'', '20130129 16:53:33.753', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1030, 792, NULL, '20130225 00:00:00.0', 3, 102, N'', '20130129 17:06:45.427', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1031, 793, NULL, '20130305 00:00:00.0', NULL, 1566, N'', '20130130 16:12:39.023', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1032, 794, NULL, '20130211 00:00:00.0', 3, 136, N'', '20130130 16:29:17.380', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1033, 795, NULL, '20130211 00:00:00.0', 3, 12, N'', '20130130 16:46:06.953', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1034, 796, NULL, '20130211 00:00:00.0', 3, 71, N'', '20130131 16:07:36.170', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1035, 797, NULL, '20130208 00:00:00.0', 2, 11, N'', '20130201 12:23:13.413', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1036, 798, NULL, '20130214 00:00:00.0', 2, 3166, N'', '20130201 13:58:50.213', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1037, 799, NULL, '20130205 00:00:00.0', 3, 169, N'', '20130201 13:59:21.550', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1038, 800, NULL, '20130208 00:00:00.0', 2, 3296, N'', '20130201 14:21:30.703', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1039, 801, NULL, '20130208 00:00:00.0', 3, 46, N'', '20130201 14:42:55.897', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1040, 802, NULL, '20130304 00:00:00.0', 3, 1566, N'', '20130201 16:08:54.167', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1041, 803, NULL, '20130214 00:00:00.0', NULL, 78, N'', '20130201 16:28:20.180', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1042, 804, NULL, '20130304 00:00:00.0', 3, 148, N'', '20130204 12:17:29.823', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1043, 805, NULL, '20130304 00:00:00.0', 3, 1368, N'', '20130204 12:25:24.240', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1044, 806, NULL, '20130304 00:00:00.0', 3, 2133, N'', '20130204 12:52:37.557', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1045, 807, NULL, '20130305 00:00:00.0', NULL, 364, N'', '20130206 15:47:33.783', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1046, 808, NULL, '20130211 00:00:00.0', NULL, 1566, N'', '20130206 16:01:45.320', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1047, 809, NULL, '20130226 00:00:00.0', 3, 5, N'', '20130206 16:45:03.523', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1048, 810, NULL, '20130221 00:00:00.0', 3, 2874, N'', '20130207 17:00:07.817', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1049, 811, NULL, '20130213 00:00:00.0', 3, 93, N'Para conocer a la nueva encargada de importaciones Alicia Latorre.', '20130211 17:59:46.390', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1050, 812, NULL, '20130306 00:00:00.0', NULL, 1566, N'', '20130212 16:05:38.923', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1051, 813, NULL, '20130305 00:00:00.0', NULL, 88, N'', '20130212 16:14:04.370', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1052, 814, NULL, '20130227 00:00:00.0', 3, 1998, N'', '20130212 15:24:03.197', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1053, 815, NULL, '20130312 00:00:00.0', 3, 90, N'', '20130212 16:36:37.430', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1054, 816, NULL, '20130220 00:00:00.0', 2, 16, N'', '20130213 14:18:44.580', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1055, 817, NULL, '20130220 00:00:00.0', 1, 24, N'', '20130213 14:38:39.837', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1056, 818, NULL, '20130311 00:00:00.0', 3, 71, N'', '20130213 14:50:25.463', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1057, 819, NULL, '20130306 00:00:00.0', 3, 3117, N'', '20130213 18:35:03.747', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1058, 820, NULL, '20130307 00:00:00.0', 3, 2545, N'', '20130213 18:47:49.417', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1059, 821, NULL, '20130311 00:00:00.0', 3, 2157, N'', '20130213 18:54:38.013', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1060, NULL, NULL, '20130228 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130213 19:01:19.173', 5, 1, 338, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1061, NULL, NULL, '20130307 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130214 08:31:00.073', 32, 1, 339, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1062, NULL, NULL, '20130307 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130214 08:40:33.467', 32, 1, 340, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1063, NULL, NULL, '20130307 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130214 08:43:01.957', 32, 1, 341, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1064, NULL, NULL, '20130306 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130214 12:32:14.550', 5, 1, 342, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1065, NULL, NULL, '20130306 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130214 12:35:48.510', 5, 1, 343, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1066, 822, NULL, '20130311 00:00:00.0', NULL, 135, N'', '20130214 18:07:42.013', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1067, 823, NULL, '20130312 00:00:00.0', 3, 76, N'', '20130215 08:33:40.410', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1068, 824, NULL, '20130307 00:00:00.0', 3, 943, N'', '20130215 08:41:31.827', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1069, 825, NULL, '20130320 00:00:00.0', 3, 48, N'', '20130215 08:52:55.390', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1070, 826, NULL, '20130321 00:00:00.0', 1, 73, N'', '20130215 09:00:19.810', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1071, 827, NULL, '20130311 00:00:00.0', 3, 27, N'', '20130215 10:44:13.253', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1072, 828, NULL, '20130222 00:00:00.0', 1, 1244, N'', '20130215 11:46:21.153', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1073, 829, NULL, '20130222 00:00:00.0', 2, 44, N'', '20130215 11:48:24.560', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1074, 830, NULL, '20130222 00:00:00.0', 1, 3345, N'', '20130215 12:18:09.390', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1075, 831, NULL, '20130222 00:00:00.0', NULL, 151, N'', '20130215 12:32:49.720', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1076, 832, NULL, '20130311 00:00:00.0', 3, 26, N'', '20130215 14:46:49.023', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1077, 833, NULL, '20130222 00:00:00.0', 1, 1887, N'', '20130215 15:34:10.763', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1078, 834, NULL, '20130222 00:00:00.0', NULL, 2142, N'', '20130215 15:40:17.677', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1079, 835, NULL, '20130223 00:00:00.0', 2, 13, N'', '20130215 15:48:16.257', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1080, NULL, NULL, '20130315 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130218 15:01:26.047', 5, 1, 344, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1081, NULL, NULL, '20130318 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130218 15:03:29.597', 5, 1, 345, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1082, NULL, NULL, '20130318 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130218 15:05:49.140', 5, 1, 346, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1083, NULL, NULL, '20130318 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130218 15:08:17.263', 5, 1, 347, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1084, NULL, NULL, '20130318 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130218 15:09:14.987', 5, 1, 348, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1085, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 11:00:14.023', 5, 1, 349, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1086, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 11:04:22.780', 5, 1, 350, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1087, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 11:07:43.887', 5, 1, 351, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1088, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 12:38:41.447', 5, 1, 352, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1089, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 12:39:36.873', 5, 1, 353, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1090, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 12:42:36.750', 5, 1, 354, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1091, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 12:49:12.487', 5, 1, 355, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1092, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:09:41.343', 5, 1, 356, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1093, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:11:39.637', 5, 1, 357, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1094, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:13:46.637', 5, 1, 358, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1095, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:38:59.627', 5, 1, 359, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1096, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:40:40.710', 5, 1, 360, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1097, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:42:29.740', 5, 1, 361, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1098, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:43:45.527', 5, 1, 362, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1099, NULL, NULL, '20130320 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130220 17:47:51.767', 5, 1, 363, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1100, NULL, NULL, '20130321 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130221 10:57:21.900', 5, 1, 364, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1101, 836, NULL, '20130321 00:00:00.0', 3, 3299, N'', '20130221 12:30:27.087', 10, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1102, 837, NULL, '20130321 00:00:00.0', 3, 2125, N'', '20130221 12:50:32.137', 10, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1103, NULL, NULL, '20130322 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130222 16:43:03.177', 5, 1, 365, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1104, NULL, 2585, '20130227 13:09:00.540', 1, 8, N'test por caida computador YIN', '20130227 13:09:56.890', 61, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1105, NULL, NULL, '20130301 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130227 16:25:47.277', 5, 1, 366, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1106, 838, NULL, '20130306 00:00:00.0', 3, 22, N'', '20130228 09:08:26.787', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1107, 839, NULL, '20130312 00:00:00.0', 3, 47, N'', '20130228 09:26:01.367', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1108, NULL, NULL, '20130305 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130228 09:33:25.577', 4, 1, 367, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1109, 840, NULL, '20130311 00:00:00.0', 3, 29, N'', '20130228 09:49:38.680', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1110, 841, NULL, '20130313 00:00:00.0', 3, 1, N'', '20130228 14:57:52.937', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1111, 842, NULL, '20130326 00:00:00.0', 3, 102, N'', '20130301 09:47:12.983', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1112, NULL, NULL, '20130405 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130301 16:49:40.187', 5, 1, 368, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1113, 843, NULL, '20130325 00:00:00.0', 1, 2875, N'Hay que llamarla a la vuelta de vacaciones', '20130304 12:55:30.970', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1114, 844, NULL, '20130325 00:00:00.0', 3, 71, N'', '20130305 15:08:42.223', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1115, 845, NULL, '20130331 00:00:00.0', 1, 2272, N'', '20130306 11:21:08.980', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1116, 846, NULL, '20130325 00:00:00.0', 3, 63, N'', '20130306 15:29:18.443', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1117, 847, NULL, '20130325 00:00:00.0', 3, 42, N'', '20130306 15:44:22.520', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1118, NULL, NULL, '20130331 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130307 10:43:09.277', 5, 1, 369, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1119, NULL, NULL, '20130404 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130307 15:07:02.523', 5, 1, 370, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1120, 848, NULL, '20130325 00:00:00.0', 3, 85, N'', '20130307 17:15:43.140', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1121, 849, NULL, '20130318 00:00:00.0', 3, 240, N'', '20130307 17:30:55.653', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1122, 850, NULL, '20130408 00:00:00.0', 3, 644, N'', '20130307 17:38:47.723', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1123, 851, NULL, '20130320 00:00:00.0', NULL, 49, N'', '20130308 17:10:21.563', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1124, 852, NULL, '20130325 00:00:00.0', 1, 2908, N'', '20130311 14:07:04.870', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1125, 853, NULL, '20130325 00:00:00.0', 1, 2913, N'', '20130311 14:11:27.677', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1126, 854, NULL, '20130327 00:00:00.0', NULL, 1566, N'', '20130313 15:22:26.697', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1127, 855, NULL, '20130326 00:00:00.0', NULL, 2374, N'', '20130313 17:06:00.783', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1128, 856, NULL, '20130408 00:00:00.0', 3, 27, N'', '20130315 12:26:31.897', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1129, 857, NULL, '20130415 00:00:00.0', 3, 12, N'', '20130315 14:38:01.640', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1130, 858, NULL, '20130325 00:00:00.0', 3, 1, N'', '20130315 14:53:02.757', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1131, 859, NULL, '20130325 00:00:00.0', 3, 59, N'', '20130315 15:25:13.490', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1132, 860, NULL, '20130311 00:00:00.0', 3, 5, N'', '20130315 15:40:27.293', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1133, 861, NULL, '20130325 00:00:00.0', 3, 108, N'', '20130315 16:00:16.287', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1134, 862, NULL, '20130401 00:00:00.0', 3, 23, N'', '20130315 16:08:25.067', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1135, 863, NULL, '20130415 00:00:00.0', 3, 3576, N'', '20130318 10:47:02.020', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1136, 864, NULL, '20130325 00:00:00.0', 2, 39, N'', '20130318 12:08:09.187', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1137, 865, NULL, '20130325 00:00:00.0', 2, 13, N'', '20130318 12:18:06.263', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1138, 866, NULL, '20130408 00:00:00.0', 3, 18, N'', '20130318 12:37:59.717', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1139, 867, NULL, '20130325 00:00:00.0', 2, 227, N'', '20130318 13:08:06.187', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1140, 868, NULL, '20130325 00:00:00.0', 2, 30, N'', '20130318 14:20:26.887', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1141, 869, NULL, '20130331 00:00:00.0', 3, 2968, N'Visita para chequear estado de arribo de carga y evaluacion de don Carlos.', '20130318 15:01:21.127', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1142, 870, NULL, '20130325 00:00:00.0', 2, 28, N'', '20130318 15:02:05.520', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1143, 871, NULL, '20130325 00:00:00.0', 2, 19, N'', '20130318 15:33:29.193', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1144, 872, NULL, '20130325 00:00:00.0', NULL, 40, N'', '20130318 16:01:14.820', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1145, 873, NULL, '20130325 00:00:00.0', 2, 51, N'', '20130318 16:35:04.573', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1146, 874, NULL, '20130402 00:00:00.0', NULL, 49, N'', '20130319 17:01:18.270', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1147, 875, NULL, '20130327 00:00:00.0', 2, 51, N'', '20130320 11:31:37.037', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1148, 876, NULL, '20130327 00:00:00.0', 2, 3030, N'', '20130320 12:11:38.160', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1149, 877, NULL, '20130327 00:00:00.0', 2, 32, N'', '20130320 12:55:03.290', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1150, 878, NULL, '20130327 00:00:00.0', 2, 39, N'', '20130320 13:03:00.150', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1151, 879, NULL, '20130327 00:00:00.0', 2, 119, N'', '20130320 13:39:26.893', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1152, 880, NULL, '20130327 00:00:00.0', 2, 14, N'', '20130320 13:46:18.850', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1153, 881, NULL, '20130327 00:00:00.0', 2, 45, N'', '20130320 13:58:15.190', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1154, 882, NULL, '20130327 00:00:00.0', 2, 220, N'', '20130320 14:42:31.343', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1155, 883, NULL, '20130327 00:00:00.0', 2, 32, N'', '20130320 14:59:47.390', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1156, 884, NULL, '20130327 00:00:00.0', 2, 258, N'', '20130320 15:27:40.950', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1157, 885, NULL, '20130408 00:00:00.0', 3, 85, N'', '20130321 15:33:10.210', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1158, 886, NULL, '20130328 00:00:00.0', 2, 30, N'', '20130321 15:42:14.583', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1159, 887, NULL, '20130408 00:00:00.0', 3, 170, N'', '20130321 17:37:13.430', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1160, 888, NULL, '20130415 00:00:00.0', 3, 100, N'', '20130322 09:07:58.117', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1161, 889, NULL, '20130408 00:00:00.0', 3, 81, N'', '20130322 14:21:47.657', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1162, 890, NULL, '20130401 00:00:00.0', 3, 43, N'', '20130322 15:26:04.523', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1163, 891, NULL, '20130408 00:00:00.0', 3, 47, N'', '20130322 15:57:25.667', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1164, 892, NULL, '20130401 00:00:00.0', 1, 3137, N'VA A TENER NUEVAS ORDENES LCL', '20130325 10:17:51.907', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1165, 893, NULL, '20130425 00:00:00.0', NULL, 1566, N'', '20130325 15:27:03.860', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1166, 894, NULL, '20130411 00:00:00.0', NULL, 1566, N'', '20130326 15:47:48.680', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1167, 895, NULL, '20130410 00:00:00.0', 3, 22, N'', '20130327 09:24:50.113', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1168, NULL, NULL, '20130417 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130327 12:06:54.970', 5, 1, 371, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1169, 896, NULL, '20130415 00:00:00.0', 3, 56, N'', '20130327 14:56:20.603', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1170, 897, NULL, '20130408 00:00:00.0', 3, 8, N'', '20130327 15:22:28.733', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1171, 898, NULL, '20130408 00:00:00.0', 3, 241, N'', '20130327 15:44:01.237', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1172, 899, NULL, '20130422 00:00:00.0', 3, 41, N'', '20130403 15:39:39.907', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1173, 900, NULL, '20130429 00:00:00.0', 3, 18, N'', '20130403 15:52:51.427', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1174, 901, NULL, '20130418 00:00:00.0', 2, 40, N'', '20130404 08:40:37.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1175, NULL, NULL, '20130425 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130404 08:44:09.610', 5, 1, 372, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1176, NULL, NULL, '20130502 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130404 08:45:09.987', 5, 1, 373, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1177, 902, NULL, '20130418 00:00:00.0', 2, 24, N'', '20130404 08:48:10.840', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1178, NULL, NULL, '20130502 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130404 09:11:39.923', 5, 1, 374, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1179, NULL, NULL, '20130502 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130404 12:57:25.860', 5, 1, 375, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1180, 903, NULL, '20130415 00:00:00.0', 3, 29, N'', '20130405 10:36:19.010', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1181, NULL, NULL, '20130510 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130405 11:14:49.780', 5, 1, 376, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1182, 904, NULL, '20130422 00:00:00.0', 3, 42, N'', '20130405 11:42:38.813', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1183, 905, NULL, '20130422 00:00:00.0', 3, 105, N'', '20130405 12:03:17.320', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1184, 906, NULL, '20130422 00:00:00.0', 3, 71, N'', '20130405 12:37:44.763', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1185, 907, NULL, '20130422 00:00:00.0', 3, 71, N'', '20130405 12:44:55.867', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1186, 908, NULL, '20130415 00:00:00.0', 1, 2876, N'', '20130405 12:52:27.290', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1187, 909, NULL, '20130423 00:00:00.0', NULL, 142, N'', '20130405 15:25:59.963', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1188, 910, NULL, '20130422 00:00:00.0', 3, 18, N'', '20130408 14:56:06.113', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1189, 911, NULL, '20130416 00:00:00.0', 2, 66, N'', '20130409 11:19:56.620', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1190, 912, NULL, '20130416 00:00:00.0', 1, 106, N'', '20130409 14:03:48.200', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1191, 913, NULL, '20130423 00:00:00.0', NULL, 65, N'', '20130410 16:19:38.650', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1192, 914, NULL, '20130429 00:00:00.0', 3, 102, N'', '20130410 17:21:15.490', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1193, 915, NULL, '20130422 00:00:00.0', 3, 136, N'', '20130411 14:51:11.920', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1194, 916, NULL, '20130422 00:00:00.0', 3, 240, N'', '20130411 15:03:26.470', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1195, 917, NULL, '20130506 00:00:00.0', 3, 154, N'', '20130411 15:10:25.763', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1196, 918, NULL, '20130429 00:00:00.0', 3, 101, N'', '20130411 15:23:19.173', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1197, 919, NULL, '20130429 00:00:00.0', 3, 27, N'', '20130411 15:35:13.393', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1198, 920, NULL, '20130429 00:00:00.0', 3, 56, N'', '20130411 16:18:17.537', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1199, NULL, NULL, '20130509 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130411 17:26:42.980', 5, 1, 377, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1200, 921, NULL, '20130422 00:00:00.0', 2, 3735, N'', '20130415 10:33:38.580', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1201, 922, NULL, '20130422 00:00:00.0', 1, 16, N'', '20130415 11:43:16.943', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1202, 923, NULL, '20130422 00:00:00.0', 2, 32, N'', '20130415 12:28:13.057', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1203, 924, NULL, '20130422 00:00:00.0', 1, 130, N'', '20130415 16:47:27.217', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1204, 925, NULL, '20130422 00:00:00.0', 1, 2875, N'', '20130417 09:52:28.443', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1205, 926, NULL, '20130429 00:00:00.0', 3, 176, N'', '20130417 10:04:45.387', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1206, 927, NULL, '20130429 00:00:00.0', 3, 3768, N'', '20130417 10:25:14.797', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1207, 928, NULL, '20130429 00:00:00.0', 3, 3767, N'', '20130417 10:34:31.200', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1208, 929, NULL, '20130429 00:00:00.0', 3, 117, N'', '20130417 10:53:04.083', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1209, 930, NULL, '20130418 00:00:00.0', 3, 12, N'', '20130417 11:00:07.530', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1210, 931, NULL, '20130506 00:00:00.0', 3, 136, N'', '20130417 14:07:26.417', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1211, NULL, NULL, '20130430 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130418 09:33:59.197', 59, 1, 378, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1212, NULL, NULL, '20130430 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130418 14:42:38.923', 59, 1, 379, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1213, 932, NULL, '20130430 00:00:00.0', NULL, 49, N'', '20130418 17:35:48.060', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1214, 933, NULL, '20130424 00:00:00.0', NULL, 1566, N'', '20130418 17:42:12.830', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1215, 934, NULL, '20130419 00:00:00.0', NULL, 203, N'', '20130418 17:47:43.820', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1216, 935, NULL, '20130506 00:00:00.0', 3, 117, N'', '20130419 10:21:29.057', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1217, 936, NULL, '20130429 00:00:00.0', 3, 1, N'', '20130419 10:43:44.287', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1218, 937, NULL, '20130429 00:00:00.0', 3, 43, N'', '20130419 10:53:33.823', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1219, 938, NULL, '20130429 00:00:00.0', 3, 1227, N'', '20130419 15:56:06.680', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1220, 939, NULL, '20130429 00:00:00.0', 2, 1887, N'', '20130422 09:34:59.143', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1221, 940, NULL, '20130429 00:00:00.0', 2, 38, N'', '20130422 09:42:07.320', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1222, 941, NULL, '20130429 00:00:00.0', 2, 3783, N'', '20130422 11:15:34.300', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1223, 942, NULL, '20130429 00:00:00.0', 2, 51, N'', '20130422 11:20:04.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1224, 943, NULL, '20130429 00:00:00.0', 2, 28, N'', '20130422 11:25:12.693', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1225, 944, NULL, '20130429 00:00:00.0', 2, 62, N'', '20130422 11:48:40.557', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1226, 945, NULL, '20130513 00:00:00.0', 3, 26, N'', '20130422 14:13:45.417', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1227, 946, NULL, '20130430 00:00:00.0', 2, 33, N'', '20130423 15:04:53.247', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1228, 947, NULL, '20130513 00:00:00.0', 3, 47, N'', '20130424 09:55:50.537', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1229, 948, NULL, '20130430 00:00:00.0', 1, 2435, N'', '20130424 09:58:10.547', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1230, 949, NULL, '20130430 00:00:00.0', 3, 18, N'', '20130424 10:21:53.650', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1231, 950, NULL, '20130430 00:00:00.0', 1, 2272, N'', '20130424 10:22:25.673', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1232, 951, NULL, '20130506 00:00:00.0', 3, 8, N'', '20130424 16:40:44.300', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1233, 952, NULL, '20130506 00:00:00.0', 3, 3790, N'', '20130424 16:52:24.217', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1234, 953, NULL, '20130502 00:00:00.0', 2, 11, N'', '20130426 09:26:43.513', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1235, 954, NULL, '20130503 00:00:00.0', 1, 46, N'', '20130426 10:29:12.213', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1236, 955, NULL, '20130513 00:00:00.0', 3, 63, N'', '20130426 10:39:21.757', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1237, 956, NULL, '20130503 00:00:00.0', NULL, 3802, N'', '20130426 11:18:00.983', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1238, 957, NULL, '20130516 00:00:00.0', 3, 54, N'', '20130426 11:20:55.173', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1239, 958, NULL, '20130513 00:00:00.0', 3, 161, N'', '20130426 11:32:07.280', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1240, 959, NULL, '20130503 00:00:00.0', 2, 4, N'', '20130426 11:33:48.507', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1241, 960, NULL, '20130516 00:00:00.0', 3, 91, N'', '20130426 11:47:38.810', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1242, 961, NULL, '20130503 00:00:00.0', 2, 87, N'', '20130426 11:51:44.537', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1243, 962, NULL, '20130502 00:00:00.0', 2, 37, N'', '20130426 12:08:49.660', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1244, 963, NULL, '20130429 00:00:00.0', 1, 183, N'', '20130426 12:19:31.527', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1245, 964, NULL, '20130503 00:00:00.0', 2, 3803, N'', '20130426 15:41:45.783', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1246, 965, NULL, '20130516 00:00:00.0', 3, 71, N'', '20130426 16:35:45.907', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1247, 966, NULL, '20130506 00:00:00.0', 2, 86, N'', '20130429 11:48:22.743', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1248, 967, NULL, '20130506 00:00:00.0', NULL, 45, N'', '20130429 12:07:47.060', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1249, 968, NULL, '20130506 00:00:00.0', 2, 3809, N'', '20130429 12:18:57.410', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1250, 969, NULL, '20130506 00:00:00.0', 1, 44, N'', '20130429 12:54:12.063', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1251, 970, NULL, '20130513 00:00:00.0', 3, 27, N'', '20130429 15:54:12.570', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1252, 971, NULL, '20130520 00:00:00.0', 3, 695, N'', '20130429 16:08:49.917', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1253, 972, NULL, '20130506 00:00:00.0', 1, 1227, N'', '20130429 16:13:00.487', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1254, 973, NULL, '20130515 00:00:00.0', NULL, 134, N'', '20130430 15:03:35.833', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1255, 974, NULL, '20130515 00:00:00.0', NULL, 1566, N'', '20130502 12:51:24.930', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1256, 975, NULL, '20130516 00:00:00.0', NULL, 165, N'', '20130502 12:57:30.123', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1257, 976, NULL, '20130520 00:00:00.0', 3, 175, N'', '20130502 15:27:26.113', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1258, 977, NULL, '20130520 00:00:00.0', 3, 241, N'', '20130502 15:37:06.367', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1259, 978, NULL, '20130520 00:00:00.0', 3, 18, N'', '20130502 16:12:06.057', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1260, 979, NULL, '20130520 00:00:00.0', 3, 137, N'', '20130502 16:32:24.120', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1261, 980, NULL, '20130520 00:00:00.0', 3, 41, N'', '20130502 16:42:28.987', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1262, 981, NULL, '20130520 00:00:00.0', 3, 101, N'', '20130502 17:06:14.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1263, 982, NULL, '20130517 00:00:00.0', 2, 151, N'', '20130503 12:38:39.763', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1264, 983, NULL, '20130524 00:00:00.0', 3, 2908, N'', '20130506 10:25:43.713', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1265, 984, NULL, '20130528 00:00:00.0', 3, 2876, N'', '20130506 10:30:31.800', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1266, 985, NULL, '20130513 00:00:00.0', 2, 31, N'', '20130506 11:15:39.283', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1267, 986, NULL, '20130531 00:00:00.0', 3, 122, N'', '20130506 12:45:43.680', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1268, 987, NULL, '20130513 00:00:00.0', 2, 35, N'', '20130506 11:51:20.627', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1269, 988, NULL, '99990101 00:00:00.0', NULL, 439, N'', '20130506 11:59:39.910', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1270, 989, NULL, '20130527 00:00:00.0', 3, 26, N'', '20130508 17:14:58.593', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1271, 990, NULL, '20130528 00:00:00.0', 3, 29, N'', '20130508 17:27:50.360', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1272, 991, NULL, '20130523 00:00:00.0', 3, 2924, N'', '20130509 12:28:10.927', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1273, 992, NULL, '20130606 00:00:00.0', 3, 73, N'', '20130509 14:55:07.623', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1274, 993, NULL, '20130613 00:00:00.0', 3, 138, N'', '20130509 14:58:23.527', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1275, 994, NULL, '20130606 00:00:00.0', 3, 148, N'', '20130509 15:01:28.807', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1276, 995, NULL, '20130606 00:00:00.0', 3, 127, N'', '20130509 15:03:32.407', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1277, NULL, NULL, '20130531 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130510 15:53:52.883', 59, 1, 380, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1278, 996, NULL, '20130528 00:00:00.0', NULL, 236, N'', '20130510 17:00:18.733', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1279, 997, NULL, '20130528 00:00:00.0', NULL, 205, N'', '20130510 17:20:25.117', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1280, 998, NULL, '20130520 00:00:00.0', 2, 40, N'', '20130513 13:56:39.327', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1281, 999, NULL, '20130520 00:00:00.0', 2, 24, N'', '20130513 14:07:51.377', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1282, 1000, NULL, '20130521 00:00:00.0', 2, 28, N'', '20130513 14:13:39.447', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1283, 1001, NULL, '20130520 00:00:00.0', 1, 2874, N'', '20130513 14:52:27.073', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1284, 1002, NULL, '20130527 00:00:00.0', 1, 2908, N'', '20130513 14:59:54.660', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1285, 1003, NULL, '20130527 00:00:00.0', 3, 2875, N'', '20130513 15:07:58.220', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1286, 1004, NULL, '20130521 00:00:00.0', 1, 3137, N'', '20130514 15:36:50.877', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1287, NULL, NULL, '20130531 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130515 09:09:46.827', 5, 1, 381, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1288, 1005, NULL, '20130522 00:00:00.0', 2, 151, N'', '20130515 09:34:19.827', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1289, 1006, NULL, '20130522 00:00:00.0', 3, 46, N'', '20130515 09:44:18.790', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1290, NULL, NULL, '20130531 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130515 16:39:02.790', 5, 1, 382, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1291, 1007, NULL, '20130523 00:00:00.0', 2, 106, N'', '20130516 10:41:53.727', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1292, 1008, NULL, '20130523 00:00:00.0', 2, 151, N'', '20130516 10:50:49.123', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1293, 1009, NULL, '20130523 00:00:00.0', 2, 38, N'', '20130516 11:11:45.850', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1294, 1010, NULL, '20130523 00:00:00.0', 3, 18, N'', '20130516 16:10:57.610', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1295, 1011, NULL, '20130527 00:00:00.0', 3, 27, N'', '20130516 16:33:48.153', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1296, 1012, NULL, '20130522 00:00:00.0', 3, 12, N'', '20130516 17:09:20.807', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1297, 1013, NULL, '20130603 00:00:00.0', 3, 1998, N'', '20130522 09:17:11.637', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1298, 1014, NULL, '20130610 00:00:00.0', 3, 56, N'', '20130522 09:25:53.760', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1299, NULL, NULL, '20130522 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130522 10:27:07.540', 5, 1, 383, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1300, NULL, NULL, '20130531 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130522 15:35:26.020', 59, 1, 384, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1301, NULL, NULL, '20130531 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130522 17:53:24.870', 59, 1, 385, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1302, 1015, NULL, '20130604 00:00:00.0', 3, 22, N'', '20130524 15:19:25.900', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1303, 1016, NULL, '20130610 00:00:00.0', 3, 105, N'', '20130524 15:31:32.170', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1304, 1017, NULL, '20130610 00:00:00.0', 3, 27, N'', '20130524 15:42:08.910', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1305, 1018, NULL, '20130610 00:00:00.0', 3, 18, N'', '20130524 15:53:28.053', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1306, 1019, NULL, '20130617 00:00:00.0', 3, 27, N'', '20130524 16:06:37.900', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1307, 1020, NULL, '20130603 00:00:00.0', 3, 42, N'', '20130524 16:16:48.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1308, 1021, NULL, '20130528 00:00:00.0', 2, 3964, N'', '20130527 13:07:57.917', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1309, 1022, NULL, '20130603 00:00:00.0', 2, 24, N'', '20130527 13:59:26.183', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1310, 1023, NULL, '20130603 00:00:00.0', 2, 24, N'', '20130527 14:12:53.127', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1311, 1024, NULL, '20130603 00:00:00.0', 2, 1887, N'', '20130527 14:28:48.127', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1312, 1025, NULL, '20130603 00:00:00.0', 2, 2142, N'', '20130527 14:42:51.527', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1313, 1026, NULL, '20130610 00:00:00.0', 3, 56, N'', '20130529 15:56:02.563', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1314, 1027, NULL, '20130610 00:00:00.0', 3, 240, N'', '20130529 16:08:24.313', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1315, 1028, NULL, '20130611 00:00:00.0', 3, 41, N'', '20130529 16:51:35.467', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1316, 1029, NULL, '20130610 00:00:00.0', 3, 108, N'', '20130529 17:05:37.450', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1317, 1030, NULL, '20130610 00:00:00.0', 3, 23, N'', '20130529 17:17:11.423', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1318, 1031, NULL, '20130610 00:00:00.0', 3, 59, N'', '20130529 17:28:03.983', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1319, 1032, NULL, '20130618 00:00:00.0', NULL, 1566, N'', '20130530 12:01:29.727', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1320, 1033, NULL, '20130618 00:00:00.0', NULL, 1566, N'', '20130530 12:05:29.290', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1321, 1034, NULL, '20130618 00:00:00.0', NULL, 49, N'', '20130530 12:08:13.727', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1322, 1035, NULL, '20130611 00:00:00.0', NULL, 209, N'', '20130530 12:22:44.300', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1323, 1036, NULL, '20130611 00:00:00.0', 3, 2875, N'', '20130530 15:30:12.940', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1324, 1037, NULL, '20130605 00:00:00.0', NULL, 1566, N'', '20130531 13:26:05.030', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1325, 1038, NULL, '20130607 00:00:00.0', 2, 24, N'', '20130531 14:39:56.050', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1326, 1039, NULL, '20130607 00:00:00.0', 1, 28, N'', '20130531 14:46:05.927', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1327, 1040, NULL, '20130603 00:00:00.0', 3, 18, N'', '20130531 15:02:55.927', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1328, 1041, NULL, '20130607 00:00:00.0', 1, 30, N'', '20130531 15:04:43.320', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1329, 1042, NULL, '20130529 00:00:00.0', 2, 13, N'', '20130531 15:25:09.050', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1330, 1043, NULL, '20130607 00:00:00.0', 2, 46, N'', '20130531 15:33:30.787', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1331, 1044, NULL, '20130606 00:00:00.0', 2, 86, N'', '20130531 15:39:20.173', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1332, 1045, NULL, '20130610 00:00:00.0', 3, 102, N'', '20130531 15:46:16.433', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1333, 1046, NULL, '20130607 00:00:00.0', NULL, 227, N'', '20130531 15:57:57.147', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1334, 1047, NULL, '20130625 00:00:00.0', 2, 53, N'', '20130603 09:14:08.560', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1335, 1048, NULL, '20130630 00:00:00.0', 1, 2968, N'', '20130603 11:48:03.090', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1336, 1049, NULL, '20130610 00:00:00.0', 3, 122, N'', '20130603 11:51:29.280', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1337, 1050, NULL, '20130610 00:00:00.0', 2, 3735, N'', '20130603 14:58:19.747', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1338, 1051, NULL, '20130617 00:00:00.0', 3, 1, N'', '20130603 18:02:18.757', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1339, 1052, NULL, '20130611 00:00:00.0', 3, 71, N'', '20130603 18:16:01.270', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1340, 1053, NULL, '20130617 00:00:00.0', 3, 56, N'', '20130603 18:27:40.973', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1341, 1054, NULL, '20130613 00:00:00.0', 3, 176, N'', '20130603 18:44:30.413', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1342, 1055, NULL, '20130611 00:00:00.0', 2, 72, N'', '20130604 11:49:33.620', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1343, 1056, NULL, '20130611 00:00:00.0', 2, 7, N'', '20130604 12:06:24.833', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1344, 1057, NULL, '20130624 00:00:00.0', 3, 137, N'', '20130604 14:55:49.273', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1345, 1058, NULL, '20130624 00:00:00.0', 3, 305, N'', '20130604 15:43:16.333', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1346, 1059, NULL, '20130624 00:00:00.0', 3, 101, N'', '20130604 17:33:35.933', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1347, 1060, NULL, '20130626 00:00:00.0', 1, 89, N'ACA SE ESCRIBE ALGUNA NOTA RECORDATORIA, EJEMPLO:  "LLAMAR POR EMBARQUE DESDE BRASIL LISTO A FIN DE MES"', '20130605 13:48:21.737', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1348, NULL, NULL, '20130705 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130605 14:22:03.793', 5, 1, 386, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1349, NULL, NULL, '20130703 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130605 18:00:32.233', 5, 1, 387, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1350, 1061, NULL, '20130620 00:00:00.0', 3, 27, N'', '20130605 18:03:00.657', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1351, NULL, NULL, '20130630 00:00:00.0', 0, 219, N'Primera reunión de seguimiento', '20130605 18:21:02.890', 5, 1, 388, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1352, 1062, NULL, '20130617 00:00:00.0', 3, 43, N'', '20130605 18:32:21.737', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1353, 1063, NULL, '20130617 00:00:00.0', 3, 170, N'', '20130606 15:40:36.100', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1354, 1064, NULL, '20130617 00:00:00.0', 3, 82, N'', '20130606 16:19:32.857', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1355, 1065, NULL, '20130624 00:00:00.0', 3, 644, N'', '20130606 17:08:19.613', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1356, 1066, NULL, '99990101 00:00:00.0', 2, 62, N'', '20130607 07:53:25.017', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1357, 1067, NULL, '20130621 00:00:00.0', 2, 104, N'', '20130607 08:16:18.660', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1358, 1068, NULL, '20130621 00:00:00.0', 2, 44, N'', '20130607 08:34:51.837', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1359, 1069, NULL, '20130621 00:00:00.0', 2, 16, N'', '20130607 09:14:52.607', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1360, 1070, NULL, '20130630 00:00:00.0', 3, 2374, N'Visita de mantención', '20130610 15:23:04.867', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1361, 1071, NULL, '20130624 00:00:00.0', 3, 42, N'', '20130611 09:38:52.007', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1362, 1072, NULL, '20130624 00:00:00.0', 3, 56, N'', '20130611 10:14:07.620', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1363, 1073, NULL, '20130618 00:00:00.0', 1, 2913, N'', '20130611 15:39:05.750', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1364, 1074, NULL, '20130619 00:00:00.0', 2, 39, N'', '20130612 10:45:34.967', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1365, 1075, NULL, '20130619 00:00:00.0', 2, 14, N'', '20130612 11:19:05.647', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1366, 1076, NULL, '20130708 00:00:00.0', 3, 71, N'', '20130612 14:48:45.617', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1367, NULL, NULL, '20130630 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130612 15:50:24.217', 5, 1, 389, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1368, 1077, NULL, '20130627 00:00:00.0', NULL, 142, N'', '20130613 16:43:34.883', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1369, NULL, NULL, '20130704 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130613 16:34:16.157', 5, 1, 390, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1370, NULL, NULL, '20130704 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130613 16:36:32.443', 5, 1, 391, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1371, NULL, NULL, '20130704 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130613 16:43:01.327', 5, 1, 392, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1372, 1078, NULL, '20130618 00:00:00.0', 1, 2875, N'', '20130614 14:46:23.277', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1373, 1079, NULL, '20130625 00:00:00.0', 2, 4053, N'', '20130618 14:46:34.320', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1374, 1080, NULL, '20130702 00:00:00.0', NULL, 144, N'', '20130618 15:55:35.673', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1375, 1081, NULL, '20130702 00:00:00.0', NULL, 1566, N'', '20130618 16:16:46.700', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1376, 1082, NULL, '20130621 00:00:00.0', 1, 2327, N'', '20130618 17:44:42.510', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1377, 1083, NULL, '20130715 00:00:00.0', 3, 102, N'', '20130619 08:45:31.483', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1378, 1084, NULL, '20130723 00:00:00.0', 3, 154, N'', '20130619 08:49:18.457', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1379, 1085, NULL, '20130715 00:00:00.0', 3, 101, N'', '20130619 09:03:17.340', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1380, 1086, NULL, '20130715 00:00:00.0', 3, 54, N'', '20130619 09:16:54.103', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1381, 1087, NULL, '20130715 00:00:00.0', 3, 26, N'', '20130619 09:38:26.817', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1382, 1088, NULL, '20130708 00:00:00.0', 3, 63, N'', '20130619 13:49:17.897', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1383, 1089, NULL, '20130619 00:00:00.0', 1, 2874, N'', '20130619 13:49:19.923', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1384, 1090, NULL, '99990101 00:00:00.0', NULL, 47, N'', '20130619 13:51:15.903', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1385, 1091, NULL, '20130626 00:00:00.0', 2, 32, N'', '20130619 13:52:14.983', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1386, 1092, NULL, '20130715 00:00:00.0', 3, 176, N'', '20130619 13:58:11.260', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1387, 1093, NULL, '20130626 00:00:00.0', 1, 183, N'', '20130619 14:03:08.957', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1388, 1094, NULL, '20130715 00:00:00.0', 3, 18, N'', '20130619 14:04:13.710', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1389, 1095, NULL, '20130708 00:00:00.0', 3, 241, N'', '20130619 14:50:25.557', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1390, 1096, NULL, '20130630 00:00:00.0', 3, 2968, N'', '20130619 17:36:13.740', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1391, 1097, NULL, '20130630 00:00:00.0', 3, 2272, N'', '20130619 17:43:20.070', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1392, 1098, NULL, '20130630 00:00:00.0', 3, 3115, N'', '20130619 17:48:34.960', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1393, 1099, NULL, '20130715 00:00:00.0', 3, 47, N'', '20130619 19:08:10.640', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1394, 1100, NULL, '20130708 00:00:00.0', 3, 27, N'', '20130619 19:16:53.240', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1395, 1101, NULL, '20130708 00:00:00.0', 3, 8, N'', '20130619 19:27:33.713', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1396, 1102, NULL, '20130708 00:00:00.0', 3, 74, N'', '20130620 17:09:25.003', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1397, 1103, NULL, '20130624 00:00:00.0', 1, 2876, N'', '20130621 09:00:09.800', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1398, 1104, NULL, '20130701 00:00:00.0', 1, 3224, N'', '20130621 13:56:55.893', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1399, 1105, NULL, '20130715 00:00:00.0', 3, 25, N'', '20130621 14:21:59.213', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1400, 1106, NULL, '20130708 00:00:00.0', 3, 41, N'', '20130621 15:31:50.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1401, 1107, NULL, '20130624 00:00:00.0', NULL, 165, N'', '20130621 16:58:38.173', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1402, 1108, NULL, '20130624 00:00:00.0', NULL, 88, N'', '20130621 17:13:24.707', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1403, 1109, NULL, '20130625 00:00:00.0', 2, 45, N'', '20130624 10:17:21.727', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1404, 1110, NULL, '20130625 00:00:00.0', 2, 30, N'', '20130624 11:31:45.550', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1405, 1111, NULL, '20130701 00:00:00.0', 2, 31, N'', '20130624 13:03:08.127', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1406, 1112, NULL, '20130710 00:00:00.0', NULL, 49, N'', '20130625 15:50:08.237', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1407, 1113, NULL, '20130708 00:00:00.0', 3, 29, N'', '20130626 09:21:45.907', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1408, 1114, NULL, '20130715 00:00:00.0', 3, 136, N'', '20130626 09:56:12.537', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1409, 1115, NULL, '20130812 00:00:00.0', 3, 117, N'', '20130626 10:10:11.083', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1410, 1116, NULL, '20130715 00:00:00.0', 3, 341, N'', '20130626 10:22:06.627', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1411, 1117, NULL, '20130715 00:00:00.0', 3, 12, N'', '20130626 10:27:27.913', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1412, NULL, NULL, '20130725 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130626 10:48:02.927', 5, 1, 393, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1413, 1118, NULL, '20130709 00:00:00.0', 1, 2926, N'', '20130626 12:02:40.867', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1414, 1119, NULL, '20130715 00:00:00.0', 3, 2924, N'', '20130626 12:16:40.850', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1415, 1120, NULL, '20130726 00:00:00.0', NULL, 131, N'', '20130626 15:50:58.010', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1416, NULL, NULL, '20130727 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130627 09:27:19.207', 5, 1, 394, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1417, NULL, NULL, '20130704 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130627 12:23:17.430', 5, 1, 395, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1418, NULL, NULL, '20130704 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130627 13:20:26.727', 5, 1, 396, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1419, 1121, NULL, '20130715 00:00:00.0', 3, 1998, N'', '20130627 15:08:40.923', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1420, 1122, NULL, '20130715 00:00:00.0', 3, 5, N'', '20130627 15:28:01.277', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1421, 1123, NULL, '20130715 00:00:00.0', 3, 240, N'', '20130627 15:52:47.970', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1422, 1124, NULL, '20130715 00:00:00.0', 3, 85, N'', '20130627 16:12:19.843', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1423, 1125, NULL, '20130710 00:00:00.0', 3, 2908, N'', '20130628 09:04:41.493', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1424, 1126, NULL, '20130710 00:00:00.0', 1, 4033, N'', '20130628 09:07:37.410', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1425, 1127, NULL, '20130714 00:00:00.0', 3, 2374, N'', '20130628 11:54:50.030', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1426, 1128, NULL, '20130705 00:00:00.0', 3, 2968, N'', '20130628 12:34:24.067', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1427, NULL, NULL, '20130705 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130628 15:42:51.853', 5, 1, 397, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1428, 1129, NULL, '20130723 00:00:00.0', 2, 51, N'', '20130702 10:33:21.547', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1429, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130702 10:48:34.447', 5, 1, 398, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1430, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130702 10:53:27.193', 5, 1, 399, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1431, 1130, NULL, '20130723 00:00:00.0', 2, 35, N'', '20130702 10:59:40.197', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1432, 1131, NULL, '20130716 00:00:00.0', 2, 24, N'', '20130702 11:10:39.530', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1433, 1132, NULL, '20130716 00:00:00.0', 2, 3202, N'', '20130702 11:48:51.637', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1434, 1133, NULL, '20130716 00:00:00.0', 2, 11, N'', '20130702 12:13:49.463', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1435, 1134, NULL, '20130723 00:00:00.0', 3, 242, N'', '20130702 12:16:46.407', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1436, 1135, NULL, '20130716 00:00:00.0', 1, 30, N'', '20130702 12:28:55.473', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1437, 1136, NULL, '20130716 00:00:00.0', 2, 198, N'', '20130702 12:45:41.410', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1438, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130702 12:46:27.787', 5, 1, 400, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1439, 1137, NULL, '20130731 00:00:00.0', 1, 39, N'', '20130702 14:09:43.887', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1440, 1138, NULL, '20130716 00:00:00.0', 1, 45, N'', '20130702 14:33:09.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1441, 1139, NULL, '20130716 00:00:00.0', 2, 215, N'', '20130702 14:36:15.977', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1442, 1140, NULL, '20130716 00:00:00.0', 2, 57, N'', '20130702 14:53:16.773', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1443, 1141, NULL, '20130723 00:00:00.0', 2, 181, N'', '20130702 14:59:36.313', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1444, 1142, NULL, '20130716 00:00:00.0', 2, 151, N'', '20130702 15:09:27.590', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1445, 1143, NULL, '20130716 00:00:00.0', 2, 3964, N'', '20130702 15:30:31.180', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1446, 1144, NULL, '20130708 00:00:00.0', NULL, 203, N'', '20130702 16:33:17.987', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1447, 1145, NULL, '20130716 00:00:00.0', 2, 3, N'', '20130702 16:01:28.487', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1448, 1146, NULL, '20130716 00:00:00.0', 2, 46, N'', '20130702 16:05:27.590', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1449, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130703 15:51:09.967', 59, 1, 401, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1450, 1147, NULL, '20130722 00:00:00.0', 3, 63, N'', '20130703 18:49:01.083', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1451, 1148, NULL, '20130722 00:00:00.0', 3, 12, N'', '20130703 18:58:41.520', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1452, 1149, NULL, '20130722 00:00:00.0', 3, 43, N'', '20130703 19:21:01.687', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1453, 1150, NULL, '20130722 00:00:00.0', 3, 71, N'', '20130703 19:39:43.570', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1454, 1151, NULL, '20130731 00:00:00.0', 3, 3115, N'', '20130704 09:35:57.083', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1455, 1152, NULL, '20130715 00:00:00.0', NULL, 142, N'', '20130704 14:09:39.910', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1456, 1153, NULL, '20130729 00:00:00.0', NULL, 134, N'', '20130704 14:21:39.683', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1457, 1154, NULL, '20130717 00:00:00.0', NULL, 1758, N'', '20130704 15:02:17.230', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1458, 1155, NULL, '20130731 00:00:00.0', NULL, 150, N'', '20130704 16:17:23.130', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1459, 1156, NULL, '20130731 00:00:00.0', 3, 132, N'', '20130704 17:05:55.977', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1460, 1157, NULL, '20130807 00:00:00.0', 3, 2159, N'', '20130704 17:16:43.347', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1461, 1158, NULL, '20130731 00:00:00.0', 3, 191, N'', '20130704 17:29:24.350', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1462, 1159, NULL, '20130731 00:00:00.0', 3, 99, N'', '20130704 18:06:53.187', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1463, 1160, NULL, '20130711 00:00:00.0', 1, 183, N'', '20130708 12:06:14.383', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1464, 1161, NULL, '20130729 00:00:00.0', 3, 102, N'', '20130708 16:09:29.720', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1465, 1162, NULL, '20130729 00:00:00.0', 3, 101, N'', '20130708 17:22:56.603', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1466, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130709 09:44:50.677', 5, 1, 402, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1467, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130709 09:46:51.843', 5, 1, 403, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1468, 1163, NULL, '20130731 00:00:00.0', 3, 3671, N'', '20130709 12:01:50.243', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1469, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130709 12:09:23.940', 5, 1, 404, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1470, 1164, NULL, '20130731 00:00:00.0', 3, 3667, N'', '20130709 12:09:25.643', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1471, 1165, NULL, '20130725 00:00:00.0', 3, 3946, N'', '20130709 12:17:26.887', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1472, 1166, NULL, '20130729 00:00:00.0', 3, 56, N'', '20130709 13:59:23.933', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1473, 1167, NULL, '20130729 00:00:00.0', 3, 42, N'', '20130709 14:37:24.407', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1474, 1168, NULL, '20130723 00:00:00.0', NULL, 4163, N'', '20130709 16:12:01.063', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1475, 1169, NULL, '20130724 00:00:00.0', 1, 2908, N'', '20130710 10:23:56.773', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1476, 1170, NULL, '20130725 00:00:00.0', 3, 2874, N'', '20130710 10:27:54.057', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1477, 1171, NULL, '20130731 00:00:00.0', 3, 122, N'', '20130710 11:37:47.963', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1478, 1172, NULL, '20130722 00:00:00.0', 3, 1, N'', '20130712 11:55:21.170', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1479, 1173, NULL, '20130722 00:00:00.0', 3, 695, N'', '20130712 12:06:05.077', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1480, 1174, NULL, '20130722 00:00:00.0', 3, 105, N'', '20130712 15:44:43.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1481, 1175, NULL, '20130729 00:00:00.0', 3, 27, N'', '20130712 15:53:07.593', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1482, 1176, NULL, '20130729 00:00:00.0', 3, 26, N'', '20130712 15:59:17.543', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1483, 1177, NULL, '20130729 00:00:00.0', 3, 43, N'', '20130712 16:03:46.720', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1484, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130715 10:11:50.800', 5, 1, 405, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1485, 1178, NULL, '20130718 00:00:00.0', 2, 2924, N'', '20130717 10:34:28.270', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1486, 1179, NULL, '20130729 00:00:00.0', 3, 56, N'', '20130717 10:47:19.290', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1487, 1180, NULL, '20130729 00:00:00.0', 3, 4201, N'', '20130717 11:30:40.007', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1488, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130717 11:46:51.463', 5, 1, 406, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1489, 1181, NULL, '20130730 00:00:00.0', 3, 3243, N'', '20130717 15:12:54.937', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1490, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130717 16:59:40.153', 5, 1, 407, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1491, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130718 14:44:44.543', 5, 1, 408, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1492, 1182, NULL, '20130724 00:00:00.0', NULL, 75, N'', '20130718 16:10:10.787', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1493, 1183, NULL, '20130729 00:00:00.0', 3, 22, N'', '20130718 17:10:33.497', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1494, 1184, NULL, '20130729 00:00:00.0', 3, 8, N'', '20130718 17:23:34.260', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1495, NULL, NULL, '20130725 00:00:00.0', 0, 22, N'Primera reunión de seguimiento', '20130718 18:57:01.317', 4, 1, 409, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1496, NULL, NULL, '20130729 00:00:00.0', 0, 87, N'Primera reunión de seguimiento', '20130722 10:43:31.513', 4, 1, 410, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1497, 1185, NULL, '20130812 00:00:00.0', 3, 29, N'', '20130722 11:27:43.180', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1498, 1186, NULL, '20130725 00:00:00.0', NULL, 160, N'', '20130722 15:30:51.220', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1499, 1187, NULL, '20130731 00:00:00.0', 1, 2875, N'', '20130724 11:16:07.837', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1500, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130724 15:09:36.447', 5, 1, 411, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1501, 1188, NULL, '20130805 00:00:00.0', 3, 3767, N'', '20130724 16:18:12.423', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1502, 1189, NULL, '20130812 00:00:00.0', 3, 3768, N'', '20130724 16:22:51.310', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1503, 1190, NULL, '20130812 00:00:00.0', 3, 154, N'', '20130724 16:30:56.473', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1504, 1191, NULL, '20130812 00:00:00.0', 3, 101, N'', '20130724 16:56:26.413', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1505, NULL, NULL, '20130731 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130724 17:45:25.797', 5, 1, 412, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1506, 1192, NULL, '20130812 00:00:00.0', 3, 80, N'', '20130725 17:20:46.853', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1507, 1193, NULL, '20130812 00:00:00.0', 3, 60, N'', '20130725 19:23:01.0', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1508, 1194, NULL, '20130812 00:00:00.0', 3, 1227, N'', '20130725 19:45:53.463', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1509, 1195, NULL, '20130801 00:00:00.0', 2, 40, N'', '20130725 22:14:41.690', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1510, 1196, NULL, '20130801 00:00:00.0', 1, 198, N'', '20130725 22:36:19.233', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1511, 1197, NULL, '20130801 00:00:00.0', 2, 106, N'', '20130725 23:14:05.147', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1512, 1198, NULL, '20130801 00:00:00.0', 1, 578, N'', '20130725 23:46:00.580', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1513, NULL, NULL, '20130802 00:00:00.0', 0, 66, N'Primera reunión de seguimiento', '20130726 12:29:06.100', 4, 1, 413, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1514, 1199, NULL, '20130802 00:00:00.0', 2, 4308, N'', '20130726 16:02:02.250', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1515, 1200, NULL, '20130805 00:00:00.0', 2, 583, N'', '20130729 12:37:40.217', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1516, 1201, NULL, '20130805 00:00:00.0', 2, 4310, N'', '20130729 12:55:16.483', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1517, 1202, NULL, '20130805 00:00:00.0', 2, 3964, N'', '20130729 12:58:33.223', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1518, 1203, NULL, '20130805 00:00:00.0', 2, 258, N'', '20130729 13:14:55.240', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1519, 1204, NULL, '20130805 00:00:00.0', 2, 4302, N'', '20130729 14:16:44.053', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1520, 1205, NULL, '20130805 00:00:00.0', 2, 14, N'', '20130729 14:41:28.310', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1521, NULL, NULL, '20130814 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130729 15:16:21.110', 5, 1, 414, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1522, 1206, NULL, '20130805 00:00:00.0', 2, 4309, N'', '20130729 16:22:37.607', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1523, 1207, NULL, '20130805 00:00:00.0', 2, 219, N'', '20130729 17:09:51.040', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1524, 1208, NULL, '20130805 00:00:00.0', 2, 3, N'', '20130729 17:18:38.400', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1525, 1209, NULL, '20130805 00:00:00.0', 2, 38, N'', '20130729 17:38:20.717', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1526, 1210, NULL, '20130805 00:00:00.0', 2, 1887, N'', '20130729 17:54:30.130', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1527, 1211, NULL, '20130805 00:00:00.0', 2, 24, N'', '20130729 18:22:54.797', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1528, 1212, NULL, '20130805 00:00:00.0', 2, 219, N'', '20130729 18:33:37.213', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1529, 1213, NULL, '20130807 00:00:00.0', 1, 2883, N'', '20130731 09:27:06.957', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1530, 1214, NULL, '20130802 00:00:00.0', NULL, 49, N'', '20130731 09:42:56.217', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1531, 1215, NULL, '99990115 00:00:00.0', 2, 30, N'', '20130731 17:42:25.423', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1532, 1216, NULL, '20130807 00:00:00.0', 2, 37, N'', '20130731 18:05:48.743', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1533, 1217, NULL, '20130807 00:00:00.0', 2, 319, N'', '20130731 18:10:48.080', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1534, 1218, NULL, '20130807 00:00:00.0', 2, 45, N'', '20130731 18:16:18.460', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1535, NULL, NULL, '20130814 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20130731 19:00:16.977', 5, 1, 415, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1536, 1219, NULL, '20130821 00:00:00.0', 1, 4144, N'', '20130801 09:24:56.050', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1537, 1220, NULL, '20130821 00:00:00.0', 1, 189, N'', '20130801 09:32:20.347', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1538, 1221, NULL, '20130814 00:00:00.0', 1, 4062, N'', '20130801 09:39:50.223', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1539, 1222, NULL, '20130815 00:00:00.0', 2, 86, N'', '20130801 15:40:49.093', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1540, 1223, NULL, '20130819 00:00:00.0', 3, 18, N'', '20130802 12:51:46.397', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1541, 1224, NULL, '20130819 00:00:00.0', 3, 71, N'', '20130802 14:10:34.427', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1542, 1225, NULL, '20130819 00:00:00.0', 3, 52, N'', '20130802 14:27:50.830', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1543, 1226, NULL, '20130819 00:00:00.0', 3, 42, N'', '20130802 15:06:31.813', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1544, 1227, NULL, '20130819 00:00:00.0', 3, 81, N'', '20130802 15:20:20.683', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1545, 1228, NULL, '20130821 00:00:00.0', 1, 2875, N'', '20130802 15:33:39.030', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1546, 1229, NULL, '20130819 00:00:00.0', 3, 1, N'', '20130802 15:37:15.390', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1547, 1230, NULL, '20130821 00:00:00.0', 3, 2874, N'', '20130802 15:42:28.137', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1548, 1231, NULL, '20130828 00:00:00.0', 3, 2908, N'', '20130802 15:48:13.503', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1549, 1232, NULL, '20130807 00:00:00.0', NULL, 142, N'', '20130806 11:05:25.580', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1550, 1233, NULL, '20130831 00:00:00.0', 3, 3115, N'', '20130806 12:04:48.063', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1551, 1234, NULL, '20130821 00:00:00.0', 1, 2913, N'', '20130806 16:27:16.330', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1552, 1235, NULL, '20130819 00:00:00.0', 3, 56, N'', '20130807 09:10:28.743', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1553, 1236, NULL, '20130819 00:00:00.0', 3, 47, N'', '20130807 12:18:00.580', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1554, 1237, NULL, '20130819 00:00:00.0', 3, 241, N'', '20130807 12:39:28.680', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1555, 1238, NULL, '20130819 00:00:00.0', 3, 43, N'', '20130807 12:50:12.007', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1556, 1239, NULL, '20130819 00:00:00.0', 3, 60, N'', '20130807 13:19:06.323', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1557, 1240, NULL, '20130823 00:00:00.0', 2, 583, N'', '20130809 10:08:40.380', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1558, 1241, NULL, '20130823 00:00:00.0', 2, 319, N'', '20130809 11:20:16.320', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1559, 1242, NULL, '20130828 00:00:00.0', 3, 245, N'', '20130809 11:33:18.973', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1560, 1243, NULL, '20130823 00:00:00.0', NULL, 38, N'', '20130809 11:42:01.100', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1561, 1244, NULL, '20130830 00:00:00.0', 3, 3671, N'', '20130809 11:42:35.800', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1562, 1245, NULL, '20130818 00:00:00.0', 3, 122, N'', '20130809 11:57:19.643', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1563, 1246, NULL, '20130822 00:00:00.0', 2, 3345, N'', '20130809 12:02:08.820', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1564, 1247, NULL, '20130826 00:00:00.0', 3, 102, N'', '20130809 14:46:37.140', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1565, 1248, NULL, '20130826 00:00:00.0', 3, 137, N'', '20130809 14:57:58.693', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1566, 1249, NULL, '20130813 00:00:00.0', 3, 101, N'', '20130809 15:02:00.787', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1567, 1250, NULL, '20130816 00:00:00.0', 2, 46, N'', '20130809 15:12:38.480', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1568, 1251, NULL, '20130826 00:00:00.0', 3, 2005, N'', '20130809 15:46:58.507', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1569, 1252, NULL, '20130828 00:00:00.0', 3, 3802, N'', '20130809 15:56:51.883', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1570, 1253, NULL, '20130827 00:00:00.0', 2, 31, N'', '20130812 09:23:41.687', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1571, NULL, NULL, '20130820 00:00:00.0', 0, 0, N'Primera reunión de seguimiento', '20130813 09:00:43.453', 4, 1, NULL, 32, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1572, 1254, NULL, '20130820 00:00:00.0', 1, 2926, N'', '20130813 09:27:33.767', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1573, 1255, NULL, '20130819 00:00:00.0', NULL, 257, N'', '20130813 13:36:13.540', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1574, 1256, NULL, '20130819 00:00:00.0', NULL, 236, N'', '20130813 13:43:12.553', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1575, 1257, NULL, '20130826 00:00:00.0', 3, 63, N'', '20130814 09:19:16.130', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1576, 1258, NULL, '20130826 00:00:00.0', 3, 29, N'', '20130814 09:35:01.113', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1577, 1259, NULL, '20130826 00:00:00.0', 3, 101, N'', '20130814 09:55:31.100', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1578, 1260, NULL, '20130828 00:00:00.0', 2, 2941, N'', '20130814 14:50:29.030', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1579, 1261, NULL, '20130826 00:00:00.0', 3, 56, N'', '20130814 15:34:51.210', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1580, 1262, NULL, '20130826 00:00:00.0', 3, 108, N'', '20130814 15:50:20.740', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1581, 1263, NULL, '20130830 00:00:00.0', 1, 35, N'', '20130816 09:37:51.343', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1582, 1264, NULL, '20130823 00:00:00.0', 2, 24, N'', '20130816 09:54:56.140', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1583, 1265, NULL, '20130823 00:00:00.0', NULL, 30, N'', '20130816 14:45:40.050', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1584, 1266, NULL, '20130823 00:00:00.0', 1, 4446, N'', '20130816 15:50:01.963', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1585, 1267, NULL, '20130826 00:00:00.0', NULL, 88, N'', '20130819 08:43:30.017', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1586, 1268, NULL, '20130826 00:00:00.0', NULL, 135, N'', '20130819 08:46:49.450', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1587, 1269, NULL, '20130826 00:00:00.0', NULL, 209, N'', '20130819 08:52:51.617', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1588, 1270, NULL, '20130831 00:00:00.0', 3, 1269, N'', '20130819 12:28:26.537', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1589, 1271, NULL, '20130828 00:00:00.0', 1, 2907, N'', '20130820 15:14:27.463', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1590, 1272, NULL, '20130831 00:00:00.0', 1, 3369, N'', '20130820 15:21:20.507', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1591, 1273, NULL, '20130909 00:00:00.0', 3, 26, N'', '20130821 12:12:45.067', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1592, 1274, NULL, '20130909 00:00:00.0', 3, 1998, N'', '20130821 12:22:51.643', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1593, 1275, NULL, '20130916 00:00:00.0', 3, 27, N'', '20130821 12:33:39.673', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1594, 1276, NULL, '20130822 00:00:00.0', NULL, 49, N'', '20130821 14:14:14.520', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1595, 1277, NULL, '20130823 00:00:00.0', NULL, 160, N'', '20130821 14:20:36.053', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1596, 1278, NULL, '20130909 00:00:00.0', 3, 161, N'', '20130822 14:25:17.657', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1597, 1279, NULL, '20130823 00:00:00.0', NULL, 68, N'', '20130822 15:00:01.273', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1598, 1280, NULL, '20130827 00:00:00.0', NULL, 165, N'', '20130822 15:04:11.773', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1599, 1281, NULL, '20130829 00:00:00.0', NULL, 144, N'', '20130822 15:08:35.243', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1600, 1282, NULL, '20130903 00:00:00.0', NULL, 134, N'', '20130822 15:17:49.163', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1601, 1283, NULL, '20130826 00:00:00.0', NULL, 4483, N'', '20130822 15:28:53.180', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1602, 1284, NULL, '20130826 00:00:00.0', 3, 42, N'', '20130823 09:22:58.377', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1603, 1285, NULL, '20130910 00:00:00.0', 3, 2908, N'', '20130823 10:38:53.200', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1604, 1286, NULL, '20130902 00:00:00.0', 3, 3768, N'', '20130823 14:59:37.383', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1605, 1287, NULL, '20130831 00:00:00.0', 1, 3774, N'', '20130823 15:29:47.710', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1606, 1288, NULL, '20130831 00:00:00.0', 3, 2272, N'', '20130823 15:42:37.097', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1607, 1289, NULL, '20130909 00:00:00.0', 3, 71, N'', '20130823 16:14:11.767', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1608, 1290, NULL, '20130904 00:00:00.0', NULL, 110, N'', '20130826 12:37:26.973', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1609, 1291, NULL, '20130906 00:00:00.0', NULL, 65, N'', '20130826 12:42:32.403', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1610, 1292, NULL, '20130909 00:00:00.0', 3, 102, N'', '20130826 14:32:00.050', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1611, 1293, NULL, '20130923 00:00:00.0', 3, 4506, N'', '20130826 16:35:23.310', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1612, 1294, NULL, '20130909 00:00:00.0', 3, 47, N'', '20130828 14:37:33.410', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1613, 1295, NULL, '20130905 00:00:00.0', NULL, 225, N'', '20130828 14:50:40.187', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1614, 1296, NULL, '20130909 00:00:00.0', 3, 1, N'', '20130828 15:19:18.607', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1615, 1297, NULL, '20130909 00:00:00.0', 3, 41, N'', '20130830 11:40:01.063', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1616, 1298, NULL, '20130909 00:00:00.0', 3, 56, N'', '20130830 12:04:36.220', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1617, 1299, NULL, '20130909 00:00:00.0', 3, 240, N'', '20130830 12:16:44.673', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1618, 1300, NULL, '20130923 00:00:00.0', 3, 644, N'', '20130830 14:39:22.797', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1619, 1301, NULL, '20130909 00:00:00.0', 3, 170, N'', '20130830 14:48:10.450', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1620, 1302, NULL, '20130924 00:00:00.0', 3, 2374, N'', '20130902 11:29:58.887', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1621, 1303, NULL, '20130930 00:00:00.0', 3, 4333, N'', '20130902 11:35:50.890', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1622, 1304, NULL, '20130912 00:00:00.0', 3, 2874, N'', '20130903 15:01:35.700', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1623, 1305, NULL, '20130923 00:00:00.0', 3, 8, N'', '20130903 15:23:50.717', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1624, 1306, NULL, '20130918 00:00:00.0', 3, 2875, N'', '20130903 15:33:08.573', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1625, 1307, NULL, '20130930 00:00:00.0', 3, 305, N'', '20130903 17:03:37.910', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1626, 1308, NULL, '20130930 00:00:00.0', NULL, 210, N'', '20130904 11:08:18.587', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1627, 1309, NULL, '20130930 00:00:00.0', 3, 29, N'', '20130905 15:31:23.293', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1628, 1310, NULL, '20130923 00:00:00.0', 1, 241, N'', '20130905 16:51:54.857', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1629, 1311, NULL, '20130906 00:00:00.0', NULL, 75, N'', '20130906 16:23:37.463', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1630, 1312, NULL, '20131003 00:00:00.0', NULL, 131, N'', '20130906 16:31:42.703', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1631, 1313, NULL, '20130915 00:00:00.0', NULL, 4560, N'', '20130909 14:58:16.307', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1632, 1314, NULL, '20130925 00:00:00.0', NULL, 78, N'', '20130911 16:23:34.473', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1633, 1315, NULL, '20130930 00:00:00.0', 3, 894, N'', '20130913 11:51:29.987', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1634, 1316, NULL, '20130923 00:00:00.0', 3, 42, N'', '20130913 15:14:10.773', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1635, 1317, NULL, '20130923 00:00:00.0', 3, 71, N'', '20130913 15:26:50.543', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1636, 1318, NULL, '20130923 00:00:00.0', 3, 12, N'', '20130913 15:32:39.127', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1637, 1319, NULL, '20131007 00:00:00.0', 1, 2874, N'', '20130916 11:40:43.990', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1638, 1320, NULL, '99990101 00:00:00.0', 3, 46, N'', '20130916 13:04:46.630', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1639, 1321, NULL, '20130925 00:00:00.0', 1, 2876, N'', '20130923 10:50:49.420', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1640, 1322, NULL, '20130925 00:00:00.0', 1, 83, N'', '20130923 11:00:13.223', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1641, 1323, NULL, '20130926 00:00:00.0', 1, 4310, N'', '20130923 11:34:40.030', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1642, 1324, NULL, '20130924 00:00:00.0', 1, 45, N'', '20130923 12:54:21.270', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1643, 1325, NULL, '20130924 00:00:00.0', 2, 4308, N'', '20130923 13:04:38.103', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1644, 1326, NULL, '20131008 00:00:00.0', 1, 3369, N'', '20130924 14:31:43.223', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1645, 1327, NULL, '20131007 00:00:00.0', 3, 102, N'', '20130924 15:18:20.460', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1646, 1328, NULL, '20131014 00:00:00.0', 3, 74, N'', '20130924 15:39:33.233', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1647, 1329, NULL, '99990101 00:00:00.0', NULL, 44, N'', '20130924 16:15:39.877', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1648, 1330, NULL, '20131003 00:00:00.0', 2, 3358, N'', '20130925 10:27:02.907', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1649, 1331, NULL, '20131014 00:00:00.0', 3, 54, N'', '20130925 14:42:06.563', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1650, 1332, NULL, '20131008 00:00:00.0', NULL, 165, N'', '20130925 14:17:38.313', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1651, 1333, NULL, '20131014 00:00:00.0', 3, 3519, N'', '20130926 14:27:58.487', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1652, 1334, NULL, '20131015 00:00:00.0', NULL, 134, N'', '20130926 17:43:15.147', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1653, 1335, NULL, '20131009 00:00:00.0', 3, 3767, N'', '20130927 16:38:14.833', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1654, 1336, NULL, '20131021 00:00:00.0', 3, 26, N'', '20130927 16:45:06.627', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1655, 1337, NULL, '20131021 00:00:00.0', 3, 8, N'', '20130927 16:48:07.877', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1656, 1338, NULL, '20131021 00:00:00.0', 3, 22, N'', '20130927 16:53:26.547', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1657, 1339, NULL, '20131021 00:00:00.0', 3, 4586, N'', '20130927 17:04:04.290', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1658, 1340, NULL, '20131002 00:00:00.0', NULL, 142, N'', '20130927 17:06:54.887', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1659, 1341, NULL, '20131002 00:00:00.0', NULL, 88, N'', '20130927 17:12:31.600', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1660, 1342, NULL, '20130930 00:00:00.0', 2, 14, N'', '20130929 14:32:17.940', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1661, 1343, NULL, '20131001 00:00:00.0', 2, 1887, N'', '20130930 09:10:12.140', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1662, 1344, NULL, '20131003 00:00:00.0', 2, 16, N'', '20130930 09:21:07.630', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1663, 1345, NULL, '20131003 00:00:00.0', 1, 104, N'', '20130930 09:26:22.120', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1664, 1346, NULL, '20131005 00:00:00.0', 2, 37, N'', '20130930 09:32:02.203', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1665, 1347, NULL, '20131003 00:00:00.0', 2, 39, N'', '20130930 09:51:01.863', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1666, 1348, NULL, '20131015 00:00:00.0', 3, 3946, N'', '20130930 08:59:50.727', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1667, 1349, NULL, '20131004 00:00:00.0', 2, 45, N'', '20130930 10:15:07.143', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1668, 1350, NULL, '20131005 00:00:00.0', 2, 3, N'', '20130930 11:55:44.693', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1669, 1351, NULL, '20131004 00:00:00.0', 2, 46, N'', '20130930 15:57:08.260', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1670, 1352, NULL, '20131001 00:00:00.0', 2, 44, N'', '20130930 16:43:39.250', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1671, 1353, NULL, '20131015 00:00:00.0', 3, 183, N'', '20131001 09:36:11.807', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1672, 1354, NULL, '20131008 00:00:00.0', 1, 2881, N'', '20131001 09:38:47.980', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1673, 1355, NULL, '20131014 00:00:00.0', 1, 2374, N'', '20131002 11:54:11.400', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1674, 1356, NULL, '20131031 00:00:00.0', 1, 2327, N'', '20131002 16:37:54.903', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1675, 1357, NULL, '20131030 00:00:00.0', 3, 4702, N'', '20131003 09:23:50.887', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1676, 1358, NULL, '20131111 00:00:00.0', 1, 2913, N'', '20131003 09:29:01.037', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1677, 1359, NULL, '20131104 00:00:00.0', 3, 2876, N'', '20131003 09:44:19.290', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1678, 1360, NULL, '20131106 00:00:00.0', 2, 1368, N'', '20131003 12:54:15.807', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1679, 1361, NULL, '20131007 00:00:00.0', NULL, 4163, N'', '20131003 14:31:05.773', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1680, 1362, NULL, '20131009 00:00:00.0', NULL, 4560, N'', '20131003 14:41:44.147', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1681, 1363, NULL, '20131008 00:00:00.0', NULL, 209, N'', '20131004 10:45:26.147', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1682, 1364, NULL, '20131008 00:00:00.0', NULL, 160, N'', '20131004 10:54:13.677', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1683, 1365, NULL, '20131018 00:00:00.0', NULL, 130, N'', '20131004 11:13:14.0', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1684, 1366, NULL, '20131007 00:00:00.0', NULL, 4280, N'', '20131004 11:32:10.997', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1685, 1367, NULL, '20131007 00:00:00.0', NULL, 4705, N'', '20131004 11:47:49.690', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1686, 1368, NULL, '20131025 00:00:00.0', 2, 31, N'', '20131004 12:09:38.727', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1687, 1369, NULL, '20131018 00:00:00.0', 2, 28, N'', '20131004 12:27:58.493', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1688, 1370, NULL, '20131025 00:00:00.0', 2, 3802, N'', '20131004 12:34:01.027', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1689, 1371, NULL, '20131025 00:00:00.0', 2, 3803, N'', '20131004 12:37:35.997', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1690, 1372, NULL, '20131025 00:00:00.0', 2, 32, N'', '20131004 12:49:28.880', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1691, 1373, NULL, '20131025 00:00:00.0', 1, 51, N'', '20131004 14:40:26.610', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1692, 1374, NULL, '20131025 00:00:00.0', NULL, 24, N'', '20131004 14:46:12.430', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1693, 1375, NULL, '20131022 00:00:00.0', 1, 2907, N'', '20131008 15:57:33.097', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1694, 1376, NULL, '20131022 00:00:00.0', 1, 3137, N'', '20131008 17:18:58.193', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1695, 1377, NULL, '20131029 00:00:00.0', 3, 2875, N'', '20131008 17:22:40.483', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1696, 1378, NULL, '20131028 00:00:00.0', 1, 2272, N'', '20131009 09:06:29.373', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1697, 1379, NULL, '20131029 00:00:00.0', 2, 3115, N'', '20131009 10:02:09.670', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1698, 1380, NULL, '20131028 00:00:00.0', 3, 47, N'', '20131009 14:07:32.583', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1699, 1381, NULL, '20131028 00:00:00.0', 3, 241, N'', '20131009 14:38:49.497', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1700, 1382, NULL, '20131106 00:00:00.0', 3, 27, N'Verificar resumen de cargas cerradas a la fecha', '20131009 14:54:51.213', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1701, 1383, NULL, '20131028 00:00:00.0', 3, 176, N'', '20131009 15:06:02.530', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1702, 1384, NULL, '20131028 00:00:00.0', 3, 1, N'', '20131009 15:17:52.903', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1703, 1385, NULL, '20131028 00:00:00.0', 3, 71, N'', '20131009 15:37:38.077', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1704, 1386, NULL, '20131014 00:00:00.0', NULL, 2159, N'', '20131009 15:52:34.557', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1705, 1387, NULL, '20131013 00:00:00.0', NULL, 257, N'', '20131009 15:59:47.560', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1706, 1388, NULL, '20131127 00:00:00.0', 3, 4033, N'', '20131010 10:39:15.167', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1707, 1389, NULL, '20131015 00:00:00.0', NULL, 225, N'', '20131010 14:19:17.410', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1708, 1390, NULL, '20131021 00:00:00.0', NULL, 203, N'', '20131010 14:25:00.180', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1709, 1391, NULL, '20131031 00:00:00.0', NULL, 1758, N'', '20131010 14:31:16.253', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1710, 1392, NULL, '20131029 00:00:00.0', NULL, 1994, N'', '20131010 15:12:26.667', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1711, 1393, NULL, '20131031 00:00:00.0', 3, 3243, N'', '20131010 14:16:37.890', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1712, 1394, NULL, '20131030 00:00:00.0', NULL, 4483, N'', '20131010 15:24:08.823', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1713, 1395, NULL, '20131030 00:00:00.0', NULL, 144, N'', '20131010 15:30:00.963', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1714, 1396, NULL, '20131028 00:00:00.0', 3, 27, N'', '20131011 09:42:00.663', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1715, 1397, NULL, '20131028 00:00:00.0', 3, 240, N'', '20131011 09:55:37.150', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1716, 1398, NULL, '20131028 00:00:00.0', 3, 85, N'', '20131011 10:06:51.720', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1717, 1399, NULL, '20131028 00:00:00.0', 3, 644, N'', '20131011 10:19:25.930', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1718, 1400, NULL, '20131028 00:00:00.0', 3, 170, N'', '20131011 10:28:37.373', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1719, 1401, NULL, '20131028 00:00:00.0', 3, 1227, N'', '20131011 10:32:56.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1720, 1402, NULL, '20131115 00:00:00.0', 3, 2874, N'', '20131011 13:02:19.653', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1721, 1403, NULL, '20131025 00:00:00.0', 1, 33, N'', '20131011 14:39:51.463', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1722, 1404, NULL, '20131021 00:00:00.0', NULL, 65, N'', '20131011 14:39:51.910', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1723, 1405, NULL, '20131102 00:00:00.0', 1, 13, N'', '20131011 14:50:52.703', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1724, 1406, NULL, '20131025 00:00:00.0', 2, 30, N'', '20131011 15:00:56.820', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1725, 1407, NULL, '20131031 00:00:00.0', 3, 2599, N'', '20131011 14:06:00.813', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1726, 1408, NULL, '20131025 00:00:00.0', 2, 3166, N'', '20131011 15:07:53.127', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1727, 1409, NULL, '20131018 00:00:00.0', 1, 220, N'', '20131011 15:11:36.117', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1728, 1410, NULL, '20131025 00:00:00.0', 1, 219, N'', '20131011 15:37:28.850', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1729, 1411, NULL, '20131025 00:00:00.0', 2, 4751, N'', '20131011 15:48:05.737', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1730, 1412, NULL, '20131018 00:00:00.0', 1, 1519, N'', '20131011 15:58:00.383', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1731, 1413, NULL, '20131018 00:00:00.0', 2, 227, N'', '20131011 16:02:54.147', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1732, 1414, NULL, '20131025 00:00:00.0', 1, 3735, N'', '20131011 16:08:15.610', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1733, 1415, NULL, '20131025 00:00:00.0', 2, 181, N'', '20131011 16:10:42.600', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1734, 1416, NULL, '20131018 00:00:00.0', 2, 86, N'', '20131011 16:14:50.993', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1735, 1417, NULL, '20131025 00:00:00.0', 1, 3964, N'', '20131011 16:19:36.170', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1736, 1418, NULL, '20131108 00:00:00.0', 1, 2656, N'', '20131014 09:19:04.703', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1737, 1419, NULL, '20131111 00:00:00.0', NULL, 2839, N'', '20131014 09:29:56.697', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1738, 1420, NULL, '20131111 00:00:00.0', NULL, 2548, N'', '20131014 09:51:36.430', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1739, 1421, NULL, '20131112 00:00:00.0', NULL, 85, N'', '20131014 10:22:11.197', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1740, 1422, NULL, '20131112 00:00:00.0', NULL, 39, N'', '20131014 10:48:08.083', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1741, 1423, NULL, '20131022 00:00:00.0', 1, 240, N'', '20131014 11:02:28.877', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1742, 1424, NULL, '20131112 00:00:00.0', 1, 55, N'', '20131014 12:00:52.300', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1743, 1425, NULL, '20131104 00:00:00.0', 3, 102, N'', '20131015 09:44:57.553', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1744, 1426, NULL, '20131104 00:00:00.0', 3, 108, N'', '20131015 14:40:51.520', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1745, 1427, NULL, '20131104 00:00:00.0', 3, 1, N'', '20131015 14:56:11.903', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1746, 1428, NULL, '20131111 00:00:00.0', 3, 2875, N'', '20131015 15:14:35.570', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1747, 1429, NULL, '20131119 00:00:00.0', 3, 3670, N'', '20131016 11:51:07.910', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1748, 1430, NULL, '20131119 00:00:00.0', 3, 2941, N'', '20131016 11:58:27.237', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1749, 1431, NULL, '20131031 00:00:00.0', 3, 208, N'', '20131016 16:43:15.950', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1750, 1432, NULL, '20131030 00:00:00.0', 3, 201, N'', '20131016 17:03:06.320', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1751, 1433, NULL, '20131104 00:00:00.0', 3, 56, N'', '20131016 17:21:59.490', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1752, 1434, NULL, '20131104 00:00:00.0', 3, 12, N'', '20131016 17:46:48.367', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1753, 1435, NULL, '20131031 00:00:00.0', 2, 215, N'', '20131017 08:59:11.640', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1754, 1436, NULL, '20131031 00:00:00.0', 3, 122, N'', '20131017 16:56:31.493', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1755, 1437, NULL, '20131030 00:00:00.0', 3, 2272, N'Retiro de pagos', '20131017 17:36:04.453', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1756, 1438, NULL, '20131022 00:00:00.0', NULL, 135, N'', '20131017 18:05:24.453', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1757, 1439, NULL, '20131018 00:00:00.0', NULL, 142, N'', '20131017 18:18:39.963', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1758, 1440, NULL, '20131104 00:00:00.0', 3, 43, N'', '20131018 11:36:03.103', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1759, 1441, NULL, '20131104 00:00:00.0', 3, 29, N'', '20131018 14:44:26.620', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1760, 1442, NULL, '20131111 00:00:00.0', 3, 1998, N'', '20131018 15:53:39.623', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1761, 1443, NULL, '99990101 00:00:00.0', -1, 37, N'', '20131020 23:16:40.333', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1762, 1444, NULL, '20131029 00:00:00.0', 1, 35, N'', '20131021 09:19:04.273', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1763, 1445, NULL, '20131111 00:00:00.0', 3, 136, N'', '20131021 17:27:37.223', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1764, 1446, NULL, '20131028 00:00:00.0', 3, 44, N'', '20131021 21:08:12.260', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1765, 1447, NULL, '20131030 00:00:00.0', NULL, 3803, N'', '20131021 21:28:04.617', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1766, 1448, NULL, '20131029 00:00:00.0', 2, 3803, N'', '20131021 21:31:56.807', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1767, 1449, NULL, '20131029 00:00:00.0', 2, 220, N'', '20131021 21:49:57.603', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1768, 1450, NULL, '20131030 00:00:00.0', 1, 3202, N'', '20131021 22:39:18.893', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1769, 1451, NULL, '20131105 00:00:00.0', 2, 319, N'', '20131021 22:47:28.830', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1770, 1452, NULL, '20131030 00:00:00.0', 2, 439, N'', '20131021 23:06:25.450', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1771, 1453, NULL, '20131120 00:00:00.0', 2, 16, N'', '20131022 08:22:12.850', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1772, 1454, NULL, '20131111 00:00:00.0', 3, 163, N'', '20131022 08:59:40.790', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1773, 1455, NULL, '20131104 00:00:00.0', 3, 4791, N'', '20131022 09:20:38.650', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1774, 1456, NULL, '20131111 00:00:00.0', 3, 3790, N'', '20131023 09:30:27.200', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1775, 1457, NULL, '20131113 00:00:00.0', 3, 2908, N'', '20131023 10:19:34.847', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1776, 1458, NULL, '20131111 00:00:00.0', 3, 8, N'', '20131023 15:36:51.980', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1777, 1459, NULL, '20131111 00:00:00.0', 3, 41, N'', '20131023 15:50:28.653', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1778, 1460, NULL, '20131111 00:00:00.0', 3, 678, N'', '20131023 15:58:03.277', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1779, 1461, NULL, '20131111 00:00:00.0', 3, 4800, N'', '20131023 16:31:57.933', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1780, 1462, NULL, '20131030 00:00:00.0', 1, 198, N'', '20131023 19:44:01.477', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1781, 1463, NULL, '20131030 00:00:00.0', 1, 66, N'', '20131023 20:05:24.270', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1782, 1465, NULL, '20131030 00:00:00.0', 2, 4801, N'', '20131023 23:50:01.550', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1783, 1466, NULL, '20131126 00:00:00.0', 3, 83, N'', '20131024 17:20:53.550', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1784, 1467, NULL, '20131120 00:00:00.0', 3, 2874, N'', '20131024 17:22:45.897', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1785, 1468, NULL, '20131111 00:00:00.0', 3, 695, N'', '20131025 14:35:04.703', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1786, 1469, NULL, '20131111 00:00:00.0', 3, 52, N'', '20131025 14:47:01.537', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1787, 1470, NULL, '20131112 00:00:00.0', 3, 90, N'', '20131025 15:14:08.313', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1788, 1471, NULL, '20131110 00:00:00.0', 3, 50, N'', '20131025 16:15:06.500', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1789, 1472, NULL, '20131030 00:00:00.0', 3, 4333, N'', '20131025 16:25:39.230', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1790, 1473, NULL, '20131029 00:00:00.0', NULL, 4678, N'', '20131025 16:40:05.297', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1791, 1474, NULL, '20131027 00:00:00.0', NULL, 4774, N'', '20131025 17:04:06.087', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1792, 1475, NULL, '20131105 00:00:00.0', 2, 245, N'', '20131028 11:11:15.627', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1793, 1476, NULL, '99990101 00:00:00.0', 2, 11, N'', '20131028 11:15:27.090', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1794, 1477, NULL, '99990122 00:00:00.0', 3, 24, N'', '20131028 11:29:10.230', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1795, 1478, NULL, '20131105 00:00:00.0', 2, 38, N'', '20131028 12:43:15.670', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1796, 1479, NULL, '20131029 00:00:00.0', 2, 219, N'', '20131028 12:58:50.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1797, 1480, NULL, '20131105 00:00:00.0', 2, 106, N'', '20131028 13:49:12.723', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1798, 1481, NULL, '20131111 00:00:00.0', 3, 59, N'', '20131029 15:08:28.830', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1799, 1482, NULL, '20131111 00:00:00.0', 3, 159, N'', '20131029 15:27:27.210', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1800, 1483, NULL, '20131107 00:00:00.0', NULL, 75, N'', '20131030 16:42:03.063', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1801, 1484, NULL, '20131202 00:00:00.0', 3, 217, N'', '20131104 11:15:10.370', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1802, 1485, NULL, '20131125 00:00:00.0', 3, 170, N'', '20131104 11:26:08.650', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1803, 1486, NULL, '20131125 00:00:00.0', 3, 644, N'', '20131104 11:33:28.077', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1804, 1487, NULL, '20131118 00:00:00.0', 3, 82, N'', '20131104 11:42:12.993', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1805, 1488, NULL, '20131125 00:00:00.0', 3, 240, N'', '20131104 11:57:03.353', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1806, 1489, NULL, '20131129 00:00:00.0', 3, 894, N'', '20131104 17:13:00.760', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1807, 1490, NULL, '20131125 00:00:00.0', 3, 42, N'', '20131105 14:56:54.293', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1808, 1491, NULL, '20131125 00:00:00.0', 3, 3768, N'', '20131105 15:07:56.593', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1809, 1492, NULL, '20131125 00:00:00.0', 1, 60, N'', '20131105 16:01:03.520', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1810, 1493, NULL, '20131126 00:00:00.0', NULL, 165, N'', '20131106 15:54:09.807', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1811, 1494, NULL, '20131111 00:00:00.0', 1, 3576, N'', '20131106 16:02:00.063', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1812, 1495, NULL, '20131111 00:00:00.0', 1, 43, N'', '20131106 16:19:22.137', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1813, 1496, NULL, '20131120 00:00:00.0', 1, 4062, N'', '20131107 08:56:04.573', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1814, 1497, NULL, '20131121 00:00:00.0', 2, 2875, N'', '20131107 09:15:06.007', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1815, 1498, NULL, '20131125 00:00:00.0', 3, 3576, N'', '20131108 10:05:10.933', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1816, 1499, NULL, '20131118 00:00:00.0', 3, 43, N'', '20131108 10:25:32.663', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1817, 1500, NULL, '20131125 00:00:00.0', 3, 1998, N'', '20131108 10:38:33.260', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1818, 1501, NULL, '20131125 00:00:00.0', 3, 3767, N'', '20131108 11:07:35.200', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1819, 1502, NULL, '20131118 00:00:00.0', 3, 4854, N'', '20131108 11:42:47.510', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1820, 1503, NULL, '20131125 00:00:00.0', NULL, 2143, N'', '20131108 11:56:34.323', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1821, 1504, NULL, '20131118 00:00:00.0', 1, 4854, N'', '20131111 10:06:41.800', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1822, 1505, NULL, '20131125 00:00:00.0', 3, 111, N'', '20131111 10:22:37.397', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1823, 1506, NULL, '20131125 00:00:00.0', 3, 207, N'', '20131111 10:28:36.313', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1824, 1507, NULL, '20131202 00:00:00.0', 3, 105, N'', '20131111 10:39:52.633', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1825, 1508, NULL, '20131202 00:00:00.0', 3, 71, N'', '20131111 11:00:06.230', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1826, 1509, NULL, '20131125 00:00:00.0', 3, 27, N'', '20131111 11:12:44.813', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1827, 1510, NULL, '20131202 00:00:00.0', 3, 89, N'', '20131111 12:40:06.540', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1828, 1511, NULL, '20131202 00:00:00.0', 3, 4864, N'', '20131111 15:16:43.590', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1829, 1512, NULL, '20131119 00:00:00.0', 3, 3297, N'', '20131112 12:15:35.670', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1830, 1513, NULL, '20131119 00:00:00.0', 2, 242, N'', '20131112 12:46:22.793', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1831, 1514, NULL, '20131119 00:00:00.0', 2, 39, N'', '20131112 14:32:56.343', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1832, 1515, NULL, '20131202 00:00:00.0', 3, 102, N'', '20131112 14:34:17.133', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1833, 1516, NULL, '20131210 00:00:00.0', 3, 154, N'', '20131112 14:41:22.280', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1834, 1517, NULL, '20131119 00:00:00.0', 2, 84, N'', '20131112 14:49:49.517', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1835, 1518, NULL, '20131202 00:00:00.0', 3, 137, N'', '20131112 14:50:29.573', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1836, 1519, NULL, '20131202 00:00:00.0', 3, 4506, N'', '20131112 14:58:56.037', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1837, 1520, NULL, '20131119 00:00:00.0', 2, 45, N'', '20131112 15:38:12.280', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1838, 1521, NULL, '20131115 00:00:00.0', 1, 3803, N'', '20131113 09:21:37.633', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1839, 1522, NULL, '20131114 00:00:00.0', 1, 66, N'', '20131113 09:23:55.857', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1840, 1523, NULL, '20131115 00:00:00.0', 1, 4, N'', '20131113 09:26:11.557', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1841, 1524, NULL, '20131125 00:00:00.0', 3, 101, N'', '20131113 16:22:37.393', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1842, 1525, NULL, '20131202 00:00:00.0', 3, 47, N'', '20131113 16:45:19.803', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1843, 1526, NULL, '20131202 00:00:00.0', 3, 26, N'', '20131113 16:54:58.597', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1844, 1527, NULL, '20131204 00:00:00.0', 3, 1041, N'', '20131114 12:27:15.247', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1845, 1528, NULL, '20131202 00:00:00.0', 3, 4891, N'', '20131114 14:16:18.733', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1846, 1529, NULL, '20131209 00:00:00.0', 3, 4892, N'', '20131114 14:45:58.317', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1847, 1530, NULL, '20131202 00:00:00.0', NULL, 1006, N'', '20131115 09:08:44.420', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1848, 1531, NULL, '20131204 00:00:00.0', 3, 3774, N'', '20131115 10:36:13.527', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1849, 1532, NULL, '20131209 00:00:00.0', 3, 91, N'', '20131115 14:27:10.147', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1850, 1533, NULL, '20131209 00:00:00.0', 3, 90, N'', '20131115 14:32:04.953', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1851, 1534, NULL, '20131120 00:00:00.0', 1, 4903, N'', '20131115 14:44:23.800', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1852, 1535, NULL, '20131204 00:00:00.0', 3, 50, N'', '20131115 15:04:13.507', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1853, 1536, NULL, '20131120 00:00:00.0', NULL, 4560, N'', '20131115 15:14:37.773', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1854, 1537, NULL, '20131126 00:00:00.0', NULL, 62, N'', '20131117 22:24:05.297', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1855, 1538, NULL, '20131125 00:00:00.0', 1, 4816, N'', '20131117 22:48:11.353', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1856, 1539, NULL, '20131126 00:00:00.0', 1, 3802, N'', '20131117 23:06:09.530', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1857, 1540, NULL, '20131126 00:00:00.0', 2, 119, N'', '20131117 23:24:38.217', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1858, 1541, NULL, '20131127 00:00:00.0', 2, 3, N'', '20131117 23:42:44.193', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1859, 1542, NULL, '99990114 00:00:00.0', -1, 4302, N'', '20131117 23:45:03.510', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1860, 1543, NULL, '20131126 00:00:00.0', 2, 4, N'', '20131117 23:59:04.390', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1861, 1544, NULL, '20131209 00:00:00.0', 3, 4676, N'', '20131118 09:57:24.407', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1862, 1545, NULL, '20131122 00:00:00.0', 1, 44, N'', '20131118 11:03:13.473', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1863, 1546, NULL, '20131122 00:00:00.0', 3, 90, N'', '20131118 11:05:41.810', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1864, 1547, NULL, '20131126 00:00:00.0', 2, 130, N'', '20131118 12:28:14.273', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1865, 1548, NULL, '20131126 00:00:00.0', 1, 71, N'', '20131118 12:36:09.107', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1866, 1549, NULL, '20131125 00:00:00.0', 1, 13, N'', '20131118 12:38:12.753', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1867, 1550, NULL, '20131209 00:00:00.0', 3, 1, N'', '20131119 14:59:03.273', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1868, 1551, NULL, '20131209 00:00:00.0', 3, 4735, N'', '20131119 15:13:39.003', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1869, 1552, NULL, '20131203 00:00:00.0', 3, 1244, N'', '20131119 15:25:34.117', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1870, 1553, NULL, '20131209 00:00:00.0', 3, 107, N'', '20131120 09:46:04.513', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1871, 1554, NULL, '20131220 00:00:00.0', 3, 138, N'', '20131120 10:51:25.337', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1872, 1555, NULL, '20131220 00:00:00.0', 3, 76, N'', '20131120 10:53:31.537', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1873, 1556, NULL, '20131220 00:00:00.0', 3, 73, N'', '20131120 11:09:28.543', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1874, 1557, NULL, '20131220 00:00:00.0', 3, 3354, N'', '20131120 11:14:18.863', 5, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1875, 1558, NULL, '20131204 00:00:00.0', 3, 122, N'', '20131120 11:20:58.770', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1876, 1559, NULL, '20131129 00:00:00.0', 3, 3115, N'', '20131120 14:32:59.150', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1877, 1560, NULL, '20131211 00:00:00.0', 3, 2875, N'', '20131121 11:02:42.470', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1878, 1561, NULL, '20131203 00:00:00.0', NULL, 1994, N'', '20131121 17:23:11.797', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1879, 1562, NULL, '20131126 00:00:00.0', NULL, 49, N'', '20131121 17:38:31.510', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1880, 1563, NULL, '20131129 00:00:00.0', 1, 3809, N'', '20131122 09:54:08.377', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1881, 1564, NULL, '20131129 00:00:00.0', NULL, 33, N'', '20131122 10:13:45.480', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1882, 1565, NULL, '20131129 00:00:00.0', 1, 87, N'', '20131122 10:23:43.490', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1883, 1566, NULL, '20131209 00:00:00.0', 3, 63, N'', '20131122 10:31:10.770', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1884, 1567, NULL, '20131209 00:00:00.0', 3, 4931, N'', '20131122 10:53:22.450', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1885, 1568, NULL, '20131209 00:00:00.0', 3, 4930, N'', '20131122 11:00:26.867', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1886, 1569, NULL, '20131129 00:00:00.0', 2, 2, N'', '20131122 11:18:06.683', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1887, 1570, NULL, '20131209 00:00:00.0', 3, 362, N'', '20131122 11:39:27.950', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1888, 1571, NULL, '20131129 00:00:00.0', 2, 62, N'', '20131122 11:48:03.563', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1889, 1572, NULL, '20131209 00:00:00.0', 3, 85, N'', '20131122 11:53:33.927', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1890, 1573, NULL, '20131209 00:00:00.0', 3, 240, N'', '20131122 12:07:05.250', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1891, 1574, NULL, '20131209 00:00:00.0', 3, 170, N'', '20131122 12:13:02.613', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1892, 1575, NULL, '20131129 00:00:00.0', 2, 4932, N'', '20131122 12:18:17.073', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1893, 1576, NULL, '20131129 00:00:00.0', 2, 44, N'', '20131122 12:26:16.697', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1894, 1577, NULL, '20131209 00:00:00.0', 3, 82, N'', '20131122 12:32:18.863', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1895, 1578, NULL, '20131128 00:00:00.0', 3, 4933, N'', '20131122 12:43:41.400', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1896, 1579, NULL, '20131209 00:00:00.0', 3, 4936, N'', '20131122 13:09:43.290', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1897, 1580, NULL, '20131210 00:00:00.0', 3, 177, N'', '20131122 13:56:17.640', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1898, 1581, NULL, '20131129 00:00:00.0', 2, 104, N'', '20131122 14:03:24.750', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1899, 1582, NULL, '20131129 00:00:00.0', 2, 3296, N'', '20131122 14:23:36.210', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1900, 1583, NULL, '20131129 00:00:00.0', 2, 2354, N'', '20131122 14:34:20.630', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1901, 1584, NULL, '20131129 00:00:00.0', 2, 1887, N'', '20131122 14:42:25.347', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1902, 1585, NULL, '20131202 00:00:00.0', 3, 1227, N'', '20131122 14:52:44.550', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1903, 1586, NULL, '20131126 00:00:00.0', NULL, 236, N'', '20131122 15:16:45.550', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1904, 1587, NULL, '20131125 00:00:00.0', NULL, 206, N'', '20131122 15:33:28.040', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1905, 1588, NULL, '20131211 00:00:00.0', 1, 2907, N'', '20131125 11:32:59.310', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1906, 1589, NULL, '20131202 00:00:00.0', 2, 1321, N'', '20131125 11:45:39.100', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1907, 1590, NULL, '20131127 00:00:00.0', 1, 4935, N'', '20131125 12:04:20.753', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1908, 1591, NULL, '20131128 00:00:00.0', 2, 4937, N'', '20131125 12:10:02.853', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1909, 1592, NULL, '20131129 00:00:00.0', 1, 4934, N'', '20131125 12:14:30.367', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1910, 1593, NULL, '20131204 00:00:00.0', 3, 4914, N'', '20131125 12:36:05.220', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1911, 1594, NULL, '20131128 00:00:00.0', 1, 4941, N'', '20131125 12:40:46.633', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1912, 1595, NULL, '20131130 00:00:00.0', 1, 39, N'', '20131125 13:05:29.043', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1913, 1596, NULL, '20131128 00:00:00.0', 2, 14, N'', '20131125 13:09:00.897', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1914, 1597, NULL, '20131129 00:00:00.0', 2, 3964, N'', '20131125 13:13:34.700', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1915, 1598, NULL, '20131202 00:00:00.0', 3, 4948, N'', '20131126 15:00:40.810', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1916, 1599, NULL, '20131209 00:00:00.0', 3, 157, N'', '20131126 15:17:01.330', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1917, 1600, NULL, '20131217 00:00:00.0', 3, 2874, N'', '20131127 10:21:50.353', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1918, 1601, NULL, '20131211 00:00:00.0', 3, 83, N'', '20131127 15:02:51.010', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1919, 1602, NULL, '20131218 00:00:00.0', 3, 183, N'', '20131127 15:09:48.190', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1920, 1603, NULL, '20131205 00:00:00.0', NULL, 160, N'', '20131127 17:33:44.970', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1921, 1604, NULL, '20131223 00:00:00.0', 3, 256, N'', '20131128 14:51:35.463', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1922, 1605, NULL, '20131204 00:00:00.0', NULL, 134, N'', '20131128 15:27:20.767', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1923, 1606, NULL, '20131206 00:00:00.0', -1, 88, N'', '20131128 15:38:36.147', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1924, 1607, NULL, '20131218 00:00:00.0', 3, 4702, N'', '20131128 16:09:36.470', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1925, 1608, NULL, '20131209 00:00:00.0', 3, 4936, N'', '20131129 09:25:12.923', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1926, 1609, NULL, '20131209 00:00:00.0', 3, 4963, N'', '20131129 09:45:23.877', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1927, 1610, NULL, '20131202 00:00:00.0', 3, 644, N'', '20131129 09:51:31.060', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1928, 1611, NULL, '20131206 00:00:00.0', 2, 14, N'', '20131129 10:13:39.623', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1929, 1612, NULL, '20131209 00:00:00.0', 3, 18, N'', '20131129 15:17:31.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1930, 1613, NULL, '20131206 00:00:00.0', NULL, 78, N'', '20131129 15:31:38.057', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1931, 1614, NULL, '20131209 00:00:00.0', 3, 362, N'', '20131129 15:33:18.103', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1932, 1615, NULL, '20131216 00:00:00.0', 3, 626, N'', '20131129 15:45:12.377', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1933, 1616, NULL, '20131209 00:00:00.0', 3, 56, N'', '20131129 15:57:23.557', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1934, 1617, NULL, '20131216 00:00:00.0', 3, 116, N'', '20131129 16:09:30.307', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1935, 1618, NULL, '20131216 00:00:00.0', 3, 47, N'', '20131129 16:25:45.753', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1936, 1619, NULL, '20131224 00:00:00.0', 3, 3946, N'', '20131202 09:10:54.357', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1937, 1620, NULL, '20131216 00:00:00.0', 3, 2969, N'', '20131202 09:31:21.633', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1938, 1621, NULL, '20131216 00:00:00.0', 3, 3243, N'', '20131202 16:26:57.993', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1939, 1622, NULL, '20131224 00:00:00.0', 3, 24, N'', '20131203 09:14:29.097', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1940, 1623, NULL, '20131217 00:00:00.0', 3, 4965, N'', '20131203 09:20:29.507', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1941, 1624, NULL, '20131217 00:00:00.0', NULL, 45, N'', '20131203 09:38:28.257', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1942, 1625, NULL, '20131217 00:00:00.0', 2, 4966, N'', '20131203 09:40:12.513', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1943, 1626, NULL, '20131217 00:00:00.0', 2, 2320, N'', '20131203 09:56:57.760', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1944, 1627, NULL, '20131217 00:00:00.0', 2, 4975, N'', '20131203 10:17:36.047', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1945, 1628, NULL, '20131224 00:00:00.0', 3, 4310, N'', '20131203 10:51:41.810', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1946, 1629, NULL, '20131217 00:00:00.0', 3, 1269, N'', '20131203 12:45:07.563', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1947, 1630, NULL, '20131223 00:00:00.0', 3, 5002, N'', '20131205 11:02:52.960', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1948, 1631, NULL, '20131230 00:00:00.0', 3, 5003, N'', '20131205 11:11:22.687', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1949, 1632, NULL, '20131230 00:00:00.0', 3, 241, N'', '20131205 11:17:36.857', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1950, 1633, NULL, '20131212 00:00:00.0', 1, 32, N'', '20131205 23:56:18.423', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1951, 1634, NULL, '20131220 00:00:00.0', 1, 4966, N'', '20131206 00:16:14.603', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1952, 1635, NULL, '20131213 00:00:00.0', 2, 187, N'', '20131206 00:28:49.813', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1953, 1636, NULL, '20131227 00:00:00.0', 2, 4053, N'', '20131206 00:40:15.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1954, 1637, NULL, '20131223 00:00:00.0', 3, 41, N'', '20131206 09:53:25.090', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1955, 1638, NULL, '20131230 00:00:00.0', 3, 27, N'', '20131206 10:02:05.883', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1956, 1639, NULL, '20131223 00:00:00.0', 3, 60, N'', '20131206 14:32:37.753', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1957, 1640, NULL, '20131230 00:00:00.0', 3, 5017, N'', '20131206 15:01:23.057', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1958, 1641, NULL, '20131230 00:00:00.0', 3, 4735, N'', '20131206 15:07:55.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1959, 1642, NULL, '20131217 00:00:00.0', 1, 5009, N'', '20131209 07:51:59.763', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1960, 1643, NULL, '20131225 00:00:00.0', 2, 5010, N'', '20131209 09:52:32.157', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1961, 1644, NULL, '20131224 00:00:00.0', 2, 51, N'', '20131209 09:58:05.330', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1962, 1645, NULL, '20131224 00:00:00.0', 1, 30, N'', '20131209 10:30:47.127', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1963, 1646, NULL, '20140101 00:00:00.0', 1, 227, N'', '20131209 10:36:32.617', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1964, 1647, NULL, '20131224 00:00:00.0', 2, 258, N'', '20131209 11:15:25.613', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1965, 1648, NULL, '20131217 00:00:00.0', 2, 1796, N'', '20131209 11:21:50.760', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1966, 1649, NULL, '20131223 00:00:00.0', 1, 5020, N'', '20131209 15:04:38.603', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1967, 1650, NULL, '20131230 00:00:00.0', 3, 47, N'', '20131210 11:42:00.117', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1968, 1651, NULL, '20140114 00:00:00.0', 3, 2907, N'', '20131210 16:50:10.180', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1969, 1652, NULL, '20131218 00:00:00.0', 3, 2876, N'', '20131210 16:56:55.563', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1970, 1653, NULL, '20140114 00:00:00.0', 3, 2908, N'', '20131210 17:03:15.543', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1971, 1654, NULL, '20131230 00:00:00.0', 3, 43, N'', '20131211 14:05:28.513', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1972, 1655, NULL, '20131230 00:00:00.0', 3, 71, N'', '20131211 14:35:11.377', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1973, 1656, NULL, '20140107 00:00:00.0', 3, 102, N'', '20131211 14:43:20.380', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1974, 1657, NULL, '20131219 00:00:00.0', NULL, 134, N'', '20131211 16:13:03.733', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1975, 1658, NULL, '20140114 00:00:00.0', 3, 183, N'', '20131212 16:49:27.873', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1976, 1659, NULL, '20140114 00:00:00.0', 3, 2881, N'', '20131212 16:51:41.533', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1977, 1660, NULL, '20140114 00:00:00.0', 3, 2875, N'', '20131216 10:43:47.900', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1978, 1661, NULL, '20131230 00:00:00.0', NULL, 88, N'', '20131216 12:48:43.057', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1979, 1662, NULL, '20140106 00:00:00.0', 3, 241, N'', '20131216 15:30:31.930', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1980, 1663, NULL, '20140106 00:00:00.0', 3, 4735, N'', '20131216 16:27:03.420', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1981, 1664, NULL, '20140113 00:00:00.0', 3, 8, N'', '20131216 16:49:49.133', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1982, 1665, NULL, '20131220 00:00:00.0', NULL, 169, N'', '20131217 15:09:34.667', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1983, 1666, NULL, '20140113 00:00:00.0', 3, 4676, N'', '20131218 09:22:19.777', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1984, 1667, NULL, '20140106 00:00:00.0', 3, 3576, N'', '20131218 09:30:44.377', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1985, 1668, NULL, '20140113 00:00:00.0', 3, 27, N'', '20131218 09:52:34.547', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1986, 1669, NULL, '20140113 00:00:00.0', 3, 29, N'', '20131218 09:59:30.817', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1987, 1670, NULL, '20140113 00:00:00.0', 3, 1998, N'', '20131218 10:14:01.243', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1988, 1671, NULL, '20140113 00:00:00.0', 3, 161, N'', '20131218 10:21:23.917', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1989, 1672, NULL, '20131225 00:00:00.0', 2, 227, N'', '20131218 10:45:14.740', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1990, 1673, NULL, '20131225 00:00:00.0', 1, 46, N'', '20131218 10:59:07.983', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1991, 1674, NULL, '20131225 00:00:00.0', 2, 130, N'', '20131218 11:11:29.883', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1992, 1675, NULL, '20131225 00:00:00.0', 2, 86, N'', '20131218 11:19:21.773', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1993, 1676, NULL, '20131225 00:00:00.0', 2, 7, N'', '20131218 11:45:58.003', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1994, 1677, NULL, '99990101 00:00:00.0', NULL, 38, N'', '20131218 13:00:24.047', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1995, 1678, NULL, '20131225 00:00:00.0', 2, 3297, N'', '20131218 17:19:12.687', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1996, 1679, NULL, '20131225 00:00:00.0', 2, 219, N'', '20131218 17:20:09.037', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1997, 1680, NULL, '20131225 00:00:00.0', 1, 3297, N'', '20131218 17:23:58.193', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1998, 1681, NULL, '20140107 00:00:00.0', NULL, 165, N'', '20131219 16:02:00.220', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(1999, 1682, NULL, '20140107 00:00:00.0', NULL, 49, N'', '20131219 16:06:35.540', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2000, 1683, NULL, '20131230 00:00:00.0', 3, 4735, N'', '20131219 17:07:50.917', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2001, 1684, NULL, '20140106 00:00:00.0', 3, 1, N'', '20131219 17:15:32.227', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2002, 1685, NULL, '20140113 00:00:00.0', 3, 3768, N'', '20131223 08:21:05.220', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2003, 1686, NULL, '20140113 00:00:00.0', 3, 12, N'', '20131223 08:30:50.050', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2004, 1687, NULL, '20140113 00:00:00.0', 3, 240, N'', '20131223 08:37:24.557', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2005, 1688, NULL, '20140113 00:00:00.0', 3, 4948, N'', '20131223 08:43:03.353', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2006, 1689, NULL, '20140113 00:00:00.0', 3, 170, N'', '20131223 08:48:59.183', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2007, 1690, NULL, '20140113 00:00:00.0', 3, 102, N'', '20131223 08:55:16.957', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2008, 1691, NULL, '20140113 00:00:00.0', 3, 154, N'', '20131223 15:00:12.440', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2009, 1692, NULL, '20140113 00:00:00.0', 3, 4506, N'', '20131223 15:02:21.313', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2010, 1693, NULL, '20140113 00:00:00.0', 3, 101, N'', '20131223 16:54:08.283', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2011, 1694, NULL, '20140113 00:00:00.0', 3, 536, N'', '20131224 10:15:31.630', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2012, 1695, NULL, '20140102 00:00:00.0', 1, 4308, N'', '20131226 09:46:52.213', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2013, 1696, NULL, '20140102 00:00:00.0', 2, 84, N'', '20131226 10:40:04.627', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2014, 1697, NULL, '20140102 00:00:00.0', 2, 5062, N'', '20131226 11:02:31.867', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2015, 1698, NULL, '20140102 00:00:00.0', 2, 119, N'', '20131226 11:08:15.543', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2016, 1699, NULL, '20140102 00:00:00.0', 1, 39, N'', '20131226 11:23:30.303', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2017, 1700, NULL, '20140115 00:00:00.0', 3, 50, N'', '20131226 12:18:12.670', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2018, 1701, NULL, '20140121 00:00:00.0', 3, 3946, N'', '20131226 12:24:21.443', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2019, 1702, NULL, '20140116 00:00:00.0', 3, 90, N'', '20131226 12:42:42.840', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2020, 1703, NULL, '20140106 00:00:00.0', 3, 3243, N'', '20131226 12:59:22.923', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2021, 1704, NULL, '20140113 00:00:00.0', 3, 695, N'', '20131227 09:37:09.970', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2022, 1705, NULL, '20140113 00:00:00.0', 3, 56, N'', '20131227 09:54:44.643', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2023, 1706, NULL, '20140113 00:00:00.0', 3, 105, N'', '20131227 15:04:21.877', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2024, 1707, NULL, '20131229 00:00:00.0', NULL, 75, N'', '20131227 15:32:50.650', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2025, 1708, NULL, '20140113 00:00:00.0', NULL, 3620, N'', '20131227 15:36:34.927', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2026, 1709, NULL, '20140113 00:00:00.0', 3, 678, N'', '20131227 15:51:00.400', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2027, 1710, NULL, '20140102 00:00:00.0', NULL, 203, N'', '20131227 15:51:12.740', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2028, 1711, NULL, '20140113 00:00:00.0', 3, 5073, N'', '20131230 09:53:31.343', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2029, 1712, NULL, '20140113 00:00:00.0', 3, 157, N'', '20131230 15:32:01.477', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2030, 1713, NULL, '20140107 00:00:00.0', 3, 278, N'', '20131230 16:56:09.817', 59, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2031, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 09:00:19.750', 64, 1, 416, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2032, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:23:21.617', 64, 1, 417, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2033, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:25:25.093', 64, 1, 418, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2034, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:27:54.223', 64, 1, 419, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2035, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:30:11.757', 64, 1, 420, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2036, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:31:57.437', 64, 1, 421, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2037, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:41:33.233', 64, 1, 422, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2038, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 12:52:44.970', 64, 1, 423, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2039, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:28:42.100', 64, 1, 424, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2040, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:31:34.723', 64, 1, 425, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2041, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:32:39.413', 64, 1, 426, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2042, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:33:50.843', 64, 1, 427, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2043, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:34:58.343', 64, 1, 428, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2044, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:35:54.313', 64, 1, 429, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2045, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:40:57.950', 64, 1, 430, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2046, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:42:57.443', 64, 1, 431, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2047, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:47:00.833', 64, 1, 432, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2048, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:48:03.957', 64, 1, 433, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2049, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:49:44.803', 64, 1, 434, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2050, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:51:01.407', 64, 1, 435, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2051, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 14:52:18.507', 64, 1, 436, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2052, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 15:06:38.643', 64, 1, 437, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2053, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 15:08:19.430', 64, 1, 438, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2054, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 15:09:22.373', 64, 1, 439, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2055, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 15:10:31.337', 64, 1, 440, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2056, NULL, NULL, '20140120 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140106 15:11:55.247', 64, 1, 441, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2057, 1714, NULL, '20140110 00:00:00.0', 3, 1006, N'', '20140108 09:45:11.980', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2058, 1715, NULL, '20140110 00:00:00.0', 1, 31, N'', '20140108 09:49:00.780', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2059, 1716, NULL, '20140110 00:00:00.0', NULL, 151, N'', '20140108 09:51:30.227', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2060, 1717, NULL, '20140110 00:00:00.0', 1, 2545, N'', '20140108 10:00:20.853', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2061, NULL, NULL, '20140127 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140108 12:35:27.923', 64, 1, 442, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2062, NULL, NULL, '20140127 00:00:00.0', 0, NULL, N'Primera reunión de seguimiento', '20140108 12:44:40.697', 64, 1, 443, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2063, 1718, NULL, '20140131 00:00:00.0', NULL, 144, N'', '20140109 17:41:44.167', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2064, 1719, NULL, '20140129 00:00:00.0', NULL, 4483, N'', '20140109 17:43:13.190', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2065, 1720, NULL, '20140129 00:00:00.0', 2, 2876, N'', '20140110 09:09:51.847', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2066, 1721, NULL, '20140128 00:00:00.0', 2, 183, N'', '20140110 09:20:08.270', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2067, 1722, NULL, '20140113 00:00:00.0', NULL, 4004, N'', '20140110 16:03:54.870', 9, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2068, 1723, NULL, '20140121 00:00:00.0', 1, 151, N'', '20140114 09:06:11.407', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2069, 1724, NULL, '20140210 00:00:00.0', 3, 1, N'', '20140114 09:08:25.633', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2070, 1725, NULL, '20140128 00:00:00.0', 2, 31, N'', '20140114 09:09:14.370', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2071, 1726, NULL, '20140127 00:00:00.0', 3, 71, N'', '20140114 09:22:01.930', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2072, 1727, NULL, '20140128 00:00:00.0', 2, 40, N'', '20140114 09:36:42.417', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2073, 1728, NULL, '20140128 00:00:00.0', 1, 3, N'', '20140114 09:57:19.510', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2074, 1729, NULL, '20140128 00:00:00.0', 2, 5062, N'', '20140114 10:57:45.433', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2075, 1730, NULL, '20140128 00:00:00.0', 2, 219, N'', '20140114 11:20:29.540', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2076, 1731, NULL, '20140128 00:00:00.0', 3, 130, N'', '20140114 11:38:21.347', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2077, 1732, NULL, '20140128 00:00:00.0', 2, 104, N'', '20140114 11:47:51.320', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2078, 1733, NULL, '20140210 00:00:00.0', 3, 47, N'', '20140114 17:37:58.210', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2079, 1734, NULL, '20140127 00:00:00.0', 2, 2913, N'', '20140116 12:34:13.937', 64, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2080, 1735, NULL, '20140123 00:00:00.0', 1, 1, N'', '20140116 15:44:28.403', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2081, 1736, NULL, '20140123 00:00:00.0', 1, 90, N'', '20140116 15:46:11.340', 14, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2082, 1737, NULL, '20140127 00:00:00.0', 3, 8, N'', '20140116 18:06:20.323', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2083, 1738, NULL, '20140203 00:00:00.0', 3, 43, N'', '20140116 18:29:41.090', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2084, 1739, NULL, '20140203 00:00:00.0', 3, 1227, N'', '20140117 08:51:30.630', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2085, 1740, NULL, '20140131 00:00:00.0', 1, 11, N'', '20140117 08:56:24.233', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2086, 1741, NULL, '20140203 00:00:00.0', 3, 240, N'', '20140117 08:59:27.513', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2087, 1742, NULL, '20140124 00:00:00.0', 1, 62, N'', '20140117 09:23:56.680', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2088, 1743, NULL, '20140124 00:00:00.0', 2, 44, N'', '20140117 09:27:00.493', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2089, 1744, NULL, '20140129 00:00:00.0', 3, 24, N'', '20140117 10:13:18.657', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2090, 1745, NULL, '20140203 00:00:00.0', 3, 85, N'', '20140117 10:27:03.653', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2091, 1746, NULL, '20140203 00:00:00.0', 3, 170, N'', '20140117 10:39:35.503', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2092, 1747, NULL, '20140131 00:00:00.0', 2, 39, N'', '20140117 10:47:46.793', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2093, 1748, NULL, '20140124 00:00:00.0', 2, 45, N'', '20140117 10:52:18.643', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2094, 1749, NULL, '20140203 00:00:00.0', 3, 644, N'', '20140117 11:02:39.570', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2095, 1750, NULL, '20140210 00:00:00.0', 3, 18, N'', '20140117 11:18:54.923', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2096, 1751, NULL, '20140210 00:00:00.0', 3, 161, N'', '20140117 11:27:29.223', 7, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2097, 1752, NULL, '20140124 00:00:00.0', 1, 5161, N'', '20140117 11:29:24.253', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2098, 1753, NULL, '20140124 00:00:00.0', 2, 5162, N'', '20140117 12:13:02.317', 6, 1, NULL, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2099, NULL, NULL, '20140206 21:48:46.810', 1, 0, N'asdasdsad', '20140206 21:49:10.713', 5, 1, NULL, 16, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2100, NULL, NULL, '20140206 21:49:55.117', 3, 0, N'esta es una prueba de una visita', '20140206 21:50:04.463', 5, 1, 22, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2101, NULL, NULL, '20140206 21:50:08.907', 2, 0, N'hola1', '20140206 21:50:22.780', 5, 1, 22, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2102, NULL, NULL, '20140206 21:50:14.850', 1, 0, N'hola2', '20140206 21:50:22.780', 5, 1, 22, NULL, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2111, NULL, NULL, '20140208 15:40:55.757', 1, 0, N'uno', '20140208 15:41:12.570', 5, 0, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2112, NULL, NULL, '20140208 15:46:51.663', 3, 0, N'esto es una prueba', '20140208 15:46:58.963', 5, 1, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2113, NULL, NULL, '20140208 15:47:11.120', 2, 0, N'vhspiceros', '20140208 15:47:26.623', 5, 0, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2114, NULL, NULL, '20140208 15:47:11.120', 2, 0, N'vhspiceros', '20140208 15:47:33.787', 5, 0, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2115, NULL, NULL, '20140208 15:47:11.120', 2, 0, N'vhspiceros', '20140208 15:47:37.450', 5, 0, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2116, NULL, NULL, '20140208 15:47:25.583', 2, 0, N'hola', '20140208 15:47:37.453', 5, 0, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2117, NULL, NULL, '20140208 15:53:39.0', 1, 0, N'nueva cotizacion', '20140208 15:54:06.280', 5, 1, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2118, NULL, NULL, '20140208 16:11:51.260', 2, 0, N'czxczxc', '20140208 16:11:57.457', 5, 1, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2119, NULL, NULL, '20140208 16:12:05.173', 2, 0, N'foo', '20140208 16:12:25.0', 5, 1, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2120, NULL, NULL, '20140208 16:12:59.213', 1, 0, N'prueba', '20140208 16:13:09.217', 5, 1, NULL, 14, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2121, NULL, NULL, '20140208 16:13:18.433', 1, 0, N'prueba2', '20140208 16:13:29.507', 5, 1, NULL, 14, NULL)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2122, NULL, NULL, '20140223 17:14:31.460', 2, 0, N'esto es en mucho tiempo', '20140208 17:14:44.300', 5, 0, NULL, NULL, 278)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2123, NULL, NULL, '20140212 17:25:44.517', 1, 0, N'esto es en 3 dias', '20140208 17:26:02.580', 5, 1, NULL, NULL, 279)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2124, NULL, NULL, '20140208 17:29:51.883', 1, 0, N'esto es ahora', '20140208 17:30:00.723', 5, 1, NULL, NULL, 277)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2125, NULL, NULL, '20140212 17:40:45.237', 2, 0, N'este debe ser amarillo', '20140208 17:41:00.137', 5, 1, NULL, NULL, 270)
GO
INSERT INTO [dbo].[CLIENTES_FOLLOW_UP]([Id], [IdInformeVisita], [IdLlamadaTelefonica], [FechaFollowUp], [IdTipoActividadSiguiente], [IdClienteMaster], [Descripcion], [FechaCreacion], [IdUsuario], [activo], [idTarget], [idSLead], [idCotizacion])
  VALUES(2126, NULL, NULL, '20140322 09:52:56.793', 1, 66, N'esta es una prueba', '20140322 09:53:07.680', 5, 1, 413, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CLIENTES_FOLLOW_UP] OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ClientesFollowUp_Visita]
	ON [dbo].[CLIENTES_FOLLOW_UP]([IdInformeVisita])
GO

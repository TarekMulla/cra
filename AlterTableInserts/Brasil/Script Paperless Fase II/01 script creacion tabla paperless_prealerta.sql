CREATE TABLE [dbo].[PAPERLESS_PREALERTA](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NumConsolidada] [nvarchar](50) NOT NULL,
	[NumMaster] [nvarchar](50) NULL,
	[IdAgente] [bigint] NULL,
	[IdNaviera] [bigint] NULL,
	[IdNave] [bigint] NULL,
	[FechaSalida] [datetime] NULL,
	[FechaLlegada] [datetime] NULL,
	[FechaRecibimiento] [datetime] NULL,
	[FechaCreacion] [datetime] NULL,
	[IdUsuarioCreacion] [bigint] NULL,
	[FechaModificacion] [datetime] NULL,
	[IdUsuarioModificacion] [bigint] NULL,
	[FechaCancelacion] [datetime] NULL,
	[IdUsuarioCancelacion] [bigint] NULL,
	[IdEstado] [bigint] NULL,
	[IdPuertoOrigen] [varchar](10) NULL,
	[IdPuertoDestino] [varchar](10) NULL,
 CONSTRAINT [PK_PAPERLESS_PREALERTA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
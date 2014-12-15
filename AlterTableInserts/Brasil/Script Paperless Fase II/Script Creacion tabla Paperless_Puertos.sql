CREATE TABLE [dbo].[Paperless_Puertos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[pais] [varchar](100) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Puertos_2] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
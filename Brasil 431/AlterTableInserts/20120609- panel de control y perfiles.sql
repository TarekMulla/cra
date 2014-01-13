select Id,Descripcion as nombre,getdate() as FechaCreacion , null as ID_PANEL
INTO PERFILES
from USUARIOS_CARGO
GO

CREATE TABLE [dbo].[PANEL_CONTROL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar] (100) not NULL,
	[XML_FILE]	[nvarchar] (100) not NULL
 CONSTRAINT [PK_PANEL_CONTROL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

select USUARIOS.id as ID_USUARIO,USUARIOS_CARGO.Id as ID_PERFIL ,0 as PRIORIDAD
into USUARIOS_PERFILES
from USUARIOS, USUARIOS_CARGO where USUARIOS.IdCargo= USUARIOS_CARGO.Id
GO


create PROCEDURE [dbo].[SP_C_USUARIO_PERFILES]
@ID_USUARIO bigint
as
select a.id  as id_perfil, a.nombre as nombre_perfil, B.prioridad,c.id as id_panel, c.nombre as nombre_panel, c.xml_file 
FROM perfiles A LEFT OUTER JOIN usuarios_perfiles B
     ON A.id=b.id_perfil
        LEFT OUTER JOIN PANEL_CONTROL C
			on a.id_panel = C.id
where b.id_usuario=@ID_USUARIO
GO



insert PANEL_CONTROL (NOMBRE,XML_FILE) values ('panel Papperless','panel1.xml')
GO

Update PERFILES set ID_PANEL=null
GO

update PERFILES set id_panel = 1 where Id in (
   select ID_PERFIL from USUARIO_PERFIL, USUARIOS 
   where USUARIO_PERFIL.ID_USUARIO=USUARIOS.Id
   and NombreUsuario in ('pcabrera','gjarpa')
)
GO
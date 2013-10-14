
if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacionDiff')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacionDiff int
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacion')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacion datetime
END


if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Resuelto')
Begin
--select * from PAPERLESS_USUARIO1_EXCEPCIONES
	alter table PAPERLESS_USUARIO1_EXCEPCIONES add Resuelto bit 	
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Resuelto_user2')
Begin
	alter table PAPERLESS_USUARIO1_EXCEPCIONES add Resuelto_user2 bit 	
END
 
 if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_CARGA' and name = 'DescripcionLarga')
Begin
	alter table PAPERLESS_TIPO_CARGA add DescripcionLarga varchar (20) 	
END
IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2') 
BEGIN
	DROP PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2]
END
GO


CREATE    PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2]

		@TieneExcepciones bit,        
		@TipoExcepcion bigint,        
		@TipoResponsabilidad bigint,        
		@IdExcepcion bigint,        
		@comentario varchar(300),      
		@Resuelto bit        ,  
		@ResueltoUser2 bit   
		AS                                            
		UPDATE PAPERLESS_USUARIO1_EXCEPCIONES        
		SET TieneExcepciones = @TieneExcepciones,TipoExcepcion=@TipoExcepcion, TipoResponsabilidad=@TipoResponsabilidad, comentario=@comentario  ,       
		Resuelto=@Resuelto    ,  
		Resuelto_User2=@ResueltoUser2    
		WHERE Id = @IdExcepcion 
go

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2') 
BEGIN
--print 'elimino [SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]'
	DROP PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]
END
GO

CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]    
@IdExcepcion bigint    
AS    
select a.TieneExcepciones,    
b.id as id_tipo_excepcion,    
b.descripcion as descripcion_tipo_excepcion,    
c.id as id_tipo_responsabilidad,    
c.descripcion as descripcion_tipo_responsabilidad  ,  
a.Resuelto,  
a.Resuelto_User2  
from PAPERLESS_USUARIO1_EXCEPCIONES A    
LEFT OUTER JOIN PAPERLESS_TIPO_EXCEPCIONES B on a.tipoExcepcion= b.id    
LEFT OUTER JOIN PAPERLESS_TIPO_RESPONSABILIDAD c on a.TipoResponsabilidad = c.id    
where A.id=@IdExcepcion      
go

if exists(select * from sysobjects where name = 'PAPERLESS_USUARIO1_EXCEPECIONES')
Begin
	DROP TABLE PAPERLESS_USUARIO1_EXCEPECIONES
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_EXCEPCIONES' and name = 'Tipo')
Begin
	alter table PAPERLESS_TIPO_EXCEPCIONES add Tipo varchar (20)
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_RESPONSABILIDAD' and name = 'Tipo')
Begin
	alter table PAPERLESS_TIPO_RESPONSABILIDAD add Tipo varchar (20)
END

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_PAPERLESS_TIPO_EXCEPCIONES') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_EXCEPCIONES]
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_PAPERLESS_TIPO_RESPONSABILIDAD') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_RESPONSABILIDAD]
END
GO

CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_EXCEPCIONES]  
@tipo varchar (20)
AS  
select id,Descripcion 
from PAPERLESS_TIPO_EXCEPCIONES  
where activo = 1   and Tipo = @tipo
order by id 

go

CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_RESPONSABILIDAD]
@tipo varchar(20)
AS  
select id,Descripcion  
from PAPERLESS_TIPO_RESPONSABILIDAD  
where activo = 1   and tipo=@tipo
UNION
select id,Descripcion  
from PAPERLESS_TIPO_RESPONSABILIDAD  
where activo = 1   and tipo is null
order by id   

go
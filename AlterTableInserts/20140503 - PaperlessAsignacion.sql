if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'numContenedor')
Begin
		alter table  PAPERLESS_ASIGNACION add  numContenedor int  
	
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]
GO



/****** Object:  StoredProcedure [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]    Script Date: 05/04/2014 02:51:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]
@NumMaster nvarchar(100),
@FechaMaster datetime,
@IdAgente bigint,
@IdNaviera bigint,
@IdNave bigint,
@Viaje nvarchar(100),
@NumHousesBL int,
@IdTipoCarga int,
@IdEstado int,
@IdUsuarioCreo int,
@IdTipoServicio int,
@IdNaveTransbordo int,
@CodEmpresa nvarchar(50),
@NumContenedor int

AS

IF @IdAgente = -1 SET @IdAgente = NULL
IF @IdNaviera = -1 SET @IdNaviera = NULL
IF @IdNave = -1 SET @IdNave = NULL
IF @IdNaveTransbordo = -1 SET @IdNaveTransbordo = NULL
IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL

INSERT INTO PAPERLESS_ASIGNACION(
	NumMaster,FechaMaster,IdAgente,IdNaviera,IdNave,Viaje,NumHousesBL,IdTipoCarga, IdTipoServicio, 
	IdEstado,FechaCreacion, FechaPaso1,IdUsuarioCreacion, Usuario1, Usuario2,IdNaveTransbordo,empresa,numContenedor
	)
VALUES(
	@NumMaster,@FechaMaster,@IdAgente,@IdNaviera,@IdNave,@Viaje,@NumHousesBL,@IdTipoCarga, @IdTipoServicio,
	@IdEstado,GETDATE(), GETDATE(),@IdUsuarioCreo, -1, -1,@IdNaveTransbordo,@CodEmpresa,@NumContenedor
)

SELECT SCOPE_IDENTITY()

GO



/****** Object:  StoredProcedure [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]    Script Date: 05/04/2014 03:09:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]
GO



/****** Object:  StoredProcedure [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]    Script Date: 05/04/2014 03:09:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]   				   
@NumMaster nvarchar(50),   
@FechaMaster datetime,   
@IdAgente bigint,   
@IdNaviera bigint,   
@IdNave bigint,   
@Viaje nvarchar(100),   
@NumHouses int,   
@IdTipoCarga int,   
@IdAsignacion bigint,  
@IdTipoServicio int, 
@IdNaveTransbordo bigint,
@CodEmpresa nvarchar(50),
@NumContenedor int,
@motivoModificacion varchar(50)    AS      IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL




UPDATE PAPERLESS_ASIGNACION SET   NumMaster = @NumMaster,
 FechaMaster = @FechaMaster,   
 IdAgente = @IdAgente,   
 IdNaviera = @IdNaviera,
 IdNave = @IdNave ,   
 Viaje = @Viaje,   
 NumHousesBL = @NumHouses,   
 IdTipoCarga = @IdTipoCarga,   
 FechaPaso1 = GETDATE(),   
 IdTipoServicio = @IdTipoServicio,   
 MotivoModificacion = @motivoModificacion ,
 IdNaveTransbordo=  @IdNaveTransbordo,
 empresa= @CodEmpresa,
 numContenedor= @NumContenedor
 
WHERE Id = @IdAsignacion

GO


Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('HBL FALTANTE',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('CBM',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('CONSIGNEE',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('CNPJ HOUSE',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('CNPJ MASTER',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('CONTAINER',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('DATA DO HBL',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('DATA DO MASTER',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('DESCRIÇÃO',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('EMBALAGEM',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('FALTA DE MASTER',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('FINAL DESTINATION',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('FRETE',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('MOEDA',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('NOMENCLATURA',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('NOTIFY',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('ORIGEN',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('PORT OF LOADING',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('PORTO DE DESTINO',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('QUANTIDADE',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('RO INCOMPLETA',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('SI INCOMPLETA',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('TAXAS',1,'FCL')
Insert into PAPERLESS_TIPO_EXCEPCIONES  (descripcion,activo,tipo)  values ('POD',1,'FCL')

GO



Insert into USUARIOS_PERFILES values(91,16,0)
Insert into USUARIOS_PERFILES values(111,16,0)
Insert into USUARIOS_PERFILES values(114,16,0)
Insert into USUARIOS_PERFILES values(115,16,0)
Insert into USUARIOS_PERFILES values(118,16,0)
Insert into USUARIOS_PERFILES values(119,16,0)
Insert into USUARIOS_PERFILES values(120,16,0)
Insert into USUARIOS_PERFILES values(126,16,0)
Insert into USUARIOS_PERFILES values(139,16,0)
Insert into USUARIOS_PERFILES values(146,16,0)
Insert into USUARIOS_PERFILES values(149,16,0)
Insert into USUARIOS_PERFILES values(130,16,0)
GO


Insert into USUARIOS_PERFILES values(90,17,0)
Insert into USUARIOS_PERFILES values(93,17,0)
Insert into USUARIOS_PERFILES values(95,17,0)
Insert into USUARIOS_PERFILES values(98,17,0)
Insert into USUARIOS_PERFILES values(99,17,0)
Insert into USUARIOS_PERFILES values(100,17,0)
Insert into USUARIOS_PERFILES values(101,17,0)
Insert into USUARIOS_PERFILES values(102,17,0)
Insert into USUARIOS_PERFILES values(104,17,0)
Insert into USUARIOS_PERFILES values(105,17,0)
Insert into USUARIOS_PERFILES values(108,17,0)
Insert into USUARIOS_PERFILES values(112,17,0)
Insert into USUARIOS_PERFILES values(125,17,0)
Insert into USUARIOS_PERFILES values(135,17,0)
Insert into USUARIOS_PERFILES values(138,17,0)
Insert into USUARIOS_PERFILES values(140,17,0)
Insert into USUARIOS_PERFILES values(124,17,0)
Insert into USUARIOS_PERFILES values(130,17,0)

GO
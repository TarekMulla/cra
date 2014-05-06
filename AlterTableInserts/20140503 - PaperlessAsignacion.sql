if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'numContenedor')
Begin
		alter table  PAPERLESS_ASIGNACION add  numContenedor int  
	
END
GO



USE [scc_brasil]
GO

/****** Object:  StoredProcedure [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]    Script Date: 05/04/2014 02:51:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]
GO

USE [scc_brasil]
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



USE [scc_brasil]
GO

/****** Object:  StoredProcedure [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]    Script Date: 05/04/2014 03:09:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]
GO

USE [scc_brasil]
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




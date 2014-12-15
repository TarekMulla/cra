
-- Se crean 2 estados: Aceptado Por Usuario 2da Etapa, Rechazada Usuario 2da Etapa

INSERT INTO PAPERLESS_ESTADO(Descripcion,Activo,PasoAnterior,PasoSiguiente)
VALUES ('Aceptado Por Usuario 2da Etapa',1,5,7)
GO
INSERT INTO PAPERLESS_ESTADO(Descripcion,Activo,PasoAnterior,PasoSiguiente)
VALUES ('Rechazada Usuario 2da Etapa',1,5,7)
GO

-- Se crea nuevo campo tipoUsuario en tabla PAPERLESS_ASIGNACION_RECHAZO por que ahora se almacenaran
-- también los rechazos del usuario2, antes solo se almacenaban los del usuario1. Con esto se podrá identificar el usuario

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION_RECHAZO' and name = 'tipoUsuario')
Begin
		alter table  PAPERLESS_ASIGNACION_RECHAZO add  tipoUsuario int  
	
END
GO

-- Se inicializa el campo tipoUsuario para los registros que ya existían en la tabla
update PAPERLESS_ASIGNACION_RECHAZO set tipoUsuario=1
GO


-- Se modifica procedimiento para grabar ahora el tipo de usuario en la tabla PAPERLESS_ASIGNACION_RECHAZO
DROP PROCEDURE SP_N_PAPERLESS_ASIGNACION_RECHAZO
GO

CREATE PROCEDURE SP_N_PAPERLESS_ASIGNACION_RECHAZO
@IdAsignacion bigint,
@IdUsuario bigint,
@Motivo nvarchar(4000),
@tipoUsuario int

AS

INSERT INTO PAPERLESS_ASIGNACION_RECHAZO
(IdAsignacion,FechaRechazo,IdUsuario,Motivo,tipoUsuario)
VALUES(
@IdAsignacion,GETDATE(),@IdUsuario,@Motivo,@tipoUsuario
)

GO

--Se modifica procedimiento que modifica estado de la asignación. Se incorporan los estados
--Aceptado Por Usuario 2da Etapa, Rechazada Usuario 2da Etapa 

DROP PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_ESTADo] 
GO

CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_ESTADo] 
                @IdEstado INT,                                    
                @IdAsignacion BIGINT,
                @IdResultado INT OUTPUT,
                @Resultado VARCHAR(255) OUTPUT
AS 
                                             

DECLARE @IdEstadoActual INT

SELECT @IdEstadoActual = IdEstado
FROM paperless_asignacion
WHERE id=@IdAsignacion

SELECT @IdResultado=0, @Resultado=''

-- Valida q la modificación de estados sea consistente con el flujo de proceso.
/*
 1      Nuevo                          
 2      En Asignacion                  
 3      Asignado Usuario 1ra Etapa     
 4      Aceptado Por Usuario 1ra Etapa 
 5      En Proceso Usuario 1ra Etapa   
 6      Enviado Usuario 2da Etapa      
 7      En Proceso Usuario 2da Etapa   
 8      Proceso Terminado              
 9      Rechazada Usuario 1ra Etapa    
10      Enviado a Mercante
11      Aceptado Por Usuario 2da Etapa 
12      Rechazada Usuario 2da Etapa 

*/


IF (@IdEstado=9 or @idEstado=10 or @idEstado=8 or @idEstado=11 or @idEstado= 12)
BEGIN
    UPDATE PAPERLESS_ASIGNACION                       
SET IdEstado = @IdEstado                   
       
WHERE Id = @IdAsignacion  
SELECT @IdResultado=1
        RETURN 0
END     

 --Unica excepción en la secuencia de ids
IF @IdEstado=9 and @IdEstadoActual<>3
    BEGIN
        SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)
        SELECT @IdResultado=1
        RETURN 0
    END
ELSE
    BEGIN
        IF (@IdEstado <> @IdEstadoActual)
            BEGIN
                IF (@IdEstado <> @IdEstadoActual + 1) 
                BEGIN
                    SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)

                    SELECT @IdResultado=1
                    RETURN 0
                END
            END
        END

UPDATE PAPERLESS_ASIGNACION                       
SET IdEstado = @IdEstado                          
WHERE Id = @IdAsignacion  

-- Marca la fecha/hora de aceptación del usuario
IF @IdEstado=5
BEGIN
    UPDATE PAPERLESS_ASIGNACION            
    SET FechaAceptacionUsr1 = getdate()                          
    WHERE Id = @IdAsignacion  
END     
                                        
                                                                                               

RETURN 0


-- Se modifica procedimiento que graba paso 3 de la asignacion, cuando usuario2 rechaza una asignación.


DROP PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO3] 
GO

CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO3] 
                    @IdUsuario1 int,                                 
                    @ObservacionUsuario1 nvarchar(4000),             
                    @IdImportancia int,                  
            
                    @IdUsuario2 int,                                 
                    @ObservacionUsuario2 nvarchar(4000),             
                    @IdEstado int,                                   
                    @IdAsignacion bigint,
                    @IdResultado INT OUTPUT,
                    @Resultado VARCHAR(255) OUTPUT

AS                                               

DECLARE @IdEstadoActual INT

SELECT @IdResultado=0, @Resultado=''

SELECT @IdEstadoActual = IdEstado
FROM paperless_asignacion
WHERE id=@IdAsignacion

-- Valida q la modificación de estados sea consistente con el flujo de proceso.
/*
 1      Nuevo                          
 2      En Asignacion                  
 3      Asignado Usuario 1ra Etapa    
 
 4      Aceptado Por Usuario 1ra Etapa 
 5      En Proceso Usuario 1ra Etapa   
 6      Enviado Usuario 2da Etapa      
 7      En Proceso Usuario 2da Etapa   
 8      Proceso Terminado              
 9      Rechazada Usuario 1ra Etapa 
 12     Rechazada Usuario 2da Etapa 
*/

--quiere decir que hubo cancelacion por usuario1 o cancelacion por usuario2
IF (@IdEstado=3 and @IdEstadoActual=9)or(@IdEstado=6 and @IdEstadoActual=12)
    BEGIN
    UPDATE PAPERLESS_ASIGNACION SET                  
    Usuario1 = @IdUsuario1,                          
    ObservacionUsuario1 = @ObservacionUsuario1,      
    IdImportancia = @IdImportancia,                  
    Usuario2 = @IdUsuario2,                          
     ObservacionUsuario2 = @ObservacionUsuario2,      
     IdEstado = @IdEstado,                            
     FechaPaso3 = GETDATE()                           
  
   WHERE Id = @IdAsignacion      
        SELECT @IdResultado=1
        RETURN 0
    END
    
-- Unica excepción en la secuencia de ids
IF @IdEstado=9 and @IdEstadoActual<>3
    BEGIN
        SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)
        SELECT @IdResultado=1
        RETURN 0
    END
ELSE
    BEGIN
        IF (@IdEstado <> @IdEstadoActual)
            BEGIN
          
      IF (@IdEstado <> @IdEstadoActual + 1) 
                BEGIN
                    SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)
                    SELECT @IdResultado=1
                    RETURN 0
                END
            END
        END

UPDATE PAPERLESS_ASIGNACION SET                  
    Usuario1 = @IdUsuario1,                          
    ObservacionUsuario1 = @ObservacionUsuario1,      
    IdImportancia = @IdImportancia,                  
    Usuario2 = @IdUsuario2,                          
     ObservacionUsuario2 = @ObservacionUsuario2,      
     IdEstado = @IdEstado,                            
    
 FechaPaso3 = GETDATE()                           
     WHERE Id = @IdAsignacion                                                                               
     
RETURN 0


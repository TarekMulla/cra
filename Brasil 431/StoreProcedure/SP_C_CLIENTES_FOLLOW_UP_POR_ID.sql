ALTER PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_ID]
@IdCliente bigint

AS

SELECT 
A.Id,
FechaFollowUp ,
B.Id IdActividad,
B.Descripcion Actividad,
B.Alias Alias,
A.Descripcion,
A.FechaCreacion,
C.Id IdUsuario,
C.Nombres,
C.ApellidoPaterno,
C.ApellidoMaterno,
A.IdClienteMaster,
A.IdLlamadaTelefonica,
A.IdInformeVisita,
A.idtarget,
A.activo ,
A.idSLead
FROM CLIENTES_FOLLOW_UP A
LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
ON A.IdTipoActividadSiguiente = B.Id
INNER JOIN USUARIOS C
ON A.IdUsuario = C.Id
WHERE A.IdClienteMaster = @IdCliente

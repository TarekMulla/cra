create Procedure [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_PUERTOS_POR_ID_OPCION]
    @idOpcion bigint
as 
begin
    select a.id,a.puerto,a.tipo,b.nombre
from 
dbo.COTIZACION_DIRECTA_OPCIONES_PUERTOS as a,Puertos as b
where b.codigo = a.puerto
and cotizacion_directa_opciones_id = @idOpcion
end
GO
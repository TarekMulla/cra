alter PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_HOUSEBL_SHIPPING] 
@Shipping varchar (20),
@Puerto varchar (20)
AS  


declare @sql varchar(4000)

set @sql = ' SELECT '
set @sql += 'PHBL.Id, '
set @sql += 'PHBL.IdAsignacion, '
set @sql += 'IndexHouse, '
set @sql += 'HouseBL, '
set @sql += 'Freehand, '
set @sql += 'Ruteado, '
set @sql += 'IdCliente, '
set @sql += 'IdTipoCliente, '
set @sql += 'TC.Descripcion '
set @sql += 'TipoCliente, '
set @sql += 'EmbarcadorContactado, '
set @sql += 'ReciboAperturaEmbarcador, '
set @sql += 'FechaReciboAperturaEmbarcador, '
set @sql += 'TipoReciboAperturaEmbarcador, '
set @sql += 'PE.RecargoCollect,  '
set @sql += 'PE.Id IdExcepcion, '
set @sql += 'PHBL.Observacion, '
set @sql += 'cc.PaperlessTipoRecibo, '
set @sql += 'PHBL.Shippinginstruction, '
set @sql += 'PHBL.Puerto '
set @sql += ',PA.NumMaster '
set @sql += 'FROM PAPERLESS_USUARIO1_HOUSESBL PHBL '
SET @SQL += 'LEFT JOIN PAPERLESS_ASIGNACION PA ON PHBL.IDASIGNACION = PA.ID '
set @sql += 'LEFT OUTER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC ON PHBL.IdTipoCliente = TC.Id '
set @sql += 'LEFT OUTER JOIN PAPERLESS_USUARIO1_EXCEPCIONES PE ON PHBL.Id = PE.IdHouseBL '
set @sql += 'LEFT join CLIENTES_CUENTA cc on cc.IdMaster=IdCliente '
set @sql += 'WHERE PHBL.Id > 0 '

if (@Puerto is not null and @Puerto <> '')  
set @sql += 'and PHBL.IdAsignacion in (select distinct IdAsignacion from PAPERLESS_USUARIO1_HOUSESBL where puerto = '''+@Puerto+''')'

if (@Shipping is not null and @Shipping <> '')  
set @sql += 'and PHBL.IdAsignacion in (select distinct IdAsignacion from PAPERLESS_USUARIO1_HOUSESBL where ShippingInstruction = '''+@Shipping+''')'



set @sql += ' ORDER BY IdAsignacion,IndexHouse'
print @sql
execute(@sql)

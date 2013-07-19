Create Procedure SP_L_Paperless_Estado_Integracion
@nummaster varchar (100)
as

/*
exec SP_L_Paperless_Estado_Integracion	'HLCURTM130713895' --retorna 0 Cerrado
go
exec SP_L_Paperless_Estado_Integracion 'NYKS6062789840' -- Retorna 1 Abierto
go		
exec SP_L_Paperless_Estado_Integracion	'HLCURTM130713895_NoExiste'--Retorna -1 no existe
go
*/

declare @existe int 
select @existe = 0

select @existe = (select COUNT (*) from paperless_asignacion where NumMaster = @nummaster)

if (@existe =1 )
begin 
select Case idestado
			When '8' Then 1
			When null	Then -1		
			Else 0
		End as 'Asig_1_cerrada_0_abierta'
		from paperless_asignacion where NumMaster = @nummaster
end 
else 
select -1 as 'Asig_1_cerrada_0_abierta'
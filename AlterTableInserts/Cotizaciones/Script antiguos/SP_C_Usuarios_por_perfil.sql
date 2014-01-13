ALTER  PROCEDURE [dbo].[SP_C_USUARIOS_POR_PERFIL]

@ID_PERFIL bigint
as
begin
select c.id
FROM perfiles A LEFT OUTER JOIN usuarios_perfiles B
     ON A.id=b.id_perfil
        LEFT OUTER JOIN usuarios C
			on b.id_usuario = C.id
where A.id=@ID_PERFIL
END

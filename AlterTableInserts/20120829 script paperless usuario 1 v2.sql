select  NombreUsuario,Nombres,ApellidoPaterno,ApellidoMaterno, IdCargo, PERFILES.Id as id_perfil,PERFILES.nombre as nombre_perfil
from usuarios, USUARIOS_PERFILES,PERFILES
where USUARIOS.Id = USUARIOS_PERFILES.ID_USUARIO
and USUARIOS_PERFILES.ID_PERFIL = PERFILES.Id

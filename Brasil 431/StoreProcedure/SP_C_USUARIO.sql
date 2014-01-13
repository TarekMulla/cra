ALTER PROCEDURE  [dbo].[SP_C_USUARIO]
    @estado int	,
    @IdCargo int
AS
    
IF @estado = -1 SET @estado = null
IF @IdCargo = -1 SET @IdCargo = null

IF @IdCargo=20
BEGIN
    SELECT     
        dbo.USUARIOS.Id, 
        dbo.USUARIOS.Nombres, 
        dbo.USUARIOS.ApellidoPaterno, 
        dbo.USUARIOS.ApellidoMaterno, 
        dbo.USUARIOS.NombreUsuario, 
        dbo.USUARIOS.Estado, 
        dbo.USUARIOS.FechaCreacion, 
        dbo.USUARIOS.Email,
        20 AS IdCargo, 
        'Usuario Sales Lead'
    FROM dbo.USUARIOS 
    WHERE USUARIOS.Id in (27,51)
    ORDER BY dbo.USUARIOS.Nombres, 
        dbo.USUARIOS.ApellidoPaterno, 
        dbo.USUARIOS.ApellidoMaterno                                     
END
ELSE IF @IdCargo is null
BEGIN
 SELECT distinct 
        dbo.USUARIOS.Id, 
        dbo.USUARIOS.Nombres, 
        dbo.USUARIOS.ApellidoPaterno, 
        dbo.USUARIOS.ApellidoMaterno, 
        dbo.USUARIOS.NombreUsuario, 
        dbo.USUARIOS.Estado, 
        dbo.USUARIOS.FechaCreacion, 
        dbo.USUARIOS.Email,
        '1' AS IdCargo, --se retorna 0 para poder hacer el distinct al cargar todos los usuarios.
        'Todos' as nombre--dbo.PERFILES.nombre
    FROM dbo.USUARIOS INNER JOIN dbo.USUARIOS_PERFILES ON dbo.USUARIOS.Id = dbo.USUARIOS_PERFILES.ID_USUARIO
    INNER JOIN PERFILES on PERFILES.Id = USUARIOS_PERFILES.ID_PERFIL
    WHERE USUARIOS.Estado = isnull(@estado, USUARIOS.Estado)
    AND PERFILES.Id= isnull(@IdCargo,PERFILES.Id)
      ORDER BY dbo.USUARIOS.Nombres, 
    dbo.USUARIOS.ApellidoPaterno, 
    dbo.USUARIOS.ApellidoMaterno
END
ELSE 
BEGIN
    SELECT     
        dbo.USUARIOS.Id, 
        dbo.USUARIOS.Nombres, 
        dbo.USUARIOS.ApellidoPaterno, 
        dbo.USUARIOS.ApellidoMaterno, 
        dbo.USUARIOS.NombreUsuario, 
        dbo.USUARIOS.Estado, 
        dbo.USUARIOS.FechaCreacion, 
        dbo.USUARIOS.Email,
        dbo.USUARIOS_PERFILES.ID_PERFIL AS IdCargo, 
        dbo.PERFILES.nombre
    FROM dbo.USUARIOS INNER JOIN dbo.USUARIOS_PERFILES ON dbo.USUARIOS.Id = dbo.USUARIOS_PERFILES.ID_USUARIO
    INNER JOIN PERFILES on PERFILES.Id = USUARIOS_PERFILES.ID_PERFIL
    WHERE USUARIOS.Estado = isnull(@estado, USUARIOS.Estado)
    AND PERFILES.Id= isnull(@IdCargo,PERFILES.Id)
      ORDER BY dbo.USUARIOS.Nombres, 
    dbo.USUARIOS.ApellidoPaterno, 
    dbo.USUARIOS.ApellidoMaterno
END

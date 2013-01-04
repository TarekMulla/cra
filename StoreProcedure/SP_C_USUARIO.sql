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
        dbo.USUARIOS_CARGO.Id AS IdCargo, 
        dbo.USUARIOS_CARGO.Descripcion
    FROM dbo.USUARIOS INNER JOIN dbo.USUARIOS_CARGO ON dbo.USUARIOS.IdCargo = dbo.USUARIOS_CARGO.Id
    WHERE USUARIOS.Estado = isnull(@estado, USUARIOS.Estado)
    AND USUARIOS.IdCargo = isnull(@IdCargo,USUARIOS.IdCargo)
    ORDER BY dbo.USUARIOS.Nombres, 
    dbo.USUARIOS.ApellidoPaterno, 
    dbo.USUARIOS.ApellidoMaterno                                     
END
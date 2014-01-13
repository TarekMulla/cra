ALTER PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_HOUSESBL]
@IdAsignacion bigint, 
@Index int, 
@HouseBL nvarchar(100), 
@Freehand bit,
@IdCliente bigint,
@IdTipoCliente int,
@ShippingInstruction varchar (20),
@Puerto varchar (20)


As

INSERT INTO PAPERLESS_USUARIO1_HOUSESBL
(IdAsignacion,IndexHouse,HouseBL, Freehand, IdCliente,IdTipoCliente,ShippingInstruction,Puerto)
VALUES(
   @IdAsignacion, @Index, @HouseBL, @Freehand,@IdCliente,@IdTipoCliente,@ShippingInstruction,@Puerto
)

SELECT SCOPE_IDENTITY()
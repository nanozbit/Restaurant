USE [SiberianDB]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Restaurante]    Script Date: 10/3/2021 8:27:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Restaurante] (
										@TipoOperacion NVARCHAR(20),								
										@NombreRestaurante nvarchar(60)='Restaurant',
										@IdCiudad integer = 0,
										@NumeroAforo integer = 0,
										@Telefono nvarchar(10) = '099999998',
										@IdRestaurante integer = 0
										
								)
AS
Declare 
@FechaCreacion datetime = GETDATE()

BEGIN
	if @TipoOperacion = 'INSERT'
	BEGIN 
		INSERT INTO dbo.Restaurante(NombreRestaurante,
									NumeroAforo,
									Telefono,
									FechaCreacion,
									IdCiudad
									)

									VALUES(@NombreRestaurante,
										@NumeroAforo,
										@Telefono,
										@FechaCreacion,
										@IdCiudad
										);
										
			
	END

	IF @TipoOperacion = 'LISTALLRESTAURANTS'
	BEGIN
		SELECT * FROM dbo.Restaurante;

	END
	IF @TipoOperacion = 'FILTERESTAURANT'
	BEGIN
		SELECT * FROM dbo.Restaurante WHERE IdRestaurante = @IdRestaurante;
	END
	IF @TipoOperacion = 'DELETE'
	BEGIN
		DELETE FROM Restaurante WHERE Restaurante.IdRestaurante=@IdRestaurante;
	END
	IF @TipoOperacion = 'UPDATE'
	BEGIN
		UPDATE Restaurante
		SET NombreRestaurante = @NombreRestaurante,
			NumeroAforo= @NumeroAforo,
			Telefono = @Telefono,
			IdCiudad = @IdCiudad
		WHERE IdRestaurante = @IdRestaurante;
	END
END

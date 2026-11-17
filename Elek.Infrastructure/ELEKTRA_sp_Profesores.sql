USE ELEKTRA
GO
CREATE PROCEDURE sp_Profesores_CRUD
@Accion VARCHAR(50),
@Nombre VARCHAR(50) = NULL,
@Apellido VARCHAR(100) = NULL,
@IdEscuela INT = NULL,
@UUID VARCHAR(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	IF @Accion = 'INSERT'
	BEGIN
		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 1;
		END
		IF @Apellido = ''
		BEGIN			
			THROW 50002, 'El Apellido no puede estar vacio', 2;
		END
		--VALIDAR SI LA ESCUELA EXISTA		
		IF NOT EXISTS (SELECT TOP 1 1 FROM Escuelas WHERE Id = @IdEscuela)
		BEGIN			
			THROW 50003, 'La Escuela ingresada no existe', 3;
		END
		INSERT INTO Profesores(Nombre,Apellido,IdEscuela,UUID) 
		OUTPUT INSERTED.*
		VALUES (@Nombre,@Apellido,@IdEscuela,@UUID)
	END

	ELSE IF @Accion = 'GET_ALL'
	BEGIN
		SELECT*FROM Profesores
	END

	ELSE IF @Accion = 'GET_UUID'
	BEGIN
		SELECT*FROM Profesores WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'GET_CUSTOM'
	BEGIN
		SELECT*FROM Profesores WHERE 
		(@Nombre IS NOT NULL AND @Nombre <> '' AND Nombre LIKE '%' + @Nombre + '%')
		OR
		(@Apellido IS NOT NULL AND @Apellido <> '' AND Apellido LIKE '%' + @Apellido + '%');
	END

	ELSE IF @Accion = 'UPDATE'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Profesores WHERE UUID = @UUID)
		BEGIN
			THROW 50004, 'No existe el profesor', 4;			
		END

		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 1;
		END

		IF @Apellido = ''
		BEGIN			
			THROW 50002, 'El Apellido no puede estar vacio', 2;
		END

		IF NOT EXISTS (SELECT TOP 1 1 FROM Escuelas WHERE Id = @IdEscuela)
		BEGIN			
			THROW 50003, 'La Escuela ingresada no existe', 3;
		END
		UPDATE Profesores SET Nombre = @Nombre, Apellido = @Apellido, IdEscuela = @IdEscuela
		OUTPUT INSERTED.*
		WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'UPDATE_NAME'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Profesores WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe el profesor', 1;			
		END

		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 2;
		END
		UPDATE Profesores SET Nombre = @Nombre 
		OUTPUT INSERTED.*
		WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'UPDATE_SUB'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Profesores WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe el profesor', 1;			
		END

		IF @Apellido = ''
		BEGIN			
			THROW 50002, 'El Apellido no puede estar vacio', 2;
		END

		UPDATE Profesores SET Apellido = @Apellido 
		OUTPUT INSERTED.*
		WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'UPDATE_ESC'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Profesores WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe el profesor', 1;			
		END

		IF NOT EXISTS (SELECT TOP 1 1 FROM Escuelas WHERE Id = @IdEscuela)
		BEGIN			
			THROW 50003, 'La Escuela ingresada no existe', 3;
		END

		UPDATE Profesores SET IdEscuela = @IdEscuela 
		OUTPUT INSERTED.*
		WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'DELETE'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Profesores WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe el profesor', 1;			
		END
		DELETE FROM Profesores 
		OUTPUT DELETED.*
		WHERE UUID = @UUID;
	END

	ELSE
	BEGIN
		THROW 50005, 'Accion no valida', 1;
	END

END
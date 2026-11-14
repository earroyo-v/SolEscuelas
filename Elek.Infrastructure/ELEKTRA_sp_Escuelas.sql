USE ELEKTRA
GO
CREATE PROCEDURE sp_Escuelas_CRUD
@Accion VARCHAR(50),
@Nombre VARCHAR(50) = NULL,
@Descripcion VARCHAR(100) = NULL,
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
		INSERT INTO Escuelas (Nombre,Descripcion,UUID) 
		OUTPUT INSERTED.*
		VALUES (@Nombre,@Descripcion,@UUID)
	END

	ELSE IF @Accion = 'GET_ALL'
	BEGIN
		SELECT*FROM Escuelas
	END

	ELSE IF @Accion = 'GET_UUID'
	BEGIN
		SELECT*FROM Escuelas WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'GET_CUSTOM'
	BEGIN
		SELECT*FROM Escuelas WHERE 
		(@Nombre IS NOT NULL AND @Nombre <> '' AND Nombre LIKE '%' + @Nombre + '%')
		OR
		(@Descripcion IS NOT NULL AND @Descripcion <> '' AND Descripcion LIKE '%' + @Descripcion + '%');
	END

	ELSE IF @Accion = 'UPDATE'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Escuelas WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe la Escuela requerida', 1;			
		END

		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 2;
		END
		UPDATE Escuelas SET Nombre = @Nombre, Descripcion = @Descripcion WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'UPDATE_NAME'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Escuelas WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe la Escuela requerida', 1;			
		END

		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 2;
		END
		UPDATE Escuelas SET Nombre = @Nombre WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'UPDATE_DESC'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Escuelas WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe la Escuela requerida', 1;			
		END
		UPDATE Escuelas SET Descripcion = @Descripcion WHERE UUID = @UUID
	END

	ELSE IF @Accion = 'DELETE'
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Escuelas WHERE UUID = @UUID)
		BEGIN
			THROW 50002, 'No existe la Escuela requerida', 1;			
		END
		DELETE FROM Escuelas 
		OUTPUT DELETED.*
		WHERE UUID = @UUID;
	END

	ELSE
	BEGIN
		THROW 50003, 'Accion no valida', 1;
	END

END
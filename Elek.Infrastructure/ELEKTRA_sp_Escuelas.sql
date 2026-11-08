CREATE PROCEDURE sp_Escuelas_CRUD
@Accion VARCHAR(50),
@Nombre VARCHAR(50),
@Descripcion VARCHAR(100),
@UUID VARCHAR(100)
AS
BEGIN
	IF @Accion = 'INSERT'
	BEGIN
		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 1;
		END
		INSERT INTO Escuelas (Nombre,Descripcion) VALUES
		(@Nombre,@Descripcion)
	END
	IF @Accion = 'READ'
	BEGIN
		SELECT*FROM Escuelas WHERE Nombre = @Nombre OR Descripcion = @Descripcion
	END
	IF @Accion = 'UPDATE'
	BEGIN
		IF @Nombre = ''
		BEGIN			
			THROW 50001, 'El Nombre no puede estar vacio', 1;
		END
		UPDATE Escuelas SET  WHERE UUID = @UUID
	END
END
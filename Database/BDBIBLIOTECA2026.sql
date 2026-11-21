USE BDBIBLIOTECA2026
GO

CREATE TABLE dbo.Libros 
( 
Id INT IDENTITY(1,1) PRIMARY KEY, 
NombreLibro VARCHAR(120) NOT NULL, 
Autor VARCHAR(100) NOT NULL, 
NombreEditorial VARCHAR(100) NOT NULL, 
ISDN VARCHAR(20) NOT NULL 
) 
GO

INSERT INTO dbo.Libros (NombreLibro, Autor, NombreEditorial, ISDN)
VALUES
    ('Cien años de soledad', 'Gabriel García Márquez', 'Editorial Sudamericana', '978-0307474728'),
    ('Don Quijote de la Mancha', 'Miguel de Cervantes', 'Francisco de Robles', '978-8424116176'),
    ('1984', 'George Orwell', 'Secker & Warburg', '978-0451524935'),
    ('El principito', 'Antoine de Saint-Exupéry', 'Reynal & Hitchcock', '978-0156012195'),
    ('Rayuela', 'Julio Cortázar', 'Editorial Sudamericana', '978-8420471839'),
    ('Fahrenheit 451', 'Ray Bradbury', 'Ballantine Books', '978-1451673319'),
    ('La sombra del viento', 'Carlos Ruiz Zafón', 'Editorial Planeta', '978-8408172178'),
    ('Orgullo y prejuicio', 'Jane Austen', 'T. Egerton', '978-0141439518'),
    ('Crónica de una muerte anunciada', 'Gabriel García Márquez', 'Editorial La Oveja Negra', '978-1400034956'),
    ('El hobbit', 'J.R.R. Tolkien', 'George Allen & Unwin', '978-0547928227');
GO


CREATE PROCEDURE dbo.usp_ListarLibros
AS
BEGIN
    SELECT Id, NombreLibro, Autor, NombreEditorial, ISDN
    FROM dbo.Libros
    ORDER BY Id;
END;
GO

CREATE PROCEDURE dbo.usp_RegistrarLibro
    @NombreLibro VARCHAR(120),
    @Autor VARCHAR(100),
    @NombreEditorial VARCHAR(100),
    @ISDN VARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.Libros (NombreLibro, Autor, NombreEditorial, ISDN)
    VALUES (@NombreLibro, @Autor, @NombreEditorial, @ISDN);
END;
GO

--actualizar libro sp
USE BDBIBLIOTECA2026;
GO

CREATE PROCEDURE dbo.usp_ActualizarLibro
    @Id INT,
    @NombreLibro VARCHAR(120),
    @Autor VARCHAR(100),
    @NombreEditorial VARCHAR(100),
    @ISDN VARCHAR(20)
AS
BEGIN
    UPDATE dbo.Libros
    SET NombreLibro = @NombreLibro,
        Autor = @Autor,
        NombreEditorial = @NombreEditorial,
        ISDN = @ISDN
    WHERE Id = @Id;
END;
GO

--eliminar por id sp
USE BDBIBLIOTECA2026;
GO
CREATE PROCEDURE dbo.usp_EliminarLibro
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Libros
    WHERE Id = @Id;
END;
GO

--sp busqueda parcial por autor
USE BDBIBLIOTECA2026;
GO
CREATE PROCEDURE dbo.usp_ListarLibrosPorAutor
    @Autor VARCHAR(100)
AS
BEGIN
    SELECT Id, NombreLibro, Autor, NombreEditorial, ISDN
    FROM dbo.Libros
    WHERE Autor LIKE '%' + @Autor + '%'
    ORDER BY Id;
END;
GO

--ejecucion del sp listarLibros
EXEC dbo.usp_ListarLibros;

-- ejecucion del sp con datos de prueba
EXEC dbo.usp_RegistrarLibro
    @NombreLibro = 'Libro de prueba',
    @Autor = 'Autor de prueba',
    @NombreEditorial = 'Editorial de prueba',
    @ISDN = '12345';

EXEC dbo.usp_ListarLibros;
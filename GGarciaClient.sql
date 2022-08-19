CREATE DATABASE GGarciaClient

USE GGarciaClient



CREATE TABLE Profesor 
(
IdProfesor INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
Sueldo DECIMAL

);




INSERT INTO Profesor VALUES ('Sergio','Salinas','Andrade',5000)




SELECT*FROM Profesor

CREATE PROCEDURE ProfesorAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sueldo DECIMAL
AS
INSERT INTO Profesor (Nombre,ApellidoPaterno,ApellidoMaterno,Sueldo) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sueldo)

GO

ProfesorAdd 'Ana','Torres','Ortiz',8800




SELECT*FROM Profesor

CREATE PROCEDURE ProfesorUpdate
@IdProfesor INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sueldo DECIMAL
AS
UPDATE Profesor SET Nombre=@Nombre,ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno,Sueldo=@Sueldo 
WHERE IdProfesor=@IdProfesor
GO


ProfesorUpdate 2,'Laura','Torres','Ortiz',8800



SELECT*FROM Profesor
CREATE PROCEDURE ProfesorDelete
@IdProfesor INT
AS

DELETE FROM Profesor
WHERE IdProfesor=@IdProfesor
GO





ProfesorDelete 2


CREATE PROCEDURE ProfesorGetAll
AS
SELECT [IdProfesor]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[Sueldo]
  FROM [Profesor]
GO
ProfesorGetAll




CREATE PROCEDURE ProfesorGetById
@IdProfesor INT
AS
SELECT [IdProfesor]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[Sueldo]
  FROM [Profesor]


  WHERE IdProfesor=@IdProfesor
GO

ProfesorGetById 1

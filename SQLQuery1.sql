CREATE TABLE Personas (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nombres VARCHAR(50) NOT NULL,
  apellidos VARCHAR(50) NOT NULL,
  num_identificacion VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  tipo_identificacion VARCHAR(10) NOT NULL,
  fecha_creacion DATETIME2 NOT NULL DEFAULT GETDATE(),
  num_identificacion_tipo AS (CONCAT(num_identificacion, '-', tipo_identificacion)) PERSISTED,
  nombres_apellidos AS (CONCAT(nombres, ' ', apellidos)) PERSISTED
);
GO
CREATE PROCEDURE ConsultarPersonas
AS
BEGIN
  SELECT * FROM Personas;
END
GO
CREATE TABLE Usuario (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  usuario VARCHAR(50) NOT NULL,
  pass VARCHAR(50) NOT NULL,
  fecha_creacion DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO
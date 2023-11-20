CREATE DATABASE EQUIPOCOMPUTO;
GO

USE EQUIPOCOMPUTO;
GO

CREATE TABLE USUARIOS
(
	UsuarioID INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	CorreoElectronico VARCHAR(50),
	Telefono VARCHAR(15) UNIQUE
);


CREATE TABLE REPARACIONES
(
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT FOREIGN KEY REFERENCES Equipos(EquipoID),
    FechaSolicitud DATETIME,
    Estado VARCHAR(50)
);

CREATE TABLE Equipos
(
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50),
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE Tecnicos
(
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Especialidad VARCHAR(50)
);

CREATE TABLE Asignaciones
(
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT FOREIGN KEY REFERENCES REPARACIONES(ReparacionID),
    TecnicoID INT FOREIGN KEY REFERENCES Tecnicos(TecnicoID),
    FechaAsignacion DATETIME
);

CREATE TABLE DetallesReparacion
(
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
    Descripcion VARCHAR(50),
    FechaInicio DATETIME,
    FechaFin DATETIME
);
GO
CREATE PROCEDURE AgregarUsuario
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO USUARIOS (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;
GO

CREATE PROCEDURE BorrarUsuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM USUARIOS WHERE UsuarioID = @UsuarioID;
END;
GO

CREATE PROCEDURE ModificarUsuario
    @UsuarioID INT,
    @NuevoNombre VARCHAR(50),
    @NuevoCorreoElectronico VARCHAR(50),
    @NuevoTelefono VARCHAR(15)
AS
BEGIN
    UPDATE USUARIOS
    SET
        Nombre = @NuevoNombre,
        CorreoElectronico = @NuevoCorreoElectronico,
        Telefono = @NuevoTelefono
    WHERE UsuarioID = @UsuarioID;
END;


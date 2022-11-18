CREATE DATABASE STransito
GO
USE STransito
GO
CREATE TABLE Matricula(
Id int identity(1,1),
Numero varchar(20) Primary key,
FechaExpedicion Date,
ValidaHasta Date,
Activo bit
)
GO
CREATE TABLE Conductor(
Id int identity(1,1),
Identificacion varchar(15) primary key,
Nombre varchar(20) not null,
Apellidos varchar(20) not null,
Direccion varchar(30),
Telefono varchar(15),
Email varchar(30),
FechaNacimiento Date,
Activo bit,
IdMatricula varchar(20)
Foreign key references Matricula (Numero)
ON UPDATE CASCADE
)
GO
Create table Sanciones(
Id int identity(1,1),
FechaActual Date Default getdate(),
ConductorId varchar(15)
Foreign key references Conductor (Identificacion),
Sancion varchar(100),
Observacion varchar(MAX),
Valor Decimal(10,2)
)

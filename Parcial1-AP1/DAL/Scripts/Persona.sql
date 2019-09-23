CREATE DATABASE PersonaDb
GO
USE PersonaDb
GO
CREATE TABLE Persona
(
	PersonaId int identity(1,1),
	Matricula varchar(9),
	Nombres varchar(30),
	Apellidos varchar (30),
	Email varchar(30),
	FechaNacimiento date,  
    Sexo int,
	Balance int,
);
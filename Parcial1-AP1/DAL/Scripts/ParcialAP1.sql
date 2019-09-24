CREATE DATABASE ParcialAP1
GO
USE ParcialAP1
CREATE TABLE EstudianteE
(
	ID int identity(1,1),
	Fecha date,  
	Estudiante varchar(9),
	Calificaion int,
	Valor  int,
	Logrado int,
	Perdido int,
	Pronostico int,
	
	
);
create database dbSistemaGestionEmpleados

use dbSistemaGestionEmpleados

create table Empleados(
id int primary key identity (1,1),
nombres varchar(50),
primerapellido varchar(50),
segundoapellido varchar (50),
correo varchar(50),
foto image)



create table Departamentos(
id int primary key identity (1,1),
departamento varchar(50))

create table EmpleadoDepartamento(
idEmpleado int foreign key references Empleados(id),
idDepartamento int foreign key references Departamentos(id))

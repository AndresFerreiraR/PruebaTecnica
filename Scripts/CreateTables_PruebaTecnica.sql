CREATE DATABASE PruebaTecnica

USE [PruebaTecnica]
CREATE TABLE dbo.Company
(
	IdCompany INT NOT NULL IDENTITY,
	Nombre varchar(50) NOT NULL,
	NIT varchar(50) NOT NULL UNIQUE,
	Telefono varchar(18) NULL,
	Contacto varchar(50) NULL,
	CONSTRAINT PK_COMPANY PRIMARY KEY (IdCompany)
)

CREATE TABLE dbo.Producto
(
	IdProducto INT NOT NULL IDENTITY,
	Nombre varchar(50) NOT NULL,
	FK_IdCompany int NOT NULL,
	Descripcion varchar(200) NULL,
	Prima decimal(3,2) NOT NULL,
	ValorAsegurado INT NOT NULL
	CONSTRAINT PK_PRODUCTO PRIMARY KEY (IdProducto),
	CONSTRAINT FK_ID_COMPANY_PRODUCTO FOREIGN KEY (FK_IdCompany) REFERENCES dbo.Company (IdCompany)
)


CREATE TABLE dbo.Cobertura
(
	IdCobertura INT NOT NULL IDENTITY,
	Nombre varchar(50) NOT NULL,
	FK_IdProducto int NOT NULL,
	Descripcion varchar(200) NULL,
	CONSTRAINT PK_COBERTURA PRIMARY KEY (IdCobertura),
	CONSTRAINT FK_ID_PRODUCTO_COBERTURA FOREIGN KEY (FK_IdProducto) REFERENCES dbo.Producto (IdProducto)
)

CREATE TABLE dbo.Cliente
(
	IdCliente INT NOT NULL,
	Nombres varchar(50) NOT NULL,
	Apellidos varchar(50) NOT NULL,
	Numero_Identificacion varchar(20) NOT NULL UNIQUE,
	Fecha_Nacimiento DATE,
	Correo varchar(50),
	Telefono varchar(18) NULL,
	CONSTRAINT PK_CLIENTE PRIMARY KEY (IdCliente)
)



CREATE TABLE dbo.Ventas
(
	IdVentas INT NOT NULL IDENTITY,
	Descripcion varchar(50) NOT NULL,
	FK_IdCliente INT NOT NULL,
	FK_IdProducto INT NOT NULL,
	CONSTRAINT PK_VENTAS PRIMARY KEY (IdVentas),
	CONSTRAINT FK_ID_VENTAS_CLIENTE FOREIGN KEY (FK_IdCliente) REFERENCES dbo.Cliente (IdCliente),
	CONSTRAINT FK_ID_VENTAS_PRODUCTO FOREIGN KEY (FK_IdProducto) REFERENCES dbo.Producto (IdProducto)
)
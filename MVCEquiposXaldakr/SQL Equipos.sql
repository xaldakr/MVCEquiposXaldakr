CREATE DATABASE equipos
GO
USE [equipos]
GO
CREATE TABLE [dbo].[estados_equipo](
	[id_estados_equipo] [int] IDENTITY PRIMARY KEY,
	[descripcion] [varchar](50) NULL,
	[estado] [char](1) NULL,
	)
GO
CREATE TABLE [dbo].[marcas](
	[id_marcas] [int] IDENTITY PRIMARY KEY,
	[nombre_marca] [varchar](50) NULL,
	[estados] [char](1) NULL,
	)
GO
CREATE TABLE [dbo].[tipo_equipo](
	[id_tipo_equipo] [int] IDENTITY PRIMARY KEY,
	[descripcion] [varchar](50) NULL,
	[estado] [char](1) NULL,
	)
GO
CREATE TABLE equipos (
    id_equipos INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(MAX),
    descripcion NVARCHAR(MAX),
    tipo_equipo_id INT,
    marca_id INT,
    modelo NVARCHAR(MAX),
    anio_compra INT,
    costo DECIMAL(18, 2),
    vida_util INT,
    estado_equipo_id INT,
    estado NVARCHAR(MAX),
    FOREIGN KEY (tipo_equipo_id) REFERENCES tipo_equipo(id_tipo_equipo),
    FOREIGN KEY (marca_id) REFERENCES marcas(id_marcas),
    FOREIGN KEY (estado_equipo_id) REFERENCES estados_equipo(id_estados_equipo)
);
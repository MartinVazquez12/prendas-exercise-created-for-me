CREATE DATABASE prendasDB
GO

USE prendasDB
GO

-- Crear tabla Marcas
CREATE TABLE [Marcas]
(
  [Id] uniqueidentifier NOT NULL CONSTRAINT DF_Marcas_Id DEFAULT(NEWID()),
  [Marca] nvarchar(100) NOT NULL,
  CONSTRAINT PK_Marcas PRIMARY KEY (Id)
);

GO

-- Crear tabla Prendas
CREATE TABLE [Prendas]
(
  [Id] uniqueidentifier NOT NULL CONSTRAINT DF_Prendas_Id DEFAULT(NEWID()),
  [Nombre] nvarchar(100) NOT NULL,
  [Talle] nvarchar(50) NOT NULL,
  [Color] nvarchar(50) NOT NULL,
  [Id_Marca] uniqueidentifier NOT NULL CONSTRAINT FK_Prendas_Marcas FOREIGN KEY(Id_Marca) REFERENCES Marcas(Id),
  CONSTRAINT PK_Prendas PRIMARY KEY (Id)
);

GO

-- Inserts de ejemplo para la tabla Marcas
INSERT INTO [Marcas] ([Marca]) VALUES ('Nike');
INSERT INTO [Marcas] ([Marca]) VALUES ('Adidas');
INSERT INTO [Marcas] ([Marca]) VALUES ('Puma');
INSERT INTO [Marcas] ([Marca]) VALUES ('Reebok');
INSERT INTO [Marcas] ([Marca]) VALUES ('Under Armour');

GO

-- Obtener IDs de las marcas insertadas para usarlas en las prendas
DECLARE @NikeId uniqueidentifier = (SELECT Id FROM [Marcas] WHERE [Marca] = 'Nike');
DECLARE @AdidasId uniqueidentifier = (SELECT Id FROM [Marcas] WHERE [Marca] = 'Adidas');
DECLARE @PumaId uniqueidentifier = (SELECT Id FROM [Marcas] WHERE [Marca] = 'Puma');
DECLARE @ReebokId uniqueidentifier = (SELECT Id FROM [Marcas] WHERE [Marca] = 'Reebok');
DECLARE @UnderArmourId uniqueidentifier = (SELECT Id FROM [Marcas] WHERE [Marca] = 'Under Armour');

-- Inserts de ejemplo para la tabla Prendas
INSERT INTO [Prendas] ([Nombre], [Talle], [Color], [Id_Marca]) VALUES ('Camiseta Deportiva', 'M', 'Rojo', @NikeId);
INSERT INTO [Prendas] ([Nombre], [Talle], [Color], [Id_Marca]) VALUES ('Pantalón de Chándal', 'L', 'Negro', @AdidasId);
INSERT INTO [Prendas] ([Nombre], [Talle], [Color], [Id_Marca]) VALUES ('Chaqueta', 'S', 'Azul', @PumaId);
INSERT INTO [Prendas] ([Nombre], [Talle], [Color], [Id_Marca]) VALUES ('Sudadera', 'XL', 'Verde', @ReebokId);
INSERT INTO [Prendas] ([Nombre], [Talle], [Color], [Id_Marca]) VALUES ('Camiseta Deportiva', 'M', 'Blanco', @UnderArmourId);

GO
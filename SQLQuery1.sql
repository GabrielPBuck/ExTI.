-- Create database
CREATE DATABASE ExTI;
GO

-- Use database
USE ExTI;
GO

-- Create table CadClientes
CREATE TABLE CadClientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    NomeCliente VARCHAR(100),
    Sobrenome VARCHAR(100),
    Telefone VARCHAR(20),
    CPF VARCHAR(20)
);
GO

-- Create table CadMaquinas
CREATE TABLE CadMaquinas (
    IdMaquina INT IDENTITY(1,1) PRIMARY KEY,
    Patrimonio INT,
    Memoria VARCHAR(50),
    HD VARCHAR(50)
);
GO

-- Create table Inventario
CREATE TABLE Inventario (
    IdInventario INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT,
    IdMaquina INT,
    Valor VARCHAR(20),
    Quantidade INT
);
GO

-- Select data from tables
SELECT * FROM CadClientes;
SELECT * FROM CadMaquinas;
SELECT * FROM Inventario;

GO

ALTER TABLE Inventario
ADD CONSTRAINT FK_Inventario_CadClientes
FOREIGN KEY (IdCliente) REFERENCES CadClientes(IdCliente);
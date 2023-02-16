
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2023 22:35:08
-- Generated from EDMX file: D:\Porject\project de C#\Practica2\TiendaVirtual\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tienda];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompraProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_CompraProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_StockProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK_StockProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_CompraPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidoes] DROP CONSTRAINT [FK_CompraPedido];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Productoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productoes];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[Compras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compras];
GO
IF OBJECT_ID(N'[dbo].[Pedidoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidoes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Productoes'
CREATE TABLE [dbo].[Productoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [price] float  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [stockQuantity] int  NOT NULL,
    [Producto_Id] int  NOT NULL
);
GO

-- Creating table 'Compras'
CREATE TABLE [dbo].[Compras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [compradoQuantity] bigint  NOT NULL,
    [ProductoId] int  NOT NULL
);
GO

-- Creating table 'Pedidoes'
CREATE TABLE [dbo].[Pedidoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [amount] nvarchar(max)  NOT NULL,
    [time] datetime  NOT NULL,
    [CompraId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [PK_Productoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [PK_Compras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedidoes'
ALTER TABLE [dbo].[Pedidoes]
ADD CONSTRAINT [PK_Pedidoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Producto_Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK_StockProducto]
    FOREIGN KEY ([Producto_Id])
    REFERENCES [dbo].[Productoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockProducto'
CREATE INDEX [IX_FK_StockProducto]
ON [dbo].[Stocks]
    ([Producto_Id]);
GO

-- Creating foreign key on [CompraId] in table 'Pedidoes'
ALTER TABLE [dbo].[Pedidoes]
ADD CONSTRAINT [FK_CompraPedido]
    FOREIGN KEY ([CompraId])
    REFERENCES [dbo].[Compras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompraPedido'
CREATE INDEX [IX_FK_CompraPedido]
ON [dbo].[Pedidoes]
    ([CompraId]);
GO

-- Creating foreign key on [ProductoId] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_ProductoCompra]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoCompra'
CREATE INDEX [IX_FK_ProductoCompra]
ON [dbo].[Compras]
    ([ProductoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
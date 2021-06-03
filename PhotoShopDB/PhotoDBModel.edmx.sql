
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2021 19:16:12
-- Generated from EDMX file: F:\OURS\RGB.PhotoShopDB\PhotoShopDB\PhotoDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PhotoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employee_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Position];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_List_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_List] DROP CONSTRAINT [FK_Order_List_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_List_Service]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_List] DROP CONSTRAINT [FK_Order_List_Service];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Order_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Order_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Service_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Service] DROP CONSTRAINT [FK_Service_Material];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Material]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Material];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Order_List]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_List];
GO
IF OBJECT_ID(N'[dbo].[Order_Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_Status];
GO
IF OBJECT_ID(N'[dbo].[Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Position];
GO
IF OBJECT_ID(N'[dbo].[Service]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Service];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [Id_client] int IDENTITY(1,1) NOT NULL,
    [Lname] nvarchar(100)  NOT NULL,
    [Fname] nvarchar(100)  NOT NULL,
    [Mname] nvarchar(100)  NULL,
    [Phone_number] nchar(12)  NULL,
    [Email] nvarchar(100)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [Id_employee] int IDENTITY(1,1) NOT NULL,
    [Lname] nvarchar(100)  NOT NULL,
    [Fname] nvarchar(100)  NOT NULL,
    [Mname] nvarchar(100)  NULL,
    [Birth_day] datetime  NOT NULL,
    [Id_position] int  NOT NULL,
    [Tel_number] nchar(12)  NULL,
    [login] nchar(20)  NOT NULL,
    [password] nchar(20)  NOT NULL
);
GO

-- Creating table 'Material'
CREATE TABLE [dbo].[Material] (
    [Id_material] int IDENTITY(1,1) NOT NULL,
    [Material_name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id_order] int IDENTITY(1,1) NOT NULL,
    [Id_client] int  NOT NULL,
    [Id_employee] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Id_status] int  NOT NULL,
    [Note] nvarchar(300)  NULL
);
GO

-- Creating table 'Order_List'
CREATE TABLE [dbo].[Order_List] (
    [Id_order] int  NOT NULL,
    [Id_service] int  NOT NULL,
    [Amount] int  NOT NULL
);
GO

-- Creating table 'Order_Status'
CREATE TABLE [dbo].[Order_Status] (
    [Id_status] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(100)  NULL
);
GO

-- Creating table 'Position'
CREATE TABLE [dbo].[Position] (
    [Id_position] int IDENTITY(1,1) NOT NULL,
    [Position_name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Service'
CREATE TABLE [dbo].[Service] (
    [Id_service] int IDENTITY(1,1) NOT NULL,
    [Service_name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(300)  NULL,
    [Price] decimal(10,2)  NOT NULL,
    [Id_material] int  NULL,
    [Material_amount] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_client] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id_client] ASC);
GO

-- Creating primary key on [Id_employee] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([Id_employee] ASC);
GO

-- Creating primary key on [Id_material] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [PK_Material]
    PRIMARY KEY CLUSTERED ([Id_material] ASC);
GO

-- Creating primary key on [Id_order] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id_order] ASC);
GO

-- Creating primary key on [Id_order], [Id_service] in table 'Order_List'
ALTER TABLE [dbo].[Order_List]
ADD CONSTRAINT [PK_Order_List]
    PRIMARY KEY CLUSTERED ([Id_order], [Id_service] ASC);
GO

-- Creating primary key on [Id_status] in table 'Order_Status'
ALTER TABLE [dbo].[Order_Status]
ADD CONSTRAINT [PK_Order_Status]
    PRIMARY KEY CLUSTERED ([Id_status] ASC);
GO

-- Creating primary key on [Id_position] in table 'Position'
ALTER TABLE [dbo].[Position]
ADD CONSTRAINT [PK_Position]
    PRIMARY KEY CLUSTERED ([Id_position] ASC);
GO

-- Creating primary key on [Id_service] in table 'Service'
ALTER TABLE [dbo].[Service]
ADD CONSTRAINT [PK_Service]
    PRIMARY KEY CLUSTERED ([Id_service] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_client] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Client]
    FOREIGN KEY ([Id_client])
    REFERENCES [dbo].[Client]
        ([Id_client])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Client'
CREATE INDEX [IX_FK_Order_Client]
ON [dbo].[Order]
    ([Id_client]);
GO

-- Creating foreign key on [Id_position] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Position]
    FOREIGN KEY ([Id_position])
    REFERENCES [dbo].[Position]
        ([Id_position])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Position'
CREATE INDEX [IX_FK_Employee_Position]
ON [dbo].[Employee]
    ([Id_position]);
GO

-- Creating foreign key on [Id_employee] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Employee]
    FOREIGN KEY ([Id_employee])
    REFERENCES [dbo].[Employee]
        ([Id_employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Employee'
CREATE INDEX [IX_FK_Order_Employee]
ON [dbo].[Order]
    ([Id_employee]);
GO

-- Creating foreign key on [Id_material] in table 'Service'
ALTER TABLE [dbo].[Service]
ADD CONSTRAINT [FK_Service_Material]
    FOREIGN KEY ([Id_material])
    REFERENCES [dbo].[Material]
        ([Id_material])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Service_Material'
CREATE INDEX [IX_FK_Service_Material]
ON [dbo].[Service]
    ([Id_material]);
GO

-- Creating foreign key on [Id_order] in table 'Order_List'
ALTER TABLE [dbo].[Order_List]
ADD CONSTRAINT [FK_Order_List_Order]
    FOREIGN KEY ([Id_order])
    REFERENCES [dbo].[Order]
        ([Id_order])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_status] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Order_Status]
    FOREIGN KEY ([Id_status])
    REFERENCES [dbo].[Order_Status]
        ([Id_status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Order_Status'
CREATE INDEX [IX_FK_Order_Order_Status]
ON [dbo].[Order]
    ([Id_status]);
GO

-- Creating foreign key on [Id_service] in table 'Order_List'
ALTER TABLE [dbo].[Order_List]
ADD CONSTRAINT [FK_Order_List_Service]
    FOREIGN KEY ([Id_service])
    REFERENCES [dbo].[Service]
        ([Id_service])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_List_Service'
CREATE INDEX [IX_FK_Order_List_Service]
ON [dbo].[Order_List]
    ([Id_service]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
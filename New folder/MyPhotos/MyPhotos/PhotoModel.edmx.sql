
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/14/2020 21:58:22
-- Generated from EDMX file: E:\ceva TSP\Proiect-TSP\New folder\MyPhotos\MyPhotos\PhotoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Photos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [abs_path] nvarchar(max)  NOT NULL,
    [created_date] nvarchar(max)  NOT NULL,
    [event] nvarchar(max)  NOT NULL,
    [event_date] nvarchar(max)  NOT NULL,
    [event_location] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [relation] nvarchar(max)  NULL,
    [lastname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FilesProperties'
CREATE TABLE [dbo].[FilesProperties] (
    [Files_Id] int  NOT NULL,
    [Properties_Id] int  NOT NULL
);
GO

-- Creating table 'FilesPersons'
CREATE TABLE [dbo].[FilesPersons] (
    [Files_Id] int  NOT NULL,
    [Persons_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Files_Id], [Properties_Id] in table 'FilesProperties'
ALTER TABLE [dbo].[FilesProperties]
ADD CONSTRAINT [PK_FilesProperties]
    PRIMARY KEY CLUSTERED ([Files_Id], [Properties_Id] ASC);
GO

-- Creating primary key on [Files_Id], [Persons_Id] in table 'FilesPersons'
ALTER TABLE [dbo].[FilesPersons]
ADD CONSTRAINT [PK_FilesPersons]
    PRIMARY KEY CLUSTERED ([Files_Id], [Persons_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Files_Id] in table 'FilesProperties'
ALTER TABLE [dbo].[FilesProperties]
ADD CONSTRAINT [FK_FilesProperties_Files]
    FOREIGN KEY ([Files_Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Properties_Id] in table 'FilesProperties'
ALTER TABLE [dbo].[FilesProperties]
ADD CONSTRAINT [FK_FilesProperties_Properties]
    FOREIGN KEY ([Properties_Id])
    REFERENCES [dbo].[Properties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilesProperties_Properties'
CREATE INDEX [IX_FK_FilesProperties_Properties]
ON [dbo].[FilesProperties]
    ([Properties_Id]);
GO

-- Creating foreign key on [Files_Id] in table 'FilesPersons'
ALTER TABLE [dbo].[FilesPersons]
ADD CONSTRAINT [FK_FilesPersons_Files]
    FOREIGN KEY ([Files_Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Persons_Id] in table 'FilesPersons'
ALTER TABLE [dbo].[FilesPersons]
ADD CONSTRAINT [FK_FilesPersons_Persons]
    FOREIGN KEY ([Persons_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilesPersons_Persons'
CREATE INDEX [IX_FK_FilesPersons_Persons]
ON [dbo].[FilesPersons]
    ([Persons_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
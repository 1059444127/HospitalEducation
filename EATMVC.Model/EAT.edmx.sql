
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2017 11:00:32
-- Generated from EDMX file: D:\王杰\王杰-锅只是个传说\医院科技教育与培训管理平台设计与开发\EducationAndTraining\EATMVC.Model\EAT.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EducationAndTraining];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GP_LoginRoleInfo_GP_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GP_LoginRoleInfo] DROP CONSTRAINT [FK_GP_LoginRoleInfo_GP_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_GP_LoginRoleInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GP_LoginRoleInfo] DROP CONSTRAINT [FK_GP_LoginRoleInfo_RoleInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GP_Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GP_Login];
GO
IF OBJECT_ID(N'[dbo].[GP_LoginRoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GP_LoginRoleInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GP_Login'
CREATE TABLE [dbo].[GP_Login] (
    [id] nvarchar(50)  NOT NULL,
    [name] nvarchar(50)  NULL,
    [password] nvarchar(50)  NULL,
    [real_name] nvarchar(50)  NULL,
    [training_base_code] nvarchar(50)  NULL,
    [training_base_name] nvarchar(50)  NULL,
    [type] nvarchar(50)  NULL,
    [LoginState] nvarchar(50)  NULL,
    [RegisterDate] nvarchar(50)  NULL,
    [professional_base_code] nvarchar(50)  NULL,
    [professional_base_name] nvarchar(50)  NULL,
    [dept_code] nvarchar(50)  NULL,
    [dept_name] nvarchar(50)  NULL
);
GO

-- Creating table 'GP_LoginRoleInfo'
CREATE TABLE [dbo].[GP_LoginRoleInfo] (
    [Id] nvarchar(50)  NOT NULL,
    [GP_LoginId] nvarchar(50)  NULL,
    [RoleInfoId] int  NULL,
    [GP_LoginName] nvarchar(50)  NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlatformName] nvarchar(50)  NULL,
    [RoleName] nvarchar(50)  NULL,
    [Sort] nvarchar(50)  NULL,
    [Remark] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'GP_Login'
ALTER TABLE [dbo].[GP_Login]
ADD CONSTRAINT [PK_GP_Login]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'GP_LoginRoleInfo'
ALTER TABLE [dbo].[GP_LoginRoleInfo]
ADD CONSTRAINT [PK_GP_LoginRoleInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GP_LoginId] in table 'GP_LoginRoleInfo'
ALTER TABLE [dbo].[GP_LoginRoleInfo]
ADD CONSTRAINT [FK_GP_LoginRoleInfo_GP_Login]
    FOREIGN KEY ([GP_LoginId])
    REFERENCES [dbo].[GP_Login]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GP_LoginRoleInfo_GP_Login'
CREATE INDEX [IX_FK_GP_LoginRoleInfo_GP_Login]
ON [dbo].[GP_LoginRoleInfo]
    ([GP_LoginId]);
GO

-- Creating foreign key on [RoleInfoId] in table 'GP_LoginRoleInfo'
ALTER TABLE [dbo].[GP_LoginRoleInfo]
ADD CONSTRAINT [FK_GP_LoginRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfoId])
    REFERENCES [dbo].[RoleInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GP_LoginRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_GP_LoginRoleInfo_RoleInfo]
ON [dbo].[GP_LoginRoleInfo]
    ([RoleInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
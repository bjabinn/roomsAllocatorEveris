--IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
--BEGIN
--    CREATE TABLE [__EFMigrationsHistory] (
--        [MigrationId] nvarchar(150) NOT NULL,
--        [ProductVersion] nvarchar(32) NOT NULL,
--        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
--    );
--END;

--GO

--CREATE TABLE [RoomInformations] (
--    [RoomId] int NOT NULL IDENTITY,
--    [Name] nvarchar(max) NULL,
--    [Floor] int NOT NULL,
--    [NumRoom] nvarchar(max) NULL,
--    CONSTRAINT [PK_RoomInformations] PRIMARY KEY ([RoomId])
--);

--GO

--INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
--VALUES (N'20190401120547_InitialCreate', N'2.2.3-servicing-35854');

--GO

ALTER TABLE [RoomInformations] ADD [idBuilding] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Office] (
    [OfficeId] int NOT NULL IDENTITY,
    [Alias] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Office] PRIMARY KEY ([OfficeId])
);

GO

CREATE TABLE [Building] (
    [BuildingId] int NOT NULL IDENTITY,
    [idOffice] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Street] nvarchar(max) NULL,
    [NumberOfStreet] int NOT NULL,
    CONSTRAINT [PK_Building] PRIMARY KEY ([BuildingId]),
    CONSTRAINT [FK_Building_Office_idOffice] FOREIGN KEY ([idOffice]) REFERENCES [Office] ([OfficeId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_RoomInformations_idBuilding] ON [RoomInformations] ([idBuilding]);

GO

CREATE INDEX [IX_Building_idOffice] ON [Building] ([idOffice]);

GO

ALTER TABLE [RoomInformations] ADD CONSTRAINT [FK_RoomInformations_Building_idBuilding] 
FOREIGN KEY ([idBuilding]) REFERENCES [Building] ([BuildingId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190410112017_OfficesAndBuildings', N'2.2.3-servicing-35854');

GO


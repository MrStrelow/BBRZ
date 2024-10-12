IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(6,2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [OrderPlaced] datetime2 NOT NULL,
    [OrderFulfilled] datetime2 NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderDetails] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);
GO

CREATE INDEX [IX_OrderDetails_ProductId] ON [OrderDetails] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240904221543_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Customers] ADD [Email] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240904222713_AddEmail', N'8.0.8');
GO

COMMIT;
GO


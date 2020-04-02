IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] varchar(100) NOT NULL,
    [Name] varchar(100) NULL,
    [NormalizedName] varchar(100) NULL,
    [ConcurrencyStamp] varchar(100) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] varchar(100) NOT NULL,
    [UserName] varchar(100) NULL,
    [NormalizedUserName] varchar(100) NULL,
    [Email] varchar(100) NULL,
    [NormalizedEmail] varchar(100) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] varchar(100) NULL,
    [SecurityStamp] varchar(100) NULL,
    [ConcurrencyStamp] varchar(100) NULL,
    [PhoneNumber] varchar(100) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Permissao] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] varchar(250) NOT NULL,
    [sigla] varchar(2) NOT NULL,
    CONSTRAINT [PK_Permissao] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] varchar(100) NOT NULL,
    [ClaimType] varchar(100) NULL,
    [ClaimValue] varchar(100) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] varchar(100) NOT NULL,
    [ClaimType] varchar(100) NULL,
    [ClaimValue] varchar(100) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] varchar(100) NOT NULL,
    [ProviderKey] varchar(100) NOT NULL,
    [ProviderDisplayName] varchar(100) NULL,
    [UserId] varchar(100) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] varchar(100) NOT NULL,
    [RoleId] varchar(100) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] varchar(100) NOT NULL,
    [LoginProvider] varchar(100) NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Value] varchar(100) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [IdUser] varchar(100) NOT NULL,
    [CPF] varchar(11) NULL,
    [Imagem] varchar(100) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]),
    CONSTRAINT [fk_AspNetUsers] FOREIGN KEY ([IdUser]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [IdUsuaruio] int NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Logradouro] varchar(250) NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id]),
    CONSTRAINT [fk_UsuarioEndereco] FOREIGN KEY ([IdUsuaruio]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Log] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] int NOT NULL,
    [DataLog] datetime NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [IP] varchar(50) NOT NULL,
    [Navegador] varchar(50) NOT NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Log_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Telefones] (
    [Id] int NOT NULL IDENTITY,
    [IdUsuaruio] int NOT NULL,
    [Telefone] varchar(11) NOT NULL,
    [Celular] varchar(11) NOT NULL,
    CONSTRAINT [PK_Telefones] PRIMARY KEY ([Id]),
    CONSTRAINT [fk_UsuarioTelefone] FOREIGN KEY ([IdUsuaruio]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE ([NormalizedName] IS NOT NULL);

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE ([NormalizedUserName] IS NOT NULL);

GO

CREATE INDEX [IX_Endereco_IdUsuaruio] ON [Endereco] ([IdUsuaruio]);

GO

CREATE INDEX [IX_Log_UsuarioId] ON [Log] ([UsuarioId]);

GO

CREATE INDEX [IX_Telefones_IdUsuaruio] ON [Telefones] ([IdUsuaruio]);

GO

CREATE INDEX [IX_Usuario_IdUser] ON [Usuario] ([IdUser]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200402043521_Initial_01', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuario]') AND [c].[name] = N'Imagem');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuario] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usuario] ALTER COLUMN [Imagem] varchar(100) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200402044433_Imagem_02', N'3.1.3');

GO


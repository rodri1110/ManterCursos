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

CREATE TABLE [Categorias] (
    [CategoriaId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([CategoriaId])
);
GO

CREATE TABLE [Cursos] (
    [CursoId] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NULL,
    [dtInicio] datetime2 NOT NULL,
    [dtTermino] datetime2 NOT NULL,
    [QtdAluno] int NOT NULL,
    [CategoriaId] int NULL,
    [UsuarioResponsavel] nvarchar(max) NULL,
    [DtCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([CursoId])
);
GO

CREATE TABLE [CursosHistorico] (
    [CursoHistoricoId] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NULL,
    [dtInicio] datetime2 NOT NULL,
    [dtTermino] datetime2 NOT NULL,
    [QtdAluno] int NOT NULL,
    [UsuarioResponsavel] nvarchar(max) NULL,
    [DtCriacao] datetime2 NOT NULL,
    [Acao] nvarchar(max) NULL,
    [DtUltModificacao] datetime2 NOT NULL,
    CONSTRAINT [PK_CursosHistorico] PRIMARY KEY ([CursoHistoricoId])
);
GO

CREATE TABLE [Logs] (
    [LogId] int NOT NULL IDENTITY,
    [UsuarioResponsavel] nvarchar(max) NULL,
    [DtCriacao] datetime2 NOT NULL,
    [DtUltModificacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([LogId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118000519_Inicial', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118002130_Inicial45', N'5.0.12');
GO

COMMIT;
GO


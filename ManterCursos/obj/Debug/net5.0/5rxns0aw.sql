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
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([CursoId]),
    CONSTRAINT [FK_Cursos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([CategoriaId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Logs] (
    [LogId] int NOT NULL IDENTITY,
    [DtInclusao] datetime2 NOT NULL,
    [DtUltAtualizacao] datetime2 NOT NULL,
    [UsuResponsável] nvarchar(max) NULL,
    [CursoId] int NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([LogId]),
    CONSTRAINT [FK_Logs_Cursos_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Cursos] ([CursoId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Cursos_CategoriaId] ON [Cursos] ([CategoriaId]);
GO

CREATE INDEX [IX_Logs_CursoId] ON [Logs] ([CursoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211115141511_Inicial', N'5.0.12');
GO

COMMIT;
GO


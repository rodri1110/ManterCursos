USE [ManterCursoDB]
GO

SELECT [CursoId]
      ,[Descricao]
      ,[dtInicio]
      ,[dtTermino]
      ,[QtdAluno]
      ,[CategoriaId]
  FROM [dbo].[Cursos]

GO

select * from cursos;
update Cursos set categoriaId=1 where Descricao = 'curso noturnoe';




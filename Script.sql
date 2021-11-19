select * from cursos;
select * from Categorias;
insert into Categorias (Nome, CursoId) values ('Multiplataforma', 1);
insert into Categorias (Nome) values ('Banco de Dados');
insert into Categorias (Nome) values ('Metodologia');
insert into Categorias (Nome) values ('Comportamento');
insert into Categorias (Nome) values ('Comunicação');

insert into Cursos (Descricao, dtInicio, dtTermino, QtdAluno) values 
('Curso Noturno',convert(datetime,'18-06-12 10:34:09 PM',3), convert(datetime,'18-06-12 10:34:09 PM',5), 25);

###📘 Descrição da API – Sistema de Gestão Acadêmica
A API desenvolvida com Entity Framework Core e C# representa um sistema de gerenciamento acadêmico voltado para instituições de ensino. O sistema permite o controle completo de entidades relacionadas a cursos, disciplinas, alunos, professores e suas respectivas relações. A seguir estão as funcionalidades principais inferidas do modelo:

##🔧 Funcionalidades e Estrutura de Dados
#🎓 Alunos (Aluno)
Cadastro de alunos com nome, sexo e data de nascimento.

Associação com disciplinas por meio da entidade Cursa, que registra faltas, notas e aprovação.

#📚 Cursos (Curso)
Cadastro de cursos, com ligação a uma instituição e a um tipo de curso.

Descrição única por instituição e tipo.

#🏫 Instituições (Instituicao)
Representa as instituições de ensino.

Cada curso pertence a uma instituição específica.

#🧑‍🏫 Professores (Professor)
Cadastro de professores com nome, telefone, sexo, estado civil, título e data de nascimento.

Professores podem lecionar diversas disciplinas via a entidade Leciona.

#📖 Disciplinas (Disciplina)
Associadas a cursos e a um tipo de disciplina.

Informações como carga horária, período, sigla e descrição.

Podem ser lecionadas por professores (Leciona) e cursadas por alunos (Cursa).

#🏷️ Tipos Diversos
TipoCurso: Classificações para cursos (ex: Bacharelado, Licenciatura).

TipoDisciplina: Classificações para disciplinas (ex: Teórica, Prática).

Titulo: Títulos acadêmicos dos professores (ex: Mestre, Doutor).

#📈 Relacionamentos Acadêmicos
Cursa: Relaciona alunos com disciplinas em semestres específicos, registrando desempenho.

Leciona: Relaciona professores com disciplinas que eles ensinam.

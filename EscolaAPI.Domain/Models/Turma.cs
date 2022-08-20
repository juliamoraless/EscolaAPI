namespace EscolaAPI.Domain.Models
{
    public class Turma : EntidadeBase
    {
        public string Nome {get; set;}
        public Disciplina Disciplina {get; set;}
        public int DisciplinaId {get; set;}
        public Professor Professor {get; set;}
        public int ProfessorId {get; set;}
        public List<Aluno> Alunos {get; set;}
    }
}
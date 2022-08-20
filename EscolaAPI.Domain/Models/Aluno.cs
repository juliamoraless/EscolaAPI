namespace EscolaAPI.Domain.Models
{
    public class Aluno : EntidadeBase
    {
        public string Nome {get; set;}
        public Turma Turma {get; set;}
        public int TurmaId {get; set;}
        public string Email {get; set;}
    }
}
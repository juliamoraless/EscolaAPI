namespace EscolaAPI.Domain.Models
{
    public class Disciplina : EntidadeBase
    {
        public string Nome {get; set;}
        public List<Turma> Turmas {get; set;}
    }
}
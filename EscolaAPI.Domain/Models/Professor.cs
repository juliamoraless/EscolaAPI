namespace EscolaAPI.Domain.Models
{
    public class Professor : EntidadeBase
    {
        public string Nome {get; set;}
        public Turma Turma {get; set;}
    }
}
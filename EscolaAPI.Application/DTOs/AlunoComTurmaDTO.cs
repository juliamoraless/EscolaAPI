using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.DTOs
{
    public class AlunoComTurmaDTO
    {
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Turma {get; set;}
    }
}
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.DTOs
{
    public class AlunoComIdDTO
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Turma {get; set;}
    }
}
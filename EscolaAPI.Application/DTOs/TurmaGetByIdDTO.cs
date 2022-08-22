using EscolaAPI.Application.DTOs;

namespace EscolaAPI.Domain.Models
{
    public class TurmaGetByIdDTO 
    {
        public string Nome {get; set;}
        public DisciplinaComNomeDTO Disciplina {get; set;}
        public ProfessorComNomeDTO Professor {get; set;}
        public List<AlunoComNomeDTO> Alunos {get; set;}

    }
}
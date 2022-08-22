using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Repositories;

namespace EscolaAPI.Application.Services
{
    public class ProfessorService
    {
        private readonly IProfessorRepositorio RepoProfessor;
        private readonly ITurmaRepositorio RepoTurma;
        private readonly IMapper Mapper;

        public ProfessorService(IProfessorRepositorio repoProfessor, IMapper mapper, ITurmaRepositorio repoTurma)
        {
            RepoProfessor = repoProfessor;
            Mapper = mapper;
            RepoTurma = repoTurma;
        } 

        public List<ProfessorComIdDTO> GetProfessores()
        {
            List<Professor> Professores = RepoProfessor.GetAll();
            List<ProfessorComIdDTO> ProfessoresDTO = new();
            foreach(Professor professor in Professores)
            {
                ProfessorComIdDTO professorDTO = new();
                professorDTO = Mapper.Map<ProfessorComIdDTO>(professor);
                ProfessoresDTO.Add(professorDTO);
            }
            return ProfessoresDTO;
        }

        public void PostProfessores(ProfessorComNomeDTO professorDTO)
        {
            Professor Professor = new();
            Professor = Mapper.Map<Professor>(professorDTO);
            RepoProfessor.Post(Professor);
        }

        public void PutProfessores(ProfessorComIdDTO professorDTO)
        {
            Professor professorAtualizado = RepoProfessor.GetById(professorDTO.Id);
            if(professorAtualizado != null)
            {
                professorAtualizado.Nome = professorDTO.Nome;
                RepoProfessor.Put(professorAtualizado);

            }

        }

        public void DeleteProfessores(int id)
        {
            Professor professorRemovido = RepoProfessor.GetById(id);
            if(professorRemovido != null)
            {
                RepoProfessor.Delete(professorRemovido);
            }
        }

    }
}

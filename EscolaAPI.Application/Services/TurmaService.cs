using AutoMapper;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Repositories;

namespace EscolaAPI.Application.Services
{
    public class TurmaService
    {
        private readonly ITurmaRepositorio RepoTurma;
        private readonly IDisciplinaRepositorio RepoDisciplina;
        private readonly IProfessorRepositorio RepoProfessor;
        private readonly IMapper Mapper;

        public TurmaService (ITurmaRepositorio repoTurma, IMapper mapper, IDisciplinaRepositorio repoDisciplina, IProfessorRepositorio repoProfessor)
        {
            RepoTurma = repoTurma;
            RepoDisciplina = repoDisciplina;
            Mapper = mapper;
            RepoProfessor = repoProfessor;
        }

         public List<TurmaGetDTO> GetTurmas()
        {
            List<Turma> Turmas = RepoTurma.GetAll();
            List<TurmaGetDTO> TurmasDTO = new();
            foreach(Turma turma in Turmas)
            {
                TurmaGetDTO turmaDTO = new();
                turmaDTO = Mapper.Map<TurmaGetDTO>(turma);
                TurmasDTO.Add(turmaDTO);
            }
            return TurmasDTO;
        }

        public TurmaGetByIdDTO GetTurmaById(int id)
        {
            Turma Turma = RepoTurma.GetTurmaComTudoById(id);
            TurmaGetByIdDTO TurmaDTO = new();
            TurmaDTO = Mapper.Map<TurmaGetByIdDTO>(Turma);
            return TurmaDTO;
        }


        public void PostTurmas(TurmaPostDTO turmaDTO)
        {
            Professor professor = RepoProfessor.GetProfessorByName(turmaDTO.Professor); 
            Disciplina disciplina = RepoDisciplina.GetDisciplinaByName(turmaDTO.Disciplina); 
            if(professor != null && disciplina != null)
            {
                Turma turma = new();
                turma.Nome = turmaDTO.Nome;
                turma.Disciplina = disciplina;
                turma.Professor = professor;

                RepoTurma.Post(turma);
            }

        }

        public void DeleteTurmas(int id)
        {
            Turma turmaRemovida = RepoTurma.GetById(id);
            if(turmaRemovida != null)
            {
                RepoTurma.Delete(turmaRemovida);
            }
        
        }
    }
}
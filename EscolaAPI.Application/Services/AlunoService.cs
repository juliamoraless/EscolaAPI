using AutoMapper;
using EscolaAPI.Infra.Repositories;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.Services
{
    public class AlunoService
    {
        private readonly AlunoRepositorio RepoAluno;
        private readonly TurmaRepositorio RepoTurma;
        private readonly IMapper Mapper;

        public AlunoService (AlunoRepositorio repoAluno, TurmaRepositorio repoTurma, IMapper mapper)
        {
            RepoAluno = repoAluno;
            Mapper = mapper;
            RepoTurma = repoTurma;
        }

        public List<AlunoComIdDTO> GetAlunos() 
        {
            List<Aluno> Alunos = RepoAluno.GetAlunosComTurma();
            List<AlunoComIdDTO> ListaAlunosDTO = new();
            foreach(Aluno aluno in Alunos)
            {
                AlunoComIdDTO alunoDTO = new();
                alunoDTO = Mapper.Map<AlunoComIdDTO>(aluno);
                ListaAlunosDTO.Add(alunoDTO);
            }
            return ListaAlunosDTO;
        }

        public void PostAlunos(AlunoComTurmaDTO alunoDTO)
        {
            Turma Turma = RepoTurma.GetTurmaByName(alunoDTO.Turma);
            if(Turma != null)
            {
                Aluno aluno = new();
                //aluno = Mapper.Map<Aluno>(alunoDTO);
                aluno.Email = alunoDTO.Email;
                aluno.Nome = alunoDTO.Nome;
                aluno.Turma = Turma;
                RepoAluno.Post(aluno);
            }
        }

        public void PutAluno(AlunoComIdDTO alunoDTO)
        {
            Turma turma = RepoTurma.GetTurmaByName(alunoDTO.Nome);
            Aluno alunoAtualizado = RepoAluno.GetById(alunoDTO.Id);  
            if(alunoAtualizado != null)
            {
                alunoAtualizado.Nome = alunoDTO.Nome;
                alunoAtualizado.Email = alunoDTO.Email;
                alunoAtualizado.Turma = turma;
                RepoAluno.Put(alunoAtualizado);
            } 
        }

        public void DeleteAluno(int id)
        {
            Aluno AlunoRemovido = RepoAluno.GetById(id);
             if(AlunoRemovido != null)
            {
                RepoAluno.Delete(AlunoRemovido);
            }
        }
    }
}
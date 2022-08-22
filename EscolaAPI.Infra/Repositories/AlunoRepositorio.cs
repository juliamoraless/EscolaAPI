using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Infra.Repositories
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(EscolaContext BancoDeDados) : base (BancoDeDados)
        {
            
        }

        public List<Aluno> GetAlunosComTurma() => BancoDeDados.Alunos.Include(a => a.Turma).ToList();
    }

}
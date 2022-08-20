using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Infra.Repositories
{
    public class TurmaRepositorio : BaseRepositorio<Turma>
    {
        public TurmaRepositorio(EscolaContext BancoDeDados) : base (BancoDeDados)
        {
            
        }

        public Turma GetTurmaByName(string nome) => BancoDeDados.Turmas.Where(t => t.Nome == nome).FirstOrDefault();

        public Turma GetTurmaComTudoById(int id) => BancoDeDados.Turmas.Include(t => t.Professor).Include(t => t.Disciplina).Include(t => t.Alunos).Where(t => t.Id == id).FirstOrDefault();
    }

}
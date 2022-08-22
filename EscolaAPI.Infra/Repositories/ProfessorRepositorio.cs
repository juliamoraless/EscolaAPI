using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;

namespace EscolaAPI.Infra.Repositories
{
    public class ProfessorRepositorio : BaseRepositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(EscolaContext BancoDeDados) : base (BancoDeDados)
        {
            
        }

        public Professor GetProfessorByName(string Nome) =>  BancoDeDados.Professores.Where(p => p.Nome == Nome).FirstOrDefault();
    }

}
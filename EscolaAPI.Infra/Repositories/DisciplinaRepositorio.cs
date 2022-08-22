using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;

namespace EscolaAPI.Infra.Repositories
{
    public class DisciplinaRepositorio : BaseRepositorio<Disciplina>, IDisciplinaRepositorio
    {
        public DisciplinaRepositorio(EscolaContext BancoDeDados) : base (BancoDeDados)
        {
            
        }

       public Disciplina GetDisciplinaByName(string nome) => BancoDeDados.Disciplinas.Where(t => t.Nome == nome).FirstOrDefault();

        
    }

}
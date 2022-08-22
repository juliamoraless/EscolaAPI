using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IDisciplinaRepositorio : IBaseRepositorio<Disciplina>
    {
        Disciplina GetDisciplinaByName(string nome);
    }
}
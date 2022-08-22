using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        List<Aluno> GetAlunosComTurma();
    }
}
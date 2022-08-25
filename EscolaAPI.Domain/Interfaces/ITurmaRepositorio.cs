using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface ITurmaRepositorio : IBaseRepositorio<Turma>
    {
        Turma GetTurmaByName(string nome);
        Turma GetTurmaComTudoById(int id); 
   }
}
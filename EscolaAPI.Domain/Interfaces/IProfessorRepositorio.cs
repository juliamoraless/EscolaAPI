using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IProfessorRepositorio : IBaseRepositorio<Professor>
    {
        Professor GetProfessorByName(string Nome); 
    }
}
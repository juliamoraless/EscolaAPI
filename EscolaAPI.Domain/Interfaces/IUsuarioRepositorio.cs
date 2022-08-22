using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario CheckLogin(string Nome, string Senha);
    }
}
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Infra.Repositories
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(EscolaContext BancoDeDados) : base (BancoDeDados)
        {
            
        }

        public Usuario CheckLogin(string Nome, string Senha) => BancoDeDados.Usuarios.Where(u => u.Nome == Nome && u.Senha == Senha).FirstOrDefault();
    }

}
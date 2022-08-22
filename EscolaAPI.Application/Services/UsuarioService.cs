using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EscolaAPI.Application.Services
{
    public class UsuarioService
    {
        private readonly IConfiguration Configuration;
        // private static List<Usuario> ListaUsuarios = new();
        private readonly IUsuarioRepositorio RepoUsuario;
        public UsuarioService(IConfiguration configuration, IUsuarioRepositorio repoUsuario)
        {
            Configuration = configuration;
            RepoUsuario = repoUsuario;
            
        }

        public Usuario Get(string Nome, string Senha) => RepoUsuario.CheckLogin(Nome, Senha);
        public string GenerateToken(Usuario usuario)
        {
            string secretKeyConfig = Configuration.GetSection("SecretKey").Value;
            byte[] secretKey = Encoding.ASCII.GetBytes(secretKeyConfig);
            var TokenHandler = new JwtSecurityTokenHandler();

            var PermissaoNome = new Claim("Nome", usuario.Nome);
            var PermissaoPerfil = new Claim(ClaimTypes.Role, usuario.Cargo);
            List<Claim> Permissoes = new();
            Permissoes.Add(PermissaoNome);
            Permissoes.Add(PermissaoPerfil);
            var Claims = new ClaimsIdentity(Permissoes);

            var TokenDescriptor = new SecurityTokenDescriptor();
            TokenDescriptor.Subject = Claims;

            TokenDescriptor.Expires = DateTime.Now.AddHours(8);

            TokenDescriptor.Issuer = usuario.Nome;
            TokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            string Token = TokenHandler.CreateEncodedJwt(TokenDescriptor);

            return Token;
        }
        

    }
}
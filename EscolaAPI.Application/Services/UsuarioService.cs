using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EscolaAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EscolaAPI.Application.Services
{
    public class UsuarioService
    {
        private readonly IConfiguration Configuration;
        private static List<Usuario> ListaUsuarios = new();
        public UsuarioService(IConfiguration configuration)
        {
            Configuration = configuration;
            Usuario user = new();
            user.Nome = "Julia";
            user.Cargo = "Administrador";
            user.Senha = "123";  
            user.Id = 1; 
            Usuario user2 = new();
            user2.Id = 2;
            user2.Nome = "Rafael";
            user2.Senha = "123";
            user2.Cargo = "Usuario";
            ListaUsuarios.Add(user2);
            ListaUsuarios.Add(user);
        }

        public Usuario Get(string Nome) => ListaUsuarios.Where(u => u.Nome.ToLower() == Nome.ToLower()).FirstOrDefault(); 
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
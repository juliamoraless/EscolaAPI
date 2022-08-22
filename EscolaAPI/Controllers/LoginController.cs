using EscolaAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService UsuarioService;
        public LoginController(UsuarioService usuarioService)
        {
            UsuarioService = usuarioService;
        }

        // [HttpGet("{Nome}")]
        // public Usuario GetByName(string Nome) => UsuarioService.Get(Nome);

        [HttpGet]
        public string Login([FromQuery]string Nome, [FromQuery]string Senha)
        {
            var Usuario = UsuarioService.Get(Nome, Senha); 
            return UsuarioService.GenerateToken(Usuario);
        }
    }
}
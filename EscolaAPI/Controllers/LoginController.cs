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

        [HttpGet("{Nome}")]
        public string Login(string Nome)
        {
            var Usuario = UsuarioService.Get(Nome); 
            return UsuarioService.GenerateToken(Usuario);
        }
    }
}
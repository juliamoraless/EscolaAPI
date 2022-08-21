using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService AlunoService;

        public AlunoController(AlunoService alunoService)
        {
            AlunoService = alunoService;
        }

        [HttpGet]
        [Authorize]
        public List<AlunoComIdDTO> GetAlunosC() => AlunoService.GetAlunos();

        [HttpPost]
        [Authorize]
        public void PostAlunosC(AlunoComTurmaDTO alunoDTO) => AlunoService.PostAlunos(alunoDTO);

        [HttpPut]
        [Authorize]
        public void PutAlunoC(AlunoComIdDTO alunoDTO) => AlunoService.PutAluno(alunoDTO);

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public void DeleteAlunoC(int id) => AlunoService.DeleteAluno(id);
    }
}
using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
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
        public List<AlunoComIdDTO> GetAlunosC() => AlunoService.GetAlunos();

        [HttpPost]
        public void PostAlunosC(AlunoComTurmaDTO alunoDTO) => AlunoService.PostAlunos(alunoDTO);

        [HttpPut]
        public void PutAlunoC(AlunoComIdDTO alunoDTO) => AlunoService.PutAluno(alunoDTO);

        [HttpDelete("{id}")]
        public void DeleteAlunoC(int id) => AlunoService.DeleteAluno(id);
    }
}
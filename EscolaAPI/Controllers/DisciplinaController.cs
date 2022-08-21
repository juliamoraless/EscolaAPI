using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaService DisciplinaService;

        public DisciplinaController(DisciplinaService disciplinaService)
        {
            DisciplinaService = disciplinaService;
        }

        [HttpGet]
        [Authorize]
        public List<DisciplinaGetDTO> GetDisciplinasC() => DisciplinaService.GetDisciplinas();

        [HttpPost]
        [Authorize]
        public void PostDisciplinasC(DisciplinaComNomeDTO disciplinaDTO) => DisciplinaService.PostDisciplinas(disciplinaDTO);

        [HttpPut]
        [Authorize]
        public void PutDisciplinaC(DisciplinaPutDTO disciplinaDTO) => DisciplinaService.PutDisciplina(disciplinaDTO);

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public void DeleteDisciplinaC(int id) => DisciplinaService.DeleteDisciplina(id);
    }
}
using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
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
        public List<DisciplinaGetDTO> GetDisciplinasC() => DisciplinaService.GetDisciplinas();

        [HttpPost]
        public void PostDisciplinasC(DisciplinaComNomeDTO disciplinaDTO) => DisciplinaService.PostDisciplinas(disciplinaDTO);

        [HttpPut]
        public void PutDisciplinaC(DisciplinaPutDTO disciplinaDTO) => DisciplinaService.PutDisciplina(disciplinaDTO);

        [HttpDelete("{id}")]
        public void DeleteDisciplinaC(int id) => DisciplinaService.DeleteDisciplina(id);
    }
}
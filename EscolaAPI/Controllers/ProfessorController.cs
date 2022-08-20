using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService ProfessorService;

        public ProfessorController(ProfessorService professorService)
        {
            ProfessorService = professorService;
        }

        [HttpGet]
        public List<ProfessorComIdDTO> GetProfessoresC() => ProfessorService.GetProfessores();

        [HttpPost]
        public void PostProfessoresC(ProfessorComNomeDTO professorDTO) => ProfessorService.PostProfessores(professorDTO);

        [HttpPut]
        public void PutProfessoresC(ProfessorComIdDTO professorDTO) => ProfessorService.PutProfessores(professorDTO);
        
        [HttpDelete("{id}")]
        public void DeleteProfessoresC(int id) => ProfessorService.DeleteProfessores(id);
    }
}
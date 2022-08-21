using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public List<ProfessorComIdDTO> GetProfessoresC() => ProfessorService.GetProfessores();

        [HttpPost]
        [Authorize]
        public void PostProfessoresC(ProfessorComNomeDTO professorDTO) => ProfessorService.PostProfessores(professorDTO);

        [HttpPut]
        [Authorize]
        public void PutProfessoresC(ProfessorComIdDTO professorDTO) => ProfessorService.PutProfessores(professorDTO);
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public void DeleteProfessoresC(int id) => ProfessorService.DeleteProfessores(id);
    }
}
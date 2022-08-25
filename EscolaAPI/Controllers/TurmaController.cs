using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaService TurmaService;

        public TurmaController(TurmaService turmaService)
        {
            TurmaService = turmaService;
        }

        [HttpGet]
        [Authorize]
        public List<TurmaGetDTO> GetTurmasC() => TurmaService.GetTurmas();

        [HttpGet("{id}")]
        [Authorize]
        public TurmaGetByIdDTO GetTurmaGetByIdC(int id) => TurmaService.GetTurmaById(id);

        [HttpPost]
        [Authorize]
        public void PostTurmassC(TurmaPostDTO turmaDTO) => TurmaService.PostTurmas(turmaDTO);

        [HttpPut]
        [Authorize]
        public void PutTurmasC(TurmaPutDTO turmaDTO) => TurmaService.PutTurmas(turmaDTO);

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public void DeleteTurmasC(int id)   => TurmaService.DeleteTurmas(id);     
    }
}
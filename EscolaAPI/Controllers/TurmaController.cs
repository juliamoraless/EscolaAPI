using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Models;
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
        public List<TurmaGetDTO> GetTurmasC() => TurmaService.GetTurmas();

        [HttpGet("{id}")]
        public TurmaGetByIdDTO GetTurmaGetByIdC(int id) => TurmaService.GetTurmaById(id);

        [HttpPost]
        public void PostTurmassC(TurmaPostDTO turmaDTO) => TurmaService.PostTurmas(turmaDTO);
    }
}
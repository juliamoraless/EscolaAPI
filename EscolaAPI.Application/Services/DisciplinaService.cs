using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Infra.Repositories;
using EscolaAPI.Domain.Models;


namespace EscolaAPI.Application.Services
{
    public class DisciplinaService
    {
        private readonly DisciplinaRepositorio RepoDisciplina;
        private readonly IMapper Mapper;

        public DisciplinaService(DisciplinaRepositorio repoDisciplina, IMapper mapper)
        {
            RepoDisciplina = repoDisciplina;
            Mapper = mapper;
        }

        public List<DisciplinaGetDTO> GetDisciplinas()
        {
            List<Disciplina> Disciplinas = RepoDisciplina.GetAll();
            List<DisciplinaGetDTO> DisciplinasDTO = new();
            foreach (Disciplina disciplina in Disciplinas)
            {
                DisciplinaGetDTO disciplinaDTO = new();
                disciplinaDTO = Mapper.Map<DisciplinaGetDTO>(disciplina);
                DisciplinasDTO.Add(disciplinaDTO);
            }
            return DisciplinasDTO;
        }

        public void PostDisciplinas(DisciplinaComNomeDTO disciplinaDTO)
        {
            Disciplina disciplina = new();
            disciplina = Mapper.Map<Disciplina>(disciplinaDTO);
            RepoDisciplina.Post(disciplina);
        }

        public void PutDisciplina(DisciplinaPutDTO disciplinaDTO)
        {
            Disciplina disciplinaEscolhida = RepoDisciplina.GetById(disciplinaDTO.Id);
            if(disciplinaEscolhida != null)
            {
                disciplinaEscolhida.Nome = disciplinaDTO.Nome;
                RepoDisciplina.Put(disciplinaEscolhida);
            }
        }

        public void DeleteDisciplina(int id)
        {
            Disciplina disciplinaRemovida = RepoDisciplina.GetById(id);
             if(disciplinaRemovida != null)
            {
                RepoDisciplina.Delete(disciplinaRemovida);
            }
        }

    }

}
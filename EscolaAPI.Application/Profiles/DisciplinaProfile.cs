using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.Profiles
{
    public class DisciplinaProfile : Profile
    {
        public DisciplinaProfile()
        {
            CreateMap<Disciplina, DisciplinaComNomeDTO>().ReverseMap();
            CreateMap<Disciplina, DisciplinaGetDTO>();
        }
    }
}
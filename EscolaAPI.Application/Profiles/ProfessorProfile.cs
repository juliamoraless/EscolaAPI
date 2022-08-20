using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<ProfessorComNomeDTO, Professor>().ReverseMap();
            CreateMap<Professor, ProfessorComIdDTO>();
        }
    }
}
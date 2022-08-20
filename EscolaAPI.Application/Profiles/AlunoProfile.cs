using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {

            CreateMap<Aluno, AlunoComIdDTO>()
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma.Nome))
                .ReverseMap();

            CreateMap<AlunoComTurmaDTO, Aluno>();
                //.ForMember(dest => dest.Turma.Nome, opt => opt.MapFrom(src => src.Turma));

            CreateMap<Aluno, AlunoComNomeDTO>();    
        }
    }
}
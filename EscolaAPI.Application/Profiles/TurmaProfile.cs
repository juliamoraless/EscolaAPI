using AutoMapper;
using EscolaAPI.Domain.Models;

namespace EscolaAPI.Application.Profiles
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<Turma, TurmaGetDTO>();
            CreateMap<TurmaPostDTO, Turma>();
            CreateMap<Turma, TurmaGetByIdDTO>();
                //.ForMember(dest => dest.Professor.Nome, opt => opt.MapFrom(src => src.Professor.Nome));
            CreateMap<Turma, TurmaComNomeDTO>();
        }

    }
}
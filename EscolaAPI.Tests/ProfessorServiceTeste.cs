using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Profiles;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Moq;
using Xunit;

namespace EscolaAPI.Testes
{

public class ProfessorServiceTeste
{
    private readonly ProfessorService Sut;
    private readonly Mock<IProfessorRepositorio> RepoProfessor;
    private readonly Mock<ITurmaRepositorio> RepoTurma;

    public ProfessorServiceTeste()
    {
        RepoProfessor = new();
        RepoTurma = new Mock<ITurmaRepositorio>();
        IMapper Mapper = new MapperConfiguration(x => x.AddProfile(new ProfessorProfile())).CreateMapper();
        Sut = new(RepoProfessor.Object, Mapper, RepoTurma.Object);
    }

    [Fact]
    public void TesteGetAllProfessor()
    {
        //
        List<Professor> Professores = new();
        Professor prof1 = new();
        prof1.Id = 1;
        prof1.Nome = "jose";
        Professor prof2 = new();
        prof2.Id = 2;
        prof2.Nome = "fabio";
        Professores.Add(prof1);
        Professores.Add(prof2);
        RepoProfessor.Setup(d => d.GetAll()).Returns(Professores);
        //
        List<ProfessorComIdDTO> Lista = Sut.GetProfessores();
        //
        RepoProfessor.Verify(x => x.GetAll(), Times.Once);
        Assert.NotEmpty(Lista);

    }

    [Fact]
    public void TestePostProfessor()
    {
        //
        ProfessorComNomeDTO ProfessorDTO = new();
        ProfessorDTO.Nome = "jose";
        //
        Sut.PostProfessores(ProfessorDTO);
        //
        RepoProfessor.Verify(x => x.Post(It.Is<Professor>(d => d.Nome == ProfessorDTO.Nome)),Times.Once);

    }

    [Fact]
    public void TestePutProfessor()
    {
        //preparar
        ProfessorComIdDTO ProfessorDTO = new();
        Professor Professor = new();
        RepoProfessor.Setup(x => x.GetById(It.IsAny<int>())).Returns(Professor);
        //atuar
        Sut.PutProfessores(ProfessorDTO);
        //verificar
        RepoProfessor.Verify(x => x.Put(Professor), Times.Once);
    }

    [Fact]
    public void TesteGetByIdProfessor()
    {
        //preparar
        ProfessorComIdDTO ProfessorDTO = new();
        Professor Professor = new();
        RepoProfessor.Setup(x => x.GetById(It.IsAny<int>())).Returns(Professor);
        //atuar
        Sut.PutProfessores(ProfessorDTO);
        //verificar
        Assert.NotNull(Professor);
    }


    [Fact]
    public void TesteDeleteProfessor()
    {
        //
        int id = 2;
        Professor Professor = new();
        RepoProfessor.Setup(d => d.GetById(It.IsAny<int>())).Returns(Professor);
        //
        Sut.DeleteProfessores(id);
        //
        RepoProfessor.Verify(x => x.Delete(Professor), Times.Once);
    } 

    
}
}
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

public class DisciplinaServiceTeste
{
    private readonly DisciplinaService Sut;
    private readonly Mock<IDisciplinaRepositorio> RepoDisciplina;
        
    public DisciplinaServiceTeste()
    {
        RepoDisciplina = new();
        IMapper Mapper = new MapperConfiguration(x => x.AddProfile(new DisciplinaProfile())).CreateMapper();
        Sut = new(RepoDisciplina.Object, Mapper);
    }


    [Fact]
    public void TesteGetAllDisciplina()
    {
        //
        List<Disciplina> Disciplinas = new();
        Disciplina disc1 = new();
        disc1.Id = 1;
        disc1.Nome = "matematica";
        Disciplina disc2 = new();
        disc2.Id = 1;
        disc2.Nome = "portugues";
        Disciplinas.Add(disc1);
        Disciplinas.Add(disc2);
        RepoDisciplina.Setup(d => d.GetAll()).Returns(Disciplinas);
        //
        List<DisciplinaGetDTO> Lista = Sut.GetDisciplinas();
        //
        RepoDisciplina.Verify(x => x.GetAll(), Times.Once);
        Assert.NotEmpty(Lista);

    }

    [Fact]
    public void TestePostDisciplina()
    {
        //
        DisciplinaComNomeDTO disciplinaDTO = new();
        disciplinaDTO.Nome = "Portugues";
        //
        Sut.PostDisciplinas(disciplinaDTO);
        //
        RepoDisciplina.Verify(x => x.Post(It.Is<Disciplina>(d => d.Nome == disciplinaDTO.Nome)),Times.Once);

    }

    [Fact]
    public void TestePutDisciplina()
    {
        //preparar
        DisciplinaPutDTO disciplinaDTO = new();
        Disciplina disciplina = new();
        RepoDisciplina.Setup(x => x.GetById(It.IsAny<int>())).Returns(disciplina);
        //atuar
        Sut.PutDisciplina(disciplinaDTO);
        //verificar
        RepoDisciplina.Verify(x => x.Put(disciplina), Times.Once);
    }

    [Fact]
    public void TesteGetByIdDisciplina()
    {
        //preparar
        DisciplinaPutDTO disciplinaDTO = new();
        Disciplina disciplina = new();
        RepoDisciplina.Setup(x => x.GetById(It.IsAny<int>())).Returns(disciplina);
        //atuar
        Sut.PutDisciplina(disciplinaDTO);
        //verificar
        Assert.NotNull(disciplina);
    }


    [Fact]
    public void TesteDeleteDisciplina()
    {
        //
        int id = 2;
        Disciplina disciplina = new();
        RepoDisciplina.Setup(d => d.GetById(It.IsAny<int>())).Returns(disciplina);
        //
        Sut.DeleteDisciplina(id);
        //
        RepoDisciplina.Verify(x => x.Delete(disciplina), Times.Once);
    }

   

    
}
}
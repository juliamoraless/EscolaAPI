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

public class AlunoServiceTeste
{
    private readonly AlunoService Sut;
    private readonly Mock<IAlunoRepositorio> RepoAluno;
    private readonly Mock<ITurmaRepositorio> RepoTurma;

    public AlunoServiceTeste()
    {
        RepoAluno = new();
        RepoTurma = new();
        IMapper Mapper = new MapperConfiguration(x => x.AddProfile(new AlunoProfile())).CreateMapper();
        Sut = new(RepoAluno.Object, RepoTurma.Object, Mapper);
    }

    [Fact]
    public void TesteMetodo_GetAlunoComTurma()
    {
        //preparar
        AlunoComIdDTO AlunoDTO = new();
        List<Aluno> Alunos = new();
        RepoAluno.Setup(x => x.GetAlunosComTurma()).Returns(Alunos);
        //atuar
        Sut.GetAlunos();
        //verificar
        RepoAluno.Verify(x => x.GetAlunosComTurma(), Times.Once);
        Assert.NotNull(Alunos);

    }

    [Fact]
    public void TurmaNula_NaoDevePostarAluno()
    {
        //
        AlunoComTurmaDTO AlunoDTO = new();
        Aluno Aluno = new();
        RepoTurma.Setup(x => x.GetTurmaByName(It.IsAny<string>())).Returns<Turma>(null);
        //
        Sut.PostAlunos(AlunoDTO);
        //
        RepoAluno.Verify(x => x.Post(It.IsAny<Aluno>()), Times.Never);
    }


    [Fact]
    public void TestePostAluno()
    {
        //
        AlunoComTurmaDTO AlunoDTO = new();
        AlunoDTO.Nome = "jose";
        Turma turma = new();
        RepoTurma.Setup(x => x.GetTurmaByName(It.IsAny<string>())).Returns(turma);
        //
        Sut.PostAlunos(AlunoDTO);
        //
        RepoAluno.Verify(x => x.Post(It.Is<Aluno>(d => d.Nome == AlunoDTO.Nome)),Times.Once);

    }

    [Fact]
    public void TestePutDisciplina()
    {
        //preparar
        AlunoComIdDTO AlunoDTO = new();
        Aluno Aluno = new();
        RepoAluno.Setup(x => x.GetById(It.IsAny<int>())).Returns(Aluno);
        //atuar
        Sut.PutAluno(AlunoDTO);
        //verificar
        RepoAluno.Verify(x => x.Put(Aluno), Times.Once);
    }

    [Fact]
    public void TesteDeleteAluno()
    {
        //
        Aluno Aluno = new();
        int id = 1;
        RepoAluno.Setup(x => x.GetById(It.IsAny<int>())).Returns(Aluno);
        //
        Sut.DeleteAluno(id);
        //
        RepoAluno.Verify(x => x.Delete(Aluno), Times.Once);
    } 

    
}
}
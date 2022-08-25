using AutoMapper;
using EscolaAPI.Application.Profiles;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Moq;
using Xunit;

namespace EscolaAPI.Testes
{

public class TurmaServiceTeste
{
    private readonly TurmaService Sut;
    private readonly Mock<ITurmaRepositorio> RepoTurma;
    private readonly Mock<IProfessorRepositorio> RepoProfessor;
        private readonly Mock<IDisciplinaRepositorio> RepoDisciplina;

    

    public TurmaServiceTeste()
    {
        RepoTurma = new Mock<ITurmaRepositorio>();
        RepoProfessor = new Mock<IProfessorRepositorio>();
        RepoDisciplina = new Mock<IDisciplinaRepositorio>();
        IMapper Mapper = new MapperConfiguration(x => x.AddProfile(new TurmaProfile())).CreateMapper();
        Sut = new(RepoTurma.Object, Mapper, RepoDisciplina.Object, RepoProfessor.Object);
    }

    [Fact]
    public void TesteGetAllTurmas()
    {
        //
        List<Turma> Turmas = new();
        Turma turma1 = new();
        turma1.Id = 1;
        turma1.Nome = "matematica";
        Turma turma2 = new();
        turma2.Id = 1;
        turma2.Nome = "portugues";
        Turmas.Add(turma1);
        Turmas.Add(turma2);
        RepoTurma.Setup(d => d.GetAll()).Returns(Turmas);
        //
        List<TurmaGetDTO> Lista = Sut.GetTurmas();
        //
        RepoTurma.Verify(x => x.GetAll(), Times.Once);
        Assert.NotEmpty(Lista);

    }

    [Fact]
    public void TesteRetorno_GetTurmaById()
    {
        //preparar
        TurmaGetByIdDTO TurmaDTO = new();
        Turma Turma = new();
        Turma.Nome = "infantil";
        RepoTurma.Setup(x => x.GetTurmaComTudoById(It.IsAny<int>())).Returns(Turma);
        //atuar
        Sut.GetTurmaById(It.IsAny<int>());
        //verificar
        Assert.NotNull(Turma);
        Assert.Equal("infantil", Turma.Nome);
    }

    [Fact]
    public void TesteMetodo_GetTurmaComTudoById()
    {
        //preparar
        TurmaGetByIdDTO TurmaDTO = new();
        Turma Turma = new();
        RepoTurma.Setup(x => x.GetTurmaComTudoById(It.IsAny<int>())).Returns(Turma);
        //atuar
        Sut.GetTurmaById(It.IsAny<int>());
        //verificar
        RepoTurma.Verify(x => x.GetTurmaComTudoById(It.IsAny<int>()), Times.Once);
        Assert.NotNull(Turma);

    }

    [Fact]
    public void ProfessorNulo_NaoDevePostarTurma()
    {
        //
        TurmaPostDTO turmaDTO = new();
        Turma turma = new();
        RepoProfessor.Setup(x => x.GetProfessorByName(It.IsAny<string>())).Returns<Professor>(null);
        //
        Sut.PostTurmas(turmaDTO);
        //
        RepoTurma.Verify(x => x.Post(It.IsAny<Turma>()), Times.Never);
    }

    [Fact]
    public void turmaiplinaNulo_NaoDevePostarTurma()
    {
        //
        TurmaPostDTO turmaDTO = new();
        Turma turma = new();
        RepoDisciplina.Setup(x => x.GetDisciplinaByName(It.IsAny<string>())).Returns<Disciplina>(null);
        //
        Sut.PostTurmas(turmaDTO);
        //
        RepoTurma.Verify(x => x.Post(It.IsAny<Turma>()), Times.Never);
    }

    [Fact]
    public void TestePostTurma()
    {
        //
        TurmaPostDTO turmaDTO = new();
        turmaDTO.Nome = "Infantil";
        Professor prof = new();
        Disciplina turma = new();
        RepoDisciplina.Setup(x => x.GetDisciplinaByName(It.IsAny<string>())).Returns(turma);
        RepoProfessor.Setup(x => x.GetProfessorByName(It.IsAny<string>())).Returns(prof);
        //
        Sut.PostTurmas(turmaDTO);
        //
        RepoTurma.Verify(x => x.Post(It.Is<Turma>(d => d.Nome == turmaDTO.Nome)),Times.Once);

    }

    [Fact]
    public void TestePutturmaiplina()
    {
        //preparar
        TurmaPutDTO turmaDTO = new();
        Turma turma = new();
        RepoTurma.Setup(x => x.GetById(It.IsAny<int>())).Returns(turma);
        //atuar
        Sut.PutTurmas(turmaDTO);
        //verificar
        RepoTurma.Verify(x => x.Put(turma), Times.Once);
    }

    [Fact]
    public void TesteDeleteTurma()
    {
        //
        Turma Turma = new();
        int id = 1;
        RepoTurma.Setup(x => x.GetById(It.IsAny<int>())).Returns(Turma);
        //
        Sut.DeleteTurmas(id);
        //
        RepoTurma.Verify(x => x.Delete(Turma), Times.Once);
    }


    
}
}
using EscolaAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Infra.Context
{
    public class EscolaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public EscolaContext(DbContextOptions<EscolaContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>().HasKey(a => a.Id); //definindo chaves primarias
            builder.Entity<Professor>().HasKey(p => p.Id);
            builder.Entity<Disciplina>().HasKey(d => d.Id);
            builder.Entity<Turma>().HasKey(t => t.Id);

            //relacoes entre entidades

            builder.Entity<Turma>()   
                .HasOne(t => t.Professor)  //relacao em que um professor tem uma turma e vice-versa
                    .WithOne(p => p.Turma)
                        .HasForeignKey<Turma>(t => t.ProfessorId);

            builder.Entity<Turma>()
                .HasMany(t => t.Alunos)  //1 turma tem varios alunos e 1 aluno tem 1 turma
                    .WithOne(a => a.Turma)
                        .HasForeignKey(a => a.TurmaId); 

            builder.Entity<Turma>()
                .HasOne(t => t.Disciplina) //1 turma tem 1 disciplina que tem muitas turmas
                    .WithMany(d => d.Turmas)
                        .HasForeignKey(t => t.DisciplinaId);

            builder.Entity<Usuario>().HasData(new Usuario()
            {
                Id = 1,
                Nome = "Julia",
                Senha = "julia123",
                Cargo = "Administrador"
            });
            builder.Entity<Usuario>().HasData(new Usuario()
            {
                Id = 2,
                Nome = "Rafael",
                Senha = "rafael123",
                Cargo = "Funcionario"
            });
            builder.Entity<Disciplina>().HasData(new Disciplina()
            {
                Nome = "Matematica",
                Id = 1
            });
            builder.Entity<Professor>().HasData(new Professor()
            {
                Nome = "Fabio",
                Id = 1
            });

        }

    }

}
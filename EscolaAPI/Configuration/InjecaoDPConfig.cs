using EscolaAPI.Infra.Repositories;
using EscolaAPI.Application.Services;
using EscolaAPI.Infra;
using EscolaAPI.Domain.Interfaces;

namespace EscolaAPI.Configuration
{
    public static class InjecaoDPConfig
    {
        public static void AddRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IDisciplinaRepositorio, DisciplinaRepositorio>();
            services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<ITurmaRepositorio, TurmaRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<UsuarioService>();
            services.AddTransient<AlunoService>();
            services.AddTransient<TurmaService>();
            services.AddTransient<ProfessorService>();
            services.AddTransient<DisciplinaService>();
        }
        
    }
}
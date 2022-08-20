using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EscolaAPI.Application
{
    public static class InjecaoDP
    {
        public static void AddApplication(this IServiceCollection Service)
        {
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
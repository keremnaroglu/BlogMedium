using WebApplication1.Data;
using WebApplication1.IRepositories;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public static class DependencyInjection
    {
        public static void AddScopeEf(this IServiceCollection services)
        {
            services.AddDbContext<Context>()
                .AddScoped<IKisiRepository, KisiRepository>()
                .AddScoped<IKonuRepository, KonuRepository>()
                .AddScoped<IMakaleRepository, MakaleRepository>();
        }
    }
}

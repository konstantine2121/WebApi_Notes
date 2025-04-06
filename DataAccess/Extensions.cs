using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<INoteRepository, NoteRepository>();
        servicesCollection.AddDbContext<AppContext>(x =>
        {
            x.UseNpgsql("Host=localhost; Database=Notes; Username=postgres;Password=postgres");
        });

        return servicesCollection;
    }
}
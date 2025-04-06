using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class Extensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<INoteService, NoteService>();

        return servicesCollection;
    }
}
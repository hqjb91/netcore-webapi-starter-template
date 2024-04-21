using API.Modules;

namespace API.Extensions;
public static class WebApplicationBuilderExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {      
        var modules = typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
        
        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }
    }
}
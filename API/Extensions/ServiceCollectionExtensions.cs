using API.Modules;

namespace API.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddModules(this IServiceCollection services)
    {
        var modules = typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
        
        foreach (var module in modules)
        {
            module.RegisterModules(services);
        }
    }
}
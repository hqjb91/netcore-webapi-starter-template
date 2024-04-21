namespace API.Modules;

public interface IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services);
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
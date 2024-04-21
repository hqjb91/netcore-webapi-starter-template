using Application.Features.EAV.Commands.CreateEAVEntity;
using Core.Application.Features.EAV.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.EAV;
public class EAVEntityModule : IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        // services.AddScoped<IExampleService, ExampleService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("eaventity", 
            (
                [FromBody] CreateEAVEntityCommand createEAVEntityCommand,
                [FromServices] IMediator mediatR
            ) => 
            {
                return mediatR.Send(createEAVEntityCommand);
            })
            .CacheOutput()
            .WithTags("EAVEntities")
            .WithName("CreateEAVEntity")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Create a new EAV Entity"
            });

        endpoints.MapGet("eaventity", 
            (
                [FromQuery] string description,
                [FromServices] IMediator mediatR
            ) => 
            {
                var query = new GetAllEAVEntitiesByDescriptionQuery()
                                {
                                    Description = description
                                };
                return mediatR.Send(query);
            })
            .CacheOutput()
            .WithTags("EAVEntities")
            .WithName("GetEAVEntitiesByDescription")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Get EAV Entities by Description"
            });

        return endpoints;
    }
}
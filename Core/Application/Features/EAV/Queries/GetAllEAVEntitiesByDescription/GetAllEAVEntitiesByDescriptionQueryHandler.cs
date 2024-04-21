using Application.Contracts.Persistence.Repositories;
using Core.Application.Features.EAV.Queries;
using Core.Domain.Specification.EAV;
using Domain;
using MediatR;

namespace Application.Features.EAV.Commands.CreateEAVEntity;

public class GetAllEAVEntitiesByDescriptionQueryHandler(IReadRepository<EAVEntity> repository) : IRequestHandler<GetAllEAVEntitiesByDescriptionQuery, GetAllEAVEntitiesByDescriptionQueryResponse>
{
    private readonly IReadRepository<EAVEntity> _repository = repository;
    public async Task<GetAllEAVEntitiesByDescriptionQueryResponse> Handle(GetAllEAVEntitiesByDescriptionQuery request, CancellationToken cancellationToken)
    {
        GetAllEAVEntitiesByDescriptionQueryResponse response = new GetAllEAVEntitiesByDescriptionQueryResponse();

        var spec = new EAVEntityByDescriptionSpecification(request.Description);
        IReadOnlyCollection<EAVEntity> specResult = await _repository.ListAsync(spec);

        response.EAVEntities = specResult;

        return response;
    }
}
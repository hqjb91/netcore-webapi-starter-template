using MediatR;

namespace Core.Application.Features.EAV.Queries;

public class GetAllEAVEntitiesByDescriptionQuery : IRequest<GetAllEAVEntitiesByDescriptionQueryResponse>
{
    public string Description { get; set; } = string.Empty;
}
using Application.Responses;
using Domain;

namespace Core.Application.Features.EAV.Queries;

public class GetAllEAVEntitiesByDescriptionQueryResponse : BaseResponse
{
    public IReadOnlyCollection<EAVEntity>? EAVEntities { get; set; }
}
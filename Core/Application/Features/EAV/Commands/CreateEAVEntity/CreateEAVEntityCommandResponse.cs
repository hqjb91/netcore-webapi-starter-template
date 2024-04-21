using Application.Responses;

namespace Application.Features.EAV.Commands.CreateEAVEntity;

public class CreateEAVEntityCommandResponse : BaseResponse
{
    public CreateEAVEntityDto EAVEntity { get; set; } = default!;
}
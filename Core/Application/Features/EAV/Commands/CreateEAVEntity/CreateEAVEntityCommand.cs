using MediatR;

namespace Application.Features.EAV.Commands.CreateEAVEntity;

public class CreateEAVEntityCommand: IRequest<CreateEAVEntityCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
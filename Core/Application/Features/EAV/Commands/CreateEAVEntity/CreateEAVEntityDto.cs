namespace Application.Features.EAV.Commands.CreateEAVEntity;
public class CreateEAVEntityDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
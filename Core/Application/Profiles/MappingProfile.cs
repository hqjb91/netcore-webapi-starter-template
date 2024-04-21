using Application.Features.EAV.Commands.CreateEAVEntity;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EAVEntity, CreateEAVEntityCommand>().ReverseMap();
        CreateMap<EAVEntity, CreateEAVEntityDto>().ReverseMap();
    }
}
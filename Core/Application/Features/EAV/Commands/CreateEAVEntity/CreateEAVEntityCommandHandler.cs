using Application.Contracts.Persistence.Repositories;
using Ardalis.Specification;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EAV.Commands.CreateEAVEntity;

public class CreateEAVEntityCommandHandler(IRepository<EAVEntity> repository, IMapper mapper) : IRequestHandler<CreateEAVEntityCommand, CreateEAVEntityCommandResponse>
{
    private readonly IRepositoryBase<EAVEntity> _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<CreateEAVEntityCommandResponse> Handle(CreateEAVEntityCommand request, CancellationToken cancellationToken)
    {
        CreateEAVEntityCommandResponse response = new CreateEAVEntityCommandResponse();

        EAVEntity eavEntity = _mapper.Map<EAVEntity>( request );
        EAVEntity result = await _repository.AddAsync( eavEntity );
        CreateEAVEntityDto resultDto = _mapper.Map<CreateEAVEntityDto>(result);
        response.EAVEntity = resultDto;

        return response;
    }
}
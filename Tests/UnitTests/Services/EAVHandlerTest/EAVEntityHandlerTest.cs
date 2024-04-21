using Application.Features.EAV.Commands.CreateEAVEntity;
using Ardalis.Specification;
using AutoFixture.Xunit2;
using AutoMapper;
using Domain;
using Moq;
using Tests.UnitTests.Helpers;
using Newtonsoft.Json;

namespace Tests.UnitTests.Services.EAVHandlerTest;

public class EAVEntityHandlerTest
{
    [Theory, GenerateDefaultTestData]
    public async Task EAVService_CreateEAVEntityCommandHandler_Handle_Returns_CreateEAVEntityCommandResponse(
        [Frozen] Mock<IRepositoryBase<EAVEntity>> eavEntityRepositoryMock,
        [Frozen] Mock<IMapper> mapperMock,
        CreateEAVEntityCommandHandler createEAVEntityCommandHandler)
    {
        // Arrange
        CreateEAVEntityCommandResponse expectedResponse = new CreateEAVEntityCommandResponse()
        {
            EAVEntity = new CreateEAVEntityDto()
            {
                Id = 1,
                Name = "Test",
                Description = "Test Description"
            }
        };

        CreateEAVEntityCommand testRequest = new CreateEAVEntityCommand()
        {
            Name = "Test",
            Description = "Test Description"
        };

        EAVEntity eavEntity = new EAVEntity()
        {
            Id = 1,
            Name = "Test",
            Description = "Test Description"
        };

        CreateEAVEntityDto eavEntityDto = new CreateEAVEntityDto()
        {
            Id = 1,
            Name = "Test",
            Description = "Test Description"
        };

        mapperMock
            .Setup(x => x.Map<EAVEntity>(It.IsAny<CreateEAVEntityCommand>()))
            .Returns(eavEntity);

        eavEntityRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<EAVEntity>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(eavEntity));

        mapperMock
            .Setup(x => x.Map<CreateEAVEntityDto>(It.IsAny<EAVEntity>()))
            .Returns(eavEntityDto);

        // Act
        CreateEAVEntityCommandResponse testResponse = 
            await createEAVEntityCommandHandler.Handle(testRequest, new CancellationToken());

        // Assert
        string expectedResponseStr = JsonConvert.SerializeObject(expectedResponse);
        string testResponseStr = JsonConvert.SerializeObject(testResponse);
        Assert.Equal(expectedResponseStr, testResponseStr);
    }
}
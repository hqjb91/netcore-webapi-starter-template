using System.Net;
using System.Net.Http.Json;
using Application.Features.EAV.Commands.CreateEAVEntity;
using Tests.IntegrationTests.Helpers;

namespace Tests.IntegrationTests.EAV;

public class EAVTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task Create_New_EAVEntity_Returns_OK()
    {
        HttpClient client = _factory.CreateClient();

        var createEAVEntityResponse = await client.PostAsJsonAsync("eaventity", new CreateEAVEntityCommand()
        {
            Name = "Test",
            Description = "Test Description"
        });

        Assert.Equal(HttpStatusCode.OK, createEAVEntityResponse.StatusCode);
    }
}
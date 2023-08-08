using FluentAssertions;
using System.Net.Http.Json;
using Contexts.Users.Application.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Contexts.Users.Domain;
using Contexts.Users.Application.Command;
using System.Net;

namespace IntegrationTest;

public class IntegrationTestCreateUser
{

    [Fact]
    public async void Create_User()
    {
        ApiWebApplicationFactory Application = new ApiWebApplicationFactory();
        var client = Application.CreateClient();

        var newClient = new CreateUserCommand(){
            Name = "Test",
            Email = "test@gmail.com",
            Country = "Nicaragua",
            Image = "https://myurl"
        };

        var result = await client.PostAsJsonAsync("/api/users", newClient);
        
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
using FluentAssertions;
using System.Net.Http.Json;
using Contexts.Users.Application.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest;

public class IntegrationTestGetAllUsers
{

    [Fact]
    public async void Get_All_Users()
    {
        ApiWebApplicationFactory Application = new ApiWebApplicationFactory();
        var client = Application.CreateClient();

        //var users = await client.GetFromJsonAsync<List<UserDTO>>("/api/users");
        HttpResponseMessage response = await client.GetAsync("/api/users");
        response.EnsureSuccessStatusCode();

        var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
        users.Should().NotBeNullOrEmpty();
    }
}
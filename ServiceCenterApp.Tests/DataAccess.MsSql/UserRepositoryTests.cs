using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories;
using Xunit;

public class UserRepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Should_Get_User_By_Email()
    {
        using var context = CreateContext();

        context.Users.Add(new User
        {
            Id = Guid.NewGuid(),
            Email = "test@mail.com",
            FullName = "Test"
        });

        context.SaveChanges();

        var repo = new UserRepository(context);

        var result = await repo.GetByEmailAsync("test@mail.com");

        result.Should().NotBeNull();
        result!.Email.Should().Be("test@mail.com");
    }
}
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories;
using Xunit;

public class RepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Should_Add_Entity()
    {
        using var context = CreateContext();
        var repo = new Repository<Service>(context);

        var service = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            BasePrice = 100
        };

        await repo.AddAsync(service);

        context.Services.Should().HaveCount(1);
    }

    [Fact]
    public async Task Should_Get_By_Id()
    {
        using var context = CreateContext();
        var repo = new Repository<Service>(context);

        var service = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            BasePrice = 100
        };

        await repo.AddAsync(service);

        var result = await repo.GetByIdAsync(service.Id);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Test");
    }

    [Fact]
    public async Task Should_Delete_Entity()
    {
        using var context = CreateContext();
        var repo = new Repository<Service>(context);

        var service = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            BasePrice = 100
        };

        await repo.AddAsync(service);
        await repo.DeleteAsync(service);

        context.Services.Should().BeEmpty();
    }
}
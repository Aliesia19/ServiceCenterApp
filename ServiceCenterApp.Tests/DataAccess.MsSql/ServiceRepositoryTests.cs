using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories;
using Xunit;

public class ServiceRepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Should_Add_Service()
    {
        using var context = CreateContext();
        var repo = new ServiceRepository(context);

        var service = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Repair",
            BasePrice = 200
        };

        await repo.AddAsync(service);

        context.Services.Should().HaveCount(1);
    }
}
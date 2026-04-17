using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories;
using Xunit;

public class RequestRepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Should_Get_By_ClientId()
    {
        using var context = CreateContext();

        var clientId = Guid.NewGuid();

        var client = new User
        {
            Id = clientId,
            FullName = "Test Client",
            Email = "test@test.com"
        };

        var consultant = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Consultant",
            Email = "c@test.com"
        };

        context.Users.AddRange(client, consultant);

        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            ClientId = clientId,
            Client = client,
            ConsultantId = consultant.Id,
            Consultant = consultant,
            Status = RequestStatus.New
        };

        context.RepairRequests.Add(request);

        await context.SaveChangesAsync();

        var repo = new RequestRepository(context);

        var result = await repo.GetByClientIdAsync(clientId);

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task Should_Get_By_MasterId()
    {
        using var context = CreateContext();

        var masterId = Guid.NewGuid();

        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            MasterId = masterId,
            Status = RequestStatus.InProgress
        };

        context.RepairRequests.Add(request);

        await context.SaveChangesAsync();

        var repo = new RequestRepository(context);

        var result = await repo.GetByMasterIdAsync(masterId);

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task Should_Get_By_Status()
    {
        using var context = CreateContext();

        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Status = RequestStatus.Completed
        };

        context.RepairRequests.Add(request);

        await context.SaveChangesAsync();

        var repo = new RequestRepository(context);

        var result = await repo.GetByStatusAsync(RequestStatus.Completed);

        result.Should().HaveCount(1);
    }
}
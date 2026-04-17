using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using FluentAssertions;
using Xunit;


public class AppDbContextTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void Should_Create_DbSets()
    {
        using var context = CreateContext(); 
        context.Users.Should().NotBeNull();
        context.RepairRequests.Should().NotBeNull();
        context.Services.Should().NotBeNull();
        context.ChatMessages.Should().NotBeNull();
        context.ChecklistItems.Should().NotBeNull();
        context.Notifications.Should().NotBeNull();
        context.EquipmentTypes.Should().NotBeNull();
    }
}
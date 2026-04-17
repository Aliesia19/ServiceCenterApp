using System;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;

public class DatabaseInitializerTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void Should_Seed_Data_When_Database_Is_Empty()
    {
        using var context = CreateContext();

        var initializer = new DatabaseInitializer(context);

        initializer.Initialize();

        context.Services.Should().HaveCountGreaterThan(0);
        context.EquipmentTypes.Should().HaveCountGreaterThan(0);
    }
}
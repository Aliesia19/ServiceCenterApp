using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class GetEquipmentTypesTests
{
    private readonly IRepository<EquipmentType> _repo = Substitute.For<IRepository<EquipmentType>>();
    private readonly GetEquipmentTypes _useCase;

    public GetEquipmentTypesTests()
    {
        _useCase = new GetEquipmentTypes(_repo);
    }

    [Fact]
    public async Task Should_Return_All_Equipment_Types()
    {
        var data = new List<EquipmentType>
        {
            new EquipmentType { Id = Guid.NewGuid(), Name = "TV" },
            new EquipmentType { Id = Guid.NewGuid(), Name = "Laptop" }
        };

        _repo.GetAllAsync().Returns(data);

        var result = await _useCase.Execute();

        result.Should().HaveCount(2);
        result.First().Name.Should().Be("TV");

        await _repo.Received(1).GetAllAsync();
    }
}
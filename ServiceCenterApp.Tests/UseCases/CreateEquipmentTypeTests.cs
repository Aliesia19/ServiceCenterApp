using NSubstitute;
using Xunit;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases;

public class CreateEquipmentTypeTests
{
    private readonly IRepository<EquipmentType> _repo =
        Substitute.For<IRepository<EquipmentType>>();

    private readonly CreateEquipmentType _useCase;

    public CreateEquipmentTypeTests()
    {
        _useCase = new CreateEquipmentType(_repo);
    }

    [Fact]
    public async Task Should_Add_EquipmentType_To_Repository()
    {
        var dto = new EquipmentTypeDto
        {
            Name = "Laptop"
        };

        await _useCase.Execute(dto);

        await _repo.Received(1).AddAsync(Arg.Is<EquipmentType>(
            x => x.Name == "Laptop" && x.Id != Guid.Empty));
    }
}
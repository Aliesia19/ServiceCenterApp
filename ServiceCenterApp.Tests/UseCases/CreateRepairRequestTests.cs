using NSubstitute;
using Xunit;
using FluentAssertions;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases;

public class CreateRepairRequestTests
{
    private readonly IRequestRepository _repo =
        Substitute.For<IRequestRepository>();

    private readonly CreateRepairRequest _useCase;

    public CreateRepairRequestTests()
    {
        _useCase = new CreateRepairRequest(_repo);
    }

    [Fact]
    public async Task Should_Create_Request_With_New_Status()
    {
        var dto = new CreateRepairRequestDto
        {
            ClientId = Guid.NewGuid(),
            EquipmentTypeId = Guid.NewGuid(),
            Description = "Broken screen",
            Street = "Main",
            City = "Kyiv",
            ZipCode = "01001"
        };

        Guid resultId = await _useCase.Execute(dto);

        await _repo.Received(1).AddAsync(Arg.Is<RepairRequest>(r =>
            r.ClientId == dto.ClientId &&
            r.Status == RequestStatus.New &&
            r.Description == dto.Description &&
            r.ClientAddress.City == dto.City &&
            r.EquipmentType != null &&
            r.EquipmentType.Id == dto.EquipmentTypeId &&
            r.Id != Guid.Empty
        ));

        resultId.Should().NotBe(Guid.Empty);
    }
}
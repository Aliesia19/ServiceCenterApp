using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using Xunit;

public class RequestDetailsTests
{
    private readonly RequestDetailsMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map_Complex_Object()
    {
        var domain = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Description = "Fix laptop",
            Status = RequestStatus.InProgress,
            Client = new User { FullName = "Client" },
            Master = new User { FullName = "Master" },
            Checklist = new List<ChecklistItem>
            {
                new ChecklistItem
                {
                    Quantity = 1,
                    Price = 100,
                    Service = new Service { Name = "Fix" }
                }
            }
        };

        var dto = _mapper.ToDto(domain);

        dto.Description.Should().Be("Fix laptop");
        dto.Status.Should().Be("InProgress");
        dto.ClientName.Should().Be("Client");
        dto.MasterName.Should().Be("Master");
        dto.Checklist.Should().HaveCount(1);
    }
}
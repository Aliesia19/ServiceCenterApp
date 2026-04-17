using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.Entities;

public class CalculateTotalPriceTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly CalculateTotalPrice _useCase;

    public CalculateTotalPriceTests()
    {
        _useCase = new CalculateTotalPrice(_repo);
    }

    [Fact]
    public async Task Should_Calculate_Total_Price()
    {
        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Checklist = new List<ChecklistItem>
            {
                new ChecklistItem { Price = 100, Quantity = 2 },
                new ChecklistItem { Price = 50, Quantity = 1 }
            }
        };

        _repo.GetByIdAsync(request.Id).Returns(request);

        await _useCase.Execute(request.Id);

        request.TotalPrice.Should().Be(250);

        await _repo.Received(1).UpdateAsync(request);
    }

    [Fact]
    public async Task Should_Do_Nothing_When_Request_Not_Found()
    {
        var id = Guid.NewGuid();

        _repo.GetByIdAsync(id).Returns(null as RepairRequest);

        await _useCase.Execute(id);

        await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
    }
}
using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class GetStatisticsTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly GetStatistics _useCase;

    public GetStatisticsTests()
    {
        _useCase = new GetStatistics(_repo);
    }

    [Fact]
    public async Task Should_Calculate_Statistics_Correctly()
    {
        // ARRANGE
        var requests = new List<RepairRequest>
        {
            new RepairRequest { Status = RequestStatus.Completed, TotalPrice = 100 },
            new RepairRequest { Status = RequestStatus.Completed, TotalPrice = 200 },
            new RepairRequest { Status = RequestStatus.InProgress, TotalPrice = 50 }
        };

        _repo.GetAllAsync().Returns(requests);

        // ACT
        var result = await _useCase.Execute();

        // ASSERT
        result.TotalRequests.Should().Be(3);
        result.CompletedRequests.Should().Be(2);
        result.TotalRevenue.Should().Be(350);
    }
}
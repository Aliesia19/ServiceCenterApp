using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Tests.UseCases;

public class CompleteRequestTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly CompleteRequest _useCase;

    public CompleteRequestTests()
    {
        _useCase = new CompleteRequest(_repo);
    }

    [Fact]
    public async Task Should_Complete_Request()
    {
        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Status = RequestStatus.InProgress
        };

        _repo.GetByIdAsync(request.Id).Returns(request);

        await _useCase.Execute(request.Id);

        request.Status.Should().Be(RequestStatus.Completed);
        request.ClosedAt.Should().NotBeNull();

        await _repo.Received(1).UpdateAsync(request);
    }

    [Fact]
    public async Task Should_Do_Nothing_When_Request_Not_Found()
    {
        _repo.GetByIdAsync(Arg.Any<Guid>())
              .Returns((RepairRequest?)null);

        await _useCase.Execute(Guid.NewGuid());

        await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
    }
}
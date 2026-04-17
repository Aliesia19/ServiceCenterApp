using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;
using Xunit;

namespace ServiceCenterApp.Tests.UseCases
{
    public class RejectRequestTests
    {
        private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
        private readonly RejectRequest _useCase;

        public RejectRequestTests()
        {
            _useCase = new RejectRequest(_repo);
        }

        [Fact]
        public async Task Should_Cancel_Request_And_Clear_Master()
        {
            // Arrange
            var request = new RepairRequest
            {
                Id = Guid.NewGuid(),
                MasterId = Guid.NewGuid(),
                Status = RequestStatus.InProgress
            };

            _repo.GetByIdAsync(request.Id).Returns(request);

            // Act
            await _useCase.Execute(request.Id);

            // Assert
            request.MasterId.Should().BeNull();
            request.Status.Should().Be(RequestStatus.Canceled);

            await _repo.Received(1).UpdateAsync(request);
        }

        [Fact]
        public async Task Should_Do_Nothing_When_Not_Found()
        {
            // FIXED HERE ↓↓↓
            _repo.GetByIdAsync(Arg.Any<Guid>()).Returns((RepairRequest?)null);

            await _useCase.Execute(Guid.NewGuid());

            await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
        }
    }
}
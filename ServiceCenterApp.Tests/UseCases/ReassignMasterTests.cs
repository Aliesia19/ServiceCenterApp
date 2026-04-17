using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Domain.Interfaces;
using Xunit;

namespace ServiceCenterApp.Tests.UseCases
{
    public class ReassignMasterTests
    {
        private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
        private readonly ReassignMaster _useCase;

        public ReassignMasterTests()
        {
            _useCase = new ReassignMaster(_repo);
        }

        [Fact]
        public async Task Should_Update_MasterId_When_Request_Exists()
        {
            // Arrange
            var request = new RepairRequest
            {
                Id = Guid.NewGuid(),
                MasterId = Guid.NewGuid()
            };

            var dto = new AssignMasterDto
            {
                RequestId = request.Id,
                MasterId = Guid.NewGuid()
            };

            _repo.GetByIdAsync(dto.RequestId).Returns(request);

            // Act
            await _useCase.Execute(dto);

            // Assert
            request.MasterId.Should().Be(dto.MasterId);
            await _repo.Received(1).UpdateAsync(request);
        }

        [Fact]
        public async Task Should_Do_Nothing_When_Request_Not_Found()
        {
            // FIXED HERE ↓↓↓
            _repo.GetByIdAsync(Arg.Any<Guid>()).Returns((RepairRequest?)null);

            var dto = new AssignMasterDto
            {
                RequestId = Guid.NewGuid(),
                MasterId = Guid.NewGuid()
            };

            // Act
            await _useCase.Execute(dto);

            // Assert
            await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
        }
    }
}
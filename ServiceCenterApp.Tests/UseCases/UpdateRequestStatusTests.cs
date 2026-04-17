using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases
{
    public class UpdateRequestStatusTests
    {
        private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
        private readonly UpdateRequestStatus _useCase;

        public UpdateRequestStatusTests()
        {
            _useCase = new UpdateRequestStatus(_repo);
        }

        [Fact]
        public async Task Should_Update_Status_When_Request_Exists()
        {
            var request = new RepairRequest
            {
                Id = Guid.NewGuid(),
                Status = RequestStatus.New
            };

            var dto = new UpdateRequestStatusDto
            {
                RequestId = request.Id,
                Status = RequestStatus.Completed.ToString()
            };

            _repo.GetByIdAsync(request.Id)
                .Returns(Task.FromResult<RepairRequest?>(request));

            await _useCase.Execute(dto);

            request.Status.Should().Be(RequestStatus.Completed);
            await _repo.Received(1).UpdateAsync(request);
        }

        [Fact]
        public async Task Should_Do_Nothing_When_Request_Not_Found()
        {
            var dto = new UpdateRequestStatusDto
            {
                RequestId = Guid.NewGuid(),
                Status = RequestStatus.Completed.ToString()
            };

            _repo.GetByIdAsync(dto.RequestId)
                .Returns(Task.FromResult<RepairRequest?>(null));

            await _useCase.Execute(dto);

            await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
        }
    }
}
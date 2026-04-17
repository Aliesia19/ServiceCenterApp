using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Tests.UseCases
{
    public class AssignMasterTests
    {
        private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
        private readonly AssignMaster _useCase;

        public AssignMasterTests()
        {
            _useCase = new AssignMaster(_repo);
        }

        [Fact]
        public async Task Should_Assign_Master_And_Set_Status()
        {
            var request = new RepairRequest
            {
                Id = Guid.NewGuid(),
                Status = RequestStatus.New
            };

            var dto = new AssignMasterDto
            {
                RequestId = request.Id,
                MasterId = Guid.NewGuid()
            };

            _repo.GetByIdAsync(request.Id).Returns(request);

            await _useCase.Execute(dto);

            request.MasterId.Should().Be(dto.MasterId);
            request.Status.Should().Be(RequestStatus.InProgress);

            await _repo.Received(1).UpdateAsync(request);
        }
    }
}
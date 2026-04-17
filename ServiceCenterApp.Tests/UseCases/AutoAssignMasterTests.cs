using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

public class AutoAssignMasterTests
{
    private readonly IRepository<User> _userRepo = Substitute.For<IRepository<User>>();
    private readonly IRequestRepository _requestRepo = Substitute.For<IRequestRepository>();
    private readonly AutoAssignMaster _useCase;

    public AutoAssignMasterTests()
    {
        _useCase = new AutoAssignMaster(_userRepo, _requestRepo);
    }

    [Fact]
    public async Task Should_Assign_Least_Loaded_Master()
    {
        var master1 = new User { Id = Guid.NewGuid(), Role = UserRole.Master };
        var master2 = new User { Id = Guid.NewGuid(), Role = UserRole.Master };

        _userRepo.GetAllAsync().Returns(new List<User> { master1, master2 });

        var requests = new List<RepairRequest>
        {
            new RepairRequest { MasterId = master1.Id },
            new RepairRequest { MasterId = master1.Id }
        };

        _requestRepo.GetAllAsync().Returns(requests);

        var targetRequest = new RepairRequest { Id = Guid.NewGuid() };

        _requestRepo.GetByIdAsync(targetRequest.Id).Returns(targetRequest);

        await _useCase.Execute(targetRequest.Id);

        targetRequest.MasterId.Should().Be(master2.Id);
        targetRequest.Status.Should().Be(RequestStatus.InProgress);

        await _requestRepo.Received(1).UpdateAsync(targetRequest);
    }

    [Fact]
    public async Task Should_Do_Nothing_When_No_Masters()
    {
        _userRepo.GetAllAsync().Returns(new List<User>());

        await _useCase.Execute(Guid.NewGuid());

        await _requestRepo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
    }
}
using Xunit;
using NSubstitute;
using AutoFixture;
using FluentAssertions;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.Entities;

public class AddChecklistItemTests
{
    private const RepairRequest? ReturnThis = (RepairRequest)null;
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly AddChecklistItem _useCase;

    private readonly Fixture _fixture = new();

    public AddChecklistItemTests()
    {
        _useCase = new AddChecklistItem(_repo);
    }

    [Fact]
    public async Task Should_Add_Item_To_Checklist_And_Update()
    {
        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Checklist = new List<ChecklistItem>()
        };

        _repo.GetByIdAsync(request.Id).Returns(request);

        var dto = _fixture.Create<AddChecklistItemDto>();
        dto.RequestId = request.Id;

        await _useCase.Execute(dto);

        request.Checklist.Should().HaveCount(1);

        await _repo.Received(1).UpdateAsync(request);
    }

    [Fact]
    public async Task Should_Do_Nothing_When_Request_Not_Found()
    {
        var dto = _fixture.Create<AddChecklistItemDto>();

        _repo.GetByIdAsync(dto.RequestId).Returns(ReturnThis);

        await _useCase.Execute(dto);

        await _repo.DidNotReceive().UpdateAsync(Arg.Any<RepairRequest>());
    }
}
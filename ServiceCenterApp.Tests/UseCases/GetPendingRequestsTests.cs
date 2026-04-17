using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class GetPendingRequestsTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper = Substitute.For<IMapper<RepairRequest, RepairRequestDto>>();

    private readonly GetPendingRequests _useCase;

    public GetPendingRequestsTests()
    {
        _useCase = new GetPendingRequests(_repo, _mapper);
    }

    [Fact]
    public async Task Should_Return_Pending_Requests()
    {
        var requests = new List<RepairRequest>
        {
            new RepairRequest { Id = Guid.NewGuid() }
        };

        _repo.GetByStatusAsync(RequestStatus.New).Returns(requests);

        _mapper.ToDto(Arg.Any<RepairRequest>())
            .Returns(new RepairRequestDto());

        var result = await _useCase.Execute();

        result.Should().HaveCount(1);
        await _repo.Received(1).GetByStatusAsync(RequestStatus.New);
    }
}
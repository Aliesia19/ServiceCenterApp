using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class GetMasterRequestsTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper = Substitute.For<IMapper<RepairRequest, RepairRequestDto>>();

    private readonly GetMasterRequests _useCase;

    public GetMasterRequestsTests()
    {
        _useCase = new GetMasterRequests(_repo, _mapper);
    }

    [Fact]
    public async Task Should_Return_Master_Requests()
    {
        var masterId = Guid.NewGuid();

        var requests = new List<RepairRequest>
        {
            new RepairRequest { Id = Guid.NewGuid() }
        };

        _repo.GetByMasterIdAsync(masterId)
            .Returns(requests);

        _mapper.ToDto(Arg.Any<RepairRequest>())
            .Returns(x => new RepairRequestDto());

        var result = await _useCase.Execute(masterId);

        result.Should().HaveCount(1);
        await _repo.Received(1)
            .GetByMasterIdAsync(masterId);
    }
}
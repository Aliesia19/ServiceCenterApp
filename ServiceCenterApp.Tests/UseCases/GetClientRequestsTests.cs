using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class GetClientRequestsTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly IMapper<RepairRequest, RepairRequestDto> _mapper =
        Substitute.For<IMapper<RepairRequest, RepairRequestDto>>();

    private readonly GetClientRequests _useCase;

    public GetClientRequestsTests()
    {
        _useCase = new GetClientRequests(_repo, _mapper);
    }

    [Fact]
    public async Task Should_Return_Mapped_Client_Requests()
    {
        // Arrange
        var clientId = Guid.NewGuid();

        var requests = new List<RepairRequest>
        {
            new RepairRequest { Id = Guid.NewGuid() },
            new RepairRequest { Id = Guid.NewGuid() }
        };

        _repo.GetByClientIdAsync(clientId)
            .Returns(requests);

        _mapper.ToDto(Arg.Any<RepairRequest>())
            .Returns(x => new RepairRequestDto
            {
                Id = ((RepairRequest)x[0]).Id
            });

        // Act
        var result = await _useCase.Execute(clientId);

        // Assert
        result.Should().HaveCount(2);

        await _repo.Received(1)
            .GetByClientIdAsync(clientId);
    }
}
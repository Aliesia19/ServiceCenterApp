using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

public class GetRequestDetailsTests
{
    private readonly IRequestRepository _repo = Substitute.For<IRequestRepository>();
    private readonly IMapper<RepairRequest, RequestDetailsDto> _mapper = Substitute.For<IMapper<RepairRequest, RequestDetailsDto>>();

    private readonly GetRequestDetails _useCase;

    public GetRequestDetailsTests()
    {
        _useCase = new GetRequestDetails(_repo, _mapper);
    }

    [Fact]
    public async Task Should_Return_Request_Details()
    {
        var id = Guid.NewGuid();

        var request = new RepairRequest { Id = id };

        _repo.GetByIdAsync(id).Returns(request);
        _mapper.ToDto(request).Returns(new RequestDetailsDto { Id = id });

        var result = await _useCase.Execute(id);

        result.Should().NotBeNull();
        result!.Id.Should().Be(id);

        await _repo.Received(1).GetByIdAsync(id);
    }

    [Fact]
    public async Task Should_Return_Null_When_Not_Found()
    {
        var id = Guid.NewGuid();

        _repo.GetByIdAsync(id).Returns((RepairRequest?)null);

        var result = await _useCase.Execute(id);

        result.Should().BeNull();
    }
}
using NSubstitute;
using Xunit;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases;

public class CreateServiceTests
{
    private readonly IRepository<Service> _repo =
        Substitute.For<IRepository<Service>>();

    private readonly CreateService _useCase;

    public CreateServiceTests()
    {
        _useCase = new CreateService(_repo);
    }

    [Fact]
    public async Task Should_Add_Service()
    {
        var dto = new ServiceDto
        {
            Name = "Repair",
            BasePrice = 100
        };

        await _useCase.Execute(dto);

        await _repo.Received(1).AddAsync(Arg.Is<Service>(s =>
            s.Name == "Repair" &&
            s.BasePrice == 100 &&
            s.Id != Guid.Empty
        ));
    }
}
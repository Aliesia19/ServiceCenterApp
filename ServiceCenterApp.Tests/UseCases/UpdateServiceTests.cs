using Xunit;
using NSubstitute;
using FluentAssertions;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases
{
    public class UpdateServiceTests
    {
        private readonly IRepository<Service> _repo = Substitute.For<IRepository<Service>>();
        private readonly UpdateService _useCase;

        public UpdateServiceTests()
        {
            _useCase = new UpdateService(_repo);
        }

        [Fact]
        public async Task Should_Update_Service_Correctly()
        {
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                BasePrice = 100
            };

            var dto = new ServiceDto
            {
                Id = service.Id,
                Name = "New Name",
                BasePrice = 250
            };

            _repo.GetByIdAsync(service.Id)
                .Returns(Task.FromResult<Service?>(service));

            await _useCase.Execute(dto);

            service.Name.Should().Be("New Name");
            service.BasePrice.Should().Be(250);

            await _repo.Received(1).UpdateAsync(service);
        }

        [Fact]
        public async Task Should_Do_Nothing_When_Service_Not_Found()
        {
            var dto = new ServiceDto
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                BasePrice = 100
            };

            _repo.GetByIdAsync(dto.Id)
                .Returns(Task.FromResult<Service?>(null));

            await _useCase.Execute(dto);

            await _repo.DidNotReceive().UpdateAsync(Arg.Any<Service>());
        }
    }
}
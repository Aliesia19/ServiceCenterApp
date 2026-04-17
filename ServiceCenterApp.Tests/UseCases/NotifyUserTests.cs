using NSubstitute;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using Xunit;

namespace ServiceCenterApp.Tests.UseCases
{
    public class NotifyUserTests
    {
        private readonly IRepository<Notification> _repo = Substitute.For<IRepository<Notification>>();
        private readonly NotifyUser _useCase;

        public NotifyUserTests()
        {
            _useCase = new NotifyUser(_repo);
        }

        [Fact]
        public async Task Should_Add_Notification()
        {
            var userId = Guid.NewGuid();
            var message = "Hello";

            await _useCase.Execute(userId, message);

            await _repo.Received(1).AddAsync(
                Arg.Is<Notification>(n =>
                    n.UserId == userId &&
                    n.Message == message &&
                    n.Id != Guid.Empty
                ));
        }
    }
}
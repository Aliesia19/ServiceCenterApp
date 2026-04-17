using NSubstitute;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using Xunit;

namespace ServiceCenterApp.Tests.UseCases
{
    public class SendMessageTests
    {
        private readonly IRepository<ChatMessage> _repo = Substitute.For<IRepository<ChatMessage>>();
        private readonly SendMessage _useCase;

        public SendMessageTests()
        {
            _useCase = new SendMessage(_repo);
        }

        [Fact]
        public async Task Should_Add_ChatMessage()
        {
            // Arrange
            var dto = new SendMessageDto
            {
                RequestId = Guid.NewGuid(),
                SenderId = Guid.NewGuid(),
                Message = "Hello"
            };

            // Act
            await _useCase.Execute(dto);

            // Assert
            await _repo.Received(1).AddAsync(
                Arg.Is<ChatMessage>(m =>
                    m.RepairRequestId == dto.RequestId &&
                    m.SenderId == dto.SenderId &&
                    m.Message == dto.Message &&
                    m.Id != Guid.Empty
                ));
        }
    }
}
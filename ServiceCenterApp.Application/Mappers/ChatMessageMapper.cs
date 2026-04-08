using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Application.Mappers
{
    public class ChatMessageMapper : IMapper<ChatMessage, ChatMessageDto>
    {
        public ChatMessageDto ToDto(ChatMessage domain)
        {
            return new ChatMessageDto
            {
                Id = domain.Id,
                SenderName = domain.Sender.FullName,
                Message = domain.Message,
                SentAt = domain.SentAt
            };
        }

        public ChatMessage ToDomain(ChatMessageDto dto)
        {
            return new ChatMessage
            {
                Id = dto.Id,
                Message = dto.Message,
                SentAt = dto.SentAt
            };
        }
    }
}
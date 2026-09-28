using Translator.Api.Models;

namespace Translator.Api.Interfaces;

public interface IConversationService
{
    Conversation CreateConversation();
    Conversation? GetConversation(Guid id);
    bool AddMessage(Guid conversationId, ConversationMessage message);

}

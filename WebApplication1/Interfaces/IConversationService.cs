using Translator.Api.Models;

namespace Translator.Api.Interfaces;

public interface IConversationService
{
    Conversation CreateConversation();
    Conversation? GetConversation(Guid id);
    void AddMessage(Guid conversationId, ConversationMessage message);

}

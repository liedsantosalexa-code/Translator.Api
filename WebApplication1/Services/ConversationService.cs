using Translator.Api.Models;
using Translator.Api.Interfaces;

namespace Translator.Api.Services;

public class ConversationService : IConversationService
{
    private readonly Dictionary<Guid, Conversation> _conversations = new();
    public Conversation CreateConversation()
    {
        var conversation = new Conversation
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,

        };
          _conversations.Add(conversation.Id, conversation);
        return conversation;

    }

    public Conversation? GetConversation(Guid id)
    {

        _conversations.TryGetValue(id, out var conversation);

        return conversation;

    }

    public bool AddMessage(Guid conversationId, ConversationMessage message)
    {
      if (_conversations.TryGetValue(conversationId, out var conversation))

        {
            conversation.Messages.Add(message);
            return true;
        }

        return false;

    }
}

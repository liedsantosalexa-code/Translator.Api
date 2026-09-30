using Translator.Api.Models;

namespace Translator.Api.Interfaces;

public interface IConversationContextService
{
    string BuildContext(Guid conversationId);
}

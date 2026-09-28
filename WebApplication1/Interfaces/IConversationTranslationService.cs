using Translator.Api.Models;


namespace Translator.Api.Interfaces;

public interface IConversationTranslationService
{
    Task<ConversationMessage?> AddTranslatedMessage(
        Guid ConversationId,
        string text,
        string targetLanguage);


}

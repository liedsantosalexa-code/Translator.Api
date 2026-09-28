using Translator.Api.Interfaces;
using Translator.Api.Models;


namespace Translator.Api.Services;

public class ConversationTranslationService : IConversationTranslationService
{
    private readonly ITranslationService _translationService;
    private readonly IConversationService _conversationService; 
    public ConversationTranslationService(
        IConversationService conversationService,
        ITranslationService translationService)

    {
        _conversationService = conversationService;
        _translationService = translationService;

    }
    public async Task<ConversationMessage?> AddTranslatedMessage(
        Guid conversationId,
        string text,
        string targetLanguage)
    {
        var conversation = _conversationService.GetConversation(conversationId);
        if (conversation == null)

        {
            return null;
        }

        var translationRequest = new TranslationRequest
        {
            Text = text,
            SourceLanguage = string.Empty,
            TargetLanguage = targetLanguage

        };

        var translation = await _translationService.Translate(translationRequest);
        var message = new ConversationMessage
        {
            Id = Guid.NewGuid(),
            Text = text,
            TranslatedText = translation.TranslatedText,
            SourceLanguage = translation.SourceLanguage,
            TargetLanguage = translation.TargetLanguage,
            CreatedAt = DateTime.UtcNow

        };

        var added = _conversationService.AddMessage(conversationId, message);
        if(!added)
        {  return null; }

        return message;








    }

}

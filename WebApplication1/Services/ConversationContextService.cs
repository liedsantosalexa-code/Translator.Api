using System.Text;
using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Services;

public class ConversationContextService : IConversationContextService
{
    private readonly IConversationService _conversationService;

    public ConversationContextService(IConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    public string BuildContext(Guid conversationId)
    {
        var conversation = _conversationService.GetConversation(conversationId);

        if (conversation == null)
        {
            return string.Empty;
        }

        var context = new StringBuilder();

        foreach (var message in conversation.Messages)
        {
            context.AppendLine(
                $"Original: {message.Text} | " +
                $"Translation: {message.TranslatedText} | " +
                $"Source: {message.SourceLanguage} | " +
                $"Target: {message.TargetLanguage}");
        }

        return context.ToString();
    }
}
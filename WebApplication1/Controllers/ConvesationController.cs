using Microsoft.AspNetCore.Mvc;
using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationController : ControllerBase
{
    private readonly IConversationService _conversationService;
    private readonly IConversationTranslationService _conversationTranslationService;
    private readonly IConversationContextService _conversationContextService;

    public ConversationController(
        IConversationService conversationService,
        IConversationTranslationService conversationTranslationService,
        IConversationContextService conversationContextService)
    {
        _conversationService = conversationService;
        _conversationTranslationService = conversationTranslationService;
        _conversationContextService = conversationContextService;
    }

    [HttpPost]
    public ActionResult<Conversation> CreateConversation()
    {
        var conversation = _conversationService.CreateConversation();

        return Ok(conversation);
    }

    [HttpGet("{id}")]
    public ActionResult<Conversation> GetConversation(Guid id)
    {
        var conversation = _conversationService.GetConversation(id);

        if (conversation == null)
        {
            return NotFound();
        }

        return Ok(conversation);
    }

    [HttpPost("{id}/messages")]
    public async Task<ActionResult<ConversationMessage>> AddMessage(
        Guid id,
        AddMessageRequest request)
    {
        var message = await _conversationTranslationService.AddTranslatedMessage(
            id,
            request.Text,
            request.TargetLanguage);

        if (message == null)
        {
            return NotFound();
        }

        return Ok(message);
    }

    [HttpGet("{id}/context")]
    public ActionResult<string> GetContext(Guid id)
    {
        var context = _conversationContextService.BuildContext(id);

        if (string.IsNullOrEmpty(context))
        {
            return NotFound();
        }

        return Ok(context);
    }
}
using Microsoft.AspNetCore.Mvc;
using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationController : ControllerBase
{
    private readonly IConversationService _conversationService;

    public ConversationController(IConversationService conversationService)
    {
        _conversationService = conversationService;
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
    public IActionResult AddMessage(Guid id, ConversationMessage message)
    {
        var added = _conversationService.AddMessage(id, message);

        if (!added)
        {
            return NotFound();
        }

        return Ok();
    }
}
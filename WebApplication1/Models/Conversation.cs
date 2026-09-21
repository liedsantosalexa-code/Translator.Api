namespace Translator.Api.Models;

public class Conversation
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
    public List<ConversationMessage> Messages { get; set; } = new();

}

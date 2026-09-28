namespace Translator.Api.Models;

public class AddMessageRequest
{
  public string Text { get; set; } = string.Empty;
  public string TranslatedText {  get; set; } = string.Empty;
  public string SourceLanguage {  get; set; } = string.Empty;
  public string TargetLanguage {  get; set; } = string.Empty;
}

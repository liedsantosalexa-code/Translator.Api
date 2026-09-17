namespace Translator.Api.Models
{
    public class TranslationRequest
    {
        public string Text { get; set; } = string.Empty;
        public string? SourceLanguage {  get; set; } 
        public string TargetLanguage {  get; set; } = string.Empty;
            
    }
}

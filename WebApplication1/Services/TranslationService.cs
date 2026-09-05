using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Services;

public class TranslationService : ITranslationService
{
    private readonly ITranslationEngine _translationEngine;
    public TranslationService(ITranslationEngine translationEngine)
    {  
        _translationEngine = translationEngine; 
    }
    public async Task<TranslationResponse> Translate(TranslationRequest request)
    {
        return new TranslationResponse
        {
            OriginalText = request.Text,
            TranslatedText = await _translationEngine.TranslateAsync
            (  request.Text,
               request.SourceLanguage,
               request.TargetLanguage),
            SourceLanguage = request.SourceLanguage,
            TargetLanguage = request.TargetLanguage
        };
    }

    public List<SupportedLanguage> GetSupportedLanguages()
{
    return new List<SupportedLanguage>
    {
        new SupportedLanguage
        {
            Code = "es",
            Name = "Español"
        },
        new SupportedLanguage
        {
            Code = "en",
            Name = "English"
        },
        new SupportedLanguage
        {
            Code = "fr",
            Name = "Français"
        }
    };
}






}
using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Services;

public class TranslationService : ITranslationService
{
    private readonly ITranslationEngine _translationEngine;
    private readonly ILanguageDetectionService _languageDetectionService;
    public TranslationService(ITranslationEngine translationEngine, ILanguageDetectionService languageDetectionService)
    {  
        _translationEngine = translationEngine; 
        _languageDetectionService = languageDetectionService;
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
    public async Task<TranslationResponse> Translate(TranslationRequest request)
    {
        string sourceLanguage;
        if (string.IsNullOrEmpty(request.SourceLanguage))

        {
            var detectedLanguage = await _languageDetectionService.DetectLanguageAsync(
                new LanguageDetectionRequest
                {
                    Text = request.Text,
                });

            sourceLanguage = detectedLanguage.Language;

        }
        else
        {

          sourceLanguage = request.SourceLanguage!;

        }

        var translatedText = await _translationEngine.TranslateAsync(
            request.Text,
            sourceLanguage,
            request.TargetLanguage);

        return new TranslationResponse
        {
            OriginalText = request.Text,
            TranslatedText = translatedText,
            SourceLanguage = sourceLanguage,
            TargetLanguage = request.TargetLanguage



        };


    }

   
}
using Translator.Api.Interfaces;


namespace Translator.Api.Services;

public class TranslationEngine : ITranslationEngine
{
    public async Task<string> TranslateAsync(
        string text,
        string sourceLanguage,
        string targetLanguage)

    {

        return text;

    }



}

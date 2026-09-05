namespace Translator.Api.Interfaces;

public interface ITranslationEngine
{

    Task<string> TranslateAsync(
        string text,
        string sourceLanguage,
        string targetLanguage);



}

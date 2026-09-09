namespace Translator.Api.Interfaces;

public interface ILanguageDetectionEngine
{

    Task<string> DetectLanguageAsync(string text);

}

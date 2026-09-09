using Translator.Api.Models;



namespace Translator.Api.Interfaces;

public interface ILanguageDetectionService
{

    Task<LanguageDetectionResponse> DetectLanguageAsync(LanguageDetectionRequest request);

}

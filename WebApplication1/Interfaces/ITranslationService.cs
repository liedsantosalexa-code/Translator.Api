using Translator.Api.Models;

namespace Translator.Api.Interfaces;

public interface ITranslationService
{
    Task<TranslationResponse> Translate(TranslationRequest request);

    List<SupportedLanguage> GetSupportedLanguages();
}
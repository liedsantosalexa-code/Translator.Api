using Translator.Api.Interfaces;
using Translator.Api.Models;


namespace Translator.Api.Services;

public class LanguageDetectionService : ILanguageDetectionService
{
    public async Task<LanguageDetectionResponse> DetectLanguageAsync(LanguageDetectionRequest request)

    {
        await Task.CompletedTask;
        return new LanguageDetectionResponse

        {

            Language = "es",
          

        };

    }

}

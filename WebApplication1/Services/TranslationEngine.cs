using System.Text;
using System.Text.Json;
using Translator.Api.Interfaces;

namespace Translator.Api.Services;

public class TranslationEngine : ITranslationEngine
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public TranslationEngine(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> TranslateAsync(
        string text,
        string sourceLanguage,
        string targetLanguage)
    {
        var endpoint = _configuration["AzureTranslator:Endpoint"];
        var key = _configuration["AzureTranslator:Key"];
        var region = _configuration["AzureTranslator:Region"];

        var url =
            $"{endpoint}/translate?api-version=3.0" +
            $"&from={sourceLanguage}" +
            $"&to={targetLanguage}";

        var body = new[]
        {
            new
            {
                Text = text
            }
        };

        var json = JsonSerializer.Serialize(body);

        using var request = new HttpRequestMessage(HttpMethod.Post, url);

        request.Headers.Add("Ocp-Apim-Subscription-Key", key);
        request.Headers.Add("Ocp-Apim-Subscription-Region", region);

        request.Content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(responseContent);

        var translatedText =
            document.RootElement[0]
                .GetProperty("translations")[0]
                .GetProperty("text")
                .GetString();

        return translatedText ?? string.Empty;
    }
}
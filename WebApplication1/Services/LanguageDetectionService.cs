using System.Text;
using System.Text.Json;
using Translator.Api.Interfaces;
using Translator.Api.Models;

namespace Translator.Api.Services;

public class LanguageDetectionService : ILanguageDetectionService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public LanguageDetectionService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<LanguageDetectionResponse> DetectLanguageAsync(
        LanguageDetectionRequest request)
    {
        var endpoint = _configuration["AzureTranslator:Endpoint"];
        var key = _configuration["AzureTranslator:Key"];
        var region = _configuration["AzureTranslator:Region"];

        var url = $"{endpoint}/detect?api-version=3.0";

        var body = new[]
        {
            new
            {
                Text = request.Text
            }
        };

        var json = JsonSerializer.Serialize(body);

        using var httpRequest =
            new HttpRequestMessage(HttpMethod.Post, url);

        httpRequest.Headers.Add(
            "Ocp-Apim-Subscription-Key", 
            key);

        httpRequest.Headers.Add(
            "Ocp-Apim-Subscription-Region",
            region);

        httpRequest.Content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(httpRequest);

        response.EnsureSuccessStatusCode();

        var responseContent =
            await response.Content.ReadAsStringAsync();

        using var document =
            JsonDocument.Parse(responseContent);

        var language =
            document.RootElement[0]
                .GetProperty("language")
                .GetString();

        return new LanguageDetectionResponse
        {
            Language = language ?? string.Empty
        };
    }
}
using Microsoft.AspNetCore.Mvc;
using Translator.Api.Interfaces;
using Translator.Api.Models;


namespace Translator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageDetectionController : ControllerBase

{
    private readonly ILanguageDetectionService _languageDetectionService;
    public LanguageDetectionController(
       ILanguageDetectionService languageDetectionService)

    {
        _languageDetectionService = languageDetectionService;

    }

    [HttpPost]
    public async Task<ActionResult<LanguageDetectionResponse>> Detect(LanguageDetectionRequest request)

    {

        var response = await _languageDetectionService.DetectLanguageAsync(request);

        return Ok(response);


    }


}

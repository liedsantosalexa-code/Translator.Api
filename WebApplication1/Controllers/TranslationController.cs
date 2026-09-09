using Microsoft.AspNetCore.Mvc;
using Translator.Api.Interfaces;
using Translator.Api.Models;
using Translator.Api.Services;

namespace Translator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        public TranslationController(ITranslationService translationService)
        {

            _translationService = translationService;

        }
        [HttpPost]
        public async Task<ActionResult<TranslationResponse>> Translate(TranslationRequest request)

        {
            var response = await _translationService.Translate(request);



            return Ok(response);

        }

    [HttpGet("languages")]
        public ActionResult<List<SupportedLanguage>> GetSupportedLanguages()
        {
            var languages = _translationService.GetSupportedLanguages();

            return Ok(languages);
        }




    }

}  
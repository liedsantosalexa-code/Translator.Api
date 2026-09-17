using Translator.Api.Interfaces;
using Translator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITranslationService, TranslationService>();

builder.Services.AddHttpClient<ILanguageDetectionService, LanguageDetectionService>();

builder.Services.AddControllers();

builder.Services.AddHttpClient<ITranslationEngine, TranslationEngine>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
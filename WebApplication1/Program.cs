using Translator.Api.Interfaces;
using Translator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITranslationService, TranslationService>();

builder.Services.AddSingleton<IConversationService, ConversationService>();

builder.Services.AddScoped<IConversationTranslationService, ConversationTranslationService>();

builder.Services.AddHttpClient<ILanguageDetectionService, LanguageDetectionService>();

builder.Services.AddControllers();

builder.Services.AddHttpClient<ITranslationEngine, TranslationEngine>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Translator.Api v1");
    });
}

//app.UseHttpRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
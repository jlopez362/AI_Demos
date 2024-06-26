using AI_Demo.Client.Components;
using AI_Demo.Core.Extensions;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

string? apiKey = Environment.GetEnvironmentVariable("HUGGINGFACE_API_KEY", EnvironmentVariableTarget.Machine);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAICore(options => 
{
    options.TextModelId = "mistralai/Mistral-7B-Instruct-v0.2";
    options.ImageToTextModelId = "Salesforce/blip-image-captioning-base";
    options.ApiKey = apiKey;
});
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

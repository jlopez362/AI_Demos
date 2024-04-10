using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.TextGeneration;

namespace AI_Demo.Core.Services;

public class TextServices : ITextServices
{

    private readonly HuggingFaceOptions _options;

    public TextServices(IOptions<HuggingFaceOptions> options) => _options = options.Value;

    #pragma warning disable SKEXP0020 
    #pragma warning disable SKEXP0001 
    public async IAsyncEnumerable<string> GenerateStreamAsync(string prompt)
    {
        var kernel = Kernel
            .CreateBuilder()
            .AddHuggingFaceTextGeneration(
                model: _options.TextModelId!, 
                apiKey: _options.ApiKey)
            .Build();

        var service = kernel.GetRequiredService<ITextGenerationService>();
        var textStreaming =  service.GetStreamingTextContentsAsync(
            prompt,
            new HuggingFacePromptExecutionSettings() 
            {
                Temperature= 0.7
            }
        );

        await foreach(var item in textStreaming)
        {
            yield return item.Text ?? "";
        }
    }   
}
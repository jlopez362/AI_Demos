using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.ImageToText;

namespace AI_Demo.Core.Services;

public class ImageServices : IImageServices
{

    private readonly HuggingFaceOptions options;

    public ImageServices(IOptions<HuggingFaceOptions> _options) => options = _options.Value;
    
    // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    #pragma warning disable SKEXP0020 
    #pragma warning disable SKEXP0001 

    public async Task<string> ImageDescriptionAsync(byte[] image)
    {
        try
        {
            if(image.Length == 0)
                throw new ArgumentException("Invalid image");

            var kernel = Kernel
                .CreateBuilder()
                .AddHuggingFaceImageToText(
                    model: "Salesforce/blip-image-captioning-base",
                    apiKey: options.ApiKey
                ).Build();

            var service = kernel.GetRequiredService<IImageToTextService>();
            var imageContent = new ImageContent(image) { MimeType = "image/jpeg"};
            var textContet = await service.GetTextContentAsync(imageContent);

            return textContet.Text ?? "";
        }
        catch
        {
            throw;
        }
    }
}

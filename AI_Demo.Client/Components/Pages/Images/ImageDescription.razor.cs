using Microsoft.AspNetCore.Components.Forms;

namespace AI_Demo.Client.Components.Pages.Images;

public partial class ImageDescription
{
    private bool _loading = false;
    private string? _imageSrc = string.Empty;
    private byte[] _imageArray = [];
    string? _imageDescription;

    async Task GetImageDescriptionAsync()
    {
        if(_imageArray.Length == 0)
            return;

        _imageDescription = "";

        _loading = true;
        StateHasChanged();
        _imageDescription = await imageServices.ImageDescriptionAsync(_imageArray);
        _loading = false;
    }

    private async Task UploadImage(IBrowserFile file)
    {
        _imageDescription = "";
        using Stream imageStream = file.OpenReadStream(1024 * 1014 * 10);
        using MemoryStream ms = new();
        await imageStream.CopyToAsync(ms);

        _imageSrc = $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
        _imageArray = ms.ToArray();

        StateHasChanged();
        await Task.Delay(100);
        await GetImageDescriptionAsync();
    }
}
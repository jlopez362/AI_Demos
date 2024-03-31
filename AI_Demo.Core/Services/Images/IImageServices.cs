namespace AI_Demo.Core.Services;

public interface IImageServices
{
    /// <summary>
    /// Retrieves a textual description of an image represented as a byte array.
    /// </summary>
    /// <param name="image">The byte array representing the image.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task completes with a string describing the image,
    /// or empty if a description for the image could not be generated.
    /// </returns>
    public Task<string> ImageDescriptionAsync(byte[] image);
}
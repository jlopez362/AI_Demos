namespace AI_Demo.Core.Services;

public interface ITextServices
{
    public IAsyncEnumerable<string> GenerateStreamAsync(string prompt);
}
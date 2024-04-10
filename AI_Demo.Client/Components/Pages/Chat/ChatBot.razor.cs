namespace AI_Demo.Client.Components.Pages.Chat;

public partial class ChatBot
{
    string? _chatPrompt;
    List<ChatMessage> _messages = [];
    bool _loading = false;

    async Task SetPrompt()
    {
        if(!string.IsNullOrEmpty(_chatPrompt))
        {
            Guid id = Guid.NewGuid();
            AddChatData(_chatPrompt, id);
            _loading = true;
            await foreach(var item in textServices.GenerateStreamAsync(_chatPrompt!))
            {
                var result = _messages.FirstOrDefault(x => x.Id == id);
                result!.ResponseMessage = $"{result!.ResponseMessage} {item.Trim()}";
                StateHasChanged();
            }
            _loading = false;
        }
    }

    private void AddChatData(string Prompt, Guid id, string responseMessage = "", bool response = true) =>
        _messages.Add(new ChatMessage {Id = id, Prompt = Prompt, ResponseMessage = responseMessage, Response = response});

    public class ChatMessage
    {
        public Guid Id {get;set;}
        public string? Prompt {get;set;}
        public bool Response {get; set; }
        public string? ResponseMessage {get; set;}
    }
}
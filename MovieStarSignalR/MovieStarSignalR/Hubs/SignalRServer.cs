using Microsoft.AspNetCore.SignalR;

namespace MovieStarSignalR.Hubs
{
    public class SignalRServer : Hub
    {
        public async Task OpenChat()
        {
            await Clients.All.SendAsync("OpenChatResult");
        }
        public async Task DoingChat(String text)
        {
            await Clients.All.SendAsync("DoingChatResult", text);
        }
        public async Task CloseChat() { 
            await Clients.All.SendAsync("CloseChatResult");
        }
    }
}

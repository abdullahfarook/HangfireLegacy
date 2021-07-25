using System.Net.Http;
using System.Threading.Tasks;
using HangFireLegacy.Helpers;

namespace HangFireLegacy.Services
{
    public interface IAgentLookupService
    {
        Task AssignNewAgent(int accountId, int widgetId, int conversationId);
    }
    public class AgentLookupService:IAgentLookupService
    {
        private readonly HttpClient _httpClient;

        public AgentLookupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AssignNewAgent(int accountId, int widgetId, int conversationId)
        {
            var req = JsonContent.Create(new
            {
                AccountId = accountId,
                Action = "NEWCHAT",
                Channel = "customer_channel",
                WidgetId = widgetId,
                ConversationId = conversationId

            });

            var response = await _httpClient.PostAsync("",req);
            response.EnsureSuccessStatusCode();
        }
    }
}

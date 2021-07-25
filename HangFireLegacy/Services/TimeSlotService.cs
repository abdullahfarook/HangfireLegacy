using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace HangFireLegacy.Services
{
    public interface ITimeSlotService
    {
        Task<object> Get(int accountId, int timeSlotId);
    }
    public class TimeSlotService:ITimeSlotService
    {
        private readonly HttpClient _httpClient;

        public TimeSlotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> Get(int accountId,int timeSlotId)
        {
            if (accountId < 1 || timeSlotId < 1)
                throw new ArgumentException("AccountId or TimeSlotId must be greater than zero");
            var query = new Dictionary<string, string>
            {
                ["type"] = "7",
                ["AccountId"] = accountId.ToString(),
                ["TimeSlotId"] = timeSlotId.ToString(),
            };

            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("TestAgentData.aspx", query));
            response.EnsureSuccessStatusCode();
            return new
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(1)
            };
        }
    }
}

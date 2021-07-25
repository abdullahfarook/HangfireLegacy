using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace HangFireLegacy.Helpers
{
    public static class JsonContent
    {
        public static StringContent Create<T>(T obj)
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(obj);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            return new StringContent(stringPayload, Encoding.UTF8, "application/json");
        }
    }
}
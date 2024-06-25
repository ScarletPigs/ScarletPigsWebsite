using ScarletPigsWebsite.Data.Models.Events;

namespace ScarletPigsWebsite.Data.Services.HTTP
{
    public interface IScarletPigsApi
    {
        public Task<List<Event>> GetEventsAsync();
    }

    public class ScarletPigsApi : IScarletPigsApi
    {
        private readonly HttpClient _httpClient;

        public ScarletPigsApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Event>>("events") ?? new List<Event>();
        }
    }
}

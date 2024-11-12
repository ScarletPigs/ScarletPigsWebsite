using ScarletPigsWebsite.Data.Models.Events;

namespace ScarletPigsWebsite.Data.Services.HTTP
{
    public interface IScarletPigsApi
    {
        public Task<Event?> GetEventAsync(string id);
        public Task<List<Event>> GetEventsAsync();
    }

    public class ScarletPigsApi : IScarletPigsApi
    {
        private readonly HttpClient _httpClient;

        public ScarletPigsApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Event?> GetEventAsync(string id)
        {
            return (await _httpClient.GetFromJsonAsync<Event>($"events/{id}"));
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Event>>("events/")) ?? new List<Event>();
        }
    }
}

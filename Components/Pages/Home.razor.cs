using Heron.MudCalendar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ScarletPigsWebsite.Data.Models.Events;
using ScarletPigsWebsite.Data.Services.HTTP;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ScarletPigsWebsite.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

        [Inject]
        private IHttpContextAccessor HttpContextAccessor { get; set; } = default!;

        [Inject]
        public IScarletPigsApi ScarletPigsApi { get; set; } = default!;

        ClaimsPrincipal? User { get; set; }

        string Token { get; set; } = "";

        public List<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            User = authState.User;

            try
            {
                var accessToken = await HttpContextAccessor.HttpContext.GetTokenAsync("access_token");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri("https://keycloak.scarletpigs.com/");
                var response = await client.GetAsync("/realms/ScarletPigs/broker/discord/token");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Token = content;

                    StateHasChanged();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




            Events = (await ScarletPigsApi.GetEventsAsync()).Select(e => e.ToCalendarEvent()).ToList();
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ScarletPigsWebsite.Data.Models.Auth;
using Piglet_Domain_Models.Models;
using ScarletPigsWebsite.Data.Services.HTTP;

namespace ScarletPigsWebsite.Components.Pages.Events
{
    public partial class EventDetails
    {
        [Parameter]
        public string id { get; set; } = string.Empty;

        [Inject]
        private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

        [Inject]
        public IScarletPigsApi Api { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public Event? Event { get; set; }

        KeycloakUser? User { get; set; }


        protected override void OnInitialized()
        {
            Task.Run(async () =>
            {
                var authState = await AuthStateProvider.GetAuthenticationStateAsync();
                User = (KeycloakUser?)authState.User;

                Event = await Api.GetEventAsync(id);
                await InvokeAsync(StateHasChanged);
            });


            base.OnInitialized();
        }

        public async Task DeleteEvent()
        {
            if (Event == null)
                return;

            await Api.DeleteEventAsync(Event.Id.ToString());
            NavigationManager.NavigateTo("/");
        }

        public async Task EditEvent()
        {
            if (Event == null)
                return;

            NavigationManager.NavigateTo($"/events/edit/{Event.Id}");
        }
    }
}
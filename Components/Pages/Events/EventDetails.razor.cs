using Microsoft.AspNetCore.Components;
using ScarletPigsWebsite.Data.Models.Events;
using ScarletPigsWebsite.Data.Services.HTTP;

namespace ScarletPigsWebsite.Components.Pages.Events
{
    public partial class EventDetails
    {
        [Parameter]
        public string id { get; set; } = string.Empty;

        [Inject]
        public IScarletPigsApi Api { get; set; } = default!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public Event? Event { get; set; }

        protected override void OnInitialized()
        {
            Task.Run(async () =>
            {
                Event = await Api.GetEventAsync(id);
                await InvokeAsync(StateHasChanged);
            });
            base.OnInitialized();
        }
    }
}
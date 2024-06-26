﻿using Heron.MudCalendar;
using Microsoft.AspNetCore.Components;
using ScarletPigsWebsite.Data.Models.Events;
using ScarletPigsWebsite.Data.Services.HTTP;

namespace ScarletPigsWebsite.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IScarletPigsApi ScarletPigsApi { get; set; } = default!;

        public List<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();

        protected override async Task OnInitializedAsync()
        {
            Events = (await ScarletPigsApi.GetEventsAsync()).Select(e => e.ToCalendarEvent()).ToList();
        }
    }
}

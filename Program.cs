using ScarletPigsWebsite.Components;
using MudBlazor.Services;
using ScarletPigsWebsite.Data.Services.HTTP;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddCascadingAuthenticationState();

string apiURL = Environment.GetEnvironmentVariable("API_URL") ?? "";
Uri apiUri;
try
{
    apiUri = new Uri(apiURL.Trim());
}
catch (UriFormatException e)
{
    Console.WriteLine(e.Message);
    return;
}

// Add http client services
builder.Services.AddHttpClient<IScarletPigsApi, ScarletPigsApi>(client =>
{
    client.BaseAddress = apiUri;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using MudBlazor.Services;
using ScarletPigsWebsite.Components;
using ScarletPigsWebsite.Data.Services.HTTP;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Add authorization services.
builder.Services.AddAuthorizationCore();

// Add HttpContextAccessor for accessing HttpContext in components.
builder.Services.AddHttpContextAccessor();

// Add HTTP client services.
string apiurl = Environment.GetEnvironmentVariable("API_URL");
builder.Services.AddHttpClient<IScarletPigsApi, ScarletPigsApi>(client =>
{
    client.BaseAddress = new Uri(apiurl ?? "");
});

// Configure authentication with Keycloak for a public client.
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.Authority = "https://keycloak.scarletpigs.com/realms/ScarletPigs"; // Replace with your Keycloak server URL.
    options.ClientId = "scarletpigsclient"; // Replace with your Keycloak client ID.
    // Do not set ClientSecret since this is a public client.

    options.ResponseType = OpenIdConnectResponseType.Code; // Use Authorization Code Flow with PKCE.
    options.UsePkce = true; // Enable PKCE.

    options.SaveTokens = true;

    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    // Add any additional scopes you need.

    // Configure TokenValidationParameters if necessary.
    options.TokenValidationParameters.NameClaimType = "preferred_username";
    options.TokenValidationParameters.RoleClaimType = "roles";

    // Handle events (optional).
    options.Events = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProvider = context =>
        {
            // Modify the redirect URI if necessary.
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            // Additional token validation if necessary.
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            context.HandleResponse();
            context.Response.Redirect("/Error");
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use appropriate development exception handling.
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

// Correct middleware order starts here.
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Place UseAntiforgery after authentication and authorization, and before endpoint mappings.
app.UseAntiforgery();

// Map endpoints.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Endpoints for sign-in and sign-out.
app.MapGet("/signin", async context =>
{
    await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
});

app.MapGet("/signout", async context =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
    {
        RedirectUri = "/"
    });
});

app.Run();

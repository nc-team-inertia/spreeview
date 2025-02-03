using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend.Components;
using SpreeviewFrontend.Client.Identity;
using SpreeviewFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// register the cookie handler
builder.Services.AddTransient<CookieHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// Cascading authentication state
builder.Services.AddCascadingAuthenticationState();

// register the account management interface (satisfy IAccountManagement dependency with our previously added AuthenticationStateProvider).
builder.Services.AddScoped(sp => (IAccountManagement) sp.GetRequiredService<AuthenticationStateProvider>()); 

// Create a named HTTP client connecting to the  backend
string? backendUrl = builder.Configuration["BackendUrl"];

if (string.IsNullOrEmpty(backendUrl))
{
    throw new InvalidOperationException("BackendUrl not found in configuration.");
}

builder.Services
    .AddHttpClient("SpreeviewAPI", client => client.BaseAddress = new Uri(backendUrl))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SpreeviewFrontend.Client._Imports).Assembly);

app.Run();

using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend;
using SpreeviewFrontend.Components;
using SpreeviewFrontend.Client.Identity;
using SpreeviewFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.SetupRazorComponents();
builder.SetupAuth();
builder.SetupHttpClients();
builder.SetupUserPreferences();

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

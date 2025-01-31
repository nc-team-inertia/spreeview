using Microsoft.AspNetCore.Identity;
using SpreeviewAPI;
using SpreeviewAPI.Database;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();

string tmdbAccessToken = builder.Configuration["HttpClient:BearerToken"]!;

builder.Services.AddHttpClient("tmdb", tmdb =>
{
    tmdb.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    tmdb.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {tmdbAccessToken}");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.SetupDbContext();
builder.SetupCors();
builder.SetupIdentity();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser<int>>();

app.UseCors();

app.UseHttpsRedirection();

app.AddLogoutEndpoint();
app.AddRolesEndpoint();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

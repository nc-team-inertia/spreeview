using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SpreeviewAPI;
using SpreeviewAPI.Models;
using SpreeviewAPI.Database;
using SpreeviewAPI.HealthChecks;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Utilities;
using SpreeviewAPI.Repository.Implementations;
using SpreeviewAPI.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeasonService, SeasonService>();
builder.Services.AddScoped<IRequestManager, RequestManager>();

string tmdbAccessToken = builder.Configuration["HttpClient:BearerToken"]!;

builder.Services.AddHttpClient("tmdb", tmdb =>
{
    tmdb.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    tmdb.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {tmdbAccessToken}");
});

builder.Services.AddHealthChecks()
    .AddCheck<TmdbHealthCheck>("tmdbHealthCheck",
        failureStatus: HealthStatus.Unhealthy,
        tags: new[] { "api", "external", "tmdb" }
        )
    .AddDbContextCheck<ApplicationDbContext>("internalDbHealthCheck",
        failureStatus: HealthStatus.Unhealthy,
        tags: new[] { "api", "internal" }
        );

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

app.MapHealthChecks("/api/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckWriter.WriteHealthCheck
});

app.MapIdentityApi<ApplicationUser>();

app.UseCors();

app.UseHttpsRedirection();

app.AddRolesEndpoint();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using SpreeviewAPI;
using SpreeviewAPI.Models;
using SpreeviewAPI.Repository;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<ReviewRepository>();
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

app.MapIdentityApi<ApplicationUser>();

app.UseCors();

app.UseHttpsRedirection();

app.AddRolesEndpoint();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

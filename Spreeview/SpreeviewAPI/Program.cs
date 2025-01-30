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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.SetupDbContext();
builder.SetupIdentity();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<IdentityUser<int>>();

app.MapControllers();

app.Run();

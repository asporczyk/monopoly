using Monopoly.Api.Hubs;
using Monopoly.Api.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.States;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<IGameHubService>());
builder.Services.AddScoped<IGameHubService, GameHubService>();

builder.Services.AddSingleton<BoardState>();
builder.Services.AddSingleton<GameState>();
builder.Services.AddSingleton<PlayersState>();
builder.Services.AddSingleton<RoundState>();

builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapHub<GameHub>("/game-hub");
app.UseCors(policyBuilder =>
    policyBuilder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
);

app.Run();
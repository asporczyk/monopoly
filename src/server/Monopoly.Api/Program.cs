using Monopoly.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapHub<GameHub>("/game-hub");
app.Run();
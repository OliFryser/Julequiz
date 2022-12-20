
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

IWinnerController winnercontroller = new WinnerController();
var winnerName = app.MapGroup("/winnername");


winnerName.MapGet("/", winnercontroller.GetWinner)
.WithName("GetWinnerName")
.WithOpenApi();

winnerName.MapPost("/{name}", (string name) => winnercontroller.RegisterWinnerName(name))
.WithName("PostWinnerName")
.WithOpenApi();

winnerName.MapGet("/reset", winnercontroller.ResetWinner)
.WithName("ResetWinnerName")
.WithOpenApi();

app.Run();

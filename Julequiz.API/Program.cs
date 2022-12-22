
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

IWinnerController winnercontroller = new WinnerController();
var winnerNameGroup = app.MapGroup("/winnername");


winnerNameGroup.MapGet("/", winnercontroller.GetWinner)
.WithName("GetWinnerName")
.WithOpenApi();

winnerNameGroup.MapPost("/{name}", (string name) => winnercontroller.RegisterWinnerName(name))
.WithName("PostWinnerName")
.WithOpenApi();

winnerNameGroup.MapGet("/reset", winnercontroller.ResetWinner)
.WithName("ResetWinnerName")
.WithOpenApi();

app.Run();

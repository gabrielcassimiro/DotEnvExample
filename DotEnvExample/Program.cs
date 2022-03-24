var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load("./Environments/.env");

var idToken = DotNetEnv.Env.GetString("ID_TOKEN");
var port = DotNetEnv.Env.GetString("PORT");
var email = DotNetEnv.Env.GetString("EMAIL");
var password = DotNetEnv.Env.GetString("PASSWORD");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
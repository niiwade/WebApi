using WebApi.Models;
using WebApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/startup", () =>
{
    return Results.BadRequest("Request not successful");
});


app.MapPost("/startup", () =>
{
    return "hello";
});

app.MapPut("/startup/{id}", () =>
{
    return "hello";
});

app.MapDelete("/startup/{id}", () =>
{
    return "hello";
})

.WithOpenApi();

app.Run(); 



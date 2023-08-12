using System.Net;
using ZooAPI.controller;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
 

// set up open api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo{Title = "Zoo API", Version = "v1"});
});


// set up app for using swagger
var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseSwagger();

app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "zoo");
    option.RoutePrefix = string.Empty;
});

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/", () => "Hello World!");

app.MapPost("/api/BuyTicket", async (HttpRequest request) =>
    {
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();
        
        
        var totalPrice = await KassiererController.InsertTicketInDb(body);
        return Results.Json(totalPrice,statusCode: 200) ;
    });

app.MapGet("/api/getTickets/{date}", async (DateTime date) =>
{
    // format 2023-08-03
    var tickets = await KassiererController.getSoldTicets(date);
    return tickets;
});

app.MapGet("/api/getAnimal/{animal}", async (string animal) =>
{
    
    var animals = await BesucherController.getAnimalbyGattung(animal);
    return animals;
});


app.MapGet("/api/Tierpfleger/getAnimal/{id}", async (string id) =>
{
    
    var animals = await Tierpfleger.getAnimalbyPflegerId(id);
    return animals;
});


app.MapGet("/api/Tierpfleger/updateAnimal/{AnimalId}&{columnName}&{newData}", async (string AnimalId,string columnName,string newData) =>
{
    await Tierpfleger.updateAnimal(AnimalId,columnName,newData);
    return;
});


app.Run();

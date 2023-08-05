using ZooAPI.controller;
using System.Text.Json;
// await DBConnection.testConection();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/api/BuyTicket", async (HttpRequest request) =>
    {
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();
        
        
        var totalPrice = await KassiererController.InsertTicketInDb(body);
        return totalPrice;
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


app.Run();
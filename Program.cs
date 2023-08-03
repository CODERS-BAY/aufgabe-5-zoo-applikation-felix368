using ZooAPI.controller;

// await DBConnection.testConection();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/BuyTicket", async (HttpRequest request) =>
    {
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();


        Console.WriteLine(body);
        var totalPrice = await KassiererController.InsertTicketInDb(body);
        
        
        return totalPrice;
    });


app.Run();
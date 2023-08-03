using ZooAPI.controller;


// await DBConnection.testConection();


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();





app.MapGet("/", () => "Hello World!");

app.MapPost("/BuyTicket", () =>
    {
        return "true";
    }
);


app.Run();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

var items = new[]
{
    new Item("Cheese", 12.50M),
    new Item("Crackers", 50.10M),
    new Item("Tea", 10.50M),
    new Item("Biscuits", 5.12M),
};

app.MapGet("/items", () => items)
.WithName("GetItems")
.WithOpenApi();

app.MapGet("/item", (string name) =>
{
    return items.FirstOrDefault(x => x.Name == name);
})
.WithName("GetItem")
.WithOpenApi();


app.Run();

record Item(string Name, decimal Price);
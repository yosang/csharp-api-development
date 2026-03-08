using minimal.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new()
{
    new User() { Id = 1, Name = "John", Age = 33 },
    new User() { Id = 2, Name = "Maria", Age = 43 },
    new User() { Id = 3, Name = "Carlos", Age = 50 },
    new User() { Id = 4, Name = "Jose", Age = 32 },
};


app.MapGet("/", () => "Hello World!");

app.MapGet("/users", () => users); // Returns all users, notice how the API automatically serializes the response to JSON

app.MapGet("users/{id}", (int id) => // Endpoint with route paramater
{
    var user = users.SingleOrDefault(e => e.Id == id);
    if (user == null) return Results.NotFound();
    return Results.Ok(user);
});

app.MapPost("/users", (User user) =>
{
    user.Id = users.Max(e => e.Id) + 1; // autoincrement
    users.Add(user);
    return Results.Created();

});

app.MapPut("/users/{id}", (int id, User payload) =>
{
    var user = users.SingleOrDefault(e => e.Id == id);
    if (user == null) return Results.NotFound();

    user.Name = payload.Name;
    user.Age = payload.Age;

    return Results.Ok();
});

app.MapDelete("/users/{id}", (int id) =>
{
    var user = users.SingleOrDefault(e => e.Id == id);
    if (user == null) return Results.NotFound();

    users.Remove(user);

    return Results.Ok();
});

/*
- Automatic JSON Serialization
- Lightweight and concise, no need for controllers
- HTTP Response methods: Results.Ok(), Results.NotFound(), Results.Created() for proper Status Codes
*/

app.Run();

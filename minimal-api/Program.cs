using minimal.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new()
{
    new User() { Name = "John", Age = 33 },
    new User() { Name = "Maria", Age = 43 },
    new User() { Name = "Carlos", Age = 50 },
    new User() { Name = "Jose", Age = 32 },
};


app.MapGet("/", () => "Hello World!");
app.MapGet("/users", () => users); // Endpoint /users - 
app.MapGet("item/{id}", () => "one item"); // Endpoint with route paramater

/*

MapGet()
MapPost()
MapPut()
MapDelete()

*/

app.Run();

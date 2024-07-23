// using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();

users.Add(new User(1, "John", "Doe"));
users.Add(new User(2, "Jane", "Doe"));

// List Users
app.MapGet("/users", () => users);

// List User by ID
app.MapGet("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault( user => user.Id == id);
    if( user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound( $"User {id} does not exist" );
    }
});


// Create User
app.MapPost("/users/Add", ([FromBody] User user) => 
{
    // Console.WriteLine(user);
    users.Add(user);
    return Results.Created( $"User {user.FirstName} added successfully", user);
});

// Update User First Name
app.MapPatch("/users/Rename/{id}/{firstName}", ( int id, string firstName ) =>
{
    var user = users.FirstOrDefault( user => user.Id == id);
    if( user != null)
    {
        user.FirstName = firstName;
        return Results.Ok( $"User with ID {user.Id} renamed to {user.FirstName}" );
    }
    else
    {
        return Results.NotFound( $"User {id} does not exist" );
    }
});

// Delete User
app.MapDelete("/users/Delete/{id}", ( int id ) =>
{
    var user = users.FirstOrDefault( user => user.Id == id);
    if( user != null)
    {
        users.Remove(user);
        return Results.Ok( $"User with ID {user.Id} deleted" );
    }
    else
    {
        return Results.NotFound( $"User {id} does not exist" );
    }
});

app.Run();

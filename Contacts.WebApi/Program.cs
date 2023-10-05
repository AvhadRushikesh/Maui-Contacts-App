using Contacts.WebApi;
using Contacts.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
                            option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();  // If we try to access web API with HTTP it redirect to HTTPS

//  Get Contacts Endpoint
app.MapGet("/api/contacts", async (ApplicationDbContext db) =>
{
    var contacts = await db.Contacts.ToListAsync();
    return Results.Ok(contacts);
});


//  Post Contacts Endpoint
app.MapPost("/api/contacts", async (Contact contact, ApplicationDbContext db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
});

//  Put API / Update Contacts Endpoint
app.MapPut("/api/contacts/{id}", async (int id, Contact contact, ApplicationDbContext db) =>
{
    var contactToUpdate = await db.Contacts.FindAsync(id);

    if (contactToUpdate is null) return Results.NotFound();

    contactToUpdate.Name = contact.Name;
    contactToUpdate.Email = contact.Email;
    contactToUpdate.Phone = contact.Phone;
    contactToUpdate.Address = contact.Address;
    
    await db.SaveChangesAsync();

    //return Results.Ok(contactToUpdate);
    return Results.NoContent();
});

//  Delete Contact Endpoint
app.MapDelete("api/contacts/{id}", async (int id, ApplicationDbContext db) =>
{
    var contactToDelete = await db.Contacts.FindAsync(id);

    if (contactToDelete != null)
    {
        db.Contacts.Remove(contactToDelete);
        await db.SaveChangesAsync();
        return Results.Ok(contactToDelete);
    }

    return Results.NotFound();
});

app.Run();

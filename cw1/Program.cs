using cw1.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string FirstName = "Alojzy";
string LastName = "Bąbel";

app.MapGet("/", () => "Hello World!");
app.MapGet("/short", () => $"Witaj {FirstName} {LastName}!");
app.MapGet("/date", () => DateTime.Now.ToShortDateString());
app.MapGet("/persons", () => PersonRepo.GetPersons());
app.MapGet("/books", () => BookRepo.GetBooks());

app.Run();

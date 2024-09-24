using cw5.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

Person person = new Person {
    FirstName = "Jan",
    LastName = "Kowalski",
    Age = 20
};
app.MapRazorPages();
app.UseStaticFiles();
// app.MapGet("/", () => "Hello World!");
// app.MapGet("/strona1" , () => "To jest strona 1");
// app.MapGet("/strona2" , () => person);
// app.MapGet("/persons" , () => GetPersons());
// app.MapGet("/games", () => GetGames());
//
// List<Person> GetPersons(){
//     List<Person> people = new List<Person>();
//     people.Add(new Person{ FirstName = "Jan", LastName = "Kowalski", Age = 25});
//     people.Add(new Person{FirstName = "Anna", LastName = "Nowak", Age = 20});
//     people.Add(new Person{FirstName = "Andrzej", LastName = "Nowak", Age = 52});
//     return people;
// }
//
// List<Game> GetGames(){
//     List<Game> games = new List<Game>();
//     games.Add(new Game{ Title = "Escape From Tarkov", Developer = "Battle State Games", Genre = "FPS"});
//     games.Add(new Game{ Title = "Lethal Company", Developer = "Zeekerss", Genre = "Horror"});
//     games.Add(new Game{ Title = "Cyberpunk 2077", Developer = "CDPR", Genre = "FPS RPG"});
//     games.Add(new Game{ Title = "Vtol Vr", Developer = "Boundless Dynamics", Genre = "VR Sim"});
//     return games;
// }
app.Run();

using cw6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class index : PageModel {
    public List<Person> People { get; set; }
    public List<string> ColorList { get; set; } = new List<string>() { "white", "red", "blue", "black", "yellow"};
    public void OnGet(){
        People = GetPersons();
    }
    private List<Person> GetPersons(){
        var list = new List<Person>();
        list.Add(new Person { FirstName = "Jan", LastName = "Kowalski", Age = 20 });
        list.Add(new Person { FirstName = "Anna", LastName = "Nowak", Age = 30 });
        list.Add(new Person { FirstName = "Andrzej", LastName = "Nowak", Age = 40 });
        list.Add(new Person { FirstName = "Dominik", LastName = "Nowak", Age = 40 });
        return list;
    }
}
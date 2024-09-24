using cw5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5.Pages;

public class index : PageModel {
    List<Person> people = new List<Person>();
    public void OnGet(){
        people = GetPersons();
    }
    List<Person> GetPersons(){
    people.Add(new Person{ FirstName = "Jan", LastName = "Kowalski", Age = 25});
    people.Add(new Person{FirstName = "Anna", LastName = "Nowak", Age = 20});
    people.Add(new Person{FirstName = "Andrzej", LastName = "Nowak", Age = 52});
    return people;
}
}
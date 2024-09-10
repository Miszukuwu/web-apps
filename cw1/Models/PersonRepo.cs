using System;

namespace cw1.Models;

public class PersonRepo
{
    public static List<Person> GetPersons(){
        return new List<Person>{
            new Person{id=1, FirstName="Jan",LastName="Kowalski",age=22},
            new Person{id=2, FirstName="Tomasz",LastName="Bułecki",age=11},
            new Person{id=3, FirstName="Natasza",LastName="Kasza",age=45},
            new Person{id=4, FirstName="Ryszard",LastName="Kowal",age=24}
        };
    }
}

using System;

namespace cw1.Models;

public class BookRepo
{
    public static List<Book> GetBooks(){
        return new List<Book>{
            new Book{id=1, title="Pan Tadeusz",author="Mickiewicz", rodzajLiteracki="Liryka"},
            new Book{id=2, title="Lalka", author="Bolesław Prus", rodzajLiteracki="Epika"},
            new Book{id=3, title="Balladyna", author="Słowacki", rodzajLiteracki="Dramat"}
        };
    }
}

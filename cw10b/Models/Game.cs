namespace cw10b.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Game {
    public int Id { get; set; }
    
    [DisplayName("Podaj tytuł: ")]
    [Required(ErrorMessage = "Tytuł jest wymagany")]
    public string Title { get; set; }
    
    [DisplayName("Podaj wydawcę: ")]
    [Required(ErrorMessage = "Wydawca jest wymagany")]
    public string Publisher { get; set; }
    
    [DisplayName("Podaj Rok Wydania: ")]
    [Required(ErrorMessage = "Rok wydania jest wymagany")]
    public int ReleaseYear { get; set; }
    
    [DisplayName("Podaj cenę: ")]
    [Required(ErrorMessage = "Cena jest wymagana")]
    [Range(0, 999999999999, ErrorMessage = "Cena musi być większa od zera")]
    public float Price { get; set; }
}

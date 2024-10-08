namespace cw6.Models;

public class Game {
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Price { get; set; }
    public string? Genre { get; set; }
    public string? Publisher { get; set; }
    public DateOnly? ReleaseDate { get; set; }
}
using System.Text.Json;

namespace cw6.Models;

public class GamesRepo {
    private string _filePath;
    private List<Game>? _games;
    
    public GamesRepo(string? filePath = "games.json") {
        _filePath = filePath;
        string content = File.ReadAllText(_filePath);
        _games = JsonSerializer.Deserialize<List<Game>>(content);
    }

    public List<Game>? Games {
        get {
            return _games;
        }
    }
    private void SaveChanges(){
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        string content = JsonSerializer.Serialize(_games, options);
        File.WriteAllText(_filePath, content);
    }
    
    private int GetNextId(){
        return _games != null ?_games.Max(m => m.Id) +1 : 1;
    }
    public void AddGame(Game game){
        if (_games == null){
            _games = new List<Game>();
        }
        game.Id = GetNextId();
        _games.Add(game);
        SaveChanges();
    }
    public void DeleteGame(Game game) {
        if (_games == null) {
            return;
        }
        Games?.Remove(game);
        SaveChanges();
    }

    public Game? GetById(int? id) {
        return Games != null
            ? Games.FirstOrDefault(g => g.Id == id)
            : null;
    }

    internal void UpdateGame(Game movie) {
        var toUpdate = _games?.FirstOrDefault(m => m.Id == movie.Id);
        if (toUpdate != null) {
            toUpdate.Title = movie.Title;
            toUpdate.Publisher = movie.Publisher;
            toUpdate.Genre = movie.Genre;
            toUpdate.Price = movie.Price;
            toUpdate.ReleaseDate = movie.ReleaseDate;
            SaveChanges();
        }
    }
}
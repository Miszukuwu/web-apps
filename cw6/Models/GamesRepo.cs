using System.Text.Json;

namespace cw6.Models;

public class GamesRepo
{
    private string _filePath;
    private string _fileType;
    private List<Game>? _games;

    public List<Game>? Games {
        get {
            return _games;
        }
    }

    public GamesRepo(string? filePath = "games.json") {
        _filePath = filePath;
        _fileType = Path.GetExtension(_filePath);

        switch (_fileType) {
            case ".json":
                string content = File.ReadAllText(_filePath);
                _games = JsonSerializer.Deserialize<List<Game>>(content);
                break;
            case ".txt":
                string[] lines = File.ReadAllLines(_filePath);
                _games = new List<Game>();
                for (int i = 0; i < lines.Length; i++) {
                    if (string.IsNullOrWhiteSpace(lines[i])) {
                        continue;
                    }
                    Game game = new Game {
                        Id = int.Parse(lines[i]),
                        Title = lines[++i],
                        Publisher = lines[++i],
                        Genre = lines[++i],
                        Price = double.Parse(lines[++i]),
                        ReleaseDate = DateOnly.Parse(lines[++i])
                    };
                    _games.Add(game);
                }
                break;
        }
    }

    private void SaveChanges() {
        string content = "";
        switch (_fileType) {
            case ".json":
                JsonSerializerOptions options = new JsonSerializerOptions {
                    WriteIndented = true
                };
                content = JsonSerializer.Serialize(_games, options);
                File.WriteAllText(_filePath, content);
                break;
            case ".txt":
                foreach (Game game in _games) {
                    content += $"{game.Id}\n{game.Title}\n{game.Publisher}\n{game.Genre}\n{game.Price}\n{game.ReleaseDate}\n\n";
                }
                File.WriteAllText(_filePath, content);
                break;
        }
    }

    private int GetNextId() {
        return _games != null ? _games.Max(m => m.Id) + 1 : 1;
    }
    public void AddGame(Game game) {
        if (_games == null) {
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
        Game? toUpdate = _games?.FirstOrDefault(m => m.Id == movie.Id);
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
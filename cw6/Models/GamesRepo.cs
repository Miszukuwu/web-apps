using System.Text.Json;

namespace cw6.Models;

public class GamesRepo {
    private string _filePath;
    private List<Game>? _games;
    
    public GamesRepo(string? filePath) {
        _filePath = filePath;
        string content = File.ReadAllText(_filePath);
        _games = JsonSerializer.Deserialize<List<Game>>(content);
    }

    public List<Game>? Games {
        get {
            return _games;
        }
    }
}
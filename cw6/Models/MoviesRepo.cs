using System.Text.Json;

namespace cw6.Models;

public class MoviesRepo {
    private string _filePath;
    private string _fileType;
    private List<Movie>? _movies;

    public List<Movie>? Movies {
        get {
            return _movies;
        }
    }
    
    public MoviesRepo(string filePath = "movies.json") {
        _filePath = filePath;
        _fileType = Path.GetExtension(_filePath);
        
        switch (_fileType) {
            case ".json":
                string content = File.ReadAllText(_filePath);
                _movies = JsonSerializer.Deserialize<List<Movie>>(content);
                break;
            case ".txt":
                string[] lines = File.ReadAllLines(_filePath);
                _movies = new List<Movie>();
                for (int i = 0; i < lines.Length; i++) {
                    if (string.IsNullOrWhiteSpace(lines[i])) {
                        continue;
                    }
                    Movie movie = new Movie {
                        Id = int.Parse(lines[i]),
                        Title = lines[++i],
                        Director = lines[++i],
                        Genre = lines[++i],
                        Price = double.Parse(lines[++i]),
                        ReleaseDate = DateOnly.Parse(lines[++i])
                    };
                    _movies.Add(movie);
                }
                break;
        }
    }
    
    private void SaveToFile() {
        string content = "";
        switch (_fileType) {
            case ".json":
                var options = new JsonSerializerOptions {
                    WriteIndented = true
                };
                content = JsonSerializer.Serialize(_movies, options);
                File.WriteAllText(_filePath, content);
                break;
            case ".txt":
                foreach (var movie in _movies) {
                    content += $"{movie.Id}\n{movie.Title}\n{movie.Director}\n{movie.Genre}\n{movie.Price}\n{movie.ReleaseDate}\n\n";
                }
                File.WriteAllText(_filePath, content);
                break;
        }
    }
    
    private int GetNextId(){
        return (_movies != null && _movies.Count != 0) ?_movies.Max(m => m.Id) + 1 : 1;
    }
    public void AddMovie(Movie movie){
        if (_movies == null){
            _movies = new List<Movie>();
        }
        movie.Id = GetNextId();
        _movies.Add(movie);
        SaveToFile();
    }
     public void DeleteMovie(Movie movie) {
        if (_movies == null) {
            return;
        }
        Movies?.Remove(movie);
        SaveToFile();
    }

    public Movie? GetById(int? id) {
        return Movies != null
              ? Movies.FirstOrDefault(m => m.Id == id)
              : null;
    }

    internal void UpdateMovie(Movie movie) {
        var toUpdate = _movies?.FirstOrDefault(m => m.Id == movie.Id);
        if (toUpdate != null) {
            toUpdate.Title = movie.Title;
            toUpdate.Director = movie.Director;
            toUpdate.Genre = movie.Genre;
            toUpdate.Price = movie.Price;
            toUpdate.ReleaseDate = movie.ReleaseDate;
            SaveToFile();
        }
    }
}
﻿using System.Text.Json;

namespace cw6.Models;

public class MoviesRepo {
    private string _filePath;
    private List<Movie>? _movies;
    
    public MoviesRepo(string? filePath = "movies.json") {
        _filePath = filePath;
        string content = File.ReadAllText(_filePath);
        _movies = JsonSerializer.Deserialize<List<Movie>>(content);
    }

    public List<Movie>? Movies {
        get {
            return _movies;
        }
    }
    
    private void SaveChanges(){
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        string content = JsonSerializer.Serialize(_movies, options);
        File.WriteAllText(_filePath, content);
    }
    
    private int GetNextId(){
        return _movies != null ?_movies.Max(m => m.Id) +1 : 1;
    }
    public void AddMovie(Movie movie){
        if (_movies == null){
            _movies = new List<Movie>();
        }
        movie.Id = GetNextId();
        _movies.Add(movie);
        SaveChanges();
    }
     public void DeleteMovie(Movie movie) {
        if (_movies == null) {
            return;
        }
        Movies?.Remove(movie);
        SaveChanges();
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
            SaveChanges();
        }
    }
}
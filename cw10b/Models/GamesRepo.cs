namespace cw10b.Models;

using MySql.Data.MySqlClient;

public class GamesRepo {
    private readonly string _connectionString;
    public GamesRepo(string connectionString) {
        _connectionString = connectionString;
    }
    public List<Game> GetGames() {
        List<Game> games = new List<Game>();
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `games`";
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
            games.Add(new Game() {
            Id = reader.GetInt32("id"),
            Title = reader.GetString("title"),
            Publisher = reader.GetString("publisher"),
            ReleaseYear = reader.GetInt32("release_year"),
            Price = reader.GetFloat("price")
            });
        }
        connection.Close();
        return games;
    }
    public void AddGame(Game game) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO `games`(`title`, `publisher`, `release_year`, `price`) VALUES('{game.Title}', '{game.Publisher}', '{game.ReleaseYear}', {game.Price.ToString().Replace(',','.')});";
        connection.Open();
        Console.WriteLine(command.ExecuteNonQuery());
        connection.Close();
    }
    public void DeleteGame(int? id) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM `games` WHERE `id`={id};";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
    public Game? getGameById(int id) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM `games` WHERE `games`.`id`={id} LIMIT 1";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        if (!dataReader.Read()) {
            return null;
        }
        Game game = new Game() {
            Id = dataReader.GetInt32("id"),
            Title = dataReader.GetString("title"),
            Publisher = dataReader.GetString("publisher"),
            Price = dataReader.GetFloat("price"),
            ReleaseYear = dataReader.GetInt32("release_year")
        };
        connection.Close();
        return game;
    }
    public void UpdateGame(Game game) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"UPDATE `games` SET `title`='{game.Title}', `publisher`='{game.Publisher}', `price`={game.Price.ToString().Replace(',', '.')}, `release_year`={game.ReleaseYear} WHERE `id`={game.Id}";
        connection.Open();
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        connection.Close();
    }
}

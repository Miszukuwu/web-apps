namespace inf03styczen202101.Models;

using MySql.Data.MySqlClient;

public class FootballRepo {
    private readonly string _connectionString;
    public FootballRepo(string connectionString) {
        _connectionString = connectionString;
    }
    public List<Match> GetMatches() {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `rozgrywka` WHERE `zespol1`='EVG';";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        List<Match> matches = new List<Match>();
        while (dataReader.Read()) {
            matches.Add(new Match() {
                Team1 = dataReader.GetString("zespol1"),
                Team2 = dataReader.GetString("zespol2"),
                Date = dataReader.GetDateTime("data_rozgrywki").ToString("yyyy-MM-dd"),
                Result = dataReader.GetString("wynik")
            });
        }
        dataReader.Close();
        connection.Close();
        return matches;
    }
    public List<Player> GetPlayers() {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT `zawodnik`.`imie`, `zawodnik`.`nazwisko`, `pozycja`.`nazwa` FROM `zawodnik`, `pozycja` WHERE `zawodnik`.`pozycja_id`=`pozycja`.`id`";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        List<Player> players = new List<Player>();
        while (dataReader.Read()) {
            players.Add(new Player() {
                FirstName = dataReader.GetString("imie"),
                LastName = dataReader.GetString("nazwisko"),
                Position = dataReader.GetString("nazwa")
            });
        }
        dataReader.Close();
        connection.Close();
        return players;
    }
    public List<Player> GetPlayers(int positionId) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT `zawodnik`.`imie`, `zawodnik`.`nazwisko`, `pozycja`.`nazwa` FROM `zawodnik` INNER JOIN `pozycja` ON `zawodnik`.`pozycja_id`=`pozycja`.`id` AND `zawodnik`.`pozycja_id`={positionId}";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        List<Player> players = new List<Player>();
        while (dataReader.Read()) {
            players.Add(new Player() {
                FirstName = dataReader.GetString("imie"),
                LastName = dataReader.GetString("nazwisko"),
                Position = dataReader.GetString("nazwa")
            });
        }
        dataReader.Close();
        connection.Close();
        return players;
    }
    public List<byte[]> GetImages() {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT *, length(plik) as 'imageLength' FROM `zdjecia`";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        List<byte[]> images = new List<byte[]>();
        while (dataReader.Read()) {
            int bufferSize = dataReader.GetInt32("imageLength");
            byte[] imageBytes = new byte[bufferSize];
            dataReader.GetBytes(1, 0, imageBytes, 0, bufferSize);
            images.Add(imageBytes);
        }
        return images;
    }
    public void AddImage(IFormFile image) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        MemoryStream stream = new MemoryStream();
        image.CopyTo(stream);
        byte[] imageBytes = stream.ToArray();
        command.CommandText = $"INSERT INTO `zdjecia`(`plik`) VALUES({imageBytes})";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}

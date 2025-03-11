namespace inf03styczen2022.Models;

using MySql.Data.MySqlClient;

public class RepoReservations {
    private readonly string _connectionString;
    public RepoReservations(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("mysql");
    }
    public void AddReservation(Reservation reservation) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        connection.Open();
        command.CommandText = $"INSERT INTO `rezerwacje`(`nr_stolika`, `data_rez`, `liczba_osob`, `telefon`) VALUES({reservation.TableNumber}, '{reservation.ReservationDate}', {reservation.AmountOfPeople}, '{reservation.PhoneNumber}');";
        try {
            command.ExecuteNonQuery();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
        connection.Close();
    }
    public List<Reservation> GetReservations() {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `rezerwacje`";
        connection.Open();
        MySqlDataReader dataReader = command.ExecuteReader();
        List<Reservation> reservations = new List<Reservation>();
        while (dataReader.Read()) {
            reservations.Add(new Reservation() {
                Id = dataReader.GetInt32("id"),
                TableNumber = dataReader.GetInt32("nr_stolika"),
                AmountOfPeople = dataReader.GetInt32("liczba_osob"),
                ReservationDate = dataReader.GetDateTime("data_rez").ToString("yyyy-MM-dd"),
                PhoneNumber = dataReader.GetString("telefon")
            });
        }
        return reservations;
    }
}

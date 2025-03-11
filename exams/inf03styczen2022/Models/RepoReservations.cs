namespace inf03styczen2022.Models;

using MySql.Data.MySqlClient;

public class RepoReservations {
    private readonly string _connectionString;
    public RepoReservations(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("mysql");
    }
    public void addReservation(Reservation reservation) {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        Console.WriteLine(reservation);
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
}

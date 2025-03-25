namespace inf03styczen2022.Models;

public class Reservation {
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public string? ReservationDate { get; set; }
    public int AmountOfPeople { get; set; }
    public string? PhoneNumber { get; set; }
}

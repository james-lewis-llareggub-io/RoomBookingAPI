namespace RoomBookingAPI.Models;

public class BookingRequest
{
    public string FullName { get; set; }
    public DateTime Date { get; set; }
    public string Email { get; set; }
}
namespace RoomBookingAPI.Models;

public class BookingConfirmation
{
    public BookingConfirmation(BookingRequest bookingRequest)
    {
        BookingRequest = bookingRequest;
    }

    public BookingRequest BookingRequest { get; }
}
namespace RoomBookingAPI.Tests;

public class BookingConfirmation
{
    public BookingConfirmation(BookingRequest bookingRequest)
    {
        BookingRequest = bookingRequest;
    }

    public BookingRequest BookingRequest { get; }
}
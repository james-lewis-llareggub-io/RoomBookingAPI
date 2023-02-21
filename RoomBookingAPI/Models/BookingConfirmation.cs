namespace RoomBookingAPI.Models;

public class BookingConfirmation
{
    public BookingConfirmation(BookingRequest bookingRequest, BookingStatusFlag bookingStatusFlag)
    {
        BookingRequest = bookingRequest;
        BookingStatusFlag = bookingStatusFlag;
    }

    public BookingRequest BookingRequest { get; }
    public BookingStatusFlag BookingStatusFlag { get; }
}
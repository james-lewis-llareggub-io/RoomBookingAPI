namespace RoomBookingAPI.Models;

public class BookingConfirmation
{
    public BookingConfirmation(
        BookingRequest bookingRequest,
        BookingStatusFlag bookingStatusFlag,
        BookingRoom? room
    )
    {
        BookingRequest = bookingRequest;
        BookingStatusFlag = bookingStatusFlag;
        Room = room;
    }

    public BookingRequest BookingRequest { get; }
    public BookingStatusFlag BookingStatusFlag { get; }
    public BookingRoom? Room { get; }
}
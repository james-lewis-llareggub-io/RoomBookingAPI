namespace RoomBookingAPI.Actions;

public class BookRoom
{
    public BookingConfirmation Process(BookingRequest request)
    {
        return new BookingConfirmation(request);
    }
}
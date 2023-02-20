namespace RoomBookingAPI;

public class BookRoom
{
    public BookingConfirmation Process(BookingRequest request)
    {
        return new BookingConfirmation(request);
    }
}
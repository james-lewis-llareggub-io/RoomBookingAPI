namespace RoomBookingAPI.Actions;

public class BookRoom
{
    public BookingConfirmation Process(BookingRequest request)
    {
        if (string.IsNullOrEmpty(request.FullName)) throw new ArgumentNullException("FullName");
        return new BookingConfirmation(request);
    }
}
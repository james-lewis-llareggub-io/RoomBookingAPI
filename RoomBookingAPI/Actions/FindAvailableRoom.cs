namespace RoomBookingAPI.Actions;

public class FindAvailableRoom : IFindAvailableRoom
{
    public BookingRoom? Process(BookingRequest request)
    {
        var daysNotice = (request.Date.Date - DateTime.Today).TotalDays;
        return daysNotice >= 1 ? new BookingRoom() : null;
    }
}
namespace RoomBookingAPI.Actions;

public class FindAvailableRoom : IFindAvailableRoom
{
    public Room? Process(BookingRequest request)
    {
        var daysNotice = (request.Date.Date - DateTime.Today).TotalDays;
        return daysNotice >= 1 ? new Room() : null;
    }
}
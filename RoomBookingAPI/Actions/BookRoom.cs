namespace RoomBookingAPI.Actions;

public class BookRoom
{
    private readonly IFindAvailableRoom _iFindAvailableRoom;

    public BookRoom(IFindAvailableRoom iFindAvailableRoom)
    {
        _iFindAvailableRoom = iFindAvailableRoom;
    }

    public BookingConfirmation Process(BookingRequest request)
    {
        if (string.IsNullOrEmpty(request.FullName)) throw new ArgumentNullException(nameof(request.FullName));
        if (string.IsNullOrEmpty(request.Email)) throw new ArgumentNullException(nameof(request.Email));
        if (DateTime.MinValue.Equals(request.Date)) throw new ArgumentNullException(nameof(request.Date));
        var room = _iFindAvailableRoom.Process(request);
        return new BookingConfirmation(request, BookingStatusFlag.Successful, room);
    }
}
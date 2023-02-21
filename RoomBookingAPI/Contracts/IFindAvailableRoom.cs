namespace RoomBookingAPI.Contracts;

public interface IFindAvailableRoom
{
    BookingRoom? Process(BookingRequest request);
}
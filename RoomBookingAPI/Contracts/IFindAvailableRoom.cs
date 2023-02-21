namespace RoomBookingAPI.Contracts;

public interface IFindAvailableRoom
{
    Room? Process(BookingRequest request);
}
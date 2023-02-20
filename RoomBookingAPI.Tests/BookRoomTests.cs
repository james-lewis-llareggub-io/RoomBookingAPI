namespace RoomBookingAPI;

public class BookRoomTests
{
    [Fact]
    public void Should_return_booking_confirmation_with_original_request()
    {
        var request = new BookingRequest
        {
            FullName = "Test Name",
            Email = "test@somewhere.com",
            Date = new DateTime()
        };

        var bookRoom = new BookRoom();
        var confirmation = bookRoom.Process(request);

        Assert.NotNull(confirmation);
        Assert.IsType<BookingConfirmation>(confirmation);
        Assert.NotNull(confirmation.BookingRequest);
        Assert.Equal(request.FullName, confirmation.BookingRequest.FullName);
        Assert.Equal(request.Email, confirmation.BookingRequest.Email);
        Assert.Equal(request.Date, confirmation.BookingRequest.Date);
    }

    [Fact]
    public void Should_throw_null_exception_if_request_fullname_is_empty()
    {
        var request = new BookingRequest();

        var bookRoom = new BookRoom();
        var exception = Assert.Throws<ArgumentNullException>(() => { bookRoom.Process(request); });
        Assert.Equal("FullName", exception.ParamName);
    }
}
namespace RoomBookingAPI;

public class BookRoomTests
{
    private readonly BookRoom _bookRoom;

    public BookRoomTests()
    {
        _bookRoom = new BookRoom();
    }

    [Fact]
    public void Should_return_booking_confirmation_with_original_request()
    {
        var request = new BookingRequest
        {
            FullName = "Test Name",
            Email = "test@somewhere.com",
            Date = new DateTime()
        };

        var confirmation = _bookRoom.Process(request);
        confirmation.BookingRequest.Should().NotBeNull();
        request.FullName.Should().Be(confirmation.BookingRequest.FullName);
        request.Email.Should().Be(confirmation.BookingRequest.Email);
        request.Date.Should().Be(confirmation.BookingRequest.Date);
    }

    [Fact]
    public void Should_throw_null_exception_if_request_fullname_is_empty()
    {
        var request = new BookingRequest();
        var action = () => _bookRoom.Process(request);
        action.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(request.FullName));
    }
}
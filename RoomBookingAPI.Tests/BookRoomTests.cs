namespace RoomBookingAPI;

public class BookRoomTests
{
    private readonly BookingRequest _bookingRequest;
    private readonly BookRoom _bookRoom;

    public BookRoomTests()
    {
        _bookRoom = new BookRoom();
        _bookingRequest = new BookingRequest
        {
            FullName = "Test Name",
            Email = "test@somewhere.com",
            Date = DateTime.Now
        };
    }

    [Fact]
    public void Should_return_booking_confirmation_with_original_request()
    {
        var confirmation = _bookRoom.Process(_bookingRequest);
        confirmation.BookingRequest.Should().NotBeNull();
        var actual = confirmation.BookingRequest;
        actual.FullName.Should().Be(_bookingRequest.FullName);
        actual.Email.Should().Be(_bookingRequest.Email);
        actual.Date.Should().Be(_bookingRequest.Date);
    }

    public class NullRequestParameters : BookRoomTests
    {
        [Fact]
        public void Should_throw_null_exception_if_request_fullname_is_empty()
        {
            var request = new BookingRequest();
            var action = () => _bookRoom.Process(request);
            action.Should().Throw<ArgumentNullException>()
                .WithParameterName(nameof(request.FullName));
        }

        [Fact]
        public void Should_throw_null_exception_if_request_email_is_empty()
        {
            _bookingRequest.Email = string.Empty;
            var action = () => _bookRoom.Process(_bookingRequest);
            action.Should().Throw<ArgumentNullException>()
                .WithParameterName(nameof(_bookingRequest.Email));
        }

        [Fact]
        public void Should_throw_null_exception_if_request_date_is_empty()
        {
            _bookingRequest.Date = DateTime.MinValue;
            var action = () => _bookRoom.Process(_bookingRequest);
            action.Should().Throw<ArgumentNullException>()
                .WithParameterName(nameof(_bookingRequest.Date));
        }
    }
}
using RoomBookingAPI.Models.enums;

namespace RoomBookingAPI;

public abstract class BookRoomTests
{
    private readonly BookingRequest _bookingRequest;
    private readonly BookRoom _bookRoom;

    protected BookRoomTests()
    {
        _bookRoom = new BookRoom(new FindAvailableRoom());
        _bookingRequest = new BookingRequest
        {
            FullName = "Test Name",
            Email = "test@somewhere.com",
            Date = DateTime.Now
        };
    }

    public class CheckBookingConfirmationProperties : BookRoomTests
    {
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

        [Fact]
        public void Should_return_booking_confirmation_with_success_flag()
        {
            var confirmation = _bookRoom.Process(_bookingRequest);
            confirmation.BookingStatusFlag.Should().Be(BookingStatusFlag.Successful);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Should_return_booking_confirmation_with_room(bool available)
        {
            if (available)
                _bookingRequest.Date = _bookingRequest.Date.AddDays(1);
            var confirmation = _bookRoom.Process(_bookingRequest);
            if (available)
                confirmation.Room.Should().NotBeNull();
            else confirmation.Room.Should().BeNull();
        }
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
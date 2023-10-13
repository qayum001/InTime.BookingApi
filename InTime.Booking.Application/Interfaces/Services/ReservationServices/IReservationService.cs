namespace InTime.Booking.Application.Interfaces.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<Guid> Reserve();
        Task<bool> CancelReservation();
    }
}

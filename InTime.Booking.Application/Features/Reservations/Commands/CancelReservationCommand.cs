using MediatR;

namespace InTime.Booking.Application.Features.Reservations.Commands
{
    public class CancelReservationCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid ReservationId { get; set;}
    }

    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, bool>
    {
        public Task<bool> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
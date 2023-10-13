using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.Schedule;
using MediatR;

namespace InTime.Booking.Application.Features.Reservations.Commands
{
    public class ReserveCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }
        public Guid UserId { get; set; }
        public Guid AudienceId { get; set; }
        public string Description { get; set; }
    }

    public class ReserveCommandHandler : IRequestHandler<ReserveCommand, Guid>
    {
        private readonly IGenericRepository<ScheduleBaseEntity> _genericRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReserveCommandHandler(IGenericRepository<ScheduleBaseEntity> repository,
            IReservationRepository reservationRepository) 
        {
            _genericRepository = repository;
            _reservationRepository = reservationRepository;
        }
        //бронь которую получает этот метод должен быть сверен с рассписанием обеих бд(моя и InTime)
        public async Task<Guid> Handle(ReserveCommand request, CancellationToken cancellationToken)
        {
            var audience = await _reservationRepository.GetAudienceAsync(request.AudienceId);

            var user = await _reservationRepository.GetUserAsync(request.UserId);

            if (audience == null)
                throw new NullReferenceException($"{nameof(audience)} not found");

            var reservationId = Guid.NewGuid();

            var reservation = new Reservation(reservationId, request.Name,
                new TimeSlot(request.Start, request.End),
                user, audience, request.Description);

            return reservation.Id;
        }
    }
}

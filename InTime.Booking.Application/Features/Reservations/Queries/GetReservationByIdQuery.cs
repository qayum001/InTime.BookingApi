using AutoMapper;
using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Entity.Schedule;
using MediatR;

namespace InTime.Booking.Application.Features.Reservations.Queries //have to be replace to reservation queries
{
    public class GetReservationByIdQuery : IRequest<ReservationGetDto>
    {
        public Guid Id { get; }
    }

    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationGetDto>
    {
        private readonly IGenericRepository<Reservation> _genericRepository;
        private readonly IMapper _mapper;
        public GetReservationByIdQueryHandler(IGenericRepository<Reservation> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ReservationGetDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _genericRepository.GetById(request.Id);

            var res = _mapper.Map<ReservationGetDto>(item);// remove mapper if its uses only here
            return res;
        }
    }
}
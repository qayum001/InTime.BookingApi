using AutoMapper;
using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Entity.Schedule;
using MediatR;

namespace InTime.Booking.Application.Features.Schedule.Queries // have to be replaced to lesson queries
{
    public class GetLessonByIdQuery : IRequest<LessonGetDto> 
    {
        public Guid Id { get; }
    }

    public class GetLessonByIdQueryHadnler : IRequestHandler<GetLessonByIdQuery, LessonGetDto>
    {
        private readonly IGenericRepository<Lesson> _genericRepository;
        private readonly IMapper _mapper;

        public GetLessonByIdQueryHadnler(IGenericRepository<Lesson> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<LessonGetDto> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {

            var item = await _genericRepository.GetById(request.Id);

            var res = _mapper.Map<LessonGetDto>(item);

            return res;
        }
    }
}
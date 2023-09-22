using InTime.Booking.Domain.Common;

namespace InTime.Booking.Domain.Entity.University
{
    public class Building : BaseEntity
    {
        public List<Audience> Audience {  get; private set; } = new List<Audience>();
        public Building(Guid id, string name) : base(id, name)
        {
        }
    }
}
using InTime.Booking.Domain.Common;

namespace InTime.Booking.Domain.Entity.University
{
    public class Audience : BaseEntity
    {
        public Building Building { get; }
        public Guid BuildingId { get; }
        public Audience(Guid id, string name, Building building) : base(id, name)
        {
            Building = building;
            BuildingId = building.Id;
        }
    }
}

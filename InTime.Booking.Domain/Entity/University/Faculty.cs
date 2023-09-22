using InTime.Booking.Domain.Common;

namespace InTime.Booking.Domain.Entity.University
{
    public class Faculty : BaseEntity
    {
        public List<Group> Groups { get; private set; } = new List<Group>();
        public Faculty(Guid id, string name, List<Group> groups) : base(id, name)
        {
            Groups = groups;
        }
    }
}
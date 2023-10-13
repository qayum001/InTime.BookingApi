using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.User;

namespace InTime.Booking.Domain.Entity.University
{
    public class Faculty : BaseEntity
    {
        public ICollection<Group> Groups { get; private set; } = new List<Group>();
        public ICollection<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public Faculty(Guid id, string name, List<Group> groups) : base(id, name)
        {
            Groups = groups;
        }
    }
}
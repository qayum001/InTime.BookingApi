namespace InTime.Booking.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }
        public string Name { get; }

        public BaseEntity(Guid id, string name)
        {
            Id = id;
            Name = IsNameCorrect(name);
        }

        public BaseEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = IsNameCorrect(name);
        }

        private string IsNameCorrect(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(Name), "Name can not be null or empty");
            return name;
        }
    }
}
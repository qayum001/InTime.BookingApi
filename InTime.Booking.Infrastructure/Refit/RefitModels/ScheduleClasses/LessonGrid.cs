using JsonKnownTypes;

namespace InTime.Booking.Infrastructure.Refit.RefitModels.ScheduleClasses
{
    [JsonKnownThisType("LESSON")]
    public class LessonGrid
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public LessonType LessonType { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public Professor Professor { get; set; }
        public Audience Audience { get; set; }
    }
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSubgroup { get; set; }
    }

    public class Professor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class Audience
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Building Building { get; set; }
    }

    public class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

using JsonKnownTypes;
using Newtonsoft.Json;


namespace InTime.Booking.Infrastructure.Refit.RefitModels.ScheduleClasses
{
    [JsonConverter(typeof(JsonKnownTypesConverter<EmptyLessonGrid>))]
    [JsonDiscriminator(Name = "type")]
    [JsonKnownThisType("EMPTY")]
    public class EmptyLessonGrid
    {
        public string Type { get; set; }
        public int LessonNumber { get; set; }
        public int Starts { get; set; }
        public int Ends { get; set; }
    }
}

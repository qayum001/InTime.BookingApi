using System.Numerics;

namespace InTime.Booking.Domain.Common.Additional
{
    public static class Metrics
    {
        private const int _lessonDuratinoInSeconds = 5700;
        private const int _oneDayLessonsCount = 7;
        private const int _firstLessonStartInSeconds = 31500;
        private const int _lastLessonEndsInSeconds = 78600;
        private const int _breakDurationInSeconds = 900;
        private const int _minimalBoolkingDuration = 900;

        public static bool CanBeInSchedule(int number) => number > 0 && number <= _oneDayLessonsCount;

        public static int GetLessonStartInSeconds(int number)
        {
            var res = _firstLessonStartInSeconds + (number < 4 ? 0 : 2 * _breakDurationInSeconds);

            number--;

            res += number * (_breakDurationInSeconds + _lessonDuratinoInSeconds);

            return res;
        }

        public static int GetLessonEndInSeconds(int number)
        {
            var res = _firstLessonStartInSeconds + (number < 4 ? 0 : 2 * _breakDurationInSeconds);

            number--;

            res += number * (_breakDurationInSeconds + _lessonDuratinoInSeconds);

            return res + _lessonDuratinoInSeconds;
        }

        public static bool CanBeInSchedule(int startInSeconds, int endInSeconds) => 
            startInSeconds >= _firstLessonStartInSeconds && endInSeconds <= _lastLessonEndsInSeconds;

        public static bool IsAvailableDuration(int startInSeconds, int endInSeconds) => 
            endInSeconds - startInSeconds >= _minimalBoolkingDuration;
    }
}

using InTime.Booking.Infrastructure.Refit.RefitModels;
using Refit;

namespace InTime.Booking.Infrastructure.Refit.Interfaces
{
    public interface IInTimeClient
    {
        /// <summary>
        /// Get all professors
        /// </summary>
        /// <returns></returns>
        [Get("/v1/professors")]
        Task<IEnumerable<InTimeProfessor>> GetProfessorsAsync();

        /// <summary>
        /// Get all faculties
        /// </summary>
        /// <returns></returns>
        [Get("/v1/faculties")]
        Task<IEnumerable<InTimeFaculty>> GetFacultiesAsync();
        
        /// <summary>
        /// Get group by faculty id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        [Get("/v1/faculties/{facultyId}/groups")]
        Task<IEnumerable<InTimeGroup>> GetGroupsAsync(Guid facultyId);

        /// <summary>
        /// Get list of building
        /// </summary>
        /// <returns></returns>
        [Get("/v1/buildings")]
        Task<IEnumerable<InTimeBuilding>> GetBuildingsAsync();

        /// <summary>
        /// Get list of building audiences
        /// </summary>
        /// <param name="buildingId"></param>
        /// <returns></returns>
        [Get("/v1/buildings/{buildingId}/groups")]
        Task<IEnumerable<InTimeAudience>> GetAudiencesAsync(Guid buildingId);

        /// <summary>
        /// Get List of Schedule
        /// </summary>
        /// <param name="type">target, may be "group", "professor", "audience"</param>
        /// <param name="id">id of target</param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [Get("/v1/schedule/{type}")]
        Task<IEnumerable<InTimeSchedule>> GetSchedulesAsync(string type, Guid id, string dateFrom, string dateTo);

    }
}
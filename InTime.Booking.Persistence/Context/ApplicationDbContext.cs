using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;
using InTime.Booking.Persistence.Context.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection;

namespace InTime.Booking.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BaseUser> Users => Set<BaseUser>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Staff> Staff => Set<Staff>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();

        public DbSet<ScheduleBaseEntity> Schedule => Set<ScheduleBaseEntity>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Lesson> Lessons => Set<Lesson>();

        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Audience> Audiences => Set<Audience>();
        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Group> Groups => Set<Group>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleBaseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new AudienceConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
    }
}

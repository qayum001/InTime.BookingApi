using InTime.Booking.Domain.Entity.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InTime.Booking.Persistence.Context.ModelConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.
                HasKey(e => e.Id);
            builder.
                HasMany(e => e.Students).
                WithOne(e => e.Group);
        }
    }
}

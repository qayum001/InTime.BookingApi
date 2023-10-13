using InTime.Booking.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InTime.Booking.Persistence.Context.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.
                HasKey(x => x.Id);
        }
    }
}

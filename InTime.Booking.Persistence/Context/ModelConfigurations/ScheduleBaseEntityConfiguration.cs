using InTime.Booking.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Persistence.Context.ModelConfigurations
{
    public class ScheduleBaseEntityConfiguration : IEntityTypeConfiguration<ScheduleBaseEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleBaseEntity> builder)
        {
            builder.
                HasKey(e => e.Id);
        }
    }
}

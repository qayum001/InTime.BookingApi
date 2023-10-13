using InTime.Booking.Domain.Entity.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Persistence.Context.ModelConfigurations
{
    public class AudienceConfiguration : IEntityTypeConfiguration<Audience>
    {
        public void Configure(EntityTypeBuilder<Audience> builder)
        {
            builder.
                HasKey(t => t.Id);
        }
    }
}

using InTime.Booking.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Persistence.Context.ModelConfigurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.
                HasKey(t => t.Id);
            builder.
                HasMany(t => t.Faculties)
                .WithMany(t => t.Teachers);
        }
    }
}

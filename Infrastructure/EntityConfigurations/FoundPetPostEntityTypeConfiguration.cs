using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class FoundPetPostEntityTypeConfiguration : IEntityTypeConfiguration<FoundPetPost>

    {
        public void Configure(EntityTypeBuilder<FoundPetPost> postConfiguration)
        {

            postConfiguration
                .Property(p => p.Phone)
                .HasMaxLength(15);

            postConfiguration
                .Property(p => p.Details)
                .HasMaxLength(200);

            postConfiguration
                .Property(p => p.Address)
                .HasMaxLength(50);

            postConfiguration
                .HasMany(x => x.AssignedVolunteers)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

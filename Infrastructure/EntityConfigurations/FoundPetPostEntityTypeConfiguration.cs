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
            /*postConfiguration
                .Property(p => p.CreatedBy)
                .HasColumnName("ID Created by");*/

            postConfiguration
                .Property(p => p.Phone)
                .HasMaxLength(15);

            postConfiguration
                .Property(p => p.AvailabilityStart)
                .HasColumnName("Available from");

            postConfiguration
                .Property(p => p.AvailabilityEnd)
                .HasColumnName("Available untill");

            postConfiguration
                .Property(p => p.Comment)
                .HasMaxLength(200);

            postConfiguration
                .Property(p => p.Address)
                .HasMaxLength(50);

            postConfiguration
                .Property(p => p.CipId)
                .HasColumnName("Cip ID");

        }
    }
}

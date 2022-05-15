using FindPetOwner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration
                .HasMany(x => x.FoundPetPosts)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            userConfiguration
                .HasMany(x => x.AssignedVolunteers)
                .WithOne(x => x.AssignedTo)
                .HasForeignKey(x => x.AssignedToId)
                .OnDelete(DeleteBehavior.NoAction);

            userConfiguration
                .Property(p => p.FirstName)
                .HasMaxLength(25);

            userConfiguration
                .Property(p => p.LastName)
                .HasMaxLength(25);

            userConfiguration
                .Property(p => p.Email)
                .HasMaxLength(15);

            userConfiguration
                .Property(p => p.Address)
                .HasMaxLength(50);
        }
    }
}

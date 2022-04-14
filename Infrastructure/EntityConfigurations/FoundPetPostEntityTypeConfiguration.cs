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
        public void Configure(EntityTypeBuilder<FoundPetPost> builder)
        {
        }
    }
}

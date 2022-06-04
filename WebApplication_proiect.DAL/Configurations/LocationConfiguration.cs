using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;

namespace WebApplication_proiect.DAL.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Street)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
            builder.Property(x => x.Building)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
        }
    }
}

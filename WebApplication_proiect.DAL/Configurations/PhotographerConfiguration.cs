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
    public class PhotographerConfiguration : IEntityTypeConfiguration<Photographer>
    {
        public void Configure(EntityTypeBuilder<Photographer> builder)
        {

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
            builder.Property(x => x.PhotographyType)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
            builder.Property(x => x.Equipment)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

        }
    }
}

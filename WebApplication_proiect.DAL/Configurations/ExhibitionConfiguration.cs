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
    public class ExhibitionConfiguration : IEntityTypeConfiguration<Exhibition>
    {
        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
            builder.Property(x => x.Theme)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
        }
    }
}

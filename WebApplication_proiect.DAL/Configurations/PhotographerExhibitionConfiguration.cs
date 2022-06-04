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
    public class PhotographerExhibitionConfiguration : IEntityTypeConfiguration<PhotographerExhibition>
    {
        public void Configure(EntityTypeBuilder<PhotographerExhibition> builder)
        {
            builder.HasOne(p => p.Photographer)
                   .WithMany(p => p.PhotographerExhibitions)
                   .HasForeignKey(p => p.PhotographerId);
            
           builder.HasOne(p => p.Exhibition)
                   .WithMany(p => p.PhotographerExhibitions)
                   .HasForeignKey(p => p.ExhibitionId);

        }
    }
}

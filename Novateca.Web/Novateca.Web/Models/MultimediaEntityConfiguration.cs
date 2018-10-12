using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaEntityConfiguration : IEntityTypeConfiguration<Multimedia>
    {
        public void Configure(EntityTypeBuilder<Multimedia> builder)
        {
            builder.ToTable("Newspaper");
            builder.HasKey(c => c.MultimediaID).HasName("IdMuldimedia");
            builder.Property(c => c.MultimediaID).HasColumnName("IdMultimedia").ValueGeneratedOnAdd();
            builder.Property(c => c.TitleMain).HasColumnName("TitleMain").HasMaxLength(40).IsRequired();
            builder.Property(c => c.SubTitle).HasColumnName("Subtitle").HasMaxLength(40).IsRequired();
            builder.Property(c => c.Subject).HasColumnName("Subject").HasMaxLength(20).IsRequired();
            builder.Property(c => c.PublishingCompany).HasColumnName("PublishingCompany").HasMaxLength(255).IsRequired();


        }
    }
}

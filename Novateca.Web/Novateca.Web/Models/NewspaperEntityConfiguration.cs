using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperEntityConfiguration : IEntityTypeConfiguration<Newspaper>
    {
        public void Configure(EntityTypeBuilder<Newspaper> builder)
        {
            builder.ToTable("Newspaper");
            builder.HasKey(c => c.NewspaperID).HasName("IdBook");
            builder.Property(c => c.NewspaperID).HasColumnName("IdNewspaper").ValueGeneratedOnAdd();
            builder.Property(c => c.TitleMain).HasColumnName("TitleMain").HasMaxLength(40).IsRequired();
            builder.Property(c => c.SubTitle).HasColumnName("Subtitle").HasMaxLength(40).IsRequired();
            builder.Property(c => c.Subject).HasColumnName("Subject").HasMaxLength(20).IsRequired();
            builder.Property(c => c.PublishingCompany).HasColumnName("PublishingCompany").HasMaxLength(255).IsRequired();


        }
    }
}

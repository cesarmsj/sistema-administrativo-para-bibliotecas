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
            builder.HasKey(c => c.NewspaperID).HasName("NewspaperID");
            builder.Property(c => c.NewspaperID).HasColumnName("NewspaperID").ValueGeneratedOnAdd();
            builder.Property(c => c.TitleMain).HasColumnName("TitleMain").HasMaxLength(40).IsRequired();
            builder.Property(c => c.SubTitle).HasColumnName("Subtitle").HasMaxLength(40).IsRequired();
            builder.Property(c => c.Edition).HasColumnName("Edition").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Locate).HasColumnName("Locate").HasMaxLength(80).IsRequired();
            builder.Property(c => c.Subject).HasColumnName("Subject").HasMaxLength(20).IsRequired();
            builder.Property(c => c.PublishingCompany).HasColumnName("PublishingCompany").HasMaxLength(255).IsRequired();
            builder.Property(c => c.CurrentPeriodicity).HasColumnName("CurrentPeriodicity").HasMaxLength(30).IsRequired();
            builder.Property(c => c.URLImage).HasColumnName("URLImage").HasMaxLength(255).IsRequired();


        }
    }
}

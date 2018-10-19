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
            builder.Property(c => c.TitleMain).HasColumnName("TitleMain").HasMaxLength(80).IsRequired();
            builder.Property(c => c.SubTitle).HasColumnName("Subtitle").HasMaxLength(80);
            builder.Property(c => c.Edition).HasColumnName("Edition").HasMaxLength(20).IsRequired();
            builder.Property(c => c.PlaceOfPublication).HasColumnName("PlaceOfPublication").HasMaxLength(80).IsRequired();
            builder.Property(c => c.NewspaperSubject).HasColumnName("NewspaperSubject").HasMaxLength(20).IsRequired();
            builder.Property(c => c.ISSN).HasColumnName("ISSN").HasMaxLength(255).IsRequired();
            builder.Property(c => c.PublishingCompany).HasColumnName("PublishingCompany").HasMaxLength(255).IsRequired();
            builder.Property(c => c.CurrentPeriodicity).HasColumnName("CurrentPeriodicity").HasMaxLength(30).IsRequired();
            builder.Property(c => c.URLImage).HasColumnName("URLImage").HasMaxLength(255);


        }
    }
}

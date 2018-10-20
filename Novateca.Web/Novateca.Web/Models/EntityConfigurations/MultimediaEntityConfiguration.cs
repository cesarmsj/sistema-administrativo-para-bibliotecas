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
            builder.ToTable("Multimedia");
            builder.HasKey(c => c.MultimediaID).HasName("MuldimediaID");
            builder.Property(c => c.MultimediaID).HasColumnName("MultimediaID").ValueGeneratedOnAdd();
            builder.Property(c => c.TitleMain).HasColumnName("TitleMain").HasMaxLength(255).IsRequired();
            builder.Property(c => c.DGM).HasColumnName("DGM").HasMaxLength(100).IsRequired();
            builder.Property(c => c.SubTitle).HasColumnName("Subtitle").HasMaxLength(255);
            builder.Property(c => c.Director).HasColumnName("Director").HasMaxLength(80).IsRequired();
            builder.Property(c => c.PlaceOfPublication).HasColumnName("PlaceOfPublication").HasMaxLength(80).IsRequired();
            builder.Property(c => c.MultimediaSubject).HasColumnName("MultimediaSubject").HasMaxLength(80).IsRequired();
            builder.Property(c => c.PublishingCompany).HasColumnName("PublishingCompany").HasMaxLength(80).IsRequired();
            builder.Property(c => c.YearOfPublication).HasColumnName("YearOfPublication").IsRequired();
            builder.Property(c => c.PhysicalDescription).HasColumnName("PhysicalDescription").HasMaxLength(80).IsRequired();
            builder.Property(c => c.Abstract).HasColumnName("Abstract");
            builder.Property(c => c.NoteOfParticipants).HasColumnName("NoteOfParticipants").HasMaxLength(255).IsRequired();
            builder.Property(c => c.TargetAudience).HasColumnName("TargetAudience").HasMaxLength(80).IsRequired();
            builder.Property(c => c.Language).HasColumnName("Language").HasMaxLength(30).IsRequired();
            builder.Property(c => c.URLImage).HasColumnName("URLImage").HasMaxLength(255);

        }
    }
}

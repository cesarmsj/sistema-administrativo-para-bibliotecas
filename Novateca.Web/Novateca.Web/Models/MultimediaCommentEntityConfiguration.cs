using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaCommentEntityConfiguration : IEntityTypeConfiguration<MultimediaComment>
    {

        public void Configure(EntityTypeBuilder<MultimediaComment> builder)
        {

            builder.ToTable("MultimediaComment");
            builder.HasKey(c => c.MultimediaCommentID);
            builder.Property(c => c.MultimediaCommentID).HasColumnName("MultimediaCommentID").ValueGeneratedOnAdd();
            builder.Property(c => c.Comment).HasColumnName("Comment").HasMaxLength(255).IsRequired();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.MultimediaComments).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Multimedia).WithMany(u => u.MultimediaComments).HasForeignKey(c => c.MultimediaID);
        }

    }
}

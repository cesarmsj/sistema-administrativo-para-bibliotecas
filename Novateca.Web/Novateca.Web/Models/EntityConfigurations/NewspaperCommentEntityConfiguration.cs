using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperCommentEntityConfiguration : IEntityTypeConfiguration<NewspaperComment>
    {

        public void Configure(EntityTypeBuilder<NewspaperComment> builder)
        {

            builder.ToTable("NewspaperComment");
            builder.HasKey(c => c.NewspaperCommentID);
            builder.Property(c => c.NewspaperCommentID).HasColumnName("NewspaperCommentID").ValueGeneratedOnAdd();
            builder.Property(c => c.Comment).HasColumnName("Comment").HasMaxLength(100).IsRequired();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.NewspaperComments).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Newspaper).WithMany(u => u.NewspaperComments).HasForeignKey(c => c.NewspaperID);
        }

    }
}

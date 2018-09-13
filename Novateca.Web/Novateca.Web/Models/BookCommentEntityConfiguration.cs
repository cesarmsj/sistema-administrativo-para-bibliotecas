using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Novateca.Web.Models
{
    public class BookCommentEntityConfiguration : IEntityTypeConfiguration<BookComment>
    {

        public void Configure(EntityTypeBuilder<BookComment> builder)
        {
            
                builder.ToTable("BookComment");
                builder.HasKey(c => c.BookCommentID);
                builder.Property(c => c.Comment).HasColumnName("Comment").HasMaxLength(100).IsRequired();
                builder.HasOne(c => c.ApplicationUser).WithMany(u => u.BookComments).HasForeignKey(c => c.UserID);
                builder.HasOne(c => c.Book).WithMany(u => u.BookComments).HasForeignKey(c => c.BookID);
        }
        
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class BookLikeEntityConfiguration : IEntityTypeConfiguration<BookLike>
    {

        public void Configure(EntityTypeBuilder<BookLike> builder)
        {
            
                builder.ToTable("BookLike");
                builder.HasKey(c => c.BookLikeID);
                builder.Property(c => c.BookLikeID).HasColumnName("BookLikeID").ValueGeneratedOnAdd();
                builder.HasOne(c => c.ApplicationUser).WithMany(u => u.BookLikes).HasForeignKey(c => c.UserId);
                builder.HasOne(c => c.Book).WithMany(u => u.BookLikes).HasForeignKey(c => c.BookID);
        }
        
    }
}

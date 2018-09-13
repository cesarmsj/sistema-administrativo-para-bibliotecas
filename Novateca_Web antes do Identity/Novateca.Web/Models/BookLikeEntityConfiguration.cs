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
                builder.HasOne(c => c.User).WithMany(u => u.BookLikes).HasForeignKey(c => c.UserID);
                builder.HasOne(c => c.Book).WithMany(u => u.BookLikes).HasForeignKey(c => c.BookID);
        }
        
    }
}

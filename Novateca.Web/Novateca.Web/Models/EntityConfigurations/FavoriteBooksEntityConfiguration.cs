using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteBooksEntityConfiguration : IEntityTypeConfiguration<FavoriteBook>
    {
        public void Configure(EntityTypeBuilder<FavoriteBook> builder)
        {

            builder.ToTable("FavoriteBook");
            builder.HasKey(c => c.FavoriteBookID);
            builder.Property(c => c.FavoriteBookID).HasColumnName("FavoriteBookID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.FavoriteBooks).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Book).WithMany(u => u.FavoriteBooks).HasForeignKey(c => c.BookID);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteNewspapersEntityConfiguration : IEntityTypeConfiguration<FavoriteNewspaper>
    {
        public void Configure(EntityTypeBuilder<FavoriteNewspaper> builder)
        {

            builder.ToTable("FavoriteNewspaper");
            builder.HasKey(c => c.FavoriteNewspaperID);
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.FavoriteNewspapers).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Newspaper).WithMany(u => u.FavoriteNewspaper).HasForeignKey(c => c.NewspaperID);
        }
    }
}

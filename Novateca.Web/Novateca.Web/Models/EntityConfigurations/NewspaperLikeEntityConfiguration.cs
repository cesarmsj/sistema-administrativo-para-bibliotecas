using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperLikeEntityConfiguration : IEntityTypeConfiguration<NewspaperLike>
    {

        public void Configure(EntityTypeBuilder<NewspaperLike> builder)
        {

            builder.ToTable("NewspaperLike");
            builder.HasKey(c => c.NewspaperLikeID);
            builder.Property(c => c.NewspaperLikeID).HasColumnName("NewspaperLikeID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.NewspaperLikes).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Newspaper).WithMany(u => u.NewspaperLikes).HasForeignKey(c => c.NewspaperID);
        }

    }
}

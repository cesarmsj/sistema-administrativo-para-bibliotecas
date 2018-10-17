using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLikeEntityConfiguration : IEntityTypeConfiguration<MultimediaLike>
    {

        public void Configure(EntityTypeBuilder<MultimediaLike> builder)
        {

            builder.ToTable("MultimediaLike");
            builder.HasKey(c => c.MultimediaLikeID);
            builder.Property(c => c.MultimediaLikeID).HasColumnName("MultimediaLikeID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.MultimediaLikes).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Multimedia).WithMany(u => u.MultimediaLikes).HasForeignKey(c => c.MultimediaID);
        }

    }
}

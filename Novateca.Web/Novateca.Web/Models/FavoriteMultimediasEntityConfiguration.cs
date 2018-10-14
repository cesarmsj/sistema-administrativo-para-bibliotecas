using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteMultimediasEntityConfiguration : IEntityTypeConfiguration<FavoriteMultimedia>
    {
        public void Configure(EntityTypeBuilder<FavoriteMultimedia> builder)
        {

            builder.ToTable("FavoriteMultimedia");
            builder.HasKey(c => c.FavoriteMultimediaID);
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.FavoriteMultimedias).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Multimedia).WithMany(u => u.FavoriteMultimedias).HasForeignKey(c => c.MultimediaID);
        }
    }
}

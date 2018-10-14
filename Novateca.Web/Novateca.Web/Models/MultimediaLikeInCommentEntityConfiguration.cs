using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLikeInCommentEntityConfiguration : IEntityTypeConfiguration<MultimediaLikeInComment>
    {

        public void Configure(EntityTypeBuilder<MultimediaLikeInComment> builder)
        {

            builder.ToTable("MultimediaLikeInComment");
            builder.HasKey(c => c.MultimediaLikeInCommentID);
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.MultimediaLikeInComments).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.MultimediaComment).WithMany(u => u.MultimediaLikeInComments).HasForeignKey(c => c.MultimediaCommentID);
        }

    }
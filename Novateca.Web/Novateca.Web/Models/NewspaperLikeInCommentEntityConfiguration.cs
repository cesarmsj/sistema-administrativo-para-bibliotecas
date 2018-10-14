using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperLikeInCommentEntityConfiguration : IEntityTypeConfiguration<NewspaperLikeInComment>
    {

        public void Configure(EntityTypeBuilder<NewspaperLikeInComment> builder)
        {

            builder.ToTable("NewspaperLikeInComment");
            builder.HasKey(c => c.NewspaperLikeInCommentID);
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.NewspaperLikeInComments).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.NewspaperComment).WithMany(u => u.NewspaperLikeInComments).HasForeignKey(c => c.NewspaperCommentID);
        }

    }
}

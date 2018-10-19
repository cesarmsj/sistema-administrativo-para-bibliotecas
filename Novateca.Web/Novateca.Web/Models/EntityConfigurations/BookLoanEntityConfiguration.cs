using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class BookLoanEntityConfiguration : IEntityTypeConfiguration<BookLoan>
    {
        public void Configure(EntityTypeBuilder<BookLoan> builder)
        {

            builder.ToTable("BookLoan");
            builder.HasKey(c => c.BookLoanID);
            builder.Property(c => c.BookLoanID).HasColumnName("BookLoanID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.BookLoans).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Book).WithMany(u => u.BookLoans).HasForeignKey(c => c.BookID);
        }

    }
}

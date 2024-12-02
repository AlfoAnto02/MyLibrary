using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configurations {
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory> {
        public void Configure(EntityTypeBuilder<BookCategory> builder) {
            builder.ToTable("Book_Category");
            builder.HasKey(bc => new { bc.CategoryId, bc.BookId });
            builder.HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            builder.HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}

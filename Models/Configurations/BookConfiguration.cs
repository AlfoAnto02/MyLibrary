using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configurations {
    public class BookConfiguration : IEntityTypeConfiguration<Book> {
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Publication_Date)
                .IsRequired();
        }
    }
}

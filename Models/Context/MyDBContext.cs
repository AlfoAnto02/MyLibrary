using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Models.Context {
    public class MyDBContext : DbContext {

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        public MyDBContext() : base() { }
        public DbSet<Entities.Book> Books { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.BookCategory> BookCategories { get; set; }
        public DbSet<Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
    }
}

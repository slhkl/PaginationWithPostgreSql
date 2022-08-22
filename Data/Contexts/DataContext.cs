using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost; Database=paginatition; Username=root; Password=root");
        }
        public DbSet<Book> Books { get; set; }
    }
}

using FileSaver.Models;
using Microsoft.EntityFrameworkCore;

namespace FileSaver.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        public DbSet<Filess>? Files { get; set; }
    }
}

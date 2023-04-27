using CRUDproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDproject.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using TestMVCProject.Models.Domain;

namespace TestMVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EntityModel> EntityModels { get; set; }
    }
}

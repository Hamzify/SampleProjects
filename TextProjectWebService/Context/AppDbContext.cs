using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TextProjectWebService.Model;

namespace TextProjectWebService.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserModel> UserModels { get; set; }
    }
}

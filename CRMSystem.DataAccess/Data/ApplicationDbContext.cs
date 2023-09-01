using CRMSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Criminal> Criminals { get; set; }

    }
}

using BlazingProject.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazingProject.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        //Referenciamos los modelos que vaya a utilizar Entity Framework. 
        public  DbSet<ContactC> contact { get; set; }
        public DbSet<AdminC> admin { get; set; }

    }
}

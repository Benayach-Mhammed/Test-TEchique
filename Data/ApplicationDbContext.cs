using Microsoft.EntityFrameworkCore;
using Test.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<ApplicationViewModel> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}

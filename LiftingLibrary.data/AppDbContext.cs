using LiftingLibrary.models;
using Microsoft.EntityFrameworkCore;

namespace LiftingLibrary.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}
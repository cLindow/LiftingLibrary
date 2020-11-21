using LiftingLibrary.models;
using Microsoft.EntityFrameworkCore;

namespace LiftingLibrary.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<ExerciseRelationship> ExerciseRelationships { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExerciseCategory>()
                .HasKey(x => new {x.CategoryId, x.ExerciseId});
            
            modelBuilder.Entity<ExerciseRelationship>()
                .HasKey(x => new {x.PrerequisiteId, x.ProgressionId});
            
            modelBuilder.Entity<ExerciseRelationship>()
                .HasOne(x => x.Progression)
                .WithMany(x => x.Prerequisites)
                .HasForeignKey(x => x.ProgressionId);
            
            modelBuilder.Entity<ExerciseRelationship>()
                .HasOne(x => x.Prerequisite)
                .WithMany(x => x.Progressions)
                .HasForeignKey(x => x.PrerequisiteId);

        }
    }
}
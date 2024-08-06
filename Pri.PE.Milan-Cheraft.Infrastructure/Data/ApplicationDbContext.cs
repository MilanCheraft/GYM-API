using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pri.PE.Milan_Cheraft.Infrastructure.Data.Seeding;
using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.MuscleGroup)
                .WithMany(mg => mg.Workouts)
                .HasForeignKey(w => w.MuscleGroupId)
                .OnDelete(DeleteBehavior.Restrict);
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}

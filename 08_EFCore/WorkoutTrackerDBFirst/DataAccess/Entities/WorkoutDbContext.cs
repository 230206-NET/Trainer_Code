using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<WorkoutSession> WorkoutSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC076DE47249");

            entity.Property(e => e.ExerciseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExerciseNote)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Workout).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("FK__Exercises__Worko__60A75C0F");
        });

        modelBuilder.Entity<WorkoutSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkoutS__3214EC0772CE2E46");

            entity.Property(e => e.WorkoutDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.WorkoutName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

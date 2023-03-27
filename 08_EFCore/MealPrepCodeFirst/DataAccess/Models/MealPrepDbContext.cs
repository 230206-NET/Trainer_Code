using Microsoft.EntityFrameworkCore;
using Models;

public class MealPrepDbContext : DbContext {
    public MealPrepDbContext(DbContextOptions<MealPrepDbContext> options) : base(options) { }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Meal> Meals { get; set; }
}
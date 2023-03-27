using Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccess;
public class Repository
{
    private readonly MealPrepDbContext _context;

    public Repository(MealPrepDbContext context) {
        _context = context;
    }

    public Meal CreateMeal(Meal m) {
        _context.Add(m);

        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return m;
    }
    public List<Meal> GetAll() {
        return _context.Meals.Include("Ingredients").ToList();
    }

    public Meal UpdateMeal(Meal m) {
        _context.Update(m);
        _context.Meals.ToList();
        _context.SaveChanges();
        return m;
    }

    public Meal DeleteMeal(Meal m) {
        _context.Remove(m);
        _context.SaveChanges();
        return m;
    }
}

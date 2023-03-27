using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess;
public class Repository
{
    private readonly WorkoutDbContext _context;

    public Repository(WorkoutDbContext context) {
        _context = context;
    }

    public List<WorkoutSession> GetAllWorkouts() {
        return _context.WorkoutSessions.ToList();
    }

    public List<WorkoutSession> GetAllWorkouts(DateTime date) {
        return _context.WorkoutSessions.Where(w => w.WorkoutDate >= date).ToList();
    }
}

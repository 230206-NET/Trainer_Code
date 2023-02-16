using UI;
using Services;
using DataAccess;

// How to inject dependencies upon instantiation
// new MainMenu(new WorkoutService(new FileStorage())).Start();

IRepository repo = new FileStorage();
WorkoutService service = new WorkoutService(repo);
MainMenu menu = new MainMenu(service);
menu.Start();
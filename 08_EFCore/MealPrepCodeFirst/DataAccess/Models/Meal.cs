
namespace Models;
public class Meal {
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public DateTime DateCreated { get; set; } = new DateTime();
    public List<Ingredient> Ingredients{ get; set; } = new();
}
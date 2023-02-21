namespace Models;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }

    public override string ToString()
    {
        return $"Name: {this.Name}\nNotes:{this.Notes}";
    }
}
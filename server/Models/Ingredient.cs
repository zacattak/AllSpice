namespace AllSpice.Models;

public class Ingredient
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public string RecipeId { get; set; }

}
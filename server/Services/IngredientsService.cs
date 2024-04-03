namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
        _repository = repository;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);

        return ingredient;
    }

    internal string DestroyIngredient(int ingredientId)
    {
        _repository.DestroyIngredient(ingredientId);
        return "Ingredient is no longer a part of the recipe!";
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}
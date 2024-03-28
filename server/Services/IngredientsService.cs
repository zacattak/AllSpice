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

    internal string DestroyIngredient(int ingredientId, string id)
    {
        throw new NotImplementedException();
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}
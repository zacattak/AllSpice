namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }


    internal Recipe ArchiveRecipe(int recipeId, string userId)
    {
        Recipe recipeToArchive = GetRecipeById(recipeId);


        if (recipeToArchive.CreatorId != userId)
        {
            throw new Exception("NOT YOUR ALBUM");
        }

        recipeToArchive.Archived = !recipeToArchive.Archived;

        Recipe updatedRecipe = _repository.ArchiveRecipe(recipeToArchive);

        return updatedRecipe;

    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"Invalid Id: {recipeId}");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _repository.GetRecipes();
        return recipes;
    }
}
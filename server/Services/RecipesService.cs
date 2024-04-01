namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }


    // internal Recipe ArchiveRecipe(int recipeId, string userId)
    // {
    //     Recipe recipeToArchive = GetRecipeById(recipeId);


    //     if (recipeToArchive.CreatorId != userId)
    //     {
    //         throw new Exception("NOT YOUR ALBUM");
    //     }

    //     recipeToArchive.Archived = !recipeToArchive.Archived;

    //     Recipe updatedRecipe = _repository.ArchiveRecipe(recipeToArchive);

    //     return updatedRecipe;

    // }

    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId == userId)
        {
            _repository.DestroyRecipe(recipeId);
            return $"{recipe.Title} removed";
        }
        else
        {
            throw new Exception("You cannot destroy what you did not create!");
        }
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

    internal Recipe EditRecipe(Recipe updateData, int recipeId)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);
        originalRecipe.Title = updateData.Title?.Length > 0 ? updateData.Title : originalRecipe.Title;
        originalRecipe.Instructions = updateData.Instructions?.Length > 0 ? updateData.Instructions : originalRecipe.Instructions;
        originalRecipe.Img = updateData.Img?.Length > 0 ? updateData.Img : originalRecipe.Img;
        originalRecipe.Category = updateData.Category?.Length > 0 ? updateData.Category : originalRecipe.Category;
        Recipe newRecipe = _repository.EditRecipe(originalRecipe);
        return newRecipe;
    }
}
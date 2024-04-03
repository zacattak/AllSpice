namespace AllSpice.Repositories;
public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
    INSERT INTO
    ingredients(name, quantity, recipeId)
    VALUES(@Name, @Quantity, @RecipeId);
    
    SELECT
    ingredient.*,
    recipe.*
    FROM ingredients ingredient
    JOIN recipes recipe ON ingredient.recipeId = recipe.id
    WHERE ingredient.id = LAST_INSERT_ID();";

        // Ingredient ingredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        // {
        //     ingredient.Creator = account;
        //     return ingredient;
        // }, ingredientData).FirstOrDefault();

        // return ingredient;

        Ingredient ingredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
        {
            ingredient.RecipeId = recipe.Id;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
    SELECT
    ingredient.*,
    recipe.*
    FROM ingredients ingredient
    JOIN recipes recipe ON ingredient.recipeId = recipe.id
    WHERE ingredient.recipeId = @recipeId
    ;";

        //     List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, _populateCreator, new { recipeId }).ToList();

        //     return ingredients;
        // }

        // private Ingredient _populateCreator(Ingredient ingredient, Account account)
        // {
        //     ingredient.Creator = account;
        //     return ingredient;
        // }
        List<Ingredient> ingredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
        {
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredient;
    }

    internal void DestroyIngredient(int ingredientId)
    {
        string sql = @"DELETE FROM ingredients WHERE id = @ingredientId;";
        _db.Execute(sql, new { ingredientId });
    }
}
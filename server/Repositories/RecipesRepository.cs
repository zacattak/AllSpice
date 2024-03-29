namespace AllSpice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe ArchiveRecipe(Recipe recipeData)
    {
        string sql = @"
    UPDATE recipes
    SET
    archived = @Archived
    WHERE id = @Id;
    
    SELECT
    recipe.*,
    account.*
    FROM recipes recipe
    JOIN accounts account ON recipe.creatorId = account.id
    WHERE recipe.id = @Id;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();

        return recipe;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO
        recipes(title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

        SELECT
        recipe.*,
        account.*
        FROM recipes recipe
        JOIN accounts account ON recipe.creatorId = account.id
        WHERE recipe.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
        recipe.Creator = account;
        return recipe;
    }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
      SELECT 
      recipe.*,
      account.* 
      FROM recipes recipe
      JOIN accounts account ON recipe.creatorId = account.id 
      WHERE recipe.id = @recipeId
      ;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
        recipe.Creator = account;
        return recipe;
    }, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    internal Recipe EditRecipe(Recipe updateData)
    {
        string sql = @"
        UPDATE recipes SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;

        SELECT
        recipe.*,
        account.*
        FROM recipes recipe
        JOIN accounts account ON recipe.creatorId = account.id
        WHERE recipe.id = @id;";
        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, updateData).FirstOrDefault();
        return recipe;
    }



    internal List<Recipe> GetRecipes()
    {
        string sql = @"
    SELECT 
    recipe.*,
    account.* 
    FROM recipes recipe
    JOIN accounts account ON recipe.creatorId = account.id
    ;";
        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
          recipe.Creator = account;
          return recipe;
      }).ToList();
        return recipes;
    }
}
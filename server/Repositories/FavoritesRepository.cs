namespace AllSpice.Repositories;
public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
    INSERT INTO 
    favorites(accountId, recipeId)
    VALUES(@AccountId, @RecipeId);
    SELECT
    favorite.*,
    recipe.*
    FROM favorites favorite
    JOIN recipes recipe ON recipe.id = favorite.recipeId
    WHERE favorite.id = LAST_INSERT_ID();";

        FavoriteRecipe favoriteRecipe = _db.Query<Favorite, FavoriteRecipe, FavoriteRecipe>(sql, (favorite, recipe) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.RecipeId = favorite.RecipeId;
            return recipe;
        },
        favoriteData).FirstOrDefault();
        return favoriteRecipe;
    }

    internal Favorite FindFavoriteById(int favoriteId)
    {
        string sql = @"SELECT * FROM favorites WHERE id = @favoriteId;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId)
    {
        string sql = @"
      SELECT

     favorite.*,
     recipe.*,

     account.*
      FROM favorites favorite
      JOIN recipes recipe ON recipe.id = favorite.recipeId
      JOIN accounts account ON account.id = recipe.creatorId
      WHERE favorite.accountId = @userId;";
        List<FavoriteRecipe> favorite = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (favorite, recipe, account) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.CreatorId = favorite.AccountId;
            recipe.Creator = account;
            return recipe;
        }, new { userId }).ToList();
        return favorite;
    }

    internal void DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId;";
        _db.Execute(sql, new { favoriteId });
    }
}
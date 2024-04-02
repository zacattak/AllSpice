namespace AllSpice.Repositories;
public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
    INSERT INTO 
    favorites(accountId, recipeId)
    VALUES(@AccountId, @RecipeId);
    SELECT
    favorite.*,
    recipe.*
    FROM favorites favorite
    JOIN recipes recipe ON favorite.recipeId = @RecipeId
    WHERE favorite.id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite, Recipe, Favorite>(sql, (favorite, recipe) =>
        {
            favorite.AccountId = recipe.CreatorId;
            return favorite;
        }, favoriteData).FirstOrDefault();
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
      JOIN accounts account ON recipe.creatorId = account.id
      WHERE favorite.accountId = @userId;";
        List<FavoriteRecipe> favorite = _db.Query<FavoriteRecipe, Favorite, Account, FavoriteRecipe>(sql, (favoriteRecipe, favorite, account) =>
        {
            favoriteRecipe.FavoriteId = favorite.Id;
            favoriteRecipe.Creator = account;
            return favoriteRecipe;
        }, new { userId }).ToList();
        return favorite;
    }

    internal void DeleteFavorite(string favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId;";
        _db.Execute(sql, new { favoriteId });
    }
}
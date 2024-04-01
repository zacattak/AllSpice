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
    favorites(recipeId, accountId)
    VALUES(@RecipeId, @AccountId);
    SELECT
    favorites.*,
    recipes.*
    FROM favorites favorite
    JOIN recipes recipe ON favorite.recipeId = @recipeId
    WHERE id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite, Recipe, Favorite>(sql, (favorite, recipe) =>
        {
            favorite.AccountId = recipe.CreatorId;
            return favorite;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }
}
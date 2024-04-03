namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favoriteRecipe = _repository.CreateFavorite(favoriteData);
        return favoriteRecipe;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId)
    {
        List<FavoriteRecipe> favorites = _repository.GetAccountFavorites(userId);
        return favorites;
    }

    internal Favorite FindFavoriteById(int favoriteId)
    {
        Favorite favorite = _repository.FindFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"Invalid ID: {favoriteId}");
        }
        return favorite;
    }


    internal string DeleteFavorite(string userId, int favoriteId)
    {
        Favorite favorite = FindFavoriteById(favoriteId);
        if (userId != favorite.AccountId)
        {
            throw new Exception("Not yours to delete!");
        }
        _repository.DeleteFavorite(favoriteId);
        return "deleted from favorites";
    }
}
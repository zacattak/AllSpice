namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId)
    {
        List<FavoriteRecipe> favorites = _repository.GetAccountFavorites(userId);
        return favorites;
    }

    internal string DeleteFavorite(string favoriteId)
    {
        _repository.DeleteFavorite(favoriteId);
        return "deleted from favorites";
    }
}
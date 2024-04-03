namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;

    private readonly Auth0Provider _auth0Provider;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

            favoriteData.AccountId = userInfo.Id;

            FavoriteRecipe favoriteRecipe = _favoritesService.CreateFavorite(favoriteData);

            return Ok(favoriteRecipe);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{favoriteId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _favoritesService.DeleteFavorite(userInfo.Id, favoriteId);
            return Ok(message);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }
}
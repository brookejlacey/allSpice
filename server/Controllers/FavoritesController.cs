namespace allSpice.Controllers;

[ApiController]
[Route("api/favorites")]

public class FavoritesController : ControllerBase
{

    private readonly FavoritesService favoritesService;
    private readonly Auth0Provider auth;
    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
    {
        this.favoritesService = favoritesService;
        this.auth = auth;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {

    }
}
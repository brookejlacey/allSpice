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
    public async Task<ActionResult<FavoriteAccount>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            FavoriteAccount collabAccount = favoritesService.CreateFavorite(favoriteData);
            return Ok(collabAccount);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    //  [HttpDelete("{favoriteId}")]
    //   [Authorize]
    //   public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
    //   {
    //     try
    //     {
    //       Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
    //       string message = favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
    //       return Ok(message);
    //     }
    //   catch (Exception e)
    //     {
    //       return BadRequest(e.Message);
    //     }
    //   }
}
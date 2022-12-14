namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FavoritesController : ControllerBase
  {
    private readonly Auth0Provider _a0p;
    private readonly FavoritesService _fs;
    public FavoritesController(Auth0Provider a0p, FavoritesService fs)
    {
      _a0p = a0p;
      _fs = fs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite(
      [FromBody] Favorite favoriteData)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        favoriteData.AccountId = userInfo.Id;
        favoriteData.Id = Guid.NewGuid().ToString();
        return Ok(_fs.CreateFavorite(favoriteData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{favId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(string favId)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        return Ok(_fs.DeleteFavorite(favId, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
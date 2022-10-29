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


  }
}
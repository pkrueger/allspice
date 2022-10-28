namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly Auth0Provider _a0p;
    private readonly RecipesService _rs;

    public RecipesController(Auth0Provider a0p, RecipesService rs)
    {
      _a0p = a0p;
      _rs = rs;
    }
  }
}
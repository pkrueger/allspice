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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        recipeData.CreatorId = userInfo.Id;
        Recipe newRecipe = _rs.CreateRecipe(recipeData);
        return Ok(newRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAllRecipes();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
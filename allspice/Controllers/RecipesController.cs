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

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
      try
      {
        Recipe recipe = _rs.GetRecipeById(recipeId);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> EditRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        recipeData.CreatorId = userInfo.Id;
        recipeData.Id = recipeId;
        Recipe recipe = _rs.EditRecipe(recipeData);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        _rs.DeleteRecipe(recipeId, userInfo.Id);
        return Ok("Recipe has been deleted.");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
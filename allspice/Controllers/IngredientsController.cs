namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly Auth0Provider _a0p;
    private readonly IngredientsService _is;

    public IngredientsController(Auth0Provider a0p, IngredientsService @is)
    {
      _a0p = a0p;
      _is = @is;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingData)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        Ingredient ingredient = _is.CreateIngredient(ingData, userInfo.Id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
      try
      {
        Profile userInfo = await _a0p.GetUserInfoAsync<Profile>(HttpContext);
        _is.DeleteRecipe(ingredientId, userInfo.Id);
        return Ok("Ingredient has been deleted.");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
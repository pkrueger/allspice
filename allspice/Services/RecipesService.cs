namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recrepo;

    public RecipesService(RecipesRepository recrepo)
    {
      _recrepo = recrepo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      return _recrepo.CreateRecipe(recipeData);
    }

    internal List<Recipe> GetAllRecipes()
    {
      return _recrepo.GetAllRecipes();
    }
  }
}
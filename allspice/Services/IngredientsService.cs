namespace allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _irepo;
    private readonly RecipesRepository _recrepo;

    public IngredientsService(IngredientsRepository irepo, RecipesRepository recrepo)
    {
      _irepo = irepo;
      _recrepo = recrepo;
    }

    internal Ingredient CreateIngredient(Ingredient ingData, string accountId)
    {
      Recipe recipe = _recrepo.Get(ingData.RecipeId);
      if (recipe.CreatorId != accountId)
      {
        throw new Exception("You can't add ingredients to a recipe that isn't yours.");
      }

      return _irepo.Create(ingData);
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
      return _irepo.GetIngredientsByRecipe(recipeId);
    }

    internal void DeleteRecipe(int ingredientId, string accountId)
    {
      Ingredient ingredient = _irepo.Get(ingredientId);
      Recipe recipe = _recrepo.Get(ingredient.RecipeId);
      if (recipe.CreatorId != accountId)
      {
        throw new Exception("You can't delete ingredients from a recipe that isn't yours.");
      }

      _irepo.Delete(ingredientId);
    }
  }
}
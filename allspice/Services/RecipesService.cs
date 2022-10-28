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
      return _recrepo.Get();
    }

    internal Recipe GetRecipeById(int recipeId)
    {
      Recipe recipe = _recrepo.Get(recipeId);
      if (recipe == null)
      {
        throw new Exception("Bad Id");
      }
      return recipe;
    }

    internal Recipe EditRecipe(Recipe recipeData)
    {
      Recipe originalRecipe = GetRecipeById(recipeData.Id);
      if (originalRecipe.CreatorId != recipeData.CreatorId)
      {
        throw new Exception("You don't own this chore.");
      }

      originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
      originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
      originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
      originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;

      return _recrepo.Edit(originalRecipe);
    }
  }
}
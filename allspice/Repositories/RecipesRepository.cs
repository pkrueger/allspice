namespace allspice.Services
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes
        (title, instructions, img, category, creatorId)
      VALUES
        (@Title, @Instructions, @Img, @Category, @CreatorId);
      SELECT LAST_INSERT_ID()
      ;";
      int recipeId = _db.ExecuteScalar<int>(sql, recipeData);
      Recipe newRecipe = Get(recipeId);
      return newRecipe;

    }

    internal List<Recipe> GetAllRecipes()
    {
      string sql = @"
      SELECT rec.*, a.*
      FROM recipes rec
      JOIN accounts a ON a.id = rec.creatorId
      ;";
      return _db.Query<Recipe, ProfileSmall, Recipe>(sql, (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }).ToList();
    }

    internal Recipe Get(int recipeId)
    {
      string sql = @"
      SELECT rec.*, a.* 
      FROM recipes rec
      JOIN accounts a ON a.id = rec.creatorId 
      WHERE rec.id = @recipeId
      ;";
      return _db.Query<Recipe, ProfileSmall, Recipe>(sql, (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }, new { recipeId }).FirstOrDefault();
    }
  }
}
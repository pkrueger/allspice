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

    internal List<Recipe> Get()
    {
      string sql = @"
        SELECT
        rec.*,
        a.*
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

    internal Recipe Edit(Recipe originalRecipe)
    {
      string sql = @"
        UPDATE recipes SET
          title = @Title, instructions = @Instructions, img = @Img, category = @Category
        WHERE id = @Id
      ;";
      int rowsAffected = _db.Execute(sql, originalRecipe);

      if (rowsAffected == 0)
      {
        throw new Exception("Unable to update.");
      }

      return originalRecipe;
    }

    internal void Delete(Recipe recipe)
    {
      string sql = @"
        DELETE FROM recipes
        WHERE id = @Id
      ;";
      _db.Execute(sql, recipe);

    }
  }
}
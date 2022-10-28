namespace allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient Create(Ingredient ingData)
    {
      string sql = @"
      INSERT INTO ingredients (name, quantity, recipeId)
      VALUES (@Name, @Quantity, @RecipeId);
      SELECT LAST_INSERT_ID()
      ;";
      int ingId = _db.ExecuteScalar<int>(sql, ingData);
      Ingredient ingredient = Get(ingId);
      return ingredient;
    }

    internal Ingredient Get(int ingId)
    {
      string sql = @"
      SELECT * FROM ingredients
      WHERE id = @ingId
      ;";
      Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { ingId });
      return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
      string sql = @"
      SELECT * FROM ingredients
      WHERE recipeId = @recipeId
      ;";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
      return ingredients;
    }

    internal void Delete(int ingredientId)
    {
      string sql = @"
      DELETE FROM ingredients
      WHERE id = @ingredientId
      ;";
      _db.Execute(sql, new { ingredientId });
    }
  }
}
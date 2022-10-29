namespace allspice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Favorite Create(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites (id, recipeId, accountId)
      VALUES (@Id, @RecipeId, @AccountId);
      ;";
      _db.Execute(sql, favoriteData);
      Favorite favorite = Get(favoriteData.Id);
      return favorite;
    }

    internal Favorite Get(string favId)
    {
      string sql = @"
      SELECT * FROM favorites
      WHERE id = @favId
      ;";
      Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { favId });
      return favorite;
    }
  }
}
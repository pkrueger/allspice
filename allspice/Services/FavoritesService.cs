namespace allspice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _frepo;

    public FavoritesService(FavoritesRepository frepo)
    {
      _frepo = frepo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
      return _frepo.Create(favoriteData);
    }

    internal List<Favorite> GetFavorites(Profile userInfo)
    {
      return _frepo.Get(userInfo);
    }

    internal string DeleteFavorite(string favId, string accountId)
    {
      Favorite favorite = _frepo.Get(favId);
      if (favorite.AccountId != accountId)
      {
        throw new Exception("You don't own this favorite.");
      }
      return _frepo.Delete(favId);
    }
  }
}
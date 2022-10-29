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
  }
}
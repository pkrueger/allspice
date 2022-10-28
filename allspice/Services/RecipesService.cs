namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recrepo;

    public RecipesService(RecipesRepository recrepo)
    {
      _recrepo = recrepo;
    }
  }
}
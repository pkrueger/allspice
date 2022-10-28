namespace allspice.Models;

public class ProfileSmall
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
}

public class Profile : ProfileSmall, IRepoItem<string>
{
  public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  public DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Account : Profile
{
  public string Email { get; set; }
}
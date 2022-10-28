namespace allspice.Models;

public class ProfileSmall
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
}

public class Profile : ProfileSmall, IRepoItem<string>
{
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

public class Account : Profile
{
  public string Email { get; set; }
}
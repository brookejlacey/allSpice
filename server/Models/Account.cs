namespace allSpice.Models;

public class Account : RepoItem<string>
{
  // public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}

public class FavoriteAccount : Account
{
  public int FavoriteId { get; set; }
}
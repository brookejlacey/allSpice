namespace allSpice.Models;

public class Favorite //: RepoItem<int> do I need this?
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public int RecipeId { get; set; }

    public string CreatorId { get; set; }
    public Account Creator { get; set; }

}
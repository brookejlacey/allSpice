namespace allSpice.Models;

public class Favorite : RepoItem<int>
{
    // public int Id { get; set; }
    public string AccountId { get; set; }
    public int RecipeId { get; set; }

    // public string CreatorId { get; set; }
    // public Account Creator { get; set; }  -----> not needed because of the view model I think?

}
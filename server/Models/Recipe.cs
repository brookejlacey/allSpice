namespace allSpice.Models;

public class Recipe : RepoItem<int>
{

    public string Title { get; set; }
    public string Img { get; set; }
    public string Category { get; set; }
    public string Instructions { get; set; }
    public string CreatorId { get; set; }

    public bool Deleted { get; set; }

    public bool Updated { get; set; }

    public Account Creator { get; set; }

}
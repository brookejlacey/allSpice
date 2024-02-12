namespace allSpice.Services;


public class FavoritesService(FavoritesRepository repo)
{
  private readonly FavoritesRepository repo = repo;

  internal FavoriteAccount CreateFavorite(Favorite favoriteData)
  {
    FavoriteAccount faveAccount = repo.CreateFave(favoriteData);
    return faveAccount;
  }

  internal string DeleteFavorite(int favoriteId, string userId)
  {
    Favorite original = repo.GetById(favoriteId);
    if (original == null) throw new Exception($"no fave at id: {favoriteId}");
    if (original.AccountId != userId) throw new Exception($"You can't do that you don't own it!");

    repo.Delete(favoriteId);
    return $"Fave {favoriteId} was deleted";
  }

  public List<Recipe> GetAccountFavorites(string userId)
  {
    List<Recipe> Recipes = repo.GetAccountFavorites(userId);
    return Recipes;
  }

  // internal List<FavoriteAccount> GetRecipeFavorites(int recipeId)
  // {
  //   List<FavoriteAccount> favoratingPeople = repo.GetRecipeFavorites(recipeId);
  //   return favoratingPeople;
  // } THIS IS FOR OTHER PEOPLE WHO HAVE FAVORITED THE RECIPES WHICH WE DON"T NEED REALLY
}

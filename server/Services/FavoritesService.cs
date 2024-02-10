namespace allSpice.Services;


public class FavoritesService(FavoritesRepository repo)
{
  private readonly FavoritesRepository repo = repo;

  internal FavoriteAccount CreateFavorite(Favorite favoriteData)
  {
    FavoriteAccount faveAccount = repo.CreateFave(favoriteData);
    return faveAccount;
  }
}
// This takes in two ids and 
//     internal string DeleteFavorite(int favoriteId, string userId)
//     {
//       Favorite original = repo.GetById(favoriteId);
//       if(original == null) throw new Exception($"no fave at id: {favoriteId}");
//       if(original.AccountId != userId) throw new Exception($"You can't do that you don't own it!");

//       repo.Delete(favoriteId);
//       return $"Fave {favoriteId} was deleted";
//     }

//     internal List<FavoriteRecipe> GetAccountFavorites(string userId)
//     {
//       List<FavoriteRecipe> faveRecipes = repo.GetAccountFavorites(userId);
//       return faveRecipes;
//     }

//     internal List<FavoriteAccount> GetRecipeFavorites(int recipeId)
//     {
//       List<FavoriteAccount> faveoratingPeople = repo.GetRecipeFavorites(recipeId);
//       return faveoratingPeople;
//     }
// }
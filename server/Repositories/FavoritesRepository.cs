using allSpice.Interfaces;

namespace allSpice.Repositories;


public class FavoritesRepository(IDbConnection db)
{

  private readonly IDbConnection db = db;

  // NOTE what this create returns is VERY VERY VERY APP SPECIFIC.
  public FavoriteAccount CreateFave(Favorite favoriteData)
  {
    string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);

      SELECT
        accounts.*,
        favorites.id
      FROM favorites
      JOIN accounts ON favorites.accountId = accounts.id
      WHERE favorites.id = LAST_INSERT_ID();
      ";
    FavoriteAccount favoriteAccount = db.Query<FavoriteAccount, Favorite, FavoriteAccount>(sql, (faveAccount, favorite) =>
    {
      faveAccount.FavoriteId = favorite.Id;
      return faveAccount;
    }, favoriteData).FirstOrDefault();
    return favoriteAccount;
  }
}
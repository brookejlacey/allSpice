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

  public void Delete(int favoriteId)
  {
    string sql = @"
      DELETE FROM favorites WHERE id = @favoriteId
      ";
    db.Execute(sql, new { favoriteId });
  }


  public Favorite GetById(int favoriteId)
  {
    string sql = @"
      SELECT
        *
      FROM favorites 
      WHERE id = @favoriteId;
      ";
    Favorite favorite = db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
    return favorite;
  }

  internal List<Recipe> GetAccountFavorites(string userId)
  {
    string sql = @"
        SELECT 
        recipes.* 
        FROM favorites 
        JOIN recipes ON favorites.recipeId = recipes.id
        WHERE favorites.accountId = @userId;
        ";

    return db.Query<Recipe>(sql, new { userId }).ToList();


  }

  // List<Recipe> Recipes = db.Query<Favorite, Recipe, Recipe>(sql, (favorite, Recipe) =>
  // {
  //   Recipe.d = favorite.Id;
  //   return Recipe;
  // }, new { userId }).ToList();
  // return Recipes;



  // internal List<Recipe> GetAccountFavorites(string userId)
  // {
  //   string sql = @"
  //     SELECT
  //       recipes.*
  //     FROM favorites
  //     JOIN recipes ON favorites.recipeId = recipes.id
  //     WHERE favorites.accountId = @userId;
  //     ";
  //   List<Recipe> faveRecipes = db.Query<Favorite, Recipe, Recipe>(sql, (favorite, faveRecipe) =>
  //   {
  //     faveRecipe.FavoriteId = favorite.Id;
  //     return faveRecipe;
  //   }, new { userId }).ToList();
  //   return faveRecipes;
  // }


}
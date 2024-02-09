using Microsoft.AspNetCore.Http.HttpResults;
using allSpice.Interfaces;

namespace allSpice.Repositories;

public class IngredientsRepository(IDbConnection db) : IRepository<Ingredient>
{
  private readonly IDbConnection db = db;
  public Ingredient Create(Ingredient ingredientData)
  {
    string sql = @"
          INSERT INTO ingredients
          (name, quantity, recipeId, creatorId)
          VALUES
          (@Name, @Quantity, @RecipeId, @CreatorId);

          SELECT
            ingredients.*,
            accounts.*
          FROM ingredients
          JOIN accounts ON ingredients.creatorId = accounts.id
          WHERE ingredients.id = LAST_INSERT_ID();
        ";

    Ingredient ingredient = db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, ingredientData).FirstOrDefault();
    return ingredient;
  }

  public void Delete(int ingredientId)
  {
    string sql = @"
        DELETE FROM ingredients
        WHERE ingredients.id = @ingredientId;
      ";

    db.Execute(sql, new { ingredientId });
  }

  public List<Ingredient> GetAll()
  {
    throw new NotImplementedException();
  }

  public Ingredient GetById(int ingredientId)
  {
    string sql = @"
          SELECT 
            ingredients.*,
            accounts.*
          FROM ingredients
          JOIN accounts ON ingredients.creatorId = accounts.id
          WHERE ingredients.id = @ingredientId;
        ";
    Ingredient ingredient = db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, new { ingredientId }).FirstOrDefault();
    return ingredient;
  }

  public Ingredient Update(Ingredient updateData)
  {
    throw new NotImplementedException();
  }

  internal List<Ingredient> GetRecipeIngredients(int recipeId)
  {
    string sql = @"
        SELECT
          ingredients.*,
          accounts.*
        FROM ingredients
        JOIN accounts ON ingredients.creatorId = accounts.id
        WHERE ingredients.recipeId = @recipeId;
        ";
    List<Ingredient> ingredients = db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, new { recipeId }).ToList(); //NEW is because of the int recipeId also BLUE=NEW GREEN=lightblue
    return ingredients;
  }
}
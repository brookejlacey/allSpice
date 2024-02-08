namespace allSpice.Repositories;

public class RecipesRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    public Recipe GetById(int recipeId)
    {
        string sql = @"
        SELECT
            recipes.*,
            accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @recipeId;
        ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    public List<Recipe> GetAll()
    {
        string sql = @"
        SELECT
            recipes.*,
            accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id;
        ";
        List<Recipe> recipes = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();

        return recipes;
    }
    public Recipe Create(Recipe createData)
    {
        string sql = @"
        INSERT INTO recipes
        (title, img, category, instructions, creatorId)
        VALUES
        (@title, @img, @category, @instructions, @creatorId);

        SELECT
          recipes.*,
          accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();
        ";

        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, createData).FirstOrDefault();
        return recipe;
    }

    public Recipe Update(Recipe updateData)
    {
        string sql = @"
        UPDATE recipes SET
        title = @title,
        img = @img,
        category = @category,
        instructions = @instructions
        WHERE id = @id;

        SELECT
          recipes.*,
          accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @id;
        ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, updateData).FirstOrDefault();
        return recipe;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
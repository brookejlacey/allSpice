

namespace allSpice.Services;


public class RecipesService(RecipesRepository repo)
{
    private readonly RecipesRepository repo = repo;

    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe original = GetRecipeById(recipeId);
        if (original.CreatorId != userId) throw new Exception("NOPE");

        // original.Deleted = true; WHAT DOES THIS DO???
        repo.Update(original);
        return $"archived {original.Title}";
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = repo.Create(recipeData);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = repo.GetById(recipeId);
        if (recipe == null) throw new Exception($"no recipe at id: {recipeId}");
        return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = repo.GetAll();
        return recipes;
    }
}
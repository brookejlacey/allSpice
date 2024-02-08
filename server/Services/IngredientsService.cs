


namespace allSpice.Services;

public class IngredientsService(IngredientsRepository repo)
{
    private readonly IngredientsRepository repo = repo;

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = repo.Create(ingredientData);
        return ingredient;
    }

    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient original = repo.GetById(ingredientId);
        if (original.CreatorId != userId) throw new Exception("Not your ingredient to delete");

        repo.Delete(ingredientId);
        return $"ingredient {original.Id} was removed";


    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        List<Ingredient> ingredients = repo.GetRecipeIngredients(recipeId);
        return ingredients;
    }
}
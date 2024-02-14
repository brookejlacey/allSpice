
import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getAllRecipes() {
        const response = await api.get('api/recipes')
        console.log('got recipe', response.data)
        AppState.recipes = response.data.map(recipe => new Recipe(recipe))
    }

    // async getRecipeById(recipeId) {
    //     const response = await api.get(`api/recipes/${recipeId}`)
    //     console.log('sup', response.data)
    //     AppState.activeRecipe = new Recipe(response.data)
    // }

    async createRecipe(recipeData) {
        const response = await api.post('api/recipes', recipeData)
        console.log('yeppers', response.data)
        const newRecipe = new Recipe(response.data)
        AppState.recipes.push(newRecipe)
        return newRecipe
    }

    // async deleteRecipe(recipeId) {
    //     const response = await api.delete(`api/recipes/${recipeId}`);
    //     return response.data;
    // }

}

export const recipesService = new RecipesService()
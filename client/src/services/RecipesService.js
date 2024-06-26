import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getRecipes() {
        const response = await api.get('api/recipes')
        logger.log('GOT RECIPES', response.data)
        AppState.recipes = response.data.map(pojo => new Recipe(pojo))
    }

    setActiveRecipe(recipe) {
        AppState.activeRecipe = null
        AppState.activeRecipe = recipe
        logger.log(AppState.activeRecipe)

    }
}

export const recipesService = new RecipesService()
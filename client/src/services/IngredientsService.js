import { AppState } from "../AppState";
import { Ingredient } from "../models/Ingredient";
import { api } from "./AxiosService";
import { logger } from "../utils/Logger.js"


class IngredientsService {

    async getRecipeIngredients(recipeId) {
        AppState.recipeIngredients = null
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.recipeIngredients = response.data.map(pojo => new Ingredient(pojo))
        logger.log(AppState.recipeIngredients)
    }

}

export const ingredientsService = new IngredientsService()
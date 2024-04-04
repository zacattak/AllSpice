import { AppState } from "../AppState";
import { Ingredient } from "../models/Ingredient";
import { api } from "./AxiosService";

class IngredientsService {

    async getRecipeIngredients(recipeId) {
        AppState.recipeIngredients = null
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.recipeIngredients = response.data.map(pojo => new Ingredient(pojo))
    }

}

export const ingredientsService = new IngredientsService()
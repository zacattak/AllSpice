<template>
    <section class="row d-flex justify-content-center">
        <div @click="setActiveRecipe()" class="selectable" type="button" data-bs-toggle="modal"
            data-bs-target="#recipeModal">
            <p class="mb-0 text-center">{{ recipe.category }}</p>
            <h2 class="text-center">{{ recipe.title }}</h2>
            <img :src="recipe.img" :alt="recipe.title" class="img">
            <p>{{ recipe.instructions }}</p>
        </div>
    </section>
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { ingredientsService } from '../services/IngredientsService.js';
export default {
    props: {
        recipe: { type: Recipe, required: true },
    },

    setup(props) {
        return {
            setActiveRecipe() {
                try {
                    recipesService.setActiveRecipe(props.recipe)
                    ingredientsService.getRecipeIngredients(props.recipe.id)
                } catch (error) {
                    Pop.error(error)
                }
            },

        }
    }
}
</script>


<style lang="scss" scoped>
.img {
    width: 100%;
    object-fit: cover;
    height: 40vh;
}
</style>
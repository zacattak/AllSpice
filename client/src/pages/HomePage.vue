<template>
  <div class="container-fluid bg-info">
    <section class="row d-flex justify-content-evenly">

      <div v-for="recipe in recipes" :key="recipe.id" class="col-9 col-md-3 m-2 card mb-2 mt-2">
        <!-- <a @click="setActiveRecipe()" type="button" class="" data-bs-toggle="modal" data-bs-target="#recipeModal"> -->
        <!-- <p class="mb-0 text-center">{{ recipe.category }}</p>
        <h2 class="text-center">{{ recipe.title }}</h2>
        <img :src="recipe.img" :alt="recipe.title" class="img">
        <p>{{ recipe.instructions }}</p> -->
        <RecipeComponent :recipe="recipe" />
        <!-- </a> -->
      </div>

    </section>
    <RecipeModal />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';
import { ingredientsService } from '../services/IngredientsService.js'
import { logger } from '../utils/Logger';
export default {


  setup() {


    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      }
      catch (error) {
        Pop.error(error);
      }
    }

    onMounted(getRecipes)
    return {

      recipes: computed(() => AppState.recipes),
      // recipeIngredients: computed(() => AppState.recipeIngredients),
      // activeRecipe: computed(() => AppState.activeRecipe)

    }
  }
}
</script>

<style scoped lang="scss">
.img {
  width: 100%;
  object-fit: cover;
  height: 40vh;
}

.card {
  border: 2px solid black;
  border-radius: 16px;
  box-shadow: 3px 3px 10px rgba(42, 6, 134, 0.31);
}



// .home {
//   display: grid;
//   height: 80vh;
//   place-content: center;
//   text-align: center;
//   user-select: none;

//   .home-card {
//     width: clamp(500px, 50vw, 100%);

//     >img {
//       height: 200px;
//       max-width: 200px;
//       width: 100%;
//       object-fit: contain;
//       object-position: center;
//     }
//   }
// }</style>

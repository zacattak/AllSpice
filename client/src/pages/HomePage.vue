<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <div class="d-flex justify-content-center">
          {{ recipes }}

        </div>

      </div>

    </section>

  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
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
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>

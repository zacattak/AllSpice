<template>
    <div class="modal fade" id="recipeModal" tabindex="-1" role="dialog" aria-labelledby="recipeModal"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div v-if="activeRecipe" class="modal-content">
                <!-- <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div> -->
                <div class="modal-body">
                    <img :src="activeRecipe.img" :alt="activeRecipe.title" class="img">
                    <h2 class="text-center">{{ activeRecipe.title }}</h2>
                    <p>{{ activeRecipe.instructions }}</p>
                    <ul v-for="ingredient in recipeIngredients" :key="ingredient.id">
                        {{ ingredient.name }} | {{ ingredient.quantity }}
                    </ul>
                    ...
                </div>
                <div class="modal-footer">
                    <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal"></button> -->
                    <button type="button" class="btn btn-primary">Favorite Recipe</button>
                </div>
            </div>
        </div>
    </div>

</template>


<script>
import { Modal } from 'bootstrap';
import { AppState } from '../AppState';
import { computed } from 'vue';

export default {
    setup() {
        const activeRecipe = computed(() => AppState.activeRecipe)
        return {
            recipeIngredients: computed(() => AppState.recipeIngredients),
            activeRecipe
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
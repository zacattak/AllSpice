<template>
  <section class="container-fluid">
    <div class="row">





      <nav class="navbar navbar-expand-sm bg-dark px-3">



        <!-- <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">

          <div class="d-flex flex-column align-items-center">
            
            <h1>🏘️</h1>
          </div>

        </router-link> -->


        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
          aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>




        <div class="collapse navbar-collapse" id="navbarText">
          <div class="navbar-nav me-auto">
            <li>
              <router-link :to="{ name: 'About' }" class="btn text-white lighten-30 selectable text-uppercase">
                Favorite Recipes
              </router-link>
            </li>
          </div>

          <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
            <h1 class="text-white magic-header">Recipe Reservoir</h1>

          </router-link>

          <!-- LOGIN COMPONENT HERE -->
          <div>


            <!-- <button class="btn text-light" @click="toggleTheme">
              <i class="mdi" :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i>
            </button> -->
          </div>
          <Login />
        </div>
      </nav>


    </div>
  </section>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      // theme,
      // toggleTheme() {
      //   theme.value = theme.value == 'light' ? 'dark' : 'light'
      //   document.documentElement.setAttribute('data-bs-theme', theme.value)
      //   saveState('theme', theme.value)
      // }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.magic-header {
  position: absolute;
  right: 0px;
  bottom: 5px;
  left: 490px;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-white);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
